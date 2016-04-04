using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using log4net;
using NLock.NLockFile.Container;
using NLock.NLockFile.Encryption;
using NLock.NLockFile.Util;

namespace NLock.NLockFile
{
    public class NLockContainerCommons : IDisposable
    {
        #region Public constructors

        public enum ContainerStatus
        {
            Ok,
            Empty,
            NullTemplate
        }

        public enum VerificationStatus
        {
            Verfified,
            Failed
        }

        public NLockContainerCommons()
        {
            TemplateOperations = new NLockTemplateOperationsAes();
        }

        #endregion Public constructors

        #region Private variables

        private static readonly ILog Logger = LogManager.GetLogger(typeof (NLockContainerCommons));

        private readonly IEncryptionStrategy _encryptionStrategy = new AesEncryptionStrategy();
        private readonly IContainerInterface _container = new NlZipArchive();
        private bool _verified;
        private List<NlFile> _files = new List<NlFile>();
        private byte[] _lockedContent;

        #endregion Private variables

        #region public properties

        public string FileName { get; private set; }

        public byte[] Template { private get; set; }

        public bool AddPassword { set; private get; }

        public string Password { private get; set; }

        public NLockTemplateOperations TemplateOperations { get; set; }

        public bool IsLocked { get; private set; }

        #endregion public properties

        #region Public methods

        public List<NlFile> GetFileList()
        {
            if (_container != null)
            {
                _files = _container.GetNlFileList();
                return _files;
            }
            return null;
        }

        public ContainerStatus Save(string fileName)
        {
            Logger.Debug("Saving as : " + fileName);
            if (IsEmpty())
            {
                Logger.Warn("No files added cannot save as : " + fileName);
                return ContainerStatus.Empty;
            }

            if (Template == null || Template.Length != TemplateOperations.TemplateLength)
            {
                Logger.Warn("Template is null cannot save as : " + fileName);
                return ContainerStatus.NullTemplate;
            }
            byte[] fileStmWithTempAndFile;
            if (!AddPassword)
            {
                TemplateOperations = new NLockTemplateOperationsAes();
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
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent,
                        Password);
                }
                else
                {
                    fileStmWithTempAndFile = TemplateOperations.GenerateNLockFileContent(Template, _lockedContent,
                        Password);
                }
            }

            if (File.Exists(fileName))
            {
                Logger.Debug(fileName + " already exists so deleting");
                File.Delete(fileName);
            }

            using (var fs2 = File.Create(fileName))
            {
                Logger.Debug(fileName + " is being written");
                fs2.Write(fileStmWithTempAndFile, 0, fileStmWithTempAndFile.Length);
                fs2.Close();
            }
            _container.Dispose();
            return ContainerStatus.Ok;
        }

        public bool ExtractToFolder(string path)
        {
            return _container.ExtractToFolder(path);
        }

        public void AddDirectory(string directoryPath, bool recursively = false)
        {
            Logger.Debug("DirectoryPath : " + directoryPath + " " + "Recursively : " + recursively);

            var fileList = Directory.GetFiles(directoryPath + "\\", "*", SearchOption.AllDirectories);
            if (fileList.Length > 0)
            {
                var listd = directoryPath.Split(Path.DirectorySeparatorChar);
                _container.AddFolder(directoryPath, recursively, listd[listd.Length - 1]);
            }
        }

        public void AddFile(string fileName)
        {
            Logger.Debug(fileName);
            var nlfile = new NlFile(fileName);
            if (!_files.Contains(nlfile))
            {
                Logger.Debug("File " + Path.GetFileName(fileName) + " does not contain in the list");
                _files.Add(nlfile);
                Logger.Debug("File " + Path.GetFileName(fileName) + " Added to list");
                _container.AddFile(fileName);
                Logger.Debug("File " + Path.GetFileName(fileName) + " Added to container");
            }
            else
            {
                Logger.Debug("File " + Path.GetFileName(fileName) + "File already present");
            }
        }

        public void LoadFromFile(string fileName)
        {
            IsLocked = true;
            FileName = fileName;
            var full = File.ReadAllBytes(fileName);
            var type = DecideTemplateOperations(fileName);
            if (type > 0)
            {
                Logger.Debug("LoadFromFile Type : " + type);


                var zipContent = TemplateOperations.ExtractDataContentFromNLock(full);
                try
                {
                    Template = TemplateOperations.ExtractTemplateFromNLock(full);
                    Template = _encryptionStrategy.Decrypt(zipContent, Template);
                }
                catch (Exception)
                {
                    throw;
                }

                UnlockForm loginFrom;

                if (type == 2)
                {
                    var hash = TemplateOperations.GetHashFromNLock(full);
                    Logger.Debug("LoadFromFile Hash : " + Encoding.UTF8.GetString(hash));
                    loginFrom = new UnlockForm(Template, hash, fileName);
                }
                else
                {
                    loginFrom = new UnlockForm(Template, fileName)
                    {
                        PwHash = null
                    };
                }
                loginFrom.ShowDialog();
                var result = loginFrom.DialogResult;
                if (result != DialogResult.Cancel)
                {
                    _verified = loginFrom.Verified;
                    if (Unlock() == VerificationStatus.Failed)
                    {
                        throw new Exception("Loading from file failed");
                    }
                }
                loginFrom.Dispose();
            }
            else
            {
                throw new Exception("Loading from file failed");
            }
        }

        private int DecideTemplateOperations(string fileName)
        {
            var type = NLockTemplateOperations.IsNLock(fileName);
            Logger.Debug("DecideTemplateOperations Type : " + type);
            switch (type)
            {
                case 1:
                    TemplateOperations = new NLockTemplateOperationsAes();
                    break;

                case 2:
                    TemplateOperations = new NLockTemplateOperationsCommon();
                    break;

                default:
                    Logger.Error("Invalid NLock file type");
                    break;
            }
            return type;
        }

        public void Lock()
        {
            Logger.Debug("Locking");
            Logger.Debug("Perform encryption");
            _lockedContent = _encryptionStrategy.Encrypt(Template, _container.GetContent());
            Logger.Debug("lockedContent created");
            Template = _encryptionStrategy.Encrypt(_lockedContent, Template);
            IsLocked = true;
            Logger.Debug("Locked");
        }

        private VerificationStatus Unlock()
        {
            Logger.Debug("Unlocking");
            if (_verified)
            {
                if (FileName != null)
                {
                    var zipContent = TemplateOperations.ExtractDataContentFromNLock(FileName);
                    Logger.Debug("ExtractDataContentFromNLock");
                    _lockedContent = _encryptionStrategy.Decrypt(Template, zipContent);
                    _container.LoadFromMemory(_lockedContent);
                    IsLocked = false;
                }
                return VerificationStatus.Verfified;
            }
            else
            {
                Logger.Debug("Not verified");
                IsLocked = true;
                return VerificationStatus.Failed;
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