using System.IO;
using System.Windows.Forms;

namespace NLock.NLockFile.Util
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

    internal static class Operations
    {
        internal static App OpenNLockFile(string[] args)
        {
            App app = null;
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                app = new App(new MainForm(OperationModes.Opennlock, args[1]));
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
            return app;
        }

        internal static App UnlockHere(string[] args)
        {
            ///TODO :  Check the header content and add a CRC
            App app = null;
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                app = new App(new MainForm(OperationModes.Unlockhere, args[1]));
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
            return app;
        }

        internal static App UnlockTo(string[] args)
        {
            App app = null;
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                app = new App(new MainForm(OperationModes.Unlockto, args[1]));
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
            return app;
        }

        internal static App LockThisFolder(string[] args)
        {
            var app = new App(new MainForm(OperationModes.Lockfolder, args[1]));
            return app;
        }

        internal static App NLockThisFile(string[] args)
        {
            var app = new App(new MainForm(OperationModes.Nlockthisfile, args[1]));

            return app;
        }
    }
}