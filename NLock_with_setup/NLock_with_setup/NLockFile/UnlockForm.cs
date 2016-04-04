using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.IO;
using Neurotec.Licensing;
using NLock.NLockFile.Util;
using NLock.Properties;

namespace NLock
{
    public partial class UnlockForm : Form
    {
        #region Private variables

        private enum Ops
        {
            Capturingfailed,
            Verificationfailedretry,
            Verified,
            Verifywithpassword,
            Passwordnotsupported,
            Ongoing,
            Cancelled
        }

        private NBiometricClient _biometricClient;
        private NDeviceManager _deviceManager;
        private bool? _isSegmentationActivated;
        private NSubject _subject;
        private NSubject _subjectFromFile;
        private static int _retryCount;
        private static int _initialRetryDelay = 10;
        private bool _retryWithPw;
        private Ops _currentop = Ops.Capturingfailed;
        private bool _firstTry = true;

        private readonly byte[] _templateLoginFromFile;

        private static readonly ILog Logger = LogManager.GetLogger(typeof (UnlockForm));

        #endregion Private variables

        #region Public properties

        /// <summary>
        ///     operation
        ///     1 Capturing
        ///     2 Verification
        ///     3 Cancel
        ///     4 Verify failed
        ///     5 Capturing failed on verification
        ///     6 Retry using password
        ///     8 Verify failed again //TODO: not implemented
        ///     9 Close after capturing
        /// </summary>
        public byte[] PwHash { set; get; }

        public bool Verified { get; private set; }

        #endregion Public properties

        #region Public Constructors

        public UnlockForm(byte[] template, byte[] hash = null)
        {
            InitializeComponent();
            _templateLoginFromFile = template;
            PwHash = hash;
        }

        public UnlockForm(byte[] template, string fileName) : this(template)
        {
            Text = Resources.NLock_Unlocker_ + fileName;
        }

        public UnlockForm(byte[] template, byte[] hash, string fileName) : this(template, hash)
        {
            Text = Resources.NLock_Unlocker_ + fileName;
        }

        #endregion Public Constructors

        #region Form VisualChanges

        private void CaptureFailedFormSettings()
        {
            lblInfo.Text = Resources.CaptureFailed;
            btnMain.Text = Resources.Retry;
            btnMain.BackColor = Color.Yellow;
        }

        private void FromInit()
        {
            Verified = false;
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
            lblInfo.Text = Resources.Press_cancel_to_stop_capturing___;
            btnMain.Text = Resources.Cancel;
            btnMain.BackColor = Color.GreenYellow;
            llblRetryWithPW.Visible = false;
        }

        private void VeriFailedButtonConfig()
        {
            lblInfo.Text = Resources.UnlockingFailed_PressRetry;
            btnMain.Text = Resources.Retry;
            btnMain.BackColor = Color.Yellow;
            llblRetryWithPW.Visible = true;
            llblRetryWithPW.Text = Resources.Retry_using_password;
        }

        #endregion Form VisualChanges

        #region Biometric Client

        private void ClientInit()
        {
            _biometricClient = new NBiometricClient {BiometricTypes = NBiometricType.Face, UseDeviceManager = true};
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
            lblInfo.Text = Resources.Capturing_user___;
            _subject = new NSubject();
            var face = new NFace {CaptureOptions = NBiometricCaptureOptions.Stream};
            _subject.Faces.Add(face);
            nlockLoginFaceView.Face = _subject.Faces[0];
            _currentop = Ops.Ongoing;
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
                        _currentop = Ops.Capturingfailed;
                    }
                    else
                    {
                        _currentop = Ops.Ongoing;

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
                    lblInfo.Text = Resources.Verifying_user___;
                    var status = _biometricClient.EndVerify(ar);
                    Logger.Debug(status);
                    if (status == NBiometricStatus.Ok)
                    {
                        _currentop = Ops.Verified;
                        Verified = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Verified = false;
                        EnableRetryCounter();
                        if (PwHash != null || _firstTry)
                        {
                            VeriFailedButtonConfig();
                            _firstTry = false;
                        }
                        _currentop = Ops.Verificationfailedretry;
                        lblInfo.Text = Resources.User_verification_failed___;
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
                            Logger.Debug("Device added " + (NDevice) ea.NewItems[0]);
                            CheckCamera();

                            break;

                        case NotifyCollectionChangedAction.Remove:
                            Logger.Debug("Device Removed " + (NDevice) ea.OldItems[0]);
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
                MessageBox.Show(Resources.Device_manager_not_responding___, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblInfo.Text = string.Format("Retry after : {0,3} seconds", _initialRetryDelay);
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
            Verified = false;
            DialogResult = DialogResult.Cancel;
            if (Settings.Default.UnlockFormWidth < Settings.Default.UnlockFormWidthDefault &&
                Settings.Default.UnlockFormHeight < Settings.Default.UnlockFormHeightDefault)
                return;
            Width = Settings.Default.UnlockFormWidth;
            Height = Settings.Default.UnlockFormHeight;
        }

        private void LinkLabelAddPwLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_retryWithPw)
            {
                llblRetryWithPW.Text = Resources.Cancel_password_retry;
                tbPw.Enabled = true;
                tbPw.Visible = true;
                llblRetryWithPW.LinkVisited = true;
                tbPw.Focus();
                _currentop = Ops.Verifywithpassword;
                _retryWithPw = true;
            }
            else
            {
                llblRetryWithPW.Text = Resources.Retry_using_password;
                tbPw.Enabled = false;
                tbPw.Visible = false;

                llblRetryWithPW.LinkVisited = false;
                _retryWithPw = false;
                _currentop = Ops.Verificationfailedretry;
            }
        }

