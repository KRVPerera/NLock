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
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPassword = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filePathErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.licensePanel1 = new NLock.NLockFile.UI.LicensePanel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePathErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lockFormFaceView
            // 
            this.lockFormFaceView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lockFormFaceView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lockFormFaceView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lockFormFaceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lockFormFaceView.Face = null;
            this.lockFormFaceView.FaceIds = null;
            this.lockFormFaceView.FaceRectangleColor = System.Drawing.Color.Cyan;
            this.lockFormFaceView.Location = new System.Drawing.Point(0, 13);
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
            this.lockFormFaceView.Size = new System.Drawing.Size(311, 161);
            this.lockFormFaceView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File name";
            // 
            // tboxFileName
            // 
            this.tboxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tboxFileName.Location = new System.Drawing.Point(85, 12);
            this.tboxFileName.MinimumSize = new System.Drawing.Size(4, 20);
            this.tboxFileName.Name = "tboxFileName";
            this.tboxFileName.Size = new System.Drawing.Size(197, 20);
            this.tboxFileName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tboxFileName, "Give the file name to save your locked content");
            this.tboxFileName.TextChanged += new System.EventHandler(this.TextboxFileNameTextChanged);
            this.tboxFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TboxFileNameKeyDown);
            this.tboxFileName.Leave += new System.EventHandler(this.TextBoxFileNameLeave);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(301, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 21);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(14, 288);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(314, 29);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMain
            // 
            this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMain.BackColor = System.Drawing.SystemColors.Control;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnMain.Location = new System.Drawing.Point(34, 320);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(94, 23);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Ok";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.ButtonMainClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(134, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // btnAddPassword
            // 
            this.btnAddPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPassword.Location = new System.Drawing.Point(234, 320);
            this.btnAddPassword.Name = "btnAddPassword";
            this.btnAddPassword.Size = new System.Drawing.Size(94, 23);
            this.btnAddPassword.TabIndex = 3;
            this.btnAddPassword.Text = "Add Password";
            this.btnAddPassword.UseVisualStyleBackColor = true;
            this.btnAddPassword.Click += new System.EventHandler(this.ButtonAddPasswordClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lockFormFaceView);
            this.groupBox2.Location = new System.Drawing.Point(17, 85);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(311, 174);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Face";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(254, 265);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ButtonResetClick);
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
            // licensePanel1
            // 
            this.licensePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licensePanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.licensePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.licensePanel1.Location = new System.Drawing.Point(17, 38);
            this.licensePanel1.Name = "licensePanel1";
            this.licensePanel1.OptionalComponents = "";
            this.licensePanel1.RequiredComponents = "Biometrics.FaceExtraction,Biometrics.FaceDetection,Devices.Cameras";
            this.licensePanel1.Size = new System.Drawing.Size(311, 47);
            this.licensePanel1.TabIndex = 8;
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(340, 351);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.licensePanel1);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPassword);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tboxFileName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 311);
            this.Name = "LockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NLock Locker - Face";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LockFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockFormFormClosed);
            this.Load += new System.EventHandler(this.LoginFormLoad);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filePathErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Neurotec.Biometrics.Gui.NFaceView lockFormFaceView;
		private System.Windows.Forms.Button btnMain;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tboxFileName;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ErrorProvider filePathErrorProvider;
		private System.Windows.Forms.Button btnAddPassword;
		private NLockFile.UI.LicensePanel licensePanel1;
	}
}