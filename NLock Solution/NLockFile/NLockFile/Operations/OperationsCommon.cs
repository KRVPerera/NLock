namespace NLock.NLockFile.Operations
{
    public enum OperationModes
    {
        DEFAULT,
        OPENNLOCK,
        UNLOCKHERE,
        UNLOCKTO,
        LOCKFOLDER,
        NLOCKTHISFILE
    }

    public enum Status
    {
        SUCESSFULLYEXTRACTED,
        EXTRACTIONFAILED,
        EXTRACTIONCANCELLED
    }
}