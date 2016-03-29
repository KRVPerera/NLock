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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.licensePanel1 = new NLock.NLockFile.UI.LicensePanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.llblRetryWithPW = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.llblCancel = new System.Windows.Forms.LinkLabel();
            this.btnMain = new System.Windows.Forms.Button();
            this.retryTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nlockLoginFaceView
            // 
            this.nlockLoginFaceView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nlockLoginFaceView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nlockLoginFaceView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nlockLoginFaceView.Face = null;
            this.nlockLoginFaceView.FaceIds = null;
            this.nlockLoginFaceView.FaceRectangleColor = System.Drawing.Color.Cyan;
            this.nlockLoginFaceView.Location = new System.Drawing.Point(0, 21);
            this.nlockLoginFaceView.MinimumSize = new System.Drawing.Size(150, 200);
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
            this.nlockLoginFaceView.Size = new System.Drawing.Size(218, 200);
            this.nlockLoginFaceView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.79295F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.22997F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.77003F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 386);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Location = new System.Drawing.Point(3, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 43);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(185, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.licensePanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 64);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // licensePanel1
            // 
            this.licensePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensePanel1.Location = new System.Drawing.Point(3, 16);
            this.licensePanel1.Name = "licensePanel1";
            this.licensePanel1.OptionalComponents = "";
            this.licensePanel1.RequiredComponents = "Biometrics.FaceExtraction,Biometrics.FaceDetection,Biometrics.FaceMatching,Device" +
    "s.Cameras";
            this.licensePanel1.Size = new System.Drawing.Size(442, 45);
            this.licensePanel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(448, 220);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(227, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 214);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblHelpText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbPw, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.llblRetryWithPW, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.90476F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 195);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblHelpText
            // 
            this.lblHelpText.AutoSize = true;
            this.lblHelpText.Location = new System.Drawing.Point(3, 0);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(201, 39);
            this.lblHelpText.TabIndex = 4;
            this.lblHelpText.Text = "Adding a password will give you ability to unlock a file using the same password " +
    "again.";
            // 
            // tbPw
            // 
            this.tbPw.Location = new System.Drawing.Point(3, 171);
            this.tbPw.Name = "tbPw";
            this.tbPw.Size = new System.Drawing.Size(154, 20);
            this.tbPw.TabIndex = 6;
            this.tbPw.UseSystemPasswordChar = true;
            this.tbPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxPwKeyDown);
            // 
            // llblRetryWithPW
            // 
            this.llblRetryWithPW.AutoSize = true;
            this.llblRetryWithPW.Location = new System.Drawing.Point(3, 146);
            this.llblRetryWithPW.Name = "llblRetryWithPW";
            this.llblRetryWithPW.Size = new System.Drawing.Size(103, 13);
            this.llblRetryWithPW.TabIndex = 3;
            this.llblRetryWithPW.TabStop = true;
            this.llblRetryWithPW.Text = "Retry with Password";
            this.llblRetryWithPW.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddPWLinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nlockLoginFaceView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 214);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Face";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.59821F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.40179F));
            this.tableLayoutPanel4.Controls.Add(this.llblCancel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMain, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 348);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(448, 35);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // llblCancel
            // 
            this.llblCancel.AutoSize = true;
            this.llblCancel.Location = new System.Drawing.Point(381, 0);
            this.llblCancel.Name = "llblCancel";
            this.llblCancel.Size = new System.Drawing.Size(40, 13);
            this.llblCancel.TabIndex = 0;
            this.llblCancel.TabStop = true;
            this.llblCancel.Text = "Cancel";
            this.llblCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCancelLinkClicked);
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Location = new System.Drawing.Point(3, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(372, 29);
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
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(456, 390);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NLock Unlocker - Face";
            this.Load += new System.EventHandler(this.UnlockFormLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neurotec.Biometrics.Gui.NFaceView nlockLoginFaceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.LinkLabel llblRetryWithPW;
        private System.Windows.Forms.Label lblHelpText;
        private System.Windows.Forms.TextBox tbPw;
        private System.Windows.Forms.LinkLabel llblCancel;
        private System.Windows.Forms.Timer retryTimer;
        private NLockFile.UI.LicensePanel licensePanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}