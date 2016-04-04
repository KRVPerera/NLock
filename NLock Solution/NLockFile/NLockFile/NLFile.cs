using log4net;
using System;
using System.IO;

namespace NLock.NLockFile
{
    //TODO : Convert to a value type
    public class NlFile : IEquatable<NlFile>
    {
        #region Private variables

        private static readonly ILog logger = LogManager.GetLogger(typeof(NlFile));
        private readonly String _fileName;

        #endregion Private variables

        #region Public Properties

        public long OriginalSize { get; set; }

        public long CompressedSize { get; set; }

        public string FileName
        {
            get
            {
                return _fileName;
            }

        }

        public string FilePath
        {
            get; set;
        }

        #endregion Public Properties

        #region Public Constructors

        public NlFile(String fileName)
        {
            _fileName = Path.GetFileName(fileName);
            CompressedSize = 0;
            OriginalSize = 0;
        }

        #endregion Public Constructors

        #region IEquatable Implementations

        public bool Equals(NlFile other)
        {
            logger.Debug("Equals(NlFile other)");
            if (other == null)
                return false;

            return (FileName == other.FileName) && (FilePath == other.FilePath);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var nfileObj = obj as NlFile;
            return (nfileObj != null) && Equals(nfileObj);
        }

        public override int GetHashCode()
        {
            var hash = 23;
            hash = hash * 31 + _fileName.GetHashCode();
            hash = hash * 31 + FilePath.GetHashCode();
            hash = hash * 31 + OriginalSize.GetHashCode();
            hash = hash * 31 + CompressedSize.GetHashCode();
            logger.Debug("hash code : " + hash);
            return hash;
        }

        #endregion IEquatable Implementations
    }
}