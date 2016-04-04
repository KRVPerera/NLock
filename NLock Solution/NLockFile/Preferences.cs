using System;
using System.Windows.Forms;

namespace NLock
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void ButtonCompressionPreferenceApplyClick(object sender, EventArgs e)
        {
            SaveNLockSettings();
        }

        private void ButtonCompressionPreferenceCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCompressionPreferenceSaveClick(object sender, EventArgs e)
        {
            SaveNLockSettings();

            this.Close();
        }

        private void ButtonLockinPreferencesCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonLockinPreferencesSaveClick(object sender, EventArgs e)
        {
            SaveNLockSettings();

            this.Close();
        }

        private void PreferencesFormLoad(object sender, EventArgs e)
        {
            try
            {
                cboxCmpressionLevel.SelectedIndex = Properties.Settings.Default.compressionLevel;
                cboxPwSkip.Checked = Properties.Settings.Default.skippassword;
            }
            catch (Exception)
            {
                Properties.Settings.Default.Reset();
                cboxPwSkip.Checked = false;
                cboxCmpressionLevel.SelectedIndex = 0;
            }
        }

        private void SaveNLockSettings()
        {
            Properties.Settings.Default.compressionLevel = cboxCmpressionLevel.SelectedIndex;
            Properties.Settings.Default.skippassword = cboxPwSkip.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void ButtonLockinPreferenceApplyClick(object sender, EventArgs e)
        {
            SaveNLockSettings();
        }
    }
}