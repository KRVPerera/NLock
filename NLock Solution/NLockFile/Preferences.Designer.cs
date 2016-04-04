namespace NLock
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            this.tabControlPreferences = new System.Windows.Forms.TabControl();
            this.tabPageLockSettings = new System.Windows.Forms.TabPage();
            this.btnLockinPrefApply2 = new System.Windows.Forms.Button();
            this.cboxPwSkip = new System.Windows.Forms.CheckBox();
            this.btnLockinPrefSave = new System.Windows.Forms.Button();
            this.btnLockinPrefCancel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboxCmpressionLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCompressionPrefApply = new System.Windows.Forms.Button();
            this.btnCompressionPrefSave = new System.Windows.Forms.Button();
            this.btnCompressionPrefCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlPreferences.SuspendLayout();
            this.tabPageLockSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPreferences
            // 
            this.tabControlPreferences.Controls.Add(this.tabPageLockSettings);
            this.tabControlPreferences.Controls.Add(this.tabPage2);
            this.tabControlPreferences.Location = new System.Drawing.Point(12, 37);
            this.tabControlPreferences.Name = "tabControlPreferences";
            this.tabControlPreferences.SelectedIndex = 0;
            this.tabControlPreferences.Size = new System.Drawing.Size(422, 145);
            this.tabControlPreferences.TabIndex = 0;
            // 
            // tabPageLockSettings
            // 
            this.tabPageLockSettings.Controls.Add(this.btnLockinPrefApply2);
            this.tabPageLockSettings.Controls.Add(this.cboxPwSkip);
            this.tabPageLockSettings.Controls.Add(this.btnLockinPrefSave);
            this.tabPageLockSettings.Controls.Add(this.btnLockinPrefCancel);
            this.tabPageLockSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageLockSettings.Name = "tabPageLockSettings";
            this.tabPageLockSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLockSettings.Size = new System.Drawing.Size(414, 119);
            this.tabPageLockSettings.TabIndex = 0;
            this.tabPageLockSettings.Text = "Locking";
            this.tabPageLockSettings.UseVisualStyleBackColor = true;
            // 
            // btnLockinPrefApply2
            // 
            this.btnLockinPrefApply2.Location = new System.Drawing.Point(171, 90);
            this.btnLockinPrefApply2.Name = "btnLockinPrefApply2";
            this.btnLockinPrefApply2.Size = new System.Drawing.Size(75, 23);
            this.btnLockinPrefApply2.TabIndex = 4;
            this.btnLockinPrefApply2.Text = "Apply";
            this.btnLockinPrefApply2.UseVisualStyleBackColor = true;
            this.btnLockinPrefApply2.Click += new System.EventHandler(this.ButtonLockinPreferenceApplyClick);
            // 
            // cboxPwSkip
            // 
            this.cboxPwSkip.AutoSize = true;
            this.cboxPwSkip.Location = new System.Drawing.Point(59, 36);
            this.cboxPwSkip.Name = "cboxPwSkip";
            this.cboxPwSkip.Size = new System.Drawing.Size(169, 17);
            this.cboxPwSkip.TabIndex = 3;
            this.cboxPwSkip.Text = "Always skip password addition";
            this.cboxPwSkip.UseVisualStyleBackColor = true;
            // 
            // btnLockinPrefSave
            // 
            this.btnLockinPrefSave.Location = new System.Drawing.Point(252, 90);
            this.btnLockinPrefSave.Name = "btnLockinPrefSave";
            this.btnLockinPrefSave.Size = new System.Drawing.Size(75, 23);
            this.btnLockinPrefSave.TabIndex = 1;
            this.btnLockinPrefSave.Text = "Save";
            this.btnLockinPrefSave.UseVisualStyleBackColor = true;
            this.btnLockinPrefSave.Click += new System.EventHandler(this.ButtonLockinPreferencesSaveClick);
            // 
            // btnLockinPrefCancel
            // 
            this.btnLockinPrefCancel.Location = new System.Drawing.Point(333, 90);
            this.btnLockinPrefCancel.Name = "btnLockinPrefCancel";
            this.btnLockinPrefCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLockinPrefCancel.TabIndex = 0;
            this.btnLockinPrefCancel.Text = "Cancel";
            this.btnLockinPrefCancel.UseVisualStyleBackColor = true;
            this.btnLockinPrefCancel.Click += new System.EventHandler(this.ButtonLockinPreferencesCancelClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboxCmpressionLevel);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnCompressionPrefApply);
            this.tabPage2.Controls.Add(this.btnCompressionPrefSave);
            this.tabPage2.Controls.Add(this.btnCompressionPrefCancel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(414, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compression";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboxCmpressionLevel
            // 
            this.cboxCmpressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCmpressionLevel.FormattingEnabled = true;
            this.cboxCmpressionLevel.Items.AddRange(new object[] {
            "Optimal",
            "Fastest",
            "No Compression"});
            this.cboxCmpressionLevel.Location = new System.Drawing.Point(148, 34);
            this.cboxCmpressionLevel.Name = "cboxCmpressionLevel";
            this.cboxCmpressionLevel.Size = new System.Drawing.Size(246, 21);
            this.cboxCmpressionLevel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compression Level :";
            // 
            // btnCompressionPrefApply
            // 
            this.btnCompressionPrefApply.Location = new System.Drawing.Point(171, 90);
            this.btnCompressionPrefApply.Name = "btnCompressionPrefApply";
            this.btnCompressionPrefApply.Size = new System.Drawing.Size(75, 23);
            this.btnCompressionPrefApply.TabIndex = 2;
            this.btnCompressionPrefApply.Text = "Apply";
            this.btnCompressionPrefApply.UseVisualStyleBackColor = true;
            this.btnCompressionPrefApply.Click += new System.EventHandler(this.ButtonCompressionPreferenceApplyClick);
            // 
            // btnCompressionPrefSave
            // 
            this.btnCompressionPrefSave.Location = new System.Drawing.Point(252, 90);
            this.btnCompressionPrefSave.Name = "btnCompressionPrefSave";
            this.btnCompressionPrefSave.Size = new System.Drawing.Size(75, 23);
            this.btnCompressionPrefSave.TabIndex = 1;
            this.btnCompressionPrefSave.Text = "Save";
            this.btnCompressionPrefSave.UseVisualStyleBackColor = true;
            this.btnCompressionPrefSave.Click += new System.EventHandler(this.ButtonCompressionPreferenceSaveClick);
            // 
            // btnCompressionPrefCancel
            // 
            this.btnCompressionPrefCancel.Location = new System.Drawing.Point(333, 90);
            this.btnCompressionPrefCancel.Name = "btnCompressionPrefCancel";
            this.btnCompressionPrefCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCompressionPrefCancel.TabIndex = 0;
            this.btnCompressionPrefCancel.Text = "Cancel";
            this.btnCompressionPrefCancel.UseVisualStyleBackColor = true;
            this.btnCompressionPrefCancel.Click += new System.EventHandler(this.ButtonCompressionPreferenceCancelClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "NLock Preferences";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 189);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlPreferences);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesFormLoad);
            this.tabControlPreferences.ResumeLayout(false);
            this.tabPageLockSettings.ResumeLayout(false);
            this.tabPageLockSettings.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPreferences;
        private System.Windows.Forms.TabPage tabPageLockSettings;
        private System.Windows.Forms.Button btnLockinPrefCancel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLockinPrefSave;
        private System.Windows.Forms.Button btnCompressionPrefApply;
        private System.Windows.Forms.Button btnCompressionPrefSave;
        private System.Windows.Forms.Button btnCompressionPrefCancel;
        private System.Windows.Forms.ComboBox cboxCmpressionLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboxPwSkip;
        private System.Windows.Forms.Button btnLockinPrefApply2;
    }
}