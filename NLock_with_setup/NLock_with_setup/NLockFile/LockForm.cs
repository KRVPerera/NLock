﻿using System;
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



        #region Private variables
        private enum Modes
        {
            Initialization,
            Capturing,
            Capturesuccess,
            Invalidpath,
            Capturesuccessnopassword
        }

        private static readonly ILog Logger = LogManager.GetLogger(typeof (LockForm));

        private NBiometricClient _biometricClient;
        private NDeviceManager _deviceManager;
        private bool? _isSegmentationActivated;
        private NSubject _subject;
        private Modes _enumoperation;
        private bool _cboxSkipPWcheckState;
        public byte[] TemplateLoginForm;
        private string _predictedFileName;

        #endregion Private variables

        #region Public properties

        public string SaveFileName { get; set; }

        public string Password { get; private set; }

        public bool AddPassword { get; private set; }

        #endregion Public properties

        #region Form VisualChanges

        private void FromInit()
        {
            TemplateLoginForm = null;
            _cboxSkipPWcheckState = false;

            if (Settings.Default.LockFormWidth < Settings.Default.LockFormWidthDefault &&
                Settings.Default.LockFormHeight < Settings.Default.LockFormHeightDefault) return;
            Width = Settings.Default.LockFormWidth;
            Height = Settings.Default.LockFormHeight;

            _cboxSkipPWcheckState = Settings.Default.skippassword;
            tboxFileName.Text = !string.IsNullOrEmpty(Settings.Default.previoussave)
                    ? Settings.Default.previoussave
                    : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (_predictedFileName != null)
            {
                tboxFileName.Text = tboxFileName.Text +"\\"+ _predictedFileName;
            }

            ValidateFileName();

        }

        private void CloseButtonCapSuccessConfig()
        {
            lblInfo.Text = Resources.SaveMsg;
            lblInfo.ForeColor = Color.Green;
        }

        private void CapStartButtonInitConfig()
        {
            lblInfo.Text = Resources.StartMsg;
            lockFormFaceView.Face = new NFace {Image = NImage.FromBitmap(Resources.StartImage)};
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
            //licensePanel2.RefreshComponentsStatus();
        }

        private void CapturingOperationRest()
        {
            _enumoperation = Modes.Capturing;
            CapturingOperationInit();
            _biometricClient.BeginCapture(_subject, OnCapturingComplete, null);
        }

        #endregion Biometric Client Operation

        #region Private Form Events

        private void LockFormLoad(object sender, EventArgs e)
        {
            FromInit();
            ClientInit();
            CapStartButtonInitConfig();
            DeviceManagerUtilication();
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
                    tboxFileName.Focus();
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
            ValidateFileName();
        }

        private void TextBoxFileNameLeave(object sender, EventArgs e)
        {
            var valid = IsValidFilename(tboxFileName.Text);
            if (valid == 1)
            {
                if (!tboxFileName.Text.EndsWith(Resources.NLock_Extention))
                {
                    tboxFileName.Text = tboxFileName.Text + Resources.NLock_Extention;
                }
                lblInfo.Text = Resources.ValidPath;
                lblInfo.ForeColor = Color.Green;
                btnMain.Focus();
            }
        }

        private void LockFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_subject != null)
            {
                _subject.Dispose();
                _subject = null;
            }

            if (_biometricClient != null)
            {
                _biometricClient.Dispose();
                _biometricClient = null;
            }

            Settings.Default.LockFormWidth = Width;
            Settings.Default.LockFormHeight = Height;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        private void ButtonAddPasswordClick(object sender, EventArgs e)
        {
            ShowPasswordDialog();
        }

        private void TboxFileNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tboxFileName.SelectNextControl(tboxFileName, true, true, false, true);
            }
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

            FileInfo fi;
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

        private void ValidateFileName()
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
                        if (fi.Directory != null) fi.Directory.Create();

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
                    lockFormFaceView.Face = new NFace {Image = NImage.FromBitmap(Resources.NoCameraDetected)};
                }
                else
                {
                    lblInfo.Text = Resources.CameraDetected;
                    lblInfo.ForeColor = Color.Green;
                    lockFormFaceView.Face = new NFace {Image = NImage.FromBitmap(Resources.StartImage)};
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

        #region Public Methods
        public void ChangeSaveFileName(string savePathName)
        {
            if (savePathName != null)
            {
                _predictedFileName = Path.GetFileNameWithoutExtension(savePathName) + ".nlk";
            }
            else
            {
                _predictedFileName = null;
            }
        }
        #endregion
    }
}