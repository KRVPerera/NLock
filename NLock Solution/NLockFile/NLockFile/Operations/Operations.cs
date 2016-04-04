using System.IO;
using System.Windows.Forms;

namespace NLock.NLockFile.Operations
{
    internal class Operations
    {
        private static NLockTemplateOperations _nLockTemplateOperations = new NLockTemplateOperationsAES();

        internal static App OpenNLockFile(string[] args)
        {
            App app = null;
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                app = new App(new MainForm(OperationModes.OPENNLOCK, args[1]));
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
                app = new App(new MainForm(OperationModes.UNLOCKHERE, args[1]));
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
                app = new App(new MainForm(OperationModes.UNLOCKTO, args[1]));
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
            return app;
        }

        internal static App LockThisFolder(string[] args)
        {
            var app = new App(new MainForm(OperationModes.LOCKFOLDER, args[1]));
            return app;
        }

        internal static App NLockThisFile(string[] args)
        {
            var app = new App(new MainForm(OperationModes.NLOCKTHISFILE, args[1]));

            return app;
        }
    }
}