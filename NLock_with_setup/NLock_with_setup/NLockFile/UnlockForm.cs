using log4net;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.IO;
using Neurotec.Licensing;
using NLock.NLockFile.Biometric;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;

namespace NLock
{
    public partial class UnlockForm : Form
    {
        #region Private variables

        private enum Ops
        {
            CAPTURINGFAILED,
            VERIFICATIONFAILEDRETRY,
            VERIFIED,
            VERIFYWITHPASSWORD,
            PASSWORDNOTSUPPORTED,
            ONGOING,
            CANCELLED,
        }

        private NBiometricClient _biometricClient;
        private NDeviceManager _deviceManager;
        private bool? _isSegmentationActivated;
        private NSubject _subject;
        private NSubject _subjectFromFile;
        private static int _retryCount;
        private static int _initialRetryDelay = 10;
        private bool _retryWithPW;
        private Ops _currentop = Ops.CAPTURINGFAILED;
        private bool firstTry = true;
        private bool _verified;

        private readonly byte[] _templateLoginFromFile;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(UnlockForm));

        #endregion Private variables

        #region Public properties

        /// <summary>
        ///  operation
        ///     1 Capturing
        ///     2 Verification
        ///     3 Cancel
        ///     4 Verify failed
        ///     5 Capturing failed on verification
        ///     6 Retry using password
        ///     8 Verify failed again //TODO: not implemented
        ///     9 Close after capturing
        /// </summary>
        ///

        public byte[] PWHash
        {
            set;
            get;
        }

        public bool Verified
        {
            get { return _verified; }
        }

        #endregion Public properties

        #region Public Constructors

        public UnlockForm(byte[] template, byte[] hash = null)
        {
            InitializeComponent();
            this._templateLoginFromFile = template;
            this.PWHash = hash;
        }

        public UnlockForm(byte[] template, string fileName) : this(template)
        {
            this.Text = "NLock Unlocker " + fileName;
        }

        public UnlockForm(byte[] template, byte[] hash, string fileName) : this(template, hash)
        {
            this.Text = "NLock Unlocker " + fileName;
        }

        #endregion Public Constructors

        #region Form VisualChanges

        private void CaptureFailedFormSettings()
        {
            lblInfo.Text = "Capture failed..\nPlease look at the camera... ";
            btnMain.Text = "Retry";
            btnMain.BackColor = System.Drawing.Color.Yellow;
        }

        private void FromInit()
        {
            _verified = false;
            llblRetryWithPW.Visible = false;
            tbPw.Visible = false;
        }

        private void CapturingInit()
        {
            _subjectFromFile = new NSubject();
            _subjectFromFile.SetTemplateBuffer(new NBuffer(_templateLoginFromFile));
            _subjectFromFile.Id = "loadedFile";
        }

        private void VerificationOperationButtonconfig()
        {
            lblInfo.Text = "Press cancel to stop capturing...";
            btnMain.Text = "Cancel";
            btnMain.BackColor = System.Drawing.Color.GreenYellow;
            llblRetryWithPW.Visible = false;
        }

        private void VeriFailedButtonConfig()
        {
            lblInfo.Text = "Unlocking failed..\nPress Retry to retry unlocking...";
            btnMain.Text = "Retry";
            btnMain.BackColor = System.Drawing.Color.Yellow;
            llblRetryWithPW.Visible = true;
            llblRetryWithPW.Text = "Retry using password";
        }

        #endregion Form VisualChanges

        #region Biometric Client

        private void ClientInit()
        {
            _biometricClient = BiometricOperations.BiometricClient;
            _biometricClient.Initialize();
            _biometricClient.MatchingThreshold = 48;
            _biometricClient.FacesMatchingSpeed = NMatchingSpeed.High;
            _biometricClient.FacesTemplateSize = NTemplateSize.Small;

            if (!_isSegmentationActivated.HasValue)
            {
                _isSegmentationActivated = NLicense.IsComponentActivated("Biometrics.FaceSegmentsDetection");
            }

            _biometricClient.FacesDetectAllFeaturePoints = _isSegmentationActivated.Value;

            _deviceManager = _biometricClient.DeviceManager;
        }

