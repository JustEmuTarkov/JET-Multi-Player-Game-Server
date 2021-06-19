using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace JET.Launcher.Utilities
{
    internal class FileManager
    {
        internal static FileManager Instance { get; private set; }
        internal FileManager() => Instance = this;
        private List<string> namesToFind = new List<string>()
        {
            "server.exe"
        };
        internal static void OpenDirectory(string path)
        {
            if (!Directory.Exists(path)) return;
            var startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }
        internal static bool DeleteDirectoryFiles(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    while (Directory.Exists(path)) Thread.Sleep(100);
                    Directory.CreateDirectory(path);
                    return true;
                }
            }
            catch (Exception deleteException)
            {
                MessageBoxManager.Show($"Error occured on deleting files\r\nMessage: {deleteException.Message}", "Error:", MessageBoxManager.Button.OK, MessageBoxManager.Image.Error);
            }
            return false;

        }
        internal string ScanToConfirmDirectory(string directory, bool only_local = false)
        {
            // Search in current folder //
            var files_in_folder = Directory.GetFiles(directory, "*.exe").ToList();
            foreach (var file_path in files_in_folder)
            {
                string filename = Path.GetFileName(file_path).ToLower();
                if (namesToFind.Contains(filename))
                {
                    return Path.GetDirectoryName(file_path);
                }
            }

            // Search
            directory = Path.GetFullPath(Path.Combine(directory, @"..\"));
            files_in_folder = Directory.GetFiles(directory, "*.exe").ToList();
            foreach (var file_path in files_in_folder)
            {
                string filename = Path.GetFileName(file_path).ToLower();
                if (namesToFind.Contains(filename))
                {
                    return Path.GetDirectoryName(file_path);
                }
            }

            return "Not found";
        }
        internal string CheckIfFileExistReturnDirectory(string directory)
        {
            var filesInCurrentDirectory = Directory.GetFiles(directory);
            for (var i = 0; i < filesInCurrentDirectory.Length; i++)
            {
                for (var fileId = 0; i < namesToFind.Count; fileId++)
                {
                    if (filesInCurrentDirectory[i] == namesToFind[fileId])
                        return directory;
                }
            }
            return "Not found";
        }
        internal void FindServerDirectory(string initialDirectory = "")
        {
            if (initialDirectory != "")
            {
                if (Directory.Exists(initialDirectory))
                {
                    Global.ServerLocation = ScanToConfirmDirectory(initialDirectory, true);
                    if (Global.ServerLocation != "Not found")
                    {
                        return;
                    }
                }
            }
            var LauncherDirectory = Environment.CurrentDirectory;
            // all lower case cause we lowercase() all names of files
            //check if folder exist in current directory
            Global.ServerLocation = ScanToConfirmDirectory(LauncherDirectory);

            //if (Global.ServerLocation == "Not found")// hangs start until user specify server location
            //{
            //    var prompt = MessageBox.Show("*_* I was unable to find the server. Please select your JET server folder.", "Can't find server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    if (prompt != DialogResult.OK)
            //        // Exited the prompt
            //        Environment.Exit(0);
            //    var dialog = new FolderBrowserDialog
            //    {
            //        SelectedPath = Environment.CurrentDirectory,
            //        ShowNewFolderButton = true,
            //        Description = "Select JET server"
            //    };
            //    var result = dialog.ShowDialog();
            //    if (result == DialogResult.OK)
            //        Global.ServerLocation = ScanToConfirmDirectory(dialog.SelectedPath, true);
            //    else
            //    {
            //        Global.ServerLocation = "Server Not Selected";
            //    }
            //}
        }
    }
}
