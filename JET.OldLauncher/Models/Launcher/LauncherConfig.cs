using System;
using System.Collections.Generic;

namespace JET.OldLauncher
{
	public class LauncherConfig
	{
		public List<string> Servers;
		public string Email;
		public string Password;
        public string GamePath;
		public bool MinimizeToTray;
        public bool HidePassword;

        public LauncherConfig()
		{
			Servers = new List<string>();
			Email = "";
			Password = "";
			GamePath = new StaticData().working_dir;
			MinimizeToTray = true;
            HidePassword = true;
        }
	}
}
