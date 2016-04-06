

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripFileCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.contextMenuStripFileList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripBottom.SuspendLayout();
            this.toolStripTopMenu.SuspendLayout();
            this.contextMenuStripFileList.SuspendLayout();
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
            this.statusStripBottom.Location = new System.Drawing.Point(0, 472);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(451, 22);
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
            // toolStripTopMenu
            // 
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
            this.toolStripTopMenu.Size = new System.Drawing.Size(451, 27);
            this.toolStripTopMenu.TabIndex = 0;
            this.toolStripTopMenu.TabStop = true;
            this.toolStripTopMenu.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(60, 24);
            this.tsbOpen.Text = "&Open";
            this.tsbOpen.ToolTipText = "Open a NLock file";
            this.tsbOpen.Click += new System.EventHandler(this.ToolstripButtonOpenClick);
            // 
            // tsbAddFile
            // 
            this.tsbAddFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFile.Image")));
            this.tsbAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddFile.Name = "tsbAddFile";
            this.tsbAddFile.Size = new System.Drawing.Size(74, 24);
            this.tsbAddFile.Text = "&Add File";
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
            this.tsbRemoveItem.Text = "&Remove";
            this.tsbRemoveItem.Click += new System.EventHandler(this.ToolstripButtonRemoveItemClick);
            // 
            // tsbLock
            // 
            this.tsbLock.AutoSize = false;
            this.tsbLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbLock.Image")));
            this.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLock.Name = "tsbLock";
            this.tsbLock.Size = new System.Drawing.Size(56, 24);
            this.tsbLock.Text = "&Lock";
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
            this.tsbExtract.Text = "&Extract";
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
            this.tsbPreferences.Text = "&Preferences";
            this.tsbPreferences.Click += new System.EventHandler(this.ToolstripButtonPreferencesClick);
            // 
            // FilelistView
            // 
            this.FilelistView.AllowDrop = true;
            this.FilelistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilelistView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.columnHeader2,
            this.columnHeader3,
            this.path});
            this.FilelistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilelistView.FullRowSelect = true;
            this.FilelistView.Location = new System.Drawing.Point(1, 27);
            this.FilelistView.MinimumSize = new System.Drawing.Size(4, 75);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(450, 442);
            this.FilelistView.TabIndex = 0;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.View = System.Windows.Forms.View.Details;
            this.FilelistView.VirtualListSize = 20;
            this.FilelistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FilelistViewColumnClick);
            this.FilelistView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilelistViewDragDrop);
            this.FilelistView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilelistViewDragEnter);
            this.FilelistView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilelistViewKeyDown);
            this.FilelistView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FilelistView_MouseDown);
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
            this.columnHeader2.Width = 72;
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
            this.path.Width = 100;
            // 
            // contextMenuStripFileList
            // 
            this.contextMenuStripFileList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.removeItemToolStripMenuItem,
            this.replaceFileToolStripMenuItem,
            this.removeSelectedItemsToolStripMenuItem});
            this.contextMenuStripFileList.Name = "contextMenuStripFileList";
            this.contextMenuStripFileList.Size = new System.Drawing.Size(164, 98);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.refreshToolStripMenuItem1,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.itemsToolStripMenuItem.Text = "Files";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItemClick);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.FolderToolStripMenuItemClick);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.invertSelectionToolStripMenuItem.Text = "Invert Selection";
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.InvertSelectionToolStripMenuItemClick);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(160, 6);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeItemToolStripMenuItem.Text = "Remove file";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.RemoveItemToolStripMenuItemClick);
            // 
            // replaceFileToolStripMenuItem
            // 
            this.replaceFileToolStripMenuItem.Name = "replaceFileToolStripMenuItem";
            this.replaceFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.replaceFileToolStripMenuItem.Text = "Replace file";
            this.replaceFileToolStripMenuItem.Click += new System.EventHandler(this.ReplaceFileToolStripMenuItemClick);
            // 
            // removeSelectedItemsToolStripMenuItem
            // 
            this.removeSelectedItemsToolStripMenuItem.Name = "removeSelectedItemsToolStripMenuItem";
            this.removeSelectedItemsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeSelectedItemsToolStripMenuItem.Text = "Remove selected";
            this.removeSelectedItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectedItemsToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(451, 494);
            this.Controls.Add(this.toolStripTopMenu);
            this.Controls.Add(this.FilelistView);
            this.Controls.Add(this.statusStripBottom);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(185, 167);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nlock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.toolStripTopMenu.ResumeLayout(false);
            this.toolStripTopMenu.PerformLayout();
            this.contextMenuStripFileList.ResumeLayout(false);
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
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileList;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem replaceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedItemsToolStripMenuItem;
    }
}