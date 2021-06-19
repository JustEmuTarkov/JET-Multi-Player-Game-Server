using JET.Launcher.Structures;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using JET.Utilities.HTTP;

namespace JET.Launcher.Utilities.Form
{
    internal class Manager
    {
        private Helper _Helper;
        internal Manager() { _Helper = new Helper(); }

        internal static string ApplyButtonAction = "connect";
        internal void EnableApplyButton(bool enable) => MainWindow.Instance.__ApplyButton.IsEnabled = true;
        
        /// <summary>
        /// Handles ApplyButton in the WPF Form
        /// Possible Actions: "connect", "login", "startgame", ""(disable)
        /// </summary>
        /// <param name="action"></param>
        internal void UpdateApplyButton(string action) {
            switch (action) {
                case "connect":
                    MainWindow.Instance.__ApplyButton.Content = "Connect to Server";
                    ApplyButtonAction = "connect";
                    _Helper.DisplayGrid_LoginConnect("Connect");
                    break;
                case "login":
                    MainWindow.Instance.__ApplyButton.Content = "Login";
                    ApplyButtonAction = "login";
                    _Helper.DisplayGrid_LoginConnect("Login");
                    break;
                case "register":
                    MainWindow.Instance.__ApplyButton.Content = "Register";
                    ApplyButtonAction = "register";
                    _Helper.DisplayGrid_LoginConnect("Register");
                    break;
                case "wipe":
                    MainWindow.Instance.__ApplyButton.Content = "Wipe";
                    ApplyButtonAction = "wipe";
                    _Helper.DisplayGrid_LoginConnect("Wipe");
                    break;
                case "startgame":
                    MainWindow.Instance.__ApplyButton.Content = "Start";
                    ApplyButtonAction = "startgame";
                    _Helper.DisplayGrid_LoginConnect();
                    break;
                default:
                    ApplyButtonAction = "null";
                    MainWindow.Instance.__ApplyButton.IsEnabled = false;
                    MainWindow.Instance.__ApplyButton.Content = "Unavaliable";
                    _Helper.DisplayGrid_LoginConnect();
                    break;
            }
        }
        private int responseCode = 0;
        internal void ApplyButtonClickEvent(object sender, RoutedEventArgs e) {

            switch (ApplyButtonAction) {
                case "connect":
                    UpdateApplyButton("login");
                    break;
                case "login":
                    //Console.WriteLine($"Login: {MainWindow.Instance._LoginField.Text}, Pass: {MainWindow.Instance._PasswordField.Password}");
                    responseCode = RequestManager.ProfileLogin(MainWindow.Instance._LoginField.Text, MainWindow.Instance._PasswordField.Password);
                    switch (responseCode) {
                        case 1:
                            UpdateApplyButton("startgame");
                            MainWindow.Instance.__Label_LoggedAs.Content = RequestManager.SelectedAccount.email;
                            LauncherConfigLoader.Instance.Email = MainWindow.Instance._LoginField.Text;
                            LauncherConfigLoader.Instance.Password = MainWindow.Instance._PasswordField.Password;
                            break;
                        case -1: 
                            MessageBoxManager.Show("Wrong login data. A profile with that username and password does not exist on the server", "Login Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -2: 
                            MessageBoxManager.Show("Couldn't finish a request script crashed at login or getting account data", "Request Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        default:
                            MessageBoxManager.Show($"Something goes wrong and returned code {responseCode}", "Unknown Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                    }
                    break;
                case "register":
                    responseCode = RequestManager.ProfileRegister(MainWindow.Instance._RegisterLoginField.Text, MainWindow.Instance._RegisterPasswordField.Password, MainWindow.Instance._EditionSelectBox.SelectedItem.ToString());
                    switch (responseCode)
                    {
                        case 1:
                            UpdateApplyButton("startgame");
                            MainWindow.Instance._LoginField.Text = RequestManager.SelectedAccount.email;
                            MainWindow.Instance._PasswordField.Password = RequestManager.SelectedAccount.password;
                            MainWindow.Instance.__Label_LoggedAs.Content = RequestManager.SelectedAccount.email;
                            LauncherConfigLoader.Instance.Email = MainWindow.Instance._LoginField.Text;
                            LauncherConfigLoader.Instance.Password = MainWindow.Instance._RegisterPasswordField.Password;
                            break;
                        case -1:
                            MessageBoxManager.Show("An account with that login already exists", "", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -2:
                            MessageBoxManager.Show("Did not receive a response from the server. Please try again.", "No response", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -3:
                            UpdateApplyButton("login");
                            MessageBoxManager.Show("The account was created, but I was unable to log into it. Please try again.", "Couldn't log in", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        default:
                            MessageBoxManager.Show("Something went wrong but I don't know what", "Unknown error", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                    }
                    break;
                case "wipe":
                    var edition = MainWindow.Instance._EditionSelectBox.SelectedItem.ToString();
                    RequestManager.SelectedAccount.email = MainWindow.Instance._RegisterLoginField.Text;
                    RequestManager.SelectedAccount.password = MainWindow.Instance._RegisterPasswordField.Password;
                    
                    responseCode = RequestManager.Wipe(edition);
                    switch (responseCode)
                    {
                        case 1:
                            UpdateApplyButton("startgame");
                            MainWindow.Instance._LoginField.Text = RequestManager.SelectedAccount.email;
                            MainWindow.Instance._PasswordField.Password = RequestManager.SelectedAccount.password;
                            break;
                        case -1:
                            MessageBoxManager.Show("Failed to wipe profile", "Wipe failed", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -2:
                            MessageBoxManager.Show("Did not receive a response from the server. Please try again.", "No response", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                    }
                    break;
                case "startgame":
                    responseCode = MainWindow.Instance.__ProcM.LaunchGame();
                    switch (responseCode)
                    {
                        case 1:
                            break;
                        case -1:
                            MessageBoxManager.Show("Emulator Installed in official game", "Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -2:
                            MessageBoxManager.Show("Failed Starting Game Somethign goes wrong...", "Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -3:
                            MessageBoxManager.Show("EscapeFromTarkov.exe is missing", "File Missing Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                        case -4:
                            //Emulator not installed
                            break;
                        default:
                            MessageBoxManager.Show($"Something goes wrong and returned code {responseCode}", "Unknown Error!!", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
                            break;
                    }
                    break;
            }
        }

        internal void RegisterButtonClickEvent(object sender, RoutedEventArgs e)
        {
            switch (ApplyButtonAction)
            {
                case "startgame":
                    // Wipe
                    UpdateApplyButton("wipe");
                    break;
                case "login":
                    // Register
                    UpdateApplyButton("register");
                    break;
            }
            MainWindow.Instance._EditionSelectBox.Items.Clear();
            foreach (var edition in ServerManager.SelectedServer.editions)
                MainWindow.Instance._EditionSelectBox.Items.Add(edition);
            if (ServerManager.SelectedServer.editions.Length > 0)
                MainWindow.Instance._EditionSelectBox.SelectedIndex = 0;
            MainWindow.Instance._RegisterLoginField.Text = MainWindow.Instance._LoginField.Text;
            MainWindow.Instance._RegisterPasswordField.Password = MainWindow.Instance._PasswordField.Password;
        }
        internal void BackButtonClickEvent(object sender, RoutedEventArgs e)
        {
            switch (ApplyButtonAction)
            {
                case "connect":
                    break;
                case "login":
                    UpdateApplyButton("connect");
                    break;
                case "register":
                    UpdateApplyButton("login");
                    break;
                case "wipe":
                    UpdateApplyButton("startgame");
                    break;
                case "startgame":
                    UpdateApplyButton("login");
                    break;
            }
        }

        #region Interval Tick Timer
        internal static DispatcherTimer TickUpdater = new DispatcherTimer();
        internal void SetupIntervalUpdater(ProcessManager _procM) {
            TickUpdater.Tick += _Helper.Updater_Tick;
            TickUpdater.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            TickUpdater.Start();
        }
        #endregion
    }
}
