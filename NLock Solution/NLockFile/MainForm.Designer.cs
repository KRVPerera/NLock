

namespace NLock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripFileCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripTopMenu = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbAddFile = new System.Windows.Forms.ToolStripButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveItem = new System.Windows.Forms.ToolStripButton();
            this.tsbLock = new System.Windows.Forms.ToolStripButton();
            this.tsbExtract = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbPreferences = new System.Windows.Forms.ToolStripButton();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStripBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStripTopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "nlk";
            this.saveFileDialog.Filter = "NLock Files|*.nlk";
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripFileCountLabel,
            this.tssStatus});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 450);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(455, 22);
            this.statusStripBottom.TabIndex = 10;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel2.Text = "Files :";
            // 
            // toolStripFileCountLabel
            // 
            this.toolStripFileCountLabel.Name = "toolStripFileCountLabel";
            this.toolStripFileCountLabel.Size = new System.Drawing.Size(95, 17);
            this.toolStripFileCountLabel.Text = "tsFileCountLabel";
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(53, 17);
            this.tssStatus.Text = "tssStatus";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilelistView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.870842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.12916F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 450);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toolStripTopMenu);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 29);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // toolStripTopMenu
            // 
            this.toolStripTopMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTopMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbAddFile,
            this.tsbAddFolder,
            this.tsbRemoveItem,
            this.tsbLock,
            this.tsbExtract,
            this.tsbAbout,
            this.tsbPreferences});
            this.toolStripTopMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripTopMenu.MaximumSize = new System.Drawing.Size(0, 27);
            this.toolStripTopMenu.MinimumSize = new System.Drawing.Size(0, 27);
            this.toolStripTopMenu.Name = "toolStripTopMenu";
            this.toolStripTopMenu.Size = new System.Drawing.Size(449, 27);
            this.toolStripTopMenu.TabIndex = 12;
            this.toolStripTopMenu.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(60, 24);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.ToolTipText = "Open a NLock file";
            this.tsbOpen.Click += new System.EventHandler(this.ToolstripButtonOpenClick);
            // 
            // tsbAddFile
            // 
            this.tsbAddFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFile.Image")));
            this.tsbAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddFile.Name = "tsbAddFile";
            this.tsbAddFile.Size = new System.Drawing.Size(74, 24);
            this.tsbAddFile.Text = "Add File";
            this.tsbAddFile.ToolTipText = "Add Files";
            this.tsbAddFile.Click += new System.EventHandler(this.ToolstripButtonAddFileClick);
            // 
            // tsbAddFolder
            // 
            this.tsbAddFolder.AutoSize = false;
            this.tsbAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFolder.Image")));
            this.tsbAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddFolder.Name = "tsbAddFolder";
            this.tsbAddFolder.Size = new System.Drawing.Size(89, 24);
            this.tsbAddFolder.Text = "Add Folder";
            this.tsbAddFolder.ToolTipText = "Add Folder recursively";
            this.tsbAddFolder.Click += new System.EventHandler(this.ToolstrioButtonAddFolderClick);
            // 
            // tsbRemoveItem
            // 
            this.tsbRemoveItem.AutoSize = false;
            this.tsbRemoveItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveItem.Image")));
            this.tsbRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveItem.Name = "tsbRemoveItem";
            this.tsbRemoveItem.Size = new System.Drawing.Size(74, 24);
            this.tsbRemoveItem.Text = "Remove";
            this.tsbRemoveItem.Click += new System.EventHandler(this.ToolstripButtonRemoveItemClick);
            // 
            // tsbLock
            // 
            this.tsbLock.AutoSize = false;
            this.tsbLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbLock.Image")));
            this.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLock.Name = "tsbLock";
            this.tsbLock.Size = new System.Drawing.Size(56, 24);
            this.tsbLock.Text = "Lock";
            this.tsbLock.ToolTipText = "Lock and Save";
            this.tsbLock.Click += new System.EventHandler(this.ToolstrioButtonLockClick);
            // 
            // tsbExtract
            // 
            this.tsbExtract.AutoSize = false;
            this.tsbExtract.Image = ((System.Drawing.Image)(resources.GetObject("tsbExtract.Image")));
            this.tsbExtract.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtract.Name = "tsbExtract";
            this.tsbExtract.Size = new System.Drawing.Size(66, 24);
            this.tsbExtract.Text = "Extract";
            this.tsbExtract.ToolTipText = "Extract a locked file to a given path";
            this.tsbExtract.Click += new System.EventHandler(this.ToolstripButtonUnlockCick);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::NLock.Properties.Resources.Question_32xLG;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(64, 24);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.ToolstripButtonAboutClick);
            // 
            // tsbPreferences
            // 
            this.tsbPreferences.Image = global::NLock.Properties.Resources.Settings_32xMD;
            this.tsbPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreferences.Name = "tsbPreferences";
            this.tsbPreferences.Size = new System.Drawing.Size(92, 24);
            this.tsbPreferences.Text = "Preferences";
            this.tsbPreferences.Click += new System.EventHandler(this.ToolstripButtonPreferencesClick);
            // 
            // FilelistView
            // 
            this.FilelistView.AllowDrop = true;
            this.FilelistView.AutoArrange = false;
            this.FilelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.columnHeader2,
            this.columnHeader3,
            this.path});
            this.FilelistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilelistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilelistView.FullRowSelect = true;
            this.FilelistView.GridLines = true;
            this.FilelistView.Location = new System.Drawing.Point(3, 29);
            this.FilelistView.MinimumSize = new System.Drawing.Size(4, 75);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(449, 418);
            this.FilelistView.TabIndex = 0;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.View = System.Windows.Forms.View.Details;
            this.FilelistView.VirtualListSize = 20;
            this.FilelistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FilelistViewColumnClick);
            this.FilelistView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilelistView_DragDrop);
            this.FilelistView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilelistViewDragEnter);
            // 
            // chFileName
            // 
            this.chFileName.Text = "File Name";
            this.chFileName.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Compressed";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 111;
            // 
            // path
            // 
            this.path.Text = "Path";
            this.path.Width = 99;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStripBottom);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(16, 92);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nlock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStripTopMenu.ResumeLayout(false);
            this.toolStripTopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripFileCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStripTopMenu;
        private System.Windows.Forms.ToolStripButton tsbAddFile;
        private System.Windows.Forms.ToolStripButton tsbAddFolder;
        private System.Windows.Forms.ToolStripButton tsbRemoveItem;
        private System.Windows.Forms.ToolStripButton tsbLock;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbExtract;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbPreferences;
    }
}