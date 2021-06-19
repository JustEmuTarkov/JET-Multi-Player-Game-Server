using JET.Launcher.Structures;
using JET.Utilities.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JET.Launcher.Utilities
{
    class LauncherConfigLoader
    {
        public static LauncherConfigLoader Instance;
        internal LauncherConfigLoader()
        {
            Instance = this;
            if (ConfigFileExists())
                Load();
            else
            {
                Save(new LauncherConfig());
                Load();
            }
        }
        private LauncherConfig launcherConfig;
        internal string GetServerLocation => launcherConfig.ServerPath;

        internal string Email
        {
            get => launcherConfig.Email;
            set
            {
                launcherConfig.Email = value;
                Save();
            }
        }
        internal string Password
        {
            get => launcherConfig.Password;
            set
            {
                launcherConfig.Password = value;
                Save();
            }
        }
        internal bool StartServerAtLaunch()
        {
            return launcherConfig.AutoStartServer;
        }
        internal void ChangeStartServerAtLaunch(bool set)
        {
            launcherConfig.AutoStartServer = set;
            Save();
        }
        internal void ChangeServerAtLaunch(bool change)
        {
            launcherConfig.AutoStartServer = change;
            Save();
        }
        internal void ChangeServerLocation(string location)
        {
            launcherConfig.ServerPath = location;
            Save();
        }
        internal List<string> GetServers()
        {
            return new List<string>(launcherConfig.Servers); // Copy in order to prevent collection modification during iteration
        }
        internal int GetServersCount()
        {
            return launcherConfig.Servers.Count;
        }
        internal void AddServer(string BackendUrl)
        {
            var split = BackendUrl.Replace("https://", "").Split(':');
            var port = 0;
            if (split.Length > 1)
                int.TryParse(split[1].Replace("/", ""), out port);
            var checkForLocalHost1 = false;
            var checkForLocalHost2 = false;
            if (BackendUrl.Contains("localhost"))
                if (port > 0)
                    checkForLocalHost1 =
                        launcherConfig.Servers.Any(x => Regex.IsMatch(x, $"(localhost)((:{port})(\\/?))?$"));
                else
                    checkForLocalHost1 = launcherConfig.Servers.Any(x => x.Contains("localhost"));

            if (BackendUrl.Contains("127.0.0.1"))
                if (port > 0)
                    checkForLocalHost2 = launcherConfig.Servers.Any(x => Regex.IsMatch(x, $"(127.0.0.1)((:{port})(\\/?))?$"));
                else
                    checkForLocalHost2 = launcherConfig.Servers.Any(x => x.Contains("127.0.0.1"));
            if (launcherConfig.Servers.Contains(BackendUrl) || checkForLocalHost1 || checkForLocalHost2) return;
            lock(launcherConfig.Servers)
                launcherConfig.Servers.Add(BackendUrl);
            ServerManager.LoadServerFromDifferentBackend(BackendUrl, true);
            Save();
        }
        internal void RemoveServer(int index)
        {
            if (launcherConfig.Servers.Count <= 1) return;
            lock (launcherConfig.Servers)
                launcherConfig.Servers.RemoveAt(index);
            Save();
        }
        internal void RemoveServer(string BackendUrl)
        {
            lock (launcherConfig.Servers)
            {
                for (var i = 0; i < launcherConfig.Servers.Count; i++)
                {
                    if (launcherConfig.Servers[i] != BackendUrl) continue;
                    launcherConfig.Servers.RemoveAt(i);
                    Save();
                }
            }
        }
        internal bool ConfigFileExists() => File.Exists(Path.Combine(Environment.CurrentDirectory, "launcher.config.json"));
        internal void Load()
        {
            launcherConfig = Json.Load<LauncherConfig>(Path.Combine(Environment.CurrentDirectory, "launcher.config.json"));
        }

        internal void Save(LauncherConfig data)
        {
            Json.Save(Path.Combine(Environment.CurrentDirectory, "launcher.config.json"), data);
        }
        private void Save()
        {
            Json.Save(Path.Combine(Environment.CurrentDirectory, "launcher.config.json"), launcherConfig);
        }
    }
}
