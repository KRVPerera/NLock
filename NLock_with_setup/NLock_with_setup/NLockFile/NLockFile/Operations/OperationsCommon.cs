namespace NLock.NLockFile.Operations
{
    public enum OperationModes
    {
        Default,
        Opennlock,
        Unlockhere,
        Unlockto,
        Lockfolder,
        Nlockthisfile
    }

    public enum Status
    {
        Sucessfullyextracted,
        Extractionfailed,
        Extractioncancelled
    }
}