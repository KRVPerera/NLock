using System;
using System.Windows.Forms;
using NLock.Properties;

namespace NLock
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutFormLoad(object sender, EventArgs e)
        {
            lblInfo.Text = Resources.CopyrightYear;
            lblInfo2.Text = Resources.AllRightsReserved;
            lblNtInfo.Text = Resources.NLock_is_using ;
            linkLabel.Text = Resources.CompanyNeurotechnology + " " +Resources.VeriLookSDK;
            linkLabelNt.Text = Resources.CompanyNeurotechnology;
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.neurotechnology.com/verilook.html");
        }

        private void LinkLabelNtLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.neurotechnology.com");
        }
    }
}