using NLock.Properties;
using System;
using System.Windows.Forms;

namespace NLock
{
    public partial class PasswordForm : Form
    {
        #region Public property

        public string Password { get; private set; }

        #endregion Public property

        #region Public constructor

        public PasswordForm()
        {
            InitializeComponent();
        }

        #endregion Public constructor

        #region Private Form events

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Password = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (Password != tboxEnterPW.Text && ValidationLogic())
            {
                Password = tboxEnterPW.Text;

                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void LockFormPwLoad(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
        }

        private void TextboxEnterPwKeyUp(object sender, KeyEventArgs e)
        {
            ValidationLogic();
        }

        private void TextboxReenterPwKeyUp(object sender, KeyEventArgs e)
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
                pwErrorProvider.SetError(tboxEnterPW, Resources.EmptyPasswd);
                pwErrorProvider.Icon = Resources.err;
                rpwMatchErrorProvider.Clear();
                return false;
            }

            if (tboxEnterPW.Text == tboxReenterPW.Text)
            {
                btnOk.Enabled = true;
                pwErrorProvider.SetError(tboxEnterPW, Resources.PasswordsMatch);
                rpwMatchErrorProvider.SetError(tboxReenterPW, Resources.PasswordsMatch);
                pwErrorProvider.Icon = Resources.tick;
                rpwMatchErrorProvider.Icon = Resources.tick;

                return true;
            }
            else
            {
                btnOk.Enabled = false;
                rpwMatchErrorProvider.SetError(tboxReenterPW, Resources.PasswdNotMatch);
                rpwMatchErrorProvider.Icon = Resources.err;
                pwErrorProvider.Clear();

                return false;
            }
        }

        #endregion Private Methods

        private void LockFormPwFormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.skippassword = cboxSkipSettings.Checked;
        }
    }
}