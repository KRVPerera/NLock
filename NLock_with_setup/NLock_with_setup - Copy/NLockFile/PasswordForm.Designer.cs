namespace NLock
{
    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            this.tboxEnterPW = new System.Windows.Forms.TextBox();
            this.tboxReenterPW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboxSkipSettings = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pwErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rpwMatchErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pwErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpwMatchErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxEnterPW
            // 
            this.tboxEnterPW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxEnterPW.Location = new System.Drawing.Point(114, 97);
            this.tboxEnterPW.Name = "tboxEnterPW";
            this.tboxEnterPW.PasswordChar = '*';
            this.tboxEnterPW.Size = new System.Drawing.Size(198, 20);
            this.tboxEnterPW.TabIndex = 0;
            this.tboxEnterPW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextboxEnterPWKeyUp);
            // 
            // tboxReenterPW
            // 
            this.tboxReenterPW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxReenterPW.Location = new System.Drawing.Point(114, 126);
            this.tboxReenterPW.Name = "tboxReenterPW";
            this.tboxReenterPW.PasswordChar = '*';
            this.tboxReenterPW.Size = new System.Drawing.Size(198, 20);
            this.tboxReenterPW.TabIndex = 1;
            this.tboxReenterPW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextboxReenterPWKeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reenter password :";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 57);
            this.label3.TabIndex = 2;
            this.label3.Text = "     Adding a password will make it available for you to unlock this file again i" +
    "n the future using only the password. Consider this as a fall back option when y" +
    "our camera not working properly";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recommended";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(156, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(237, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // cboxSkipSettings
            // 
            this.cboxSkipSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxSkipSettings.AutoSize = true;
            this.cboxSkipSettings.Location = new System.Drawing.Point(12, 168);
            this.cboxSkipSettings.Name = "cboxSkipSettings";
            this.cboxSkipSettings.Size = new System.Drawing.Size(141, 17);
            this.cboxSkipSettings.TabIndex = 6;
            this.cboxSkipSettings.Text = "Never show this window";
            this.cboxSkipSettings.UseVisualStyleBackColor = true;
            // 
            // pwErrorProvider
            // 
            this.pwErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.pwErrorProvider.ContainerControl = this;
            // 
            // rpwMatchErrorProvider
            // 
            this.rpwMatchErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.rpwMatchErrorProvider.ContainerControl = this;
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 197);
            this.ControlBox = false;
            this.Controls.Add(this.tboxEnterPW);
            this.Controls.Add(this.tboxReenterPW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxSkipSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 236);
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockFormPW_FormClosed);
            this.Load += new System.EventHandler(this.LockFormPW_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pwErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpwMatchErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxEnterPW;
        private System.Windows.Forms.TextBox tboxReenterPW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cboxSkipSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider pwErrorProvider;
        private System.Windows.Forms.ErrorProvider rpwMatchErrorProvider;
    }
}