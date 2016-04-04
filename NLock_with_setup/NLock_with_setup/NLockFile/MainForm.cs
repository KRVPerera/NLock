using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using NLock.NLockFile;
using NLock.NLockFile.Util;
using NLock.Properties;

namespace NLock
{
    public partial class MainForm : Form
    {
        #region Public constructors

        public MainForm(OperationModes mode, string file = null)
        {
            XmlConfigurator.Configure();
            _opMode = mode;
            _fileName = file;
            InitializeComponent();
        }

        #endregion Public constructors

        #region Private variables

        private static readonly ILog Logger = LogManager.GetLogger(typeof (MainForm));
        private NLockContainerCommons _nlockContainer;
        private string _fileName;
        private readonly OperationModes _opMode;
        private string _oldFolderSelectedPath;
        private Status _status;
        private bool _isDirty;
        private bool _saved;
        private int _sortColumn = -1;

        #endregion Private variables

        #region Private Methods

        private void InitializeForm()
        {
            Text = @"NLock";
            tsbLock.Enabled = false;
            tsbExtract.Enabled = false;
            saveFileDialog.FileName = string.Empty;
            saveFileDialog.InitialDirectory = string.Empty;
            openFileDialog.Multiselect = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = Resources.AddToNLock;
            openFileDialog.RestoreDirectory = true;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = Resources.Warnning;
            toolStripFileCountLabel.Text = string.Empty;
            tssStatus.Text = string.Empty;
        }

        private void UpdateListView(IReadOnlyCollection<NlFile> list)
        {
            if (list == null)
            {
                tsbLock.Enabled = false;
                toolStripFileCountLabel.Text = FilelistView.Items.Count.ToString();
                return;
            }
            if (list.Count <= 0)
            {
                tsbLock.Enabled = false;
                FilelistView.Items.Clear();
                toolStripFileCountLabel.Text = FilelistView.Items.Count.ToString();
                return;
            }
            FilelistView.BeginUpdate();

            try
            {
                FilelistView.Items.Clear();

                //TODO: add image icon to file list
                foreach (var key in list)
                {
                    var item = new ListViewItem(Path.GetFileName(key.FileName));
                    var type = " B";
                    double original = key.OriginalSize;
                    double compressed = key.CompressedSize;
                    if (key.OriginalSize > 1024)
                    {
                        original = key.OriginalSize/1024.0;
                        compressed = key.CompressedSize/1024.0;
                        type = "KiB";
                    }

                    if (key.OriginalSize > 1024*1024)
                    {
                        original = original/1024;
                        compressed = compressed/1024;
                        type = "MiB";
                    }

                    if (key.OriginalSize > 1024*1024*1024)
                    {
                        original = original/1024;
                        compressed = compressed/1024;
                        type = "GiB";
                    }

                    item.SubItems.Add(string.Format("{0:N2} {1}", original, type));
                    item.SubItems.Add(string.Format("{0:N2} {1}", compressed, type));

                    item.SubItems.Add(key.FilePath != null ? key.FilePath + "\\" : "\\");
                    FilelistView.Items.Add(item);

                    tsbLock.Enabled = FilelistView.Items.Count > 0;
                }
            }
            finally
            {
                FilelistView.EndUpdate();
                toolStripFileCountLabel.Text = FilelistView.Items.Count.ToString();
            }
        }

