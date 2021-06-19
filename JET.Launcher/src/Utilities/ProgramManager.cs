using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace JET.Launcher.Utilities
{
    class ProgramManager
    {
        internal static bool isGameFilesFound() { 
            if(File.Exists(Path.Combine(Environment.CurrentDirectory, "EscapeFromTarkov.exe"))){
                return true;
            }
            MessageBoxManager.Show("Game Files Not Found", "Oopss!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
            return false;
        }
        internal static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                HandleException(exception);
            }
            else
            {
                HandleException(new Exception("Unknown Exception"));
            }
        }
        internal static void HandleException(Exception exception)
        {
            var text = $"Exception; Message:{exception.Message}{Environment.NewLine}StackTrace:{exception.StackTrace}";
            //LogManager.Instance.Error(text);
            MessageBoxManager.Show(text, "Exception", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
        }
        private static string _FileName;
        internal static Assembly AssemblyResolveEvent(object sender, ResolveEventArgs args)
        {
            try
            {
                var assembly = new AssemblyName(args.Name).Name;
                _FileName = Path.Combine(Environment.CurrentDirectory, $"EscapeFromTarkov_Data/Managed/{assembly}.dll");
                // resources are embedded inside assembly
                if (_FileName.Contains("resources"))
                {
                    return null;
                }
                return Assembly.LoadFrom(_FileName);
            }
            catch (Exception e)
            {
                MessageBoxManager.Show(
                    $"Cannot find a file(or file is not unlocked) named:\r\n{_FileName}\r\nWith an exception: {e.Message}\r\nApplication will close after pressing OK.",
                    "File load error!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                Application.Current.Shutdown();
            }
            return null;
        }
    }
}
