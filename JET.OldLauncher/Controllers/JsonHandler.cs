using System;
using System.IO;
using JET.Utilities.App;

namespace JET.OldLauncher
{
	public static class JsonHandler
	{
		private static readonly string filepath;
		private static StaticData staticData = new StaticData();
		static JsonHandler()
		{
			filepath = staticData.working_dir;
		}

		public static LauncherConfig LoadLauncherConfig()
		{
			return Json.Load<LauncherConfig>(Path.Combine(filepath, staticData.launcherConfigFile));
		}

		public static void SaveLauncherConfig(LauncherConfig data)
		{
			Json.Save(Path.Combine(filepath, staticData.launcherConfigFile), data);
		}

		public static ClientConfig LoadClientConfig()
		{
			return Json.Load<ClientConfig>(Path.Combine(filepath, staticData.clientConfigFile));
		}

		public static void SaveClientConfig(ClientConfig data)
		{
			Json.Save(Path.Combine(filepath, staticData.clientConfigFile), data);
		}
	}
}
