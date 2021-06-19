using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using JET.OldLauncher.Controllers;

namespace JET.OldLauncher
{
    public static class Program
    {
        private static readonly StaticData staticText = new StaticData();
        [STAThread]
        private static void Main()
        {
            if (!File.Exists(Path.Combine(staticText.working_dir, "EscapeFromTarkov.exe")))
            {
                MessageBox.Show(staticText.ERROR_MSG.noGameFound, staticText.ERROR_MSG.checkFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // set rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // enable logs
            Application.ThreadException += (sender, args) => HandleException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            // load assemblies from EFT's managed directory
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEvent);

            Application.Run(new Main());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                HandleException(exception);
            }
            else
            {
                HandleException(new Exception(staticText.EXCEPTIONS.unknException));
            }
        }

        private static void HandleException(Exception exception)
        {
            var text = $"{staticText.EXCEPTIONS.exception} {staticText.EXCEPTIONS.message}:{exception.Message}{Environment.NewLine}StackTrace:{exception.StackTrace}";
            LogManager.Instance.Error(text);
            MessageBox.Show(text, staticText.EXCEPTIONS.exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static string filename;
        private static Assembly AssemblyResolveEvent(object sender, ResolveEventArgs args)
        {
            try
            {
                string assembly = new AssemblyName(args.Name).Name;
                filename = Path.Combine(staticText.working_dir, $"{staticText.eft_managed}{assembly}{staticText.dll_ext}");

                // resources are embedded inside assembly
                if (filename.Contains("resources"))
                {
                    return null;
                }
                return Assembly.LoadFrom(filename);
            }
            catch (Exception)
            {
                MessageBox.Show($"Cannot find a file named:\r\n{filename}\r\nApplication will close after pressing OK.", "File not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return null;
        }
    }
}
