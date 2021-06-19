using JET.Launcher.Utilities;
using System;
using System.Diagnostics;
using System.Windows;

namespace JET.Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Application Exit - Event
        /// </summary>

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if(ProcessManager.consoleProcessName != "")
                ProcessManager.consoleProcessHandle.Kill();
        }
    }
}
