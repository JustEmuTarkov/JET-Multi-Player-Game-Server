using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JET.Utilities.App;

namespace JET.OldLauncher
{
    public partial class Main : Form
    {
        private static Main Instance;
        private LauncherConfig launcherConfig;
        private ProcessMonitor monitor;
        private Account accountManager;
        private GameStarter gameStarter;
        private static readonly StaticData sD = new StaticData(); // considered as string translator
        private static int _processedAction = 0;
        #region INIT Functions
        public Main()
        {
            Instance = this;
            InitializeComponent();
            InitializeLauncher();
            //UpdateTick.Enabled = true;
            UpdateTick.Start();
            //_processedAction = 0;

            Closing += (sender, args) => JsonHandler.SaveLauncherConfig(launcherConfig);
        }

        public static void UpdateServerList()
        {
            var servers = ServerManager.AvailableServers;
            if (Instance.Field_SelectServer.InvokeRequired)
            {
                Instance.Field_SelectServer.Invoke(new Action(UpdateServerList));
                return;
            }

            var wasEmpty = Instance.Field_SelectServer.Items.Count <= 0;
            var isEmpty = servers.Count <= 0;

            var selected = Instance.Field_SelectServer.SelectedItem?.ToString();
            var serverNames = servers.Select(x => x.name).ToArray();
            var newSelectedIndex = -1;

            if (serverNames.Contains(selected))
                newSelectedIndex = Array.IndexOf(serverNames, selected);
            else if (wasEmpty && !isEmpty)
                newSelectedIndex = 0;


            Instance.Field_SelectServer.Items.Clear();
            Instance.Field_SelectServer.Items.AddRange(serverNames.ToArray<object>());
            Instance.Field_SelectServer.SelectedIndex = newSelectedIndex;

            if (isEmpty && _processedAction == 0)
            {
                Instance.Field_SelectServer.Text = sD.ERROR_MSG.noServers;
                Instance.BTN_Process.Enabled = false;
            }
            else if (wasEmpty)
                Instance.BTN_Process.Enabled = true;

            ServerManager.SelectServer(newSelectedIndex);
        }
        private void InitializeLauncher()
        {
            launcherConfig = JsonHandler.LoadLauncherConfig();
            monitor = new ProcessMonitor(sD.eft_name, 1000, aliveCallback: null, exitCallback: GameExitCallback);
            accountManager = new Account(launcherConfig);
            gameStarter = new GameStarter();

            if (launcherConfig.Servers.Count == 0)
            {
                launcherConfig.Servers.Add("https://127.0.0.1");
                JsonHandler.SaveLauncherConfig(launcherConfig);
            }
        }
        #endregion
        /*
        initially there is Connect Button (not enabled) after server goes active then it should be enabled
        0 - Main=>			Connect,Refresh(justFunction),AddServer
        1 - AddServer=>		ViewServers(goBack),Add(confirmation);
        2 - Connect=>		Register, Login, GoBackToServers??;
        3 - Register=>		Connect(goBack), Register(confirmation);
        4 - Login=>			Logout()closeSession+goBack), Change, ChangeEmail, Wipe profile, Start(runGame)
        5 - Change=>		Back, Change(confirmation)
        6 - ChangeEmail=>	Back, Change(confirmation)
        7 - WipeProfile=>	Back, Wipe(confirmation)
        */
        ///<summary>
        /// Set Names and Visibility depends on string content passed in. [sBtn => Side Button]
        ///</summary>
        private void _SetButtonNames(string sBtn_1, string sBtn_2, string sBtn_3, string sBtn_4, string processBtn = "")
        {
            BTN_Side_1.Text = sBtn_1;
            BTN_Side_1.Visible = sBtn_1 != "";
            BTN_Side_2.Text = sBtn_2;
            BTN_Side_2.Visible = sBtn_2 != "";
            BTN_Side_3.Text = sBtn_3;
            BTN_Side_3.Visible = sBtn_3 != "";
            BTN_Side_4.Text = sBtn_4;
            BTN_Side_4.Visible = sBtn_4 != "";
            BTN_Process.Text = processBtn;
            //BTN_Process.Visible = processBtn != "";
        }
        ///<summary>
        /// Set Object Visibility. Email,Password,Edition,Server,Url fields with labels
        ///</summary>
        private void _SetObjVisibility(bool EmailField, bool PasswordField, bool EditionField, bool ServerField, bool UrlField)
        {
            Label_Email.Visible = EmailField;
            Field_Email.Visible = EmailField;
            Label_Password.Visible = PasswordField;
            Field_Password.Visible = PasswordField;
            BTN_Show_Password.Visible = PasswordField;
            Label_SelectEdition.Visible = EditionField;
            Field_SelectEdition.Visible = EditionField;
            Label_Server.Visible = ServerField;
            Field_SelectServer.Visible = ServerField;
            Label_Url.Visible = UrlField;
            Field_AddServer.Visible = UrlField;
        }
        ///<summary>
        /// Processing Main Button Functionality depends on Scene we are in.
        ///</summary>
        private void ProcessMainButtonFunction(object sender, EventArgs e)
        {
            //var button = sender as Button;
            switch (_processedAction)
            {
                case 0:
                    if (launcherConfig.Email == "" || launcherConfig.Password == "")
                    {
                        _processedAction = 3;
                        break;
                    }
                    _processedAction = 2;
                    break;
                case 1:
                    _processedAction = 0;
                    _AddServer();
                    _RefreshServerList();
                    break;
                case 2:
                    _Login();
                    break;
                case 3:
                    _processedAction = 2;
                    _Register();
                    break;
                case 4:
                    _StartGame();
                    break;
                case 5:
                    _processedAction = 4;
                    _ProfileChangePassword();
                    break;
                case 6:
                    _processedAction = 4;
                    _ProfileChangeEmail();
                    break;
                case 7:
                    _processedAction = 4;
                    _ProfileWipe();
                    break;

                default:
                    return;
            }

        }
        private void SetLoggedAs(bool v)
        {
            if (v)
            {
                LBL_LoginAs.Visible = true;
                LBL_LoginAs.Text = sD.logged_as + accountManager.SelectedAccount.email;
                BTN_GenLaunchArgs.Enabled = true;
                Text_LaunchArgs.Enabled = true;
            }
            else
            {
                BTN_GenLaunchArgs.Enabled = false;
                Text_LaunchArgs.Enabled = false;
                LBL_LoginAs.Visible = false;
            }
        }
        ///<summary>
        /// Set Names of Buttons (sub's and main one's)
        ///</summary>
        private void ButtonNameAssigner()
        {
            switch (_processedAction)
            {
                case 0:
                    _SetButtonNames(sD.FORM.refresh, sD.FORM.addServer, "", "", sD.FORM.connect);
                    return;
                case 1:
                    _SetButtonNames(sD.FORM.goBack, "", "", "", sD.FORM.addServer);
                    return;
                case 2:
                    _SetButtonNames(sD.FORM.createProfile, sD.FORM.goBack, "", "", sD.FORM.login);
                    BTN_GenLaunchArgs.Enabled = false;
                    return;
                case 3:
                    _SetButtonNames(sD.FORM.goBack, "", "", "", sD.FORM.register);
                    return;
                case 4:
                    _SetButtonNames(sD.FORM.logout, sD.FORM.changePassword, sD.FORM.changeEmail, sD.FORM.wipeProfile, sD.FORM.startGame);
                    BTN_GenLaunchArgs.Enabled = true;
                    return;
                case 5:
                    _SetButtonNames(sD.FORM.goBack, "", "", "", sD.FORM.changePassword);
                    return;
                case 6:
                    _SetButtonNames(sD.FORM.goBack, "", "", "", sD.FORM.changeEmail);
                    return;
                case 7:
                    _SetButtonNames(sD.FORM.goBack, "", "", "", sD.FORM.wipeProfile);
                    return;
                default:
                    _SetButtonNames("", "", "", "", "");
                    return;
            }
        }
        ///<summary>
        /// Display Input/Select/Label Objects Visibility depends on SceneID
        ///</summary>
        private void InputVisAssigner()
        {
            switch (_processedAction)
            {
                case 0:
                    _SetObjVisibility(false, false, false, true, false);
                    return;
                case 1:
                    _SetObjVisibility(false, false, false, false, true);
                    return;
                case 2:
                    _SetObjVisibility(true, true, false, false, false);
                    // additional setup
                    Field_Email.Text = launcherConfig.Email;
                    Field_Password.Text = launcherConfig.Password;
                    return;
                case 3:
                    _SetObjVisibility(true, true, true, false, false);
                    Field_SelectEdition.Items.Clear();
                    if (ServerManager.SelectedServer == null)
                    {
                        _RefreshServerList();
                        if (ServerManager.SelectedServer == null)
                        {
                            MessageBox.Show("Selected Server is still 'null' !!!!");
                            return;
                        }

                    }

                    foreach (string edition in ServerManager.SelectedServer.editions)
                    {
                        Field_SelectEdition.Items.Add(edition);
                    }
                    Field_SelectEdition.SelectedIndex = 0;
                    return;
                case 4:
                    _SetObjVisibility(false, false, false, false, false);
                    return;
                case 5:
                    _SetObjVisibility(false, true, false, false, false);
                    Field_Email.Text = launcherConfig.Email;
                    return;
                case 6:
                    _SetObjVisibility(true, false, false, false, false);
                    Field_Password.Text = launcherConfig.Password;
                    return;
                case 7:
                    _SetObjVisibility(false, false, true, false, false);
                    return;
                default:
                    _SetObjVisibility(false, false, false, false, false);
                    return;
            }
        }
        #region Functions
        /*private void _Connect() { 
            // not used cause its embeded :)
        }*/
        private void _Login()
        {
            int status = accountManager.Login(Field_Email.Text, Field_Password.Text);

            switch (status)
            {
                case 1:
                    _processedAction = 4;
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.wrongEmailPassword);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.connectionLost);
                    return;
                default: return;
            }
        }
        private void _StartGame()
        {
            int status = gameStarter.LaunchGame(ServerManager.SelectedServer, accountManager.SelectedAccount);

            switch (status)
            {
                case 1:
                    monitor.Start();

                    if (launcherConfig.MinimizeToTray)
                    {
                        TrayIcon.Visible = true;
                        Hide();
                    }
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.startInstalledInLive);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.senkoIsRetarded);
                    return;

                case -3:
                    MessageBox.Show(sD.ERROR_MSG.startNotFromGameDir);
                    return;
                case -4:
                default:
                    return;
            }
        }
        private void _ProfileWipe()
        {
            int status = accountManager.Wipe((string)Field_SelectEdition.SelectedItem);

            switch (status)
            {
                case 1:
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.wipeFailed);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.connectionLost);
                    return;
            }
        }
        private void _ProfileChangeEmail()
        {
            int status = accountManager.ChangeEmail(Field_Email.Text);

            switch (status)
            {
                case 1:
                    // OK!!
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.changeEmailFailed);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.connectionLost);
                    return;
            }
        }
        private void _ProfileChangePassword()
        {
            int status = accountManager.ChangePassword(Field_Password.Text);

            switch (status)
            {
                case 1:
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.changePasswordFailed);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.connectionLost);
                    return;
            }
        }
        private void _AddServer()
        {
            if (launcherConfig.Servers.Contains(Field_AddServer.Text))
            {
                MessageBox.Show(sD.ERROR_MSG.serverAlreadyExist);
                return;
            }

            launcherConfig.Servers.Add(Field_AddServer.Text);
        }
        private void _Register()
        {
            int status = accountManager.Register(Field_Email.Text, Field_Password.Text, (string)Field_SelectEdition.SelectedItem);
            switch (status)
            {
                case 1:
                    return;

                case -1:
                    MessageBox.Show(sD.ERROR_MSG.accountAlreadyExist);
                    return;

                case -2:
                    MessageBox.Show(sD.ERROR_MSG.connectionLost);
                    return;

                case -3:
                    MessageBox.Show(sD.ERROR_MSG.wrongEmailPassword);
                    return;
            }
        }
        private void _RefreshServerList()
        {
            ServerManager.requestSended = true;
            Task.Run(() => ServerManager.LoadServers(launcherConfig.Servers.ToArray()));
        }
        #endregion
        #region Side Buttons Helpers
        /// <summary>
        /// Side Button number 1, Handles Refresh servers, Register, Logout, all sort of Go back Btn's
        /// </summary>
        private void SideButton_1_Click(object sender, EventArgs e)
        {
            switch (_processedAction)
            {
                case 0:
                    _RefreshServerList();
                    return;
                case 1:
                    _processedAction = 0;
                    if (ServerManager.AvailableServers.Count <= 0) // Disable connect button
                        BTN_Process.Enabled = false;
                    // Back button
                    break;
                case 2:
                    _processedAction = 3;
                    // Register
                    break;
                case 3:
                    _processedAction = 2;
                    // Back button
                    break;
                case 4:
                    _processedAction = 2; // go back to login
                    // no logout scripts here lol. Session remains at the server...
                    break;
                case 5:
                    _processedAction = 4;
                    // Back button
                    break;
                case 6:
                    _processedAction = 4;
                    // Back button
                    break;
                case 7:
                    _processedAction = 4;
                    // Back button
                    break;
                default: return;
            }
        }
        /// <summary>
        /// Side Button number 2, Handles Add Server and Change Password
        /// </summary>
        private void SideButton_2_Click(object sender, EventArgs e)
        {
            switch (_processedAction)
            {
                case 0:
                    _processedAction = 1;
                    BTN_Process.Enabled = true; // Enable "Add Server" button
                    break;
                case 2:
                    _processedAction = 0;
                    // maybe go back button ? to select server again ??
                    return;
                case 4:
                    _processedAction = 5;
                    break;
                default: return;
            }
        }
        /// <summary>
        /// Side Button number 3, Handles only Change Email
        /// </summary>
        private void SideButton_3_Click(object sender, EventArgs e)
        {
            switch (_processedAction)
            {
                case 4:
                    _processedAction = 6;
                    break;
                default: return;
            }
        }
        /// <summary>
        /// Side Button number 4, Handles only Wipe Button
        /// </summary>
        private void SideButton_4_Click(object sender, EventArgs e)
        {
            switch (_processedAction)
            {
                case 4:
                    _processedAction = 7;
                    Field_SelectEdition.Items.Clear();
                    if (ServerManager.SelectedServer == null)
                    {
                        _RefreshServerList();
                        if (ServerManager.SelectedServer == null)
                        {
                            MessageBox.Show("Selected Server is still 'null' !!!!");
                            return;
                        }
                    }

                    foreach (string edition in ServerManager.SelectedServer.editions)
                    {
                        Field_SelectEdition.Items.Add(edition);
                    }
                    Field_SelectEdition.SelectedIndex = 0;
                    break;
                default: return;
            }
        }
        #endregion
        #region Special Functions
        private void GameExitCallback(ProcessMonitor monitor)
        {
            monitor.Stop();
            Show();
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                TrayIcon.Visible = false;
        }
        #endregion
        private void BTN_GenLaunchArgs_Click(object sender, EventArgs e)
        {
            if (accountManager != null)
            {
                if (accountManager.SelectedAccount != null)
                {
                    var account = accountManager.SelectedAccount;
                    Text_LaunchArgs.Text = sD.getExecutableArguments(
                        $"{Json.Serialize(new LoginToken(account.email, account.password))}=",
                        account.id,
                        ServerManager.SelectedServer.backendUrl);
                }
            }
        }
        private int _previousAction = -1;
        private void FormUpdate(object sender, EventArgs e)
        {
            if (_previousAction != _processedAction)
            {
                ButtonNameAssigner();
                InputVisAssigner();
                SetLoggedAs(_processedAction >= 4);
                _previousAction = _processedAction;
            }
            ServerAutoCheck();
        }
        private void ServerAutoCheck()
        {
            if (!ServerManager.requestSended)
            {
                if (ServerManager.AvailableServers.Count <= 0)
                {
                    Task.Factory.StartNew(() => _RefreshServerList());
                }
                else
                {
                    if (Field_SelectServer.Items.Count <= 0)
                    {
                        Field_SelectServer.Items.Clear();
                        foreach (ServerInfo server in ServerManager.AvailableServers)
                        {
                            Field_SelectServer.Items.Add(server.name);
                        }

                        if (Field_SelectServer.Items.Count > 0)
                        {
                            Field_SelectServer.SelectedIndex = 0;
                            ServerManager.SelectServer(0);
                            if (_processedAction == 0) BTN_Process.Enabled = true;
                        }
                        else
                        {
                            Field_SelectServer.Text = sD.ERROR_MSG.noServers;
                            if (_processedAction == 0) BTN_Process.Enabled = false;
                        }
                    }
                }
            }
        }

        private void BTN_Show_Password_Click(object sender, EventArgs e)
        {
            if (launcherConfig.HidePassword)
            {
                // Show password
                launcherConfig.HidePassword = false;
                BTN_Show_Password.Image = Launcher.Properties.Resources.eye;
                Field_Password.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                launcherConfig.HidePassword = true;
                BTN_Show_Password.Image = Launcher.Properties.Resources.eyecross;
                Field_Password.UseSystemPasswordChar = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BTN_Show_Password.Image = launcherConfig.HidePassword
                ? Launcher.Properties.Resources.eyecross
                : Launcher.Properties.Resources.eye;
            Field_Password.UseSystemPasswordChar = launcherConfig.HidePassword;
        }
    }
}