        private void VerificationOperationInit()
        {
            VerificationOperationButtonconfig();
            lblInfo.Text = "Capturing user...";
            _subject = new NSubject();
            var face = new NFace { CaptureOptions = NBiometricCaptureOptions.Stream };
            _subject.Faces.Add(face);
            nlockLoginFaceView.Face = _subject.Faces[0];
            _currentop = Ops.ONGOING;
            _biometricClient.BeginCapture(_subject, OnCapturingCompleted, null);
        }

        private void OnCapturingCompleted(IAsyncResult ar)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnCapturingCompleted), ar);
            }
            else
            {
                try
                {
                    var status = _biometricClient.EndCapture(ar);

                    if (status != NBiometricStatus.Ok)
                    {
                        CaptureFailedFormSettings();
                        _subject.Faces[0].Image = null;
                        _currentop = Ops.CAPTURINGFAILED;
                    }
                    else
                    {
                        _currentop = Ops.ONGOING;

                        _biometricClient.BeginVerify(_subjectFromFile, _subject, OnVerifyCompleted, null);
                    }
                }
                catch (Exception)
                {
                    _biometricClient.Cancel();
                    CheckCamera();
                    CheckLicense();
                    Close();
                }
            }
        }

        private void OnVerifyCompleted(IAsyncResult ar)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnVerifyCompleted), ar);
            }
            else
            {
                try
                {
                    lblInfo.Text = "Verifying user...";
                    var status = _biometricClient.EndVerify(ar);
                    Logger.Debug(status);
                    if (status == NBiometricStatus.Ok)
                    {
                        _currentop = Ops.VERIFIED;
                        _verified = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _verified = false;
                        EnableRetryCounter();
                        if (PWHash != null || firstTry)
                        {
                            VeriFailedButtonConfig();
                            firstTry = false;
                        }
                        _currentop = Ops.VERIFICATIONFAILEDRETRY;
                        lblInfo.Text = "User verification failed...";
                    }
                }
                catch (Exception)
                {
                    CheckCamera();
                    CheckLicense();
                    throw;
                }
            }
        }

        private void DeviceManagerDevicesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                BeginInvoke(new Action<NotifyCollectionChangedEventArgs>(ea =>
                {
                    switch (ea.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            Logger.Debug("Device added " + (NDevice)ea.NewItems[0]);
                            CheckCamera();

                            break;

                        case NotifyCollectionChangedAction.Remove:
                            Logger.Debug("Device Removed " + (NDevice)ea.OldItems[0]);
                            CheckCamera();
                            break;

                        case NotifyCollectionChangedAction.Reset:
                            Logger.Debug("Device list changed NotifyCollectionChangedAction.Reset");
                            CheckCamera();
                            break;
                        default:
                            Logger.Error("Device list changed unidentified collection action");
                            break;
                    }
                }), e);
            }
            catch (Exception)
            {
                MessageBox.Show("Device manager not responding..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Biometric Client

        #region Private Form Events

        private void TextboxPwKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnMain.PerformClick();
            }
        }

        private void RetryTimerTick(object sender, EventArgs e)
        {
            Interlocked.Decrement(ref _initialRetryDelay);
            lblInfo.Text = String.Format("Retry after : {0,3} seconds", _initialRetryDelay);
            if (_initialRetryDelay <= 0)
            {
                DisableRetryCounter();
            }
        }

        private void UnlockFormLoad(object sender, EventArgs e)
        {
            Interlocked.Exchange(ref _retryCount, 0);
            FromInit();
            ClientInit();
            DeviceManagerUtilication();
            CapturingInit();
            if (CheckCamera())
            {
                VerificationOperationInit();
            }
        }

        private void LinkLabelCancelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _verified = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void LinkLabelAddPWLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_retryWithPW)
            {
                llblRetryWithPW.Text = "Cancel password retry";
                tbPw.Enabled = true;
                tbPw.Visible = true;
                llblRetryWithPW.LinkVisited = true;
                tbPw.Focus();
                _currentop = Ops.VERIFYWITHPASSWORD;
                _retryWithPW = true;
            }
            else
            {
                llblRetryWithPW.Text = "Retry with Password";
                tbPw.Enabled = false;
                tbPw.Visible = false;

                llblRetryWithPW.LinkVisited = false;
                _retryWithPW = false;
                _currentop = Ops.VERIFICATIONFAILEDRETRY;
            }
        }

        private void ButtonMainClick(object sender, EventArgs e)
        {
            switch (_currentop)
            {
                case Ops.PASSWORDNOTSUPPORTED:
                case Ops.CANCELLED:
                    VerificationOperationInit();

                    break;

                case Ops.CAPTURINGFAILED:
                    _currentop = Ops.ONGOING;
                    _biometricClient.BeginCapture(_subject, OnCapturingCompleted, null);
                    break;

                case Ops.ONGOING:
                    _biometricClient.Cancel();
                    _currentop = Ops.CANCELLED;
                    lblInfo.Text = "Canceled ...";

                    break;

                case Ops.VERIFICATIONFAILEDRETRY:
                    if (!_retryWithPW)
                    {
                        VerificationOperationInit();
                    }
                    else
                    {
                        VerifyWithPassword();
                    }
                    break;

                case Ops.VERIFYWITHPASSWORD:
                    VerifyWithPassword();
                    break;

                default:
                    Logger.Error("Invalid current operation");
                    this.Close();
                    break;
            }
        }

        #endregion Private Form Events

        #region Private Methods

        private void VerifyWithPassword()
        {
            lblInfo.Text = "Verifying with password ...";
            _verified = false;
            if (tbPw.Text != null && PWHash != null)
            {
                if (NLockTemplateOperationsCommon.ValidatePassword(NLockTemplateOperations.GetBytes(tbPw.Text), PWHash))
                {
                    _verified = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lblInfo.Text = "Invalid password...";
                    _currentop = Ops.VERIFICATIONFAILEDRETRY;
                    EnableRetryCounter();
                }
            }
            else if (PWHash == null)
            {
                lblHelpText.Text = "File does not support password unlocking";
                lblInfo.Text = "Failed...";
                llblRetryWithPW.Enabled = false;
                llblRetryWithPW.Visible = false;
                tbPw.Enabled = false;
                tbPw.Visible = false;

                _retryWithPW = false;
                _currentop = Ops.PASSWORDNOTSUPPORTED;
            }
            else
            {

                lblInfo.Text = "Invalid password...";
                _currentop = Ops.VERIFICATIONFAILEDRETRY;
            }
        }

        private void EnableRetryCounter()
        {
            Interlocked.Increment(ref _retryCount);
            if (_retryCount >= 3)
            {
                btnMain.Visible = false;

                Interlocked.Exchange(ref _initialRetryDelay, 1 * (int)Math.Exp(_retryCount));
                retryTimer.Start();
            }
        }

        private void DisableRetryCounter()
        {
            retryTimer.Stop();
            btnMain.Visible = true;
            llblRetryWithPW.Visible = true;
        }

        private void DeviceManagerUtilication()
        {
            if (_deviceManager != null)
            {
                if (_deviceManager != null)
                {
                    _deviceManager.Devices.CollectionChanged += DeviceManagerDevicesCollectionChanged;
                }
                CheckCamera();
            }
        }

        private bool CheckCamera()
        {
            var deviceCount = _deviceManager.Devices.Count;
            if (deviceCount <= 0)
            {
                if (_biometricClient != null)
                {
                    _biometricClient.Cancel();
                }

                _currentop = Ops.CANCELLED;

                lblInfo.Text = "Could not detect the camera..\nPlease connect a camera.";
                btnMain.Enabled = false;
                btnMain.BackColor = System.Drawing.Color.Gray;
                nlockLoginFaceView.Face = new NFace();
                nlockLoginFaceView.Face.Image = NImage.FromBitmap(NLock.Properties.Resources.NoCameraDetected);

                return false;
            }
            else
            {
                lblInfo.Text = "Camera detected...\nPlease continue";

                nlockLoginFaceView.Face = new NFace();
                nlockLoginFaceView.Face.Image = NImage.FromBitmap(NLock.Properties.Resources.CameraDetectedContinue);
                btnMain.Enabled = true;
                btnMain.BackColor = System.Drawing.Color.Green;
                return true;
            }
        }

        private void CheckLicense()
        {
            const string Components =
                 "Biometrics.FaceExtraction," +
                 "Biometrics.FaceDetection," +
                 "Biometrics.FaceMatching," +
                 "Devices.Cameras";

            foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!NLicense.IsComponentActivated(component))
                {
                    Logger.Error("License not acquired");
                }
            }
            licensePanel1.RefreshComponentsStatus();
        }

        #endregion Private Methods
    }
}