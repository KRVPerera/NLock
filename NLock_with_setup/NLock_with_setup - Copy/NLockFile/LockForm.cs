using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using log4net;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.Licensing;
using NLock.Properties;

namespace NLock
{
    public partial class LockForm : Form
    {
        #region Public Constructors

        public LockForm()
        {
            _enumoperation = Modes.Initialization;
            InitializeComponent();
        }

        #endregion Public Constructors

        private enum Modes
        {
            Initialization,
            Capturing,
            Capturesuccess,
            Invalidpath,
            Capturesuccessnopassword
        }

        #region Private variables

        private static readonly ILog Logger = LogManager.GetLogger(typeof (LockForm));

        private NBiometricClient _biometricClient;
        private NDeviceManager _deviceManager;
        private bool? _isSegmentationActivated;
        private NSubject _subject;
        private Modes _enumoperation;
        private bool _cboxSkipPWcheckState;
        public byte[] TemplateLoginForm;

        #endregion Private variables

        #region Public properties

        public String SaveFileName { get; set; }

        public String Password { get; private set; }

        public bool AddPassword { get; private set; }

        #endregion Public properties

        #region Form VisualChanges

        private void FromInit()
        {
            TemplateLoginForm = null;
            _cboxSkipPWcheckState = false;
        }

        private void CloseButtonCapSuccessConfig()
        {
            lblInfo.Text = Resources.SaveMsg;
            lblInfo.ForeColor = Color.Green;
        }

        private void CapStartButtonInitConfig()
        {
            lblInfo.Text = Resources.StartMsg;
            lockFormFaceView.Face = new NFace();
            lockFormFaceView.Face.Image = NImage.FromBitmap(Resources.StartImage);
        }

        #endregion Form VisualChanges

        #region Biometric Client Operation

        private void CapturingOperationInit()
        {
            _subject = new NSubject();
            var face = new NFace {CaptureOptions = NBiometricCaptureOptions.Stream};
            _subject.Faces.Add(face);
            lockFormFaceView.Face = face;
        }

        private void ClientInit()
        {
            _biometricClient = new NBiometricClient {BiometricTypes = NBiometricType.Face, UseDeviceManager = true};
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
                try
                {
                    var status = _biometricClient.EndCapture(r);

                    if (status == NBiometricStatus.Ok)
                    {
                        TemplateLoginForm = _subject.GetTemplateBuffer().ToArray();

                        _enumoperation = Modes.Initialization;
                        if (_subject.Faces.Count > 1)
                        {
                            TemplateLoginForm = null;
                            lblInfo.Text = Resources.ManyFaces;
                            lblInfo.ForeColor = Color.Red;
                            CapturingOperationInit();
                            _subject.Faces[0].Image = null;
                            _biometricClient.BeginCapture(_subject, OnCapturingComplete, null);
                        }
                        else
                        {
                            CloseButtonCapSuccessConfig();
                            _enumoperation = Modes.Capturesuccess;
                        }
                    }
                    else
                    {
                        TemplateLoginForm = null;

                        lblInfo.Text = Resources.RestartCapture + "\n" + status;
                        lblInfo.ForeColor = Color.Red;
                        CapturingOperationInit();
                        _enumoperation = Modes.Initialization;
                        _subject.Faces[0].Image = null;
                        _biometricClient.BeginCapture(_subject, OnCapturingComplete, null);
                    }
                }
                catch (InvalidOperationException)
                {
                    CheckCamera();
                    CheckLicense();
                    CapturingOperationInit();
                    _enumoperation = Modes.Initialization;
                }
                catch (Exception)
                {
                    CheckCamera();
                    CheckLicense();
                    CapturingOperationInit();

                    _enumoperation = Modes.Initialization;
                }
            }
        }

        private void CheckLicense()
        {
            licensePanel1.RefreshComponentsStatus();
        }

        private void CapturingOperationRest()
        {
            _enumoperation = Modes.Capturing;
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

            _cboxSkipPWcheckState = Settings.Default.skippassword;

            tboxFileName.Text = !String.IsNullOrEmpty(Settings.Default.previoussave)
                ? Settings.Default.previoussave
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            btnMain.PerformClick();
        }

