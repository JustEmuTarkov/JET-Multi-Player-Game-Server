using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JET.Launcher
{
    internal static class Global
    {
        internal static string LauncherName = "JET Launcher";
        internal static string LauncherVersion = "1.0.0";
        internal static string ServerLocation = "Not Found";
        internal static string ServerName = "Server.exe";
        internal static string WPF_NewLine = "&#xA;";
        internal static int LimitConsoleOutput = 30;

        internal static string TarkovExecutable => Path.Combine(Environment.CurrentDirectory, "EscapeFromTarkov.exe");

        internal static class PATH {
            internal static string ServerCache = @"user\cache";
            internal static string ServerMods = @"user\mods";
            internal static string ServerLogs = @"user\logs";
            internal static string GameLogs = "Logs";
        }

        internal static class URL {
            internal static string ServerConnect = "/launcher/server/connect";
            internal static string ProfileLogin = "/launcher/profile/login";
            internal static string ProfileRegister = "/launcher/profile/register";
            internal static string ProfileRemove = "/launcher/profile/remove";
            internal static string ProfileGet = "/launcher/profile/get";
            internal static string ProfileChangeEmail = "/launcher/profile/change/email";
            internal static string ProfileChangePassword = "/launcher/profile/change/password";
            internal static string ProfileChangeWipe = "/launcher/profile/change/wipe";
        }

        internal static class Server {
            public static string ModsFolderDir => Path.Combine(ServerLocation, PATH.ServerMods);

            internal static string LogsFolderDir => Path.Combine(ServerLocation, PATH.ServerLogs);

            internal static string CacheFolderDir => Path.Combine(ServerLocation, PATH.ServerCache);

            internal static string TempFolderDir_TarkovTemp => Path.Combine(Path.GetTempPath(), "Battlestate Games\\EscapeFromTarkov");
        }

    }
}
