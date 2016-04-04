using log4net;
using NLock.NLockFile.Operations;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NLock.NLockFile.OperationsNew
{
    internal class OperationsNew
    {
        #region Private variables

        

        private static readonly ILog Logger = LogManager.GetLogger(typeof(OperationsNew));

        #endregion Private variables

        #region Thread Creation

        //TODO: need to have a separate process not a thread
        internal static void OpenNLockFile(string[] args)
        {
            Logger.Debug("");
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                var thread = new Thread(() => ThreadOpenNLockFile(args));
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
        }

        internal static void UnlockHere(string[] args)
        {
            Logger.Debug("");
            /// TODO : Check also header content and CRC
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                var thread = new Thread(() => ThreadUnlockHere(args));
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
        }

        internal static void UnlockTo(string[] args)
        {
            Logger.Debug("");
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                var thread = new Thread(() => ThreadUnlockTo(args));
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Not a valid NLock File : " + Path.GetFileName(args[1]));
            }
        }

        internal static void LockThisFolder(string[] args)
        {
            Logger.Debug("");
            var thread = new Thread(() => ThreadLockThisFolder(args));
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion Thread Creation

        #region Thread works

        private static void ThreadNLockThisFile(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.NLOCKTHISFILE, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadLockThisFolder(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.LOCKFOLDER, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadUnlockTo(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.UNLOCKTO, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadUnlockHere(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.UNLOCKHERE, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadOpenNLockFile(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.OPENNLOCK, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        #endregion Thread works
    }
}