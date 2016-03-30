namespace NLock
{
    partial class LockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockForm));
            this.lockFormFaceView = new Neurotec.Biometrics.Gui.NFaceView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPassword = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filePathErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.captureErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.licensePanel1 = new NLock.NLockFile.UI.LicensePanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePathErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lockFormFaceView
            // 
            this.lockFormFaceView.AutoSize = true;
            this.lockFormFaceView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lockFormFaceView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lockFormFaceView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lockFormFaceView.Face = null;
            this.lockFormFaceView.FaceIds = null;
            this.lockFormFaceView.FaceRectangleColor = System.Drawing.Color.Cyan;
            this.lockFormFaceView.Location = new System.Drawing.Point(32, 21);
            this.lockFormFaceView.MinimumSize = new System.Drawing.Size(200, 200);
            this.lockFormFaceView.Name = "lockFormFaceView";
            this.lockFormFaceView.ShowBaseFeaturePoints = false;
            this.lockFormFaceView.ShowEmotions = false;
            this.lockFormFaceView.ShowExpression = false;
            this.lockFormFaceView.ShowEyes = false;
            this.lockFormFaceView.ShowFaceConfidence = false;
            this.lockFormFaceView.ShowGender = false;
            this.lockFormFaceView.ShowMouth = false;
            this.lockFormFaceView.ShowNose = false;
            this.lockFormFaceView.ShowProperties = false;
            this.lockFormFaceView.Size = new System.Drawing.Size(200, 200);
            this.lockFormFaceView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.37063F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.62937F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(404, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBrowse, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(388, 27);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.tboxFileName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 26);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(348, 26);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File name";
            // 
            // tboxFileName
            // 
            this.tboxFileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tboxFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tboxFileName.Location = new System.Drawing.Point(61, 3);
            this.tboxFileName.MinimumSize = new System.Drawing.Size(4, 20);
            this.tboxFileName.Name = "tboxFileName";
            this.tboxFileName.Size = new System.Drawing.Size(267, 20);
            this.tboxFileName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tboxFileName, "Give the file name to save your locked content");
            this.tboxFileName.TextChanged += new System.EventHandler(this.TextboxFileNameTextChanged);
            this.tboxFileName.Leave += new System.EventHandler(this.TextBoxFileNameLeave);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowse.Location = new System.Drawing.Point(358, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 21);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(184, 375);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.Controls.Add(this.btnMain);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnAddPassword);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(112, 411);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(289, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.SystemColors.Control;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnMain.Location = new System.Drawing.Point(3, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(89, 23);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Ok";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.ButtonMainClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(98, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // btnAddPassword
            // 
            this.btnAddPassword.Location = new System.Drawing.Point(193, 3);
            this.btnAddPassword.Name = "btnAddPassword";
            this.btnAddPassword.Size = new System.Drawing.Size(89, 23);
            this.btnAddPassword.TabIndex = 3;
            this.btnAddPassword.Text = "Add Password";
            this.btnAddPassword.UseVisualStyleBackColor = true;
            this.btnAddPassword.Click += new System.EventHandler(this.ButtonAddPasswordClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.licensePanel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnCapture);
            this.groupBox2.Controls.Add(this.lockFormFaceView);
            this.groupBox2.Location = new System.Drawing.Point(8, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 242);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Face";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReset.Location = new System.Drawing.Point(262, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(71, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ButtonResetClick);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCapture.Location = new System.Drawing.Point(262, 94);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(71, 23);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "Capture Face";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.ButtonCaptureClick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "NLock Files|*.nlk";
            this.saveFileDialog.OverwritePrompt = false;
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            this.saveFileDialog.Title = "Save";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // filePathErrorProvider
            // 
            this.filePathErrorProvider.ContainerControl = this;
            // 
            // captureErrorProvider
            // 
            this.captureErrorProvider.ContainerControl = this;
            // 
            // licensePanel1
            // 
            this.licensePanel1.AutoSize = true;
            this.licensePanel1.Location = new System.Drawing.Point(3, 16);
            this.licensePanel1.Name = "licensePanel1";
            this.licensePanel1.OptionalComponents = "";
            this.licensePanel1.RequiredComponents = "Biometrics.FaceExtraction,Biometrics.FaceDetection,Devices.Cameras";
            this.licensePanel1.Size = new System.Drawing.Size(382, 52);
            this.licensePanel1.TabIndex = 8;
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 39);
            this.Name = "LockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NLock Locker - Face";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LockFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockFormFormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePathErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neurotec.Biometrics.Gui.NFaceView lockFormFaceView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private NLockFile.UI.LicensePanel licensePanel1;
        private System.Windows.Forms.ErrorProvider filePathErrorProvider;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnAddPassword;
        private System.Windows.Forms.ErrorProvider captureErrorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}