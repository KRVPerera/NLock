using log4net;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.Licensing;
using NLock.NLockFile.Biometric;
using NLock.Properties;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace NLock
{
    public partial class LockForm : Form
    {
        private enum Modes
        {
            INITIALIZATION,
            CAPTURING,
            CAPTURESUCCESS,
            INVALIDPATH,
            CAPTURESUCCESSNOPASSWORD
        }

        #region Private variables

        private static readonly ILog Logger = LogManager.GetLogger(typeof(LockForm));

        private NBiometricClient _biometricClient;
        private NDeviceManager _deviceManager;
        private bool? _isSegmentationActivated;
        private NSubject _subject;
        private bool _addPassword;
        private string _password;
        private Modes _enumoperation;
        private bool cboxSkipPWcheckState;
        public byte[] _templateLoginForm;

        #endregion Private variables

        #region Public properties

        public String SaveFileName
        {
            get;
            set;
        }

        public String Password
        {
            get { return _password; }
        }

        public bool AddPassword
        {
            get { return _addPassword; }
        }

        #endregion Public properties

        #region Public Constructors

        public LockForm()
        {
            _enumoperation = Modes.INITIALIZATION;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Form VisualChanges

        private void FromInit()
        {
            _templateLoginForm = null;
            cboxSkipPWcheckState = false;
        }

        private void CloseButtonCapSuccessConfig()
        {
            lblInfo.Text = "Click OK...";
            lblInfo.ForeColor = System.Drawing.Color.Green;
        }

        private void CapStartButtonInitConfig()
        {
            lblInfo.Text = "Press capture to start capturing...";
            lockFormFaceView.Face = new NFace();
            lockFormFaceView.Face.Image = NImage.FromBitmap(Resources.StartImage);
            captureErrorProvider.Clear();
        }

        #endregion Form VisualChanges

        #region Biometric Client Operation

        private void CapturingOperationInit()
        {
            _subject = new NSubject();
            var face = new NFace { CaptureOptions = NBiometricCaptureOptions.Stream };
            _subject.Faces.Add(face);
            lockFormFaceView.Face = face;
        }

        private void ClientInit()
        {
            //TODO : Check whether need a singleton pattern here
            // disposing is a issue for this at form level
            _biometricClient = BiometricOperations.BiometricClient;

            _biometricClient.Initialize();
            _biometricClient.FacesTemplateSize = NTemplateSize.Small;

            if (!_isSegmentationActivated.HasValue)
            {
                _isSegmentationActivated = NLicense.IsComponentActivated("Biometrics.FaceSegmentsDetection");
            }

            _biometricClient.FacesDetectAllFeaturePoints = _isSegmentationActivated.Value;
            _biometricClient.FacesQualityThreshold = 50;

            _deviceManager = _biometricClient.DeviceManager;
        }

        private void OnCapturingComplete(IAsyncResult r)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnCapturingComplete), r);
            }
            else
            {
                var status = NBiometricStatus.InternalError;
                try
                {
                    status = _biometricClient.EndCapture(r);

                    if (status == NBiometricStatus.Ok)
                    {
                        _templateLoginForm = _subject.GetTemplateBuffer().ToArray();

                        _enumoperation = Modes.INITIALIZATION;
                        if (_subject.Faces.Count > 1)
                        {
                            _templateLoginForm = null;
                            lblInfo.Text = @"More than one face detected..
" +
                                        "Press restart to restart capturing...";
                            lblInfo.ForeColor = System.Drawing.Color.Red;
                            CapturingOperationInit();
                            captureErrorProvider.SetError(btnCapture, "More than one face detected..");
                            captureErrorProvider.Icon = Resources.err;
                        }
                        else
                        {
                            CloseButtonCapSuccessConfig();
                            _enumoperation = Modes.CAPTURESUCCESS;
                            captureErrorProvider.SetError(btnCapture, "Face Capturing is success");
                            captureErrorProvider.Icon = Resources.tick;
                        }
                    }
                    else
                    {
                        _templateLoginForm = null;

                        lblInfo.Text = lblInfo.Text + "\n" + status;
                        lblInfo.ForeColor = System.Drawing.Color.Red;
                        CapturingOperationInit();
                        _enumoperation = Modes.INITIALIZATION;
                        captureErrorProvider.SetError(btnCapture, status + "\nPlease look at the camera and press capture button.");
                        captureErrorProvider.Icon = Resources.err;
                    }
                }
                catch (InvalidOperationException)
                {
                    CheckCamera();
                    CheckLicense();
                    CapturingOperationInit();
                    _enumoperation = Modes.INITIALIZATION;
                }
                catch (Exception)
                {
                    CheckCamera();
                    CheckLicense();
                    CapturingOperationInit();

                    _enumoperation = Modes.INITIALIZATION;
                }
            }
        }

        private void CheckLicense()
        {
            licensePanel1.RefreshComponentsStatus();
        }

        private void CapturingOperationRest()
        {
            _enumoperation = Modes.CAPTURING;
            CapturingOperationInit();
            _biometricClient.BeginCapture(_subject, OnCapturingComplete, null);
        }

        #endregion Biometric Client Operation

        #region Private Form Events

        private void LoginForm_Load(object sender, EventArgs e)
        {
            FromInit();
            ClientInit();
            CapStartButtonInitConfig();

            DeviceManagerUtilication();

            Logger.Debug("access configuration  Settings.Default.skippassword");

            cboxSkipPWcheckState = Settings.Default.skippassword;

            tboxFileName.Text = !String.IsNullOrEmpty(Settings.Default.previoussave) ? Settings.Default.previoussave : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            btnMain.PerformClick();
        }

        private void ButtonMainClick(object sender, EventArgs e)
        {
            switch (_enumoperation)
            {
                case Modes.INITIALIZATION:
                    CapturingOperationRest();
                    break;

                case Modes.CAPTURING:
                    _biometricClient.Cancel();
                    _enumoperation = Modes.INITIALIZATION;
                    break;

                case Modes.CAPTURESUCCESS:
                case Modes.CAPTURESUCCESSNOPASSWORD:
                    if (!cboxSkipPWcheckState && !_addPassword)
                    {
                        CaptureSuccessClosing();
                        if (_addPassword)
                        {
                            FormClose();
                        }
                    }
                    else
                    {
                        FormClose();
                    }

                    break;

                case Modes.INVALIDPATH:
                    FormClose();
                    break;

                default:
                    _templateLoginForm = null;
                    _password = null;
                    _addPassword = false;
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void ButtonBrowseClick(object sender, EventArgs e)
        {
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tboxFileName.Text = saveFileDialog.FileName;
                SaveFileName = saveFileDialog.FileName;
            }
            else
            {
                SaveFileName = null;
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            //TODO : may be no need to do these if depending on dialog result
            _templateLoginForm = null;
            _addPassword = false;
            SaveFileName = null;
            _subject = null;

            this.DialogResult = DialogResult.Cancel;
        }

        private void ButtonResetClick(object sender, EventArgs e)
        {
            CapStartButtonInitConfig();
            CheckCamera();
            _enumoperation = Modes.INITIALIZATION;
        }

        private void LockFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Settings.Default.previoussave = Path.GetDirectoryName(tboxFileName.Text);
                Settings.Default.Save();
            }

            if (cboxSkipPWcheckState)
            {
                _addPassword = false;
                _password = null;
            }
        }

        private void TextboxFileNameTextChanged(object sender, EventArgs e)
        {
            var valid = IsValidFilename(tboxFileName.Text);
            if (valid > 0)
            {
                filePathErrorProvider.Icon = Resources.tick;
                filePathErrorProvider.SetError(tboxFileName, "OK");
                filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            }
            else if (valid == -2)
            {
                filePathErrorProvider.Icon = Resources.err;
                filePathErrorProvider.SetError(tboxFileName, "A Directory exists with this name");
                filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            }
            else if (valid == -3)
            {
                filePathErrorProvider.Icon = Resources.err;
                filePathErrorProvider.SetError(tboxFileName, "File Already Exists. Will be overwritten");
                filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            }
            else // -1
            {
                filePathErrorProvider.Icon = Resources.err;
                filePathErrorProvider.SetError(tboxFileName, "Invalid path");
                filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            }
        }

        private void TextBoxFileNameLeave(object sender, EventArgs e)
        {
            var valid = IsValidFilename(tboxFileName.Text);
            if (valid == 1)
            {
                if (!tboxFileName.Text.EndsWith(".nlk"))
                {
                    tboxFileName.Text = tboxFileName.Text + ".nlk";
                }
                lblInfo.Text = "Path is valid Press Start...";
                lblInfo.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void LockFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_subject != null)
            {
                _subject.Dispose();
            }
        }

        private void ButtonAddPasswordClick(object sender, EventArgs e)
        {
            ShowPasswordDialog();
        }

        private void ButtonCaptureClick(object sender, EventArgs e)
        {
            CapturingOperationRest();
        }

        #endregion Private Form Events

        #region Private Methods

        /// <summary>
        ///     ref : http://stackoverflow.com/questions/422090/in-c-sharp-check-that-filename-is-possibly-valid-not-that-it-exists
        /// </summary>
        /// <param name="filePath"> Possible path name</param>
        /// <returns></returns>
        private static int IsValidFilename(string filePath)
        {
            Logger.Debug("");

            System.IO.FileInfo fi = null;
            try
            {
                fi = new System.IO.FileInfo(filePath);
            }
            catch (ArgumentException) { return -1; }
            catch (System.IO.PathTooLongException) { return -1; }
            catch (NotSupportedException) { return -1; }

            if (ReferenceEquals(fi, null))
            {
                return -1;
            }

            if (fi.Directory != null)
            {
                if (!fi.Directory.Exists)
                {
                    return 2;
                }
            }

            if (Directory.Exists(filePath))
            {
                return -2;
            }

            if (fi.Exists)
            {
                return -3;
            }

            return 1;
        }

        private void CaptureSuccessClosing()
        {
            ShowPasswordDialog();
        }

        private void FormClose()
        {
            var valid = IsValidFilename(tboxFileName.Text);

            if (valid <= 0)
            {
                tboxFileName.Select();
                btnBrowse.PerformClick();
                valid = IsValidFilename(tboxFileName.Text);
            }

            Logger.Debug("Path isValid : " + valid);
            if (valid > 0)
            {
                if (valid == 2)
                {
                    var result = MessageBox.Show("Do you want create the folder..", "Directory not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var fi = new FileInfo(tboxFileName.Text);
                        fi.Directory.Create();
                        SaveFileName = tboxFileName.Text;

                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        lblInfo.Text = "Invalid path";
                        lblInfo.ForeColor = System.Drawing.Color.Red;
                        _enumoperation = Modes.INVALIDPATH;
                    }
                }
                else if (valid == 1)
                {
                    try
                    {
                        SaveFileName = tboxFileName.Text;
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Test" + ex);
                    }
                }
            }
            else if (valid == -2)
            {
                lblInfo.Text = "Invalid path - Given path is a folder name";
                lblInfo.ForeColor = System.Drawing.Color.Red;
                _enumoperation = Modes.INVALIDPATH;
            }
            else if (valid == -3)
            {
                var result = MessageBox.Show("Do you want overwrite the file..", "File Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveFileName = tboxFileName.Text;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblInfo.Text = "Invalid path";
                    lblInfo.ForeColor = System.Drawing.Color.Red;
                    _enumoperation = Modes.INVALIDPATH;
                }
            }
            else // -1
            {
                lblInfo.Text = "Invalid path";
                lblInfo.ForeColor = System.Drawing.Color.Red;
                _enumoperation = Modes.INVALIDPATH;
            }
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

        private void CheckCamera()
        {
            var deviceCount = _deviceManager.Devices.Count;
            if (_enumoperation == Modes.INITIALIZATION)
            {
                if (deviceCount <= 0)
                {
                    lblInfo.ForeColor = System.Drawing.Color.Red;
                    lblInfo.Text = "Could not detect the camera..\nPlease connect a camera.";
                    lockFormFaceView.Face = new NFace();
                    lockFormFaceView.Face.Image = NImage.FromBitmap(NLock.Properties.Resources.NoCameraDetected);
                }
                else
                {
                    lblInfo.Text = "Camera detected...\nPlease continue";
                    lblInfo.ForeColor = System.Drawing.Color.Green;
                    lockFormFaceView.Face = new NFace();
                    lockFormFaceView.Face.Image = NImage.FromBitmap(NLock.Properties.Resources.StartImage);
                }
            }
        }

        /// <summary>
        ///         From Neurotechnology devices sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceManagerDevicesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BeginInvoke(new Action<NotifyCollectionChangedEventArgs>(ea =>
            {
                CheckCamera();
            }), e);
        }

        private void ShowPasswordDialog()
        {
            //TODO : make it appear magically - slide right from beneath
            using (LockFormPW passwordForm = new LockFormPW())
            {
                passwordForm.ShowDialog(this);
                var result = passwordForm.DialogResult;

                if (result == DialogResult.Yes)
                {
                    _addPassword = true;
                    _password = passwordForm.Password;
                    cboxSkipPWcheckState = false;
                }
                else
                {
                    _addPassword = false;
                    _password = null;
                    cboxSkipPWcheckState = true;
                }
            }
        }

        #endregion Private Methods
    }
}