using System;

namespace NLock.NLockFile.Exceptions
{
    [Serializable]
    public class NLockFileCorruptedException : Exception
    {
        public NLockFileCorruptedException()
        {
        }

        public NLockFileCorruptedException(string message)
            : base(message)
        {
        }

        public NLockFileCorruptedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [Serializable]
    public class NLockFileContainerEmptyException : Exception
    {
        public NLockFileContainerEmptyException()
        {
        }

        public NLockFileContainerEmptyException(string message)
            : base(message)
        {
        }

        public NLockFileContainerEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [Serializable]
    public class NLockUnidentifiedUserException : Exception
    {
        public NLockUnidentifiedUserException()
        {
        }

        public NLockUnidentifiedUserException(string message)
            : base(message)
        {
        }

        public NLockUnidentifiedUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [Serializable]
    public class InvalidNLockFileException : Exception
    {
        public InvalidNLockFileException()
        {
        }

        public InvalidNLockFileException(string message)
            : base(message)
        {
        }

        public InvalidNLockFileException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}