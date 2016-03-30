using log4net;
using Microsoft.VisualBasic.ApplicationServices;
using Neurotec.Licensing;
using NLock.NLockFile.ContextMenus;
using NLock.NLockFile.Operations;
using NLock.NLockFile.OperationsNew;
using NLock.Properties;
using System;
using System.Windows.Forms;

namespace NLock
{
    internal static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var manager = new SingleInstanceManager();

                Application.ApplicationExit += ApplicationExitEvent;
                manager.Run(args);
            }
            catch (Exception rx)
            {
                Logger.Error(rx.ToString());
            }
        }

        private static void ApplicationExitEvent(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }
    }

    public class App : ApplicationContext
    {
        public void Activate()
        {
            //TODO : Remove this
            this.MainForm.Activate();
        }

        public void FocusMe()
        {
            this.MainForm.Focus();
        }

        public App(Form frm)
            : base(frm)
        {
        }
    }

    public class SingleInstanceManager : WindowsFormsApplicationBase
    {
        private App app;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SingleInstanceManager));

        public SingleInstanceManager()
        {
            this.IsSingleInstance = true;
        }

        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            const int Port = 5000;
            const string Address = "/local";

            const string Components =
                "Biometrics.FaceExtraction," +
                "Biometrics.FaceMatching," +
                "Biometrics.FaceDetection," +
                "Devices.Cameras";
            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.ObtainComponents(Address, Port, component);
                    Logger.Debug("Obtaining licenses");
                }

                var args = new string[e.CommandLine.Count];
                e.CommandLine.CopyTo(args, 0);

                if (args.Length > 0)
                {
                    var choice = ArgumentParser.Parse(args);
                    Logger.Debug("Argument parser returned choice : " + choice);

                    switch (choice)
                    {
                        case 0:
                            app = Operations.OpenNLockFile(args);
                            break;

                        case 1:
                            app = Operations.UnlockTo(args);
                            break;

                        case 2:
                            app = Operations.UnlockHere(args);
                            break;

                        case 3:
                            app = Operations.NLockThisFile(args);
                            break;

                        case 4:
                            app = Operations.LockThisFolder(args);
                            break;

                        default:
                            MessageBox.Show("Invalid command, please contact System Administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    app = new App(new MainForm(OperationModes.Default));
                }

                if (app != null)
                {
                    Application.Run(app);
                }
            }
            catch (Exception rx)
            {
                Logger.Debug("tray OnStartup failed");
                Logger.Error(rx);
            }
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            try
            {
                base.OnStartupNextInstance(eventArgs);
                var args = new string[eventArgs.CommandLine.Count];
                eventArgs.CommandLine.CopyTo(args, 0);

                if (args.Length > 0)
                {
                    var choice = ArgumentParser.Parse(args);
                    Logger.Debug("Argument parser returned choice : " + choice);

                    switch (choice)
                    {
                        case 0:
                            OperationsNew.OpenNLockFile(args);
                            break;

                        case 1:
                            OperationsNew.UnlockTo(args);
                            break;

                        case 2:
                            OperationsNew.UnlockHere(args);
                            break;

                        case 3:
                            var nwForm = (MainForm)app.MainForm;
                            nwForm.AddThisFiletoNLock(args[1]);
                            app.FocusMe();
                            break;

                        case 4:
                            OperationsNew.LockThisFolder(args);
                            break;

                        default:
                            MessageBox.Show("Invalid command, please contact System Administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    app.FocusMe();
                }
            }
            catch (Exception rx)
            {
                Logger.Error(rx.ToString());
            }
        }
    }
}