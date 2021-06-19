using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JET.Launcher.Structures
{
    public class LauncherConfig
    {
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)] // Prevents duplicate local servers
        public List<string> Servers = new List<string> { "https://127.0.0.1:443" };
        public string Email = "";
        public string Password = "";
        public string ServerPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../"));
        public bool MinimizeToTray = true;
        public bool AutoStartServer = false;
    }
}