        private void Extract()
        {
            _status = Status.Extractionfailed;
            try
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var extractionFolderPath = string.Concat(folderBrowserDialog.SelectedPath, "\\");
                    if (_nlockContainer.ExtractToFolder(extractionFolderPath))
                    {
                        _status = Status.Sucessfullyextracted;
                        _nlockContainer.Dispose();
                        _nlockContainer = null;
                    }
                    _oldFolderSelectedPath = extractionFolderPath;
                }
                else // result == DialogResult.Cancel
                {
                    _status = Status.Extractioncancelled;
                }
                folderBrowserDialog.SelectedPath = _oldFolderSelectedPath;
            }
            catch (Exception)
            {
                _status = Status.Extractionfailed;
            }
        }

        #endregion Private Methods

        #region Private Form Events

        private void MainFormLoad(object sender, EventArgs e)
        {
            InitializeForm();
            Logger.Debug("---------------(----------- Starting NLock -----------)-----------------------");

            _nlockContainer = new NLockContainerCommons();

            if (_opMode == OperationModes.Opennlock)
            {
                Logger.Debug("Open NLock Operation");
                if (_fileName != null)
                {
                    try
                    {
                        Text = Resources.NLock + _fileName;
                        _nlockContainer.LoadFromFile(_fileName);
                        UpdateListView(_nlockContainer.GetFileList());
                        tsbLock.Enabled = true;
                        tsbExtract.Enabled = true;
                        Focus();
                    }
                    catch (Exception)
                    {
                        using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                        {
                            MessageBox.Show(Resources.OpeningFile, Resources.Alert, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(Resources.InvalidFile, Resources.Alert, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Logger.Info("OperationModes.OPENNLOCK Null File Name");
                    Close();
                }
            }
            else if (_opMode == OperationModes.Unlockhere)
            {
                Logger.Debug("Unlock here Operation");
                if (_fileName != null)
                {
                    try
                    {
                        _nlockContainer.LoadFromFile(_fileName);

                        var currentPath = string.Concat(Path.GetDirectoryName(_fileName), "\\");
                        DialogResult result;
                        if (_nlockContainer.ExtractToFolder(currentPath))
                        {
                            using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                            {
                                result = MessageBox.Show(form,
                                    Resources.SuccessExtractedTo + currentPath + "\n" + Resources.ExitQ,
                                    Resources.Unlocking,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                            {
                                result = MessageBox.Show(form,
                                    Resources.FailedExtractTo + currentPath + "\n" + Resources.ExitQ,
                                    Resources.UnlockingFailed,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            }
                        }

                        if (result == DialogResult.Yes)
                        {
                            Close();
                        }
                        else
                        {
                            Focus();
                            tsbExtract.Enabled = true;
                            folderBrowserDialog.SelectedPath = currentPath;
                            UpdateListView(_nlockContainer.GetFileList());
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show(Resources.InvalidUser, Resources.Alert, MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Resources.UnlockingFailed, Resources.Alert, MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    Logger.Info("OperationModes.UNLOCKHERE Null File Name");
                }
            }
            else if (_opMode == OperationModes.Unlockto)
            {
                Logger.Debug("Unlock to Operation");
                if (_fileName != null)
                {
                    try
                    {
                        _nlockContainer.LoadFromFile(_fileName);
                        tsbExtract.Enabled = true;
                        var unlockingPath = string.Concat(Path.GetDirectoryName(_fileName), "\\");
                        folderBrowserDialog.SelectedPath = unlockingPath;
                        Extract();

                        var result = DialogResult.None;

                        if (_status == Status.Sucessfullyextracted)
                        {
                            tsbExtract.Enabled = false;
                            using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                            {
                                result = MessageBox.Show(form,
                                    Resources.SuccessExtractedTo + unlockingPath + "\n" + Resources.ExitQ,
                                    Resources.Unlocking,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                        }
                        else if (_status == Status.Extractionfailed)
                        {
                            using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                            {
                                result = MessageBox.Show(form, Resources.Failed + "\n" + Resources.ExitQ,
                                    Resources.Unlocking,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            }
                        }
                        else // status == Status.EXTRACTIONCANCELLED)
                        {
                            Close();
                        }

                        if (result == DialogResult.Yes)
                        {
                            Close();
                        }
                        else // result == DialogResult.No
                        {
                            Focus();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                        {
                            MessageBox.Show(form, Resources.InvalidUser, Resources.Alert, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                    }
                    catch (Exception)
                    {
                        using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                        {
                            MessageBox.Show(Resources.UnlockingFailed, Resources.Alert, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    Logger.Info("OperationModes.UNLOCKTO Null File Name");
                }
            }
            else if (_opMode == OperationModes.Lockfolder)
            {
                try
                {
                    Logger.Debug("Lock folder Operation");
                    if (_fileName != null)
                    {
                        Logger.Debug("File name : " + _fileName);
                        var copiedName = _fileName;
                        _nlockContainer.AddDirectory(_fileName, true);
                        UpdateListView(_nlockContainer.GetFileList());
                        tsbLock.Enabled = true;
                        saveFileDialog.InitialDirectory = Path.GetDirectoryName(_fileName);
                        Logger.Debug("Perform button lock");
                        tsbLock.PerformClick();

                        if (_saved)
                        {
                            using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                            {
                                var result = MessageBox.Show(form,
                                    Resources.SuccessfullyLockedFilesTo + copiedName + "\n" + Resources.ExitQ,
                                    Resources.Successful,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                                if (result == DialogResult.Yes)
                                {
                                    Close();
                                }
                            }
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        Logger.Info("OperationModes.LOCKFOLDER Null File Name");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(Resources.EmptyFolderNoFilesAdded, Resources.Failed, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else // _opMode == OperationModes.NLOCKTHISFILE
            {
                Logger.Debug(" Lock NLock this file Operation");
                if (_fileName != null)
                {
                    Logger.Debug("File name : " + _fileName);
                    _nlockContainer.AddFile(_fileName);
                    UpdateListView(_nlockContainer.GetFileList());

                    Logger.Debug("Perform button lock");
                    tsbLock.Enabled = true;
                    tsbLock.PerformClick();

                    using (var form = new Form {WindowState = FormWindowState.Maximized, TopMost = true})
                    {
                        var result = MessageBox.Show(form, Resources.WantToExitNLock, Resources.Locking,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        saveFileDialog.InitialDirectory = Path.GetDirectoryName(_fileName);

                        if (result == DialogResult.Yes)
                        {
                            Close();
                        }
                        else // result == DialogResult.No
                        {
                            InitializeForm();
                        }
                    }
                }
                else
                {
                    Logger.Info("OperationModes.NLOCKTHISFILE Null File Name");
                }
            }
        }

        public void AddThisFiletoNLock(string fileName)
        {
            _nlockContainer.AddFile(fileName);
            UpdateListView(_nlockContainer.GetFileList());
        }

        private void DragAdd(IEnumerable<string> files)
        {
            if (_nlockContainer == null)
            {
                _nlockContainer = new NLockContainerCommons();
            }

            foreach (var file in files)
            {
                Logger.Debug("File dragged : " + file);
                _nlockContainer.AddFile(file);
                UpdateListView(_nlockContainer.GetFileList());
            }
        }

        private void FilelistViewDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void FilelistViewDragDrop(object sender, DragEventArgs e)
        {
            var filepaths = new List<string>();
            foreach (var s in (string[]) e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    _nlockContainer.AddDirectory(s, true);
                    UpdateListView(_nlockContainer.GetFileList());
                }
                else
                {
                    filepaths.Add(s);
                }
            }

            DragAdd(filepaths);
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_nlockContainer != null)
            {
                _nlockContainer.Dispose();
            }
            _nlockContainer = null;
        }

        private void ToolstripButtonOpenClick(object sender, EventArgs e)
        {
            tssStatus.ForeColor = Color.Blue;
            tssStatus.Text = Resources.Opening___;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilelistView.Items.Clear();
                    Text = Resources.NLock;
                    toolStripFileCountLabel.Text = string.Empty;
                    tssStatus.ForeColor = Color.Blue;
                    tssStatus.Text = Resources.Unlocking___;
                    if (NLockTemplateOperations.IsNLock(openFileDialog.FileName) > 0)
                    {
                        if (_nlockContainer != null)
                        {
                            _nlockContainer.Dispose();
                        }
                        _nlockContainer = new NLockContainerCommons();
                        _isDirty = false;
                        _fileName = openFileDialog.FileName;

                        _nlockContainer.LoadFromFile(_fileName);
                        if (!_nlockContainer.IsLocked)
                        {
                            Text = Resources.NLock + _fileName;
                            UpdateListView(_nlockContainer.GetFileList());

                            tsbExtract.Enabled = true;

                            tssStatus.ForeColor = Color.Green;
                            tssStatus.Text = Resources.UnlockedUserIdentified;
                        }
                        else
                        {
                            _fileName = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            Resources.FileCorrupted + Path.GetFileName(openFileDialog.FileName),
                            Resources.FileOpeningFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tssStatus.ForeColor = Color.Red;
                        tssStatus.Text = Resources.Unlocking___ + Resources.Failed;
                    }
                }
                else
                {
                    tssStatus.ForeColor = Color.Blue;
                    tssStatus.Text = Resources.Canceled___;
                }
            }
            catch (Exception)
            {
                _fileName = null;
                tssStatus.ForeColor = Color.Red;
                tssStatus.Text = Resources.UnlockingFailed;
                Logger.Info("Unlocking... Failed");
            }
        }

        private void ToolstripButtonAddFileClick(object sender, EventArgs e)
        {
            tssStatus.Text = string.Empty;

            if (Text != Resources.NLock)
            {
                Text = Resources.NLock;
            }
            if (_nlockContainer == null)
            {
                _nlockContainer = new NLockContainerCommons();
            }

            try
            {
                Logger.Debug("Add");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        _nlockContainer.AddFile(file);
                    }
                    tsbLock.Enabled = true;
                    if (_fileName != null)
                    {
                        _isDirty = true;
                    }
                    UpdateListView(_nlockContainer.GetFileList());
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(Resources.Out_of_memory, Resources.Not_enough_memory, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("OutOfMemoryException");
            }
        }

        private void ToolstrioButtonAddFolderClick(object sender, EventArgs e)
        {
            //TODO: Validate file names or foldernames to not to have "######s"
            Logger.Debug("btnAddFolder_Click");
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    Logger.Debug("Add folder selected path : " + folderBrowserDialog.SelectedPath);

                    _nlockContainer.AddDirectory(folderBrowserDialog.SelectedPath, true);
                    UpdateListView(_nlockContainer.GetFileList());
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(Resources.EmptyFolderNoFilesAdded, Resources.Failed, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Logger.Error(Resources.EmptyFolderNoFilesAdded);
            }
        }

        private void ToolstrioButtonLockClick(object sender, EventArgs e)
        {
            tssStatus.ForeColor = Color.Blue;
            tssStatus.Text = Resources.Locking___;

            if (FilelistView.Items.Count > 0)
            {
                using (var lockForm = new LockForm())
                {
                    lockForm.ShowDialog();
                    var result = lockForm.DialogResult;
                    if (result == DialogResult.OK)
                    {
                        _nlockContainer.Template = lockForm.TemplateLoginForm;

                        if (lockForm.AddPassword)
                        {
                            _nlockContainer.TemplateOperations = new NLockTemplateOperationsCommon();
                            _nlockContainer.Password = lockForm.Password;
                            _nlockContainer.AddPassword = true;
                        }
                        else
                        {
                            _nlockContainer.AddPassword = false;
                            _nlockContainer.Password = null;
                        }

                        _nlockContainer.Lock();
                        if (!lockForm.SaveFileName.EndsWith(".nlk"))
                        {
                            lockForm.SaveFileName = lockForm.SaveFileName + ".nlk";
                        }
                        var status = _nlockContainer.Save(lockForm.SaveFileName);
                        if (status == NLockContainerCommons.ContainerStatus.Empty)
                        {
                            MessageBox.Show(Resources.EmptyContainer, Resources.Locking,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Logger.Error("Failed...No files added. Empty container");
                        }
                        else if (status == NLockContainerCommons.ContainerStatus.NullTemplate)
                        {
                            MessageBox.Show(Resources.BadFaceCaptured, Resources.Locking,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Logger.Error("Failed...Bad image captured");
                        }
                        else
                        {
                            FilelistView.Items.Clear();
                            tsbLock.Enabled = false;
                            tsbExtract.Enabled = false;
                            tssStatus.ForeColor = Color.Green;
                            tssStatus.Text = Resources.Locking_Successful___;
                            _saved = true;
                            Text = Resources.NLock;
                            _fileName = null;
                            _isDirty = false;
                            toolStripFileCountLabel.Text = string.Empty;

                            _nlockContainer = null;
                        }
                    }
                    else // result == DialogResult.Cancel
                    {
                        tssStatus.ForeColor = Color.Red;
                        tssStatus.Text = Resources.Locking_Canceled___;
                    }
                }
            }
        }

        private void ToolstripButtonUnlockCick(object sender, EventArgs e)
        {
            Extract();
            if (_status == Status.Sucessfullyextracted)
            {
                tsbExtract.Enabled = false;
                MessageBox.Show(Resources.Successful___, Resources.Extraction_is, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_status == Status.Extractionfailed)
            {
                MessageBox.Show(Resources.Failed___, Resources.Extraction_is, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // status == Status.EXTRACTIONCANCELLED
            {
                tssStatus.ForeColor = Color.Blue;
                tssStatus.Text = Resources.Canceled___;
            }
        }

        private void ToolstripButtonRemoveItemClick(object sender, EventArgs e)
        {
            try
            {
                foreach (var file in FilelistView.SelectedItems)
                {
                    var item = (ListViewItem) file;
                    var tet = item.SubItems[0].Text;
                    var result = _nlockContainer.RemoveFile(tet);
                    if ((_fileName != null) && !_isDirty && result)
                    {
                        _isDirty = true;
                    }
                }
                if (FilelistView.Items.Count > 0)
                {
                    UpdateListView(_nlockContainer.GetFileList());
                }
                else
                {
                    toolStripFileCountLabel.Text = "0";
                    _nlockContainer = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.An_error_occurred + ex, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty && (_fileName != null))
            {
                var result = MessageBox.Show(Resources.Lock_file___, Resources.File_is_changed, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    tsbLock.PerformClick();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void ToolstripButtonAboutClick(object sender, EventArgs e)
        {
            using (var aboutfrom = new AboutForm())
            {
                aboutfrom.ShowDialog();
            }
        }

        private void ToolstripButtonPreferencesClick(object sender, EventArgs e)
        {
            using (var pref = new PreferencesForm())
            {
                pref.ShowDialog();
            }
        }

        /// <summary>
        ///     ref : https://msdn.microsoft.com/en-us/library/ms996467.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilelistViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != _sortColumn)
            {
                // Set the sort column to the new column.
                _sortColumn = e.Column;
                // Set the sort order to ascending by default.
                FilelistView.Sorting = SortOrder.Ascending;
            }
            else
            {
                FilelistView.Sorting = FilelistView.Sorting == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }

            FilelistView.Sort();
            FilelistView.ListViewItemSorter = new ListViewItemComparer(e.Column,
                FilelistView.Sorting);
        }

        #endregion Private Form Events
    }

    internal class ListViewItemComparer : IComparer
    {
        public ListViewItemComparer()
        {
            Col = 0;
            Order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            Col = column;
            Order = order;
        }

        public int Col { get; }

        public SortOrder Order { get; }

        public int Compare(object x, object y)
        {
            var returnVal = -1;

            if (Col == 1 || Col == 2)
            {
                double xVal;
                var xY = double.TryParse(((ListViewItem) x).SubItems[Col].Text.Split()[0], out xVal);
                double yVal;
                var yY = double.TryParse(((ListViewItem) y).SubItems[Col].Text.Split()[0], out yVal);

                if (xY && yY)
                {
                    if (xVal - yVal > double.Epsilon)
                    {
                        returnVal = 1;
                    }
                    else if (xVal - yVal < 0)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = 0;
                    }
                }
            }
            else
            {
                returnVal = string.CompareOrdinal(((ListViewItem) x).SubItems[Col].Text,
                    ((ListViewItem) y).SubItems[Col].Text);
            }

            // Determine whether the sort order is descending.
            if (Order == SortOrder.Descending)
            {
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            }
            return returnVal;
        }
    }
}