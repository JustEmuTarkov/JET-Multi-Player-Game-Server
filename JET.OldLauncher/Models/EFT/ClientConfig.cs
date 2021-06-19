namespace JET.OldLauncher
{
	public class ClientConfig
	{
		public string BackendUrl;
		public string Version;

		public ClientConfig()
		{
			BackendUrl = "https://127.0.0.1";
			Version = "live";
		}

		public ClientConfig(string backendUrl)
		{
			BackendUrl = backendUrl;
			Version = "live";
		}
	}
}
