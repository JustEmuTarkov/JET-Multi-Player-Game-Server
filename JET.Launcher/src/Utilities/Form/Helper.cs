using JET.Launcher.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JET.Launcher.Utilities.Form
{
    internal class Helper
    {
        internal Helper() { }

        internal static void UnblockFile(string path)
        {
            DeleteFile(path + ":Zone.Identifier");
        }

        internal void DisplayGrid_LoginConnect(string name = "")
        {
            switch (name)
            {
                case "Connect":
                    MainWindow.Instance.__Connect.Visibility = Visibility.Visible;
                    MainWindow.Instance.__Login.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__LoggedIn.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Register.Visibility = Visibility.Hidden;
                    break;
                case "Login":
                    MainWindow.Instance.__Connect.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Login.Visibility = Visibility.Visible;
                    MainWindow.Instance.__LoggedIn.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Register.Visibility = Visibility.Hidden;
                    break;
                case "Register":
                case "Wipe":
                    MainWindow.Instance.__Connect.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Login.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__LoggedIn.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Register.Visibility = Visibility.Visible;
                    break;
                default:
                    MainWindow.Instance.__Connect.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__Login.Visibility = Visibility.Hidden;
                    MainWindow.Instance.__LoggedIn.Visibility = Visibility.Visible;
                    MainWindow.Instance.__Register.Visibility = Visibility.Hidden;
                    break;
            }
        }

        #region Tick Updater
        internal void Updater_Tick(object sender, EventArgs e)
        {
            Task.Run(() => Parallel.Invoke(ServerCheck, UpdateStartServerButton, UpdateDeleteServerButton));
        }
        #region Functions
        private void UpdateDeleteServerButton()
        {
            MainWindow.Instance.Dispatcher.Invoke(() =>
            {
                if (MainWindow.Instance.__LauncherConfigL.GetServersCount() > 0)
                    MainWindow.Instance.__DeleteSelectedServer.IsEnabled = true;
                else
                    MainWindow.Instance.__DeleteSelectedServer.IsEnabled = false;
            });

        }
        private void UpdateStartServerButton()
        {
            MainWindow.Instance.Dispatcher.Invoke(() =>
            {
                if (ProcessManager.consoleProcessName != "")
                {
                    //Process running
                    MainWindow.Instance.__StartStopServer.Content = "Stop Server";
                }
                else
                {
                    //Process not present
                    MainWindow.Instance.__StartStopServer.Content = "Start Server";
                }
            });
        }
        private int LastServersCheckCount = 0;
        private void ServerCheck()
        {
            if (!RequestManager.OngoingRequest)
            {
                //if (LastServersCheckCount <= 0 && ServerManager.AvailableServers.Count <= 0)
                //{
                //    foreach (var server in LauncherConfigLoader.Instance.GetServers())
                //        ServerManager.LoadServerFromDifferentBackend(server, true); // load actual selected server
                //}
                //else
                //{
                foreach (var server in LauncherConfigLoader.Instance.GetServers().Where(x => ServerManager.AvailableServers.All(y => y.connectUrl != x)))
                    ServerManager.LoadServerFromDifferentBackend(server, true);


                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    if (MainWindow.Instance.__ServerList.Items.Count <= 0 || LastServersCheckCount != ServerManager.AvailableServers.Count)
                    {
                        if (MainWindow.Instance.__ServerList.Items.Count > 0)
                        {
                            MainWindow.Instance.__ApplyButton.IsEnabled = true;
                            MainWindow.Instance.__ServerList.SelectedIndex = 0;
                            ServerManager.SelectServer(0);
                        }
                        else
                        {
                            //MainWindow.Instance.__ServerList.Text = "No Servers Found";
                            //MainWindow.Instance.__ServerList.Items.Clear();
                        }
                        LastServersCheckCount = MainWindow.Instance.__ServerList.Items.Count;
                    }
                });
                //}
            }
        }
        #endregion
        #endregion


        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);
    }
}
