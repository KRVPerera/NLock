using log4net;
using NLock.NLockFile.Container;
using NLock.NLockFile.Encryption;
using NLock.NLockFile.Exceptions;
using NLock.NLockFile.NlZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NLock.NLockFile
{
    public class NLockContainerCommons : IDisposable
    {
        #region Private variables

        private static readonly ILog logger = LogManager.GetLogger(typeof(NLockContainerCommons));

        private readonly IEncryptionStrategy _encryptionStrategy = new AESEncryptionStrategy();
        private readonly IContainerInterface _container = new NlZipArchive();
        private bool _verified;
        private List<NlFile> _files = new List<NlFile>();
        private byte[] _lockedContent;

        #endregion Private variables

        #region public properties

        public string FileName { get; private set; }

        public byte[] Template { private get; set; }

        public bool AddPassword { set; private get; }

        public String Password { private get; set; }

        public NLockTemplateOperations TemplateOperations { get; set; }

        public bool IsLocked { get; private set; }

        #endregion public properties

        #region Public constructors

        public NLockContainerCommons()
        {
            TemplateOperations = new NLockTemplateOperationsAES();
        }

        #endregion Public constructors

        #region Public methods

        public List<NlFile> GetFileList()
        {
            if (_container != null)
            {
                _files = _container.GetNLFileList();
                return _files;
            }
            else
            {
                return null;
            }
        }

        public void Save(String fileName)
        {
            logger.Debug("Saving as : " + fileName);
            if (IsEmpty())
            {
                logger.Warn("No files added cannot save as : " + fileName);
                throw new NLockFileContainerEmptyException("No files added");
            }

            if (Template == null || Template.Length != TemplateOperations.TemplateLength)
            {
                logger.Warn("Template is null cannot save as : " + fileName);
                throw new NullReferenceException("Template is null");
            }
            byte[] fileStmWithTempAndFile;
            if (!AddPassword)
            {
                TemplateOperations = new NLockTemplateOperationsAES();
                if (!IsLocked)
                {
                    Lock();
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent);
                }
                else
                {
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent);
                }
            }
            else
            {
                TemplateOperations = new NLockTemplateOperationsCommon();
                if (!IsLocked)
                {
                    Lock();
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent, Password);
                }
                else
                {
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent, Password);
                }
            }

            if (File.Exists(fileName))
            {
                logger.Debug(fileName + " already exists so deleting");
                File.Delete(fileName);
            }

            using (FileStream fs2 = File.Create(fileName))
            {
                logger.Debug(fileName + " is being written");
                fs2.Write(fileStmWithTempAndFile, 0, fileStmWithTempAndFile.Length);
                fs2.Close();
            }
            _container.Dispose();
        }

        public bool ExtractToFolder(String path)
        {
            return _container.ExtractToFolder(path);
        }

        public void AddDirectory(String DirectoryPath, bool recursively = false)
        {
            logger.Debug("DirectoryPath : " + DirectoryPath + " " + "Recursively : " + recursively);

            var fileList = Directory.GetFiles(DirectoryPath + "\\", "*", SearchOption.AllDirectories);
            if (fileList.Length > 0)
            {
                var listd = DirectoryPath.Split(Path.DirectorySeparatorChar);
                _container.AddFolder(DirectoryPath, recursively, listd[listd.Length - 1]);
            }
        }

        public void AddFile(string fileName)
        {
            logger.Debug(fileName);
            var nlfile = new NlFile(fileName);
            if (!_files.Contains(nlfile))
            {
                logger.Debug("File " + Path.GetFileName(fileName) + " does not contain in the list");
                _files.Add(nlfile);
                logger.Debug("File " + Path.GetFileName(fileName) + " Added to list");
                _container.AddFile(fileName);
                logger.Debug("File " + Path.GetFileName(fileName) + " Added to container");
            }
            else
            {
                logger.Debug("File " + Path.GetFileName(fileName) + "File already present");
            }
        }

        public void LoadFromFile(string fileName)
        {
            try
            {
                IsLocked = true;
                FileName = fileName;
                var full = File.ReadAllBytes(fileName);
                var type = DecideTemplateOperations(fileName);
                logger.Debug("LoadFromFile Type : " + type);

                var zipContent = TemplateOperations.ExtractDataContentFromNLock(full);
                Template = TemplateOperations.ExtractTemplateFromNLock(full);
                Template = _encryptionStrategy.Decrypt(zipContent, Template);

                UnlockForm loginFrom;

                if (type == 2)
                {
                    var hash = TemplateOperations.GetHashFromNLock(full);
                    logger.Debug("LoadFromFile Hash : " + System.Text.Encoding.UTF8.GetString(hash));
                    loginFrom = new UnlockForm(Template, hash, fileName);
                }
                else
                {
                    loginFrom = new UnlockForm(Template, fileName)
                    {
                        PWHash = null
                    };
                }
                loginFrom.ShowDialog();
                var result = loginFrom.DialogResult;
                if (result != DialogResult.Cancel)
                {
                    _verified = loginFrom.Verified;
                    Unlock();
                }
                loginFrom.Dispose();
            }
            catch (Exception ex)
            {
                logger.Debug("LoadFromFile ex : " + ex);
                throw new Exception("Loading from file failed", ex);
            }
        }

        public int DecideTemplateOperations(String fileName)
        {
            var type = NLockTemplateOperations.IsNLock(fileName);
            logger.Debug("DecideTemplateOperations Type : " + type);
            switch (type)
            {
                case 1:
                    TemplateOperations = new NLockTemplateOperationsAES();
                    break;

                case 2:
                    TemplateOperations = new NLockTemplateOperationsCommon();
                    break;

                default:
                    throw new InvalidNLockFileException();
            }
            return type;
        }

        public void Lock()
        {
            logger.Debug("Locking");
            logger.Debug("Perform encryption");
            _lockedContent = _encryptionStrategy.Encrypt(Template, _container.GetContent());
            logger.Debug("lockedContent created");
            Template = _encryptionStrategy.Encrypt(_lockedContent, Template);
            IsLocked = true;
            logger.Debug("Locked");
        }

        public void Unlock()
        {
            logger.Debug("Unlocking");
            if (_verified)
            {
                if (FileName != null)
                {
                    var zipContent = TemplateOperations.ExtractDataContentFromNLock(FileName);
                    logger.Debug("ExtractDataContentFromNLock");
                    _lockedContent = _encryptionStrategy.Decrypt(Template, zipContent);
                    _container.LoadFromMemory(_lockedContent);
                    IsLocked = false;
                }
            }
            else
            {
                logger.Debug("Not verified");
                IsLocked = true;
                throw new NLockUnidentifiedUserException("Unlocking Failed");
            }
        }

        private bool IsEmpty()
        {
            return _files.Count <= 0;
        }

        public void Dispose()
        {
            try
            {
                if (_container != null)
                {
                    _container.Dispose();
                }

                _files = null;
                _lockedContent = null;
            }
            catch (Exception)
            {
                throw new Exception("Container dispose error");
            }
        }

        public bool RemoveFile(string file)
        {
            return _container.RemoveFile(file);
        }

        #endregion Public methods
    }
}