using System;
using System.Windows.Forms;

namespace NLock
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Copyright \u00a9 2015-2016";
            lblInfo2.Text = "All rights reserved.";
            lblNtInfo.Text = "NLock is using Neurotechnology";
            linkLabel.Text = "VeriLook SDK";
            linkLabelNt.Text = "Neurotechnology";
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.neurotechnology.com/verilook.html");
        }

        private void linkLabelNt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.neurotechnology.com");
        }
    }
}