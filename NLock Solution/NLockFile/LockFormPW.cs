using NLock.Properties;
using System;
using System.Windows.Forms;

namespace NLock
{
    public partial class LockFormPW : Form
    {
        #region Public property

        public String Password { get; set; }

        #endregion Public property

        #region Public constructor

        public LockFormPW()
        {
            InitializeComponent();
        }

        #endregion Public constructor

        #region Private Form events

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Password = null;
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (Password != tboxEnterPW.Text && ValidationLogic())
            {
                Password = tboxEnterPW.Text;

                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void LockFormPW_Load(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
        }

        private void TextboxEnterPWKeyUp(object sender, KeyEventArgs e)
        {
            ValidationLogic();
        }

        private void TextboxReenterPWKeyUp(object sender, KeyEventArgs e)
        {
            ValidationLogic();
        }

        #endregion Private Form events

        #region Private Methods

        private bool ValidationLogic()
        {
            if (String.IsNullOrEmpty(tboxEnterPW.Text) || String.IsNullOrWhiteSpace(tboxEnterPW.Text))
            {
                btnOk.Enabled = false;
                pwErrorProvider.SetError(tboxEnterPW, "Empty password");
                pwErrorProvider.Icon = Resources.err;
                rpwMatchErrorProvider.Clear();
                return false;
            }

            if (tboxEnterPW.Text == tboxReenterPW.Text)
            {
                btnOk.Enabled = true;
                pwErrorProvider.SetError(tboxEnterPW, "Both passwords match");
                rpwMatchErrorProvider.SetError(tboxReenterPW, "Both passwords match");
                pwErrorProvider.Icon = Resources.tick;
                rpwMatchErrorProvider.Icon = Resources.tick;

                return true;
            }
            else
            {
                btnOk.Enabled = false;
                rpwMatchErrorProvider.SetError(tboxReenterPW, "Passwords do not match");
                rpwMatchErrorProvider.Icon = Resources.err;
                pwErrorProvider.Clear();

                return false;
            }
        }

        #endregion Private Methods

        private void LockFormPW_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.skippassword = cboxSkipSettings.Checked;
        }
    }
}