namespace NLock
{
    partial class UnlockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlockForm));
            this.nlockLoginFaceView = new Neurotec.Biometrics.Gui.NFaceView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.licensePanel1 = new NLock.NLockFile.UI.LicensePanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.llblRetryWithPW = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.llblCancel = new System.Windows.Forms.LinkLabel();
            this.btnMain = new System.Windows.Forms.Button();
            this.retryTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nlockLoginFaceView
            // 
            this.nlockLoginFaceView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nlockLoginFaceView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nlockLoginFaceView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nlockLoginFaceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nlockLoginFaceView.Face = null;
            this.nlockLoginFaceView.FaceIds = null;
            this.nlockLoginFaceView.FaceRectangleColor = System.Drawing.Color.Cyan;
            this.nlockLoginFaceView.Location = new System.Drawing.Point(0, 13);
            this.nlockLoginFaceView.Name = "nlockLoginFaceView";
            this.nlockLoginFaceView.ShowBaseFeaturePoints = false;
            this.nlockLoginFaceView.ShowEmotions = false;
            this.nlockLoginFaceView.ShowExpression = false;
            this.nlockLoginFaceView.ShowEyes = false;
            this.nlockLoginFaceView.ShowFaceConfidence = false;
            this.nlockLoginFaceView.ShowGender = false;
            this.nlockLoginFaceView.ShowMouth = false;
            this.nlockLoginFaceView.ShowNose = false;
            this.nlockLoginFaceView.ShowProperties = false;
            this.nlockLoginFaceView.Size = new System.Drawing.Size(271, 220);
            this.nlockLoginFaceView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Location = new System.Drawing.Point(11, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(3, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(440, 37);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // licensePanel1
            // 
            this.licensePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licensePanel1.Location = new System.Drawing.Point(12, 12);
            this.licensePanel1.Name = "licensePanel1";
            this.licensePanel1.OptionalComponents = "";
            this.licensePanel1.RequiredComponents = "Biometrics.FaceExtraction,Biometrics.FaceDetection,Biometrics.FaceMatching,Device" +
    "s.Cameras";
            this.licensePanel1.Size = new System.Drawing.Size(446, 33);
            this.licensePanel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPw);
            this.groupBox2.Controls.Add(this.lblHelpText);
            this.groupBox2.Controls.Add(this.llblRetryWithPW);
            this.groupBox2.Location = new System.Drawing.Point(286, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 230);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password";
            // 
            // tbPw
            // 
            this.tbPw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPw.Location = new System.Drawing.Point(9, 202);
            this.tbPw.Name = "tbPw";
            this.tbPw.Size = new System.Drawing.Size(156, 20);
            this.tbPw.TabIndex = 4;
            this.tbPw.UseSystemPasswordChar = true;
            this.tbPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxPwKeyDown);
            // 
            // lblHelpText
            // 
            this.lblHelpText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelpText.Location = new System.Drawing.Point(6, 16);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(159, 39);
            this.lblHelpText.TabIndex = 4;
            this.lblHelpText.Text = "Adding a password will give you ability to unlock a file using the same password " +
    "again.";
            // 
            // llblRetryWithPW
            // 
            this.llblRetryWithPW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRetryWithPW.AutoSize = true;
            this.llblRetryWithPW.Location = new System.Drawing.Point(6, 186);
            this.llblRetryWithPW.Name = "llblRetryWithPW";
            this.llblRetryWithPW.Size = new System.Drawing.Size(103, 13);
            this.llblRetryWithPW.TabIndex = 3;
            this.llblRetryWithPW.TabStop = true;
            this.llblRetryWithPW.Text = "Retry with Password";
            this.llblRetryWithPW.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddPWLinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.nlockLoginFaceView);
            this.groupBox3.Location = new System.Drawing.Point(12, 48);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(271, 233);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Face";
            // 
            // llblCancel
            // 
            this.llblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblCancel.AutoSize = true;
            this.llblCancel.Location = new System.Drawing.Point(418, 368);
            this.llblCancel.Name = "llblCancel";
            this.llblCancel.Size = new System.Drawing.Size(40, 13);
            this.llblCancel.TabIndex = 2;
            this.llblCancel.TabStop = true;
            this.llblCancel.Text = "Cancel";
            this.llblCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCancelLinkClicked);
            // 
            // btnMain
            // 
            this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMain.BackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Location = new System.Drawing.Point(11, 352);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(401, 29);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Ok";
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.ButtonMainClick);
            // 
            // retryTimer
            // 
            this.retryTimer.Interval = 1000;
            this.retryTimer.Tick += new System.EventHandler(this.RetryTimerTick);
            // 
            // UnlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(469, 390);
            this.ControlBox = false;
            this.Controls.Add(this.llblCancel);
            this.Controls.Add(this.licensePanel1);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(485, 303);
            this.Name = "UnlockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NLock Unlocker - Face";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UnlockFormFormClosed);
            this.Load += new System.EventHandler(this.UnlockFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neurotec.Biometrics.Gui.NFaceView nlockLoginFaceView;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.LinkLabel llblRetryWithPW;
        private System.Windows.Forms.Label lblHelpText;
        private System.Windows.Forms.TextBox tbPw;
        private System.Windows.Forms.LinkLabel llblCancel;
        private System.Windows.Forms.Timer retryTimer;
        private NLockFile.UI.LicensePanel licensePanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}