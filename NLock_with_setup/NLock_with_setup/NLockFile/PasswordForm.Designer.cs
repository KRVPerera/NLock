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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.cboxSkipSettings = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pwErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.rpwMatchErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pwErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rpwMatchErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// tboxEnterPW
			// 
			this.tboxEnterPW.Location = new System.Drawing.Point(112, 3);
			this.tboxEnterPW.Name = "tboxEnterPW";
			this.tboxEnterPW.PasswordChar = '*';
			this.tboxEnterPW.Size = new System.Drawing.Size(194, 20);
			this.tboxEnterPW.TabIndex = 0;
			this.tboxEnterPW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextboxEnterPWKeyUp);
			// 
			// tboxReenterPW
			// 
			this.tboxReenterPW.Location = new System.Drawing.Point(112, 30);
			this.tboxReenterPW.Name = "tboxReenterPW";
			this.tboxReenterPW.PasswordChar = '*';
			this.tboxReenterPW.Size = new System.Drawing.Size(194, 20);
			this.tboxReenterPW.TabIndex = 1;
			this.tboxReenterPW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextboxReenterPWKeyUp);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.65079F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.34921F));
			this.tableLayoutPanel1.Controls.Add(this.tboxReenterPW, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tboxEnterPW, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 80);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 55);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Enter password :";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Reenter password :";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(316, 64);
			this.label3.TabIndex = 2;
			this.label3.Text = "     Adding a password will make it available for you to unlock this file again i" +
    "n the future using only the password. Consider this as a fall back option when y" +
    "our camera not working properly";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.791209F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.20879F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(332, 183);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(326, 65);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Recommended";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Controls.Add(this.btnOk);
			this.flowLayoutPanel1.Controls.Add(this.cboxSkipSettings);
			this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 143);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(326, 33);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(248, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(167, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// cboxSkipSettings
			// 
			this.cboxSkipSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cboxSkipSettings.AutoSize = true;
			this.cboxSkipSettings.Location = new System.Drawing.Point(20, 6);
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
			this.ClientSize = new System.Drawing.Size(336, 173);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PasswordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Password";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockFormPW_FormClosed);
			this.Load += new System.EventHandler(this.LockFormPW_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pwErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rpwMatchErrorProvider)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tboxEnterPW;
        private System.Windows.Forms.TextBox tboxReenterPW;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cboxSkipSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider pwErrorProvider;
        private System.Windows.Forms.ErrorProvider rpwMatchErrorProvider;
    }
}