        private void ButtonMainClick(object sender, EventArgs e)
        {
            switch (_enumoperation)
            {
                case Modes.Initialization:
                    CapturingOperationRest();
                    break;

                case Modes.Capturing:
                    _biometricClient.Cancel();
                    _enumoperation = Modes.Initialization;
                    break;

                case Modes.Capturesuccess:
                case Modes.Capturesuccessnopassword:
                    if (!_cboxSkipPWcheckState && !AddPassword)
                    {
                        CaptureSuccessClosing();
                        if (AddPassword)
                        {
                            FormClose();
                        }
                    }
                    else
                    {
                        FormClose();
                    }

                    break;

                case Modes.Invalidpath:
                    FormClose();
                    break;

                default:
                    TemplateLoginForm = null;
                    Password = null;
                    AddPassword = false;
                    DialogResult = DialogResult.Cancel;
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
            TemplateLoginForm = null;
            AddPassword = false;
            SaveFileName = null;
            _subject = null;

            DialogResult = DialogResult.Cancel;
        }

        private void ButtonResetClick(object sender, EventArgs e)
        {
            CapStartButtonInitConfig();
            CheckCamera();
            _enumoperation = Modes.Initialization;
        }

        private void LockFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Settings.Default.previoussave = Path.GetDirectoryName(tboxFileName.Text);
                Settings.Default.Save();
            }

            if (!_cboxSkipPWcheckState) return;
            AddPassword = false;
            Password = null;
        }

        private void TextboxFileNameTextChanged(object sender, EventArgs e)
        {
            var valid = IsValidFilename(tboxFileName.Text);
            if (valid > 0)
            {
                filePathErrorProvider.Clear();
            }
            else
                switch (valid)
                {
                    case -2:
                        filePathErrorProvider.SetError(tboxFileName, "A Directory exists with this name");
                        filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                        break;
                    case -3:
                        filePathErrorProvider.SetError(tboxFileName, "File Already Exists. Will be overwritten");
                        filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                        break;
                    default:
                        filePathErrorProvider.SetError(tboxFileName, Resources.InvalidPath);
                        filePathErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                        break;
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
                lblInfo.Text = Resources.ValidPath;
                lblInfo.ForeColor = Color.Green;
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

            FileInfo fi = null;
            try
            {
                fi = new FileInfo(filePath);
            }
            catch (ArgumentException)
            {
                return -1;
            }
            catch (PathTooLongException)
            {
                return -1;
            }
            catch (NotSupportedException)
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
                    var result = MessageBox.Show(Resources.AsktoCreateFolder, Resources.DirectoryNotFound,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var fi = new FileInfo(tboxFileName.Text);
                        fi.Directory.Create();
                        SaveFileName = tboxFileName.Text;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        lblInfo.Text = Resources.InvalidPath;
                        lblInfo.ForeColor = Color.Red;
                        _enumoperation = Modes.Invalidpath;
                    }
                }
                else if (valid == 1)
                {
                    SaveFileName = tboxFileName.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else if (valid == -2)
            {
                lblInfo.Text = Resources.PathIsAFolder;
                lblInfo.ForeColor = Color.Red;
                _enumoperation = Modes.Invalidpath;
            }
            else if (valid == -3)
            {
                var result = MessageBox.Show(Resources.AsktoOverwrite, Resources.FileExists,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveFileName = tboxFileName.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblInfo.Text = Resources.InvalidPath;
                    lblInfo.ForeColor = Color.Red;
                    _enumoperation = Modes.Invalidpath;
                }
            }
            else // -1
            {
                lblInfo.Text = Resources.InvalidPath;
                lblInfo.ForeColor = Color.Red;
                _enumoperation = Modes.Invalidpath;
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
            if (_enumoperation == Modes.Initialization)
            {
                if (deviceCount <= 0)
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = Resources.CameraNotDetected;
                    lockFormFaceView.Face = new NFace();
                    lockFormFaceView.Face.Image = NImage.FromBitmap(Resources.NoCameraDetected);
                }
                else
                {
                    lblInfo.Text = Resources.CameraDetected;
                    lblInfo.ForeColor = Color.Green;
                    lockFormFaceView.Face = new NFace();
                    lockFormFaceView.Face.Image = NImage.FromBitmap(Resources.StartImage);
                }
            }
        }

        /// <summary>
        ///     From CompanyNeurotechnology devices sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceManagerDevicesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BeginInvoke(new Action<NotifyCollectionChangedEventArgs>(ea => { CheckCamera(); }), e);
        }

        private void ShowPasswordDialog()
        {
            //TODO : make it appear magically - slide right from beneath
            using (var passwordForm = new PasswordForm())
            {
                passwordForm.ShowDialog(this);
                var result = passwordForm.DialogResult;

                if (result == DialogResult.Yes)
                {
                    AddPassword = true;
                    Password = passwordForm.Password;
                    _cboxSkipPWcheckState = false;
                }
                else
                {
                    AddPassword = false;
                    Password = null;
                    _cboxSkipPWcheckState = true;
                }
            }
        }

        #endregion Private Methods
    }
}