        private void ButtonMainClick(object sender, EventArgs e)
        {
            switch (_currentop)
            {
                case Ops.Passwordnotsupported:
                case Ops.Cancelled:
                    VerificationOperationInit();

                    break;

                case Ops.Capturingfailed:
                    _currentop = Ops.Ongoing;
                    _biometricClient.BeginCapture(_subject, OnCapturingCompleted, null);
                    break;

                case Ops.Ongoing:
                    _biometricClient.Cancel();
                    _currentop = Ops.Cancelled;
                    lblInfo.Text = Resources.Canceled___;

                    break;

                case Ops.Verificationfailedretry:
                    if (!_retryWithPw)
                    {
                        VerificationOperationInit();
                    }
                    else
                    {
                        VerifyWithPassword();
                    }
                    break;

                case Ops.Verifywithpassword:
                    VerifyWithPassword();
                    break;

                default:
                    Logger.Error("Invalid current operation");
                    Close();
                    break;
            }
        }

        private void UnlockFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.UnlockFormWidth = Width;
            Settings.Default.UnlockFormHeight = Height;
            Settings.Default.Save();
            Settings.Default.Reload();

            if (_biometricClient != null)
            {
                _biometricClient.Dispose();
                _biometricClient = null;
            }
            if (_subject != null)
            {
                _subject.Dispose();
                _subject = null;
            }
            if (_subjectFromFile != null)
            {
                _subjectFromFile.Dispose();
                _subjectFromFile = null;
            }
        }

        #endregion Private Form Events

        #region Private Methods

        private void VerifyWithPassword()
        {
            lblInfo.Text = Resources.Verifying_using_password____;
            Verified = false;
            if (tbPw.Text != null && PwHash != null)
            {
                if (NLockTemplateOperationsCommon.ValidatePassword(NLockTemplateOperations.GetBytes(tbPw.Text), PwHash))
                {
                    Verified = true;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    lblInfo.Text = Resources.Invalid_password___;
                    _currentop = Ops.Verificationfailedretry;
                    EnableRetryCounter();
                }
            }
            else if (PwHash == null)
            {
                lblHelpText.Text = Resources.Password_not_supported;
                lblInfo.Text = Resources.Failed___;
                llblRetryWithPW.Enabled = false;
                llblRetryWithPW.Visible = false;
                tbPw.Enabled = false;
                tbPw.Visible = false;

                _retryWithPw = false;
                _currentop = Ops.Passwordnotsupported;
            }
            else
            {
                lblInfo.Text = Resources.Invalid_password___;
                _currentop = Ops.Verificationfailedretry;
            }
        }

        private void EnableRetryCounter()
        {
            Interlocked.Increment(ref _retryCount);
            if (_retryCount >= 3)
            {
                btnMain.Visible = false;

                Interlocked.Exchange(ref _initialRetryDelay, 1*(int) Math.Exp(_retryCount));
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

                _currentop = Ops.Cancelled;

                lblInfo.Text = Resources.CameraNotDetected;
                btnMain.Enabled = false;
                btnMain.BackColor = Color.Gray;
                nlockLoginFaceView.Face = new NFace
                                          {
                                              Image =
                                                  NImage.FromBitmap(Resources.NoCameraDetected)
                                          };

                return false;
            }
            lblInfo.Text = Resources.CameraDetected;

            nlockLoginFaceView.Face = new NFace
                                      {
                                          Image =
                                              NImage.FromBitmap(
                                                  Resources.CameraDetectedContinue)
                                      };
            btnMain.Enabled = true;
            btnMain.BackColor = Color.Green;
            return true;
        }

        private void CheckLicense()
        {
            const string Components =
                "Biometrics.FaceExtraction," +
                "Biometrics.FaceDetection," +
                "Biometrics.FaceMatching," +
                "Devices.Cameras";

            foreach (var component in Components.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
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