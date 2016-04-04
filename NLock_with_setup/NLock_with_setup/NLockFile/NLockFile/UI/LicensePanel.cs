using Neurotec.Licensing;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NLock.NLockFile.UI
{
    public partial class LicensePanel : UserControl
    {
        #region Public constructor

        public LicensePanel()
        {
            InitializeComponent();
        }

        #endregion Public constructor

        #region Private fields

        public const int Port = 5000;
        public const string Address = "/local";

        private string _requiredComponents = string.Empty;
        private string _optionalComponents = string.Empty;

        #endregion Private fields

        #region Public properties

        public string RequiredComponents
        {
            get
            {
                return _requiredComponents;
            }
            set
            {
                _requiredComponents = value;
                rtbComponents.SelectionColor = Color.Black;
                rtbComponents.Text = GetRequiredComponentsString();
                var optional = GetOptionalComponentsString();
                if (!string.IsNullOrEmpty(optional))
                {
                    rtbComponents.AppendText(", " + optional);
                }
            }
        }

        public string OptionalComponents
        {
            get
            {
                return _optionalComponents;
            }
            set
            {
                _optionalComponents = value;
                rtbComponents.SelectionColor = Color.Black;
                rtbComponents.Text = GetRequiredComponentsString();
                var optional = GetOptionalComponentsString();
                if (!string.IsNullOrEmpty(optional))
                {
                    rtbComponents.AppendText(", " + optional);
                }
            }
        }

        #endregion Public properties

        #region Private methods

        private void LicensePanelLoad(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshComponentsStatus();
            }
        }

        private string GetRequiredComponentsString()
        {
            return _requiredComponents?.Replace(",", " ") ?? string.Empty;
        }

        private string GetOptionalComponentsString()
        {
            if (_optionalComponents == null) return string.Empty;

            var comps = _optionalComponents.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (comps.Length == 0)
                return string.Empty;
            var result = new StringBuilder();
            for (int i = 0; i < comps.Length; i++)
            {
                result.Append(comps[i]);
                result.Append("(optional)");
                if (i != comps.Length - 1)
                    result.Append(", ");
            }
            return result.ToString();
        }

        private void RefreshRequired()
        {
            var text = rtbComponents.Text;
            try
            {
                rtbComponents.Text = string.Empty;
                var obtainedCount = 0;
                var requiredComponents = RequiredComponents.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < requiredComponents.Length; i++)
                {
                    var item = requiredComponents[i];
                    rtbComponents.SelectionStart = rtbComponents.TextLength;
                    if (NLicense.IsComponentActivated(item))
                    {
                        rtbComponents.SelectionColor = Color.Green;
                        rtbComponents.AppendText(item);
                        obtainedCount++;
                    }
                    else
                    {
                        rtbComponents.SelectionColor = Color.Red;
                        rtbComponents.AppendText(item);
                    }
                    if (i != requiredComponents.Length - 1)
                    {
                        rtbComponents.SelectionColor = Color.Black;
                        rtbComponents.AppendText(", ");
                    }
                }

                if (obtainedCount == requiredComponents.Length)
                {
                    lblStatus.Text = @"Component licenses obtained";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = @"Not all required licenses obtained";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch
            {
                rtbComponents.SelectionColor = Color.Black;
                rtbComponents.Text = text;
                throw;
            }
        }

        private void RefreshOptional()
        {
            var text = rtbComponents.Text;
            try
            {
                rtbComponents.SelectionColor = Color.Black;
                rtbComponents.AppendText(", ");
                var comps = OptionalComponents.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < comps.Length; i++)
                {
                    var item = comps[i];
                    rtbComponents.SelectionStart = rtbComponents.TextLength;
                    rtbComponents.SelectionColor = NLicense.IsComponentActivated(item) ? Color.Green : Color.Red;
                    rtbComponents.AppendText(string.Format("{0} (optional)", item));

                    if (i != comps.Length - 1)
                    {
                        rtbComponents.SelectionColor = Color.Black;
                        rtbComponents.AppendText(", ");
                    }
                }
            }
            catch
            {
                rtbComponents.SelectionColor = Color.Black;
                rtbComponents.Text = text;
                throw;
            }
        }

        #endregion Private methods

        #region Public methods

        public void RefreshComponentsStatus()
        {
            try
            {
                RefreshRequired();
                RefreshOptional();
            }
            catch (Exception ex)
            {
                lblStatus.Text = string.Format("Failed to check components activation status. Error message: {0}", ex.Message);
                lblStatus.ForeColor = Color.Red;
            }
        }

        #endregion Public methods


    }
}