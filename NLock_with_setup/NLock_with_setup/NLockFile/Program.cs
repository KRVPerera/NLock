using log4net;
using Microsoft.VisualBasic.ApplicationServices;
using Neurotec.Licensing;
using NLock.NLockFile.Util;
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
            MainForm.Activate();
        }

        public void FocusMe()
        {
            MainForm.Focus();
        }

        public App(Form frm)
            : base(frm)
        {
        }
    }

    public class SingleInstanceManager : WindowsFormsApplicationBase
    {
        private App _app;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SingleInstanceManager));

        public SingleInstanceManager()
        {
            IsSingleInstance = true;
        }

        protected override bool OnStartup(StartupEventArgs e)
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
                            _app = Operations.OpenNLockFile(args);
                            break;

                        case 1:
                            _app = Operations.UnlockTo(args);
                            break;

                        case 2:
                            _app = Operations.UnlockHere(args);
                            break;

                        case 3:
                            _app = Operations.NLockThisFile(args);
                            break;

                        case 4:
                            _app = Operations.LockThisFolder(args);
                            break;

                        default:
                            MessageBox.Show(Resources.Invalid_command, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    _app = new App(new MainForm(OperationModes.Default));
                }

                if (_app != null)
                {
                    Application.Run(_app);
                    _app.FocusMe();
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
                            var nwForm = (MainForm) _app.MainForm;
                            nwForm.AddThisFiletoNLock(args[1]);
                            _app.FocusMe();
                            break;

                        case 4:
                            OperationsNew.LockThisFolder(args);
                            break;

                        default:
                            MessageBox.Show(Resources.Invalid_command, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    _app.FocusMe();
                }
            }
            catch (Exception rx)
            {
                Logger.Error(rx.ToString());
            }
        }
    }
}