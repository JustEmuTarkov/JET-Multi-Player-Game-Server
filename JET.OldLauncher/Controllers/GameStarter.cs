using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using JET.Utilities.App;
using System.Windows.Forms;

namespace JET.OldLauncher
{
    public class GameStarter
    {
        private StaticData staticData = new StaticData();
        public int LaunchGame(ServerInfo server, AccountInfo account)
        {
            if (IsInstalledInLive())
            {
                return -1;
            }

            SetupGameFiles();

            // TODO: check if files exists in game directory; in less retarded way
            bool isFilesMissing = false;
            if (!File.Exists($"EscapeFromTarkov_Data/Managed/0Harmony.dll"))
            {
                isFilesMissing = true;
                MessageBox.Show("Missing file: EscapeFromTarkov_Data/Managed/0Harmony.dll", "Missing Files!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!File.Exists($"EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll"))
            {
                isFilesMissing = true;
                MessageBox.Show("Missing file: EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll", "Missing Files!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!File.Exists($"EscapeFromTarkov_Data/Managed/NLog.dll.nlog"))
            {
                isFilesMissing = true;
                MessageBox.Show("Missing file: EscapeFromTarkov_Data/Managed/NLog.dll.nlog", "Missing Files!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!File.Exists($"EscapeFromTarkov_Data/Managed/NLog.JET.dll"))
            {
                isFilesMissing = true;
                MessageBox.Show("Missing file: EscapeFromTarkov_Data/Managed/NLog.JET.dll", "Missing Files!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (isFilesMissing)
                return -4;

            if (account.wipe)
            {
                RemoveRegisteryKeys();
                CleanTempFiles();
            }

            if (!File.Exists(staticData.GetExecutableFile))
            {
                return -3;
            }

            ProcessStartInfo clientProcess = new ProcessStartInfo(staticData.GetExecutableFile)
            {
                Arguments = staticData.getExecutableArguments(GenerateToken(account), account.id, ServerManager.SelectedServer.backendUrl),
                UseShellExecute = false,
                WorkingDirectory = staticData.working_dir
        };

        Process.Start(clientProcess);
            return 1;
        }

    private bool IsInstalledInLive()
    {
        // TODO: rework this shit

        var value0 = false;

        try
        {
            var value1 = Registry.LocalMachine.OpenSubKey(staticData.InstallInRegistry, false).GetValue("UninstallString");
            var value2 = (value1 != null) ? value1.ToString() : "";
            var value3 = new FileInfo(value2);
            var value4 = new FileInfo[]
            {
                    new FileInfo(value2.Replace(value3.Name, @"JET Launcher.exe")),
                    new FileInfo(value2.Replace(value3.Name, @"EscapeFromTarkov_Data\Managed\0Harmony.dll")),
                    new FileInfo(value2.Replace(value3.Name, @"EscapeFromTarkov_Data\Managed\NLog.dll.nlog")),
                    new FileInfo(value2.Replace(value3.Name, @"EscapeFromTarkov_Data\Managed\Nlog.JET.dll"))
            };

            foreach (var value in value4)
            {
                if (File.Exists(value.FullName))
                {
                    File.Delete(value.FullName);
                    value0 = true;
                }
            }

            if (value0)
            {
                File.Delete(@"EscapeFromTarkov_Data\Managed\Assembly-CSharp.dll");
            }
        }
        catch
        {
        }

        return value0;
    }

    private void SetupGameFiles()
    {
        foreach (string file in staticData.install_GetFilesToDelete)
        {
            try
            {
                if (Directory.Exists(file))
                {
                    Directory.Delete(file, true);
                }

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception) { MessageBox.Show("Something got fucked up. I could not delete a file:\r\n" + file, "Deletion Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }

    private int IsPiratedCopy()
    {
        // THIS IS DUMB !!!!

        return 0;
    }

    private void RemoveRegisteryKeys()
    {
        try
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(staticData.SettingsInRegistry, true);

            foreach (string value in key.GetValueNames())
            {
                key.DeleteValue(value);
            }
        }
        catch
        {
        }
    }

    private void CleanTempFiles()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(staticData.GetTempPath);

        if (!Directory.Exists(staticData.GetTempPath))
        {
            return;
        }

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            file.Delete();
        }

        foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
        {
            directory.Delete(true);
        }
    }

    private string GenerateToken(AccountInfo data)
    {
        return $"{Json.Serialize(new LoginToken(data.email, data.password))}=";
    }
}
}
