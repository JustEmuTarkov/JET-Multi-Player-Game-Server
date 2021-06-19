using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JET.Utilities.App;

namespace JET.OldLauncher
{
    public class ServerManager
    {
        public static ObservableCollection<ServerInfo> AvailableServers = new ObservableCollection<ServerInfo>();
        public static ServerInfo SelectedServer = new ServerInfo();

        static ServerManager()
        {
            // Update UI list
            AvailableServers.CollectionChanged += (sender, args) => Main.UpdateServerList();
        }
        public static bool requestSended = false;
        public static void SelectServer(int index)
        {
            if (index < 0 || index >= AvailableServers.Count)
            {
                SelectedServer = null;
                return;
            }
            SelectedServer = AvailableServers[index];
        }

        public static void LoadServer(string backendUrl)
        {
            string json;
            try
            {
                RequestHandler.ChangeBackendUrl(backendUrl);
                json = RequestHandler.RequestConnect();
            }
            catch
            {
                return;
            }
            if (!string.IsNullOrWhiteSpace(json))
                AvailableServers.Add(Json.Deserialize<ServerInfo>(json));
        }

        public static void LoadServers(string[] servers)
        {
            AvailableServers.Clear();

            foreach (string backendUrl in servers)
            {
                LoadServer(backendUrl);
            }
            requestSended = false;
        }
    }
}
