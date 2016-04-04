using System.IO;
using System.Threading;
using System.Windows.Forms;
using log4net;
using NLock.Properties;

namespace NLock.NLockFile.Util
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
                MessageBox.Show(Resources.Not_a_valid_NLock_File___ + Path.GetFileName(args[1]), Resources.Error, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        internal static void UnlockHere(string[] args)
        {
            Logger.Debug("");
            // TODO : Check also header content and CRC
            if (Path.GetExtension(args[1]) == ".nlk" && NLockTemplateOperations.IsNLock(args[1]) > 0)
            {
                var thread = new Thread(() => ThreadUnlockHere(args));
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show(Resources.Not_a_valid_NLock_File___ + Path.GetFileName(args[1]));
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
                MessageBox.Show(Resources.Not_a_valid_NLock_File___ + Path.GetFileName(args[1]));
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

        private static void ThreadLockThisFolder(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.Lockfolder, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadUnlockTo(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.Unlockto, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadUnlockHere(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.Unlockhere, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        private static void ThreadOpenNLockFile(string[] args)
        {
            Logger.Debug("");
            using (var newUnlockerForm = new MainForm(OperationModes.Opennlock, args[1]))
            {
                newUnlockerForm.ShowDialog();
                newUnlockerForm.Focus();
            }
        }

        #endregion Thread works
    }
}