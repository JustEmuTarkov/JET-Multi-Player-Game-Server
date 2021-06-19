using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JET.OldLauncher
{
    class StaticData
    {
#if DEBUG
        public string working_dir = @"C:\Emu Tarkov\12.9.10988\original\Client"; // Change for debugging purposes
#else
        public string working_dir = Environment.CurrentDirectory;
#endif
        public string eft_managed = "EscapeFromTarkov_Data/Managed/";
        public string dll_ext = ".dll";
        public string exe_ext = ".exe";
        public string launcherConfigFile = "launcher.config.json";
        public string clientConfigFile = "client.config.json";
        public string eft_name = "EscapeFromTarkov";
        private string bsg_name = "Battlestate Games";
        public string logged_as = "Logged as: ";

        public string getExecutableArguments(string account, string id, string backendUrl) {
            string config = "{\"BackendUrl\":\"" + backendUrl + "\",\"Version\":\"live\"}";
            return $"-bC5vLmcuaS5u={account} -token={id} -config={config}";
        }

        public string[] install_GetFilesToDelete {
            get {
                return new string[]
                {
                    Path.Combine(working_dir, "BattlEye"),
                    Path.Combine(working_dir, "Logs"),
                    Path.Combine(working_dir, "EscapeFromTarkov_BE.exe"),
                    Path.Combine(working_dir, "Uninstall.exe"),
                    Path.Combine(working_dir, "UnityCrashHandler64.exe")
                };
            }
        }
        public string InstallInRegistry
        {
            get
            {
                return $@"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{eft_name}";
            }
        }
        public string SettingsInRegistry
        {
            get
            {
                return $@"Software\{bsg_name}\{eft_name}";
            }
        }
        public string GetTempPath {
            get 
            {
                return Path.Combine(Path.GetTempPath(), $@"{bsg_name}\{eft_name}");
            }
        }
        public string GetExecutableFile {
            get 
            {
                return $"{eft_name}{exe_ext}";
            }
        }

        public EXCEPTIONS_c EXCEPTIONS = new EXCEPTIONS_c();
        public URL_c URL = new URL_c();
        public LOG_c LOG = new LOG_c();
        public ERROR_MSG_c ERROR_MSG = new ERROR_MSG_c();
        public FORM_c FORM = new FORM_c();
        public STATUS_c STATUS = new STATUS_c();
#region Classes
        public class EXCEPTIONS_c {
            public string exception = "Exception";
            public string message = "Message"; 
            public string stackTrace = "StackTrace:";
            public string unknException = "Unknown Exception!";

        }
        public class URL_c
        {
            public string l_serverConnect = "/launcher/server/connect";
            public string l_profileLogin = "/launcher/profile/login";
            public string l_profileRegister = "/launcher/profile/register";
            public string l_profileRemove = "/launcher/profile/remove";
            public string l_profileGet = "/launcher/profile/get";
            public string l_profileChangeEmail = "/launcher/profile/change/email";
            public string l_profileChangePassword = "/launcher/profile/change/password";
            public string l_profileChangeWipe = "/launcher/profile/change/wipe";
        }
        public class LOG_c {
            public string logs = "Launcher_Logs";
            public string logs_ext = ".log";
            public string debug = "[Debug]";
            public string info = "[Info]";
            public string warning = "[Warning]";
            public string error = "[Error]";
        }
        public class STATUS_c
        {
            public string OK = "OK";
            public string FAILED = "FAILED";
        }
        public class FORM_c
        {
            public string refresh = "Refresh";
            public string goBack = "Go Back";
            public string addServer = "Add Server";
            public string connect = "Connect";
            public string createProfile = "Create Profile";
            public string login = "Login";
            public string register = "Register";
            public string logout = "Logout";
            public string changeEmail = "Change Email";
            public string changePassword = "Change Password";
            public string wipeProfile = "Wipe Profile";
            public string startGame = "START GAME";
        }
        public class ERROR_MSG_c
        {
            public string wrongEmailPassword = "Wrong email and/or password";
            public string connectionLost = "Cannot establish a connection to the server";
            public string startInstalledInLive = "JET shouldn't be installed into live game. Please make a copy of the gamefiles and install JET there.";
            public string senkoIsRetarded = "Escape From Tarkov isn't installed on your computer. Please buy a copy of the game and support the developers!";
            public string startNotFromGameDir = "The launcher is not running from the game directory";
            public string wipeFailed = "Wiping profile failed!!";
            public string changeEmailFailed = "Changing email failed!!";
            public string changePasswordFailed = "Changing password failed!!";
            public string serverAlreadyExist = "Server already exists";
            public string accountAlreadyExist = "Account already exists";
            public string noServers = "No servers available";
            public string checkFailed = "Check Failed!";
            public string noGameFound = "No game files found, assuming we are not in the game directory";
        }
#endregion
    }
}
