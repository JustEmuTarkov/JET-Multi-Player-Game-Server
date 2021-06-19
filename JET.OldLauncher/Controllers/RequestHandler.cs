using JET.Utilities.App;
using JET.Utilities.HTTP;

namespace JET.OldLauncher
{
	public static class RequestHandler
	{
		private static readonly Request request = new Request(null, "");
		private static readonly StaticData staticData = new StaticData();
		public static string GetBackendUrl()
		{
			return request.RemoteEndPoint;
		}

		public static void ChangeBackendUrl(string remoteEndPoint)
		{
			request.RemoteEndPoint = remoteEndPoint;
		}

        public static void ChangeSession(string session)
        {
            request.Session = session;
        }

		public static string RequestConnect()
		{
			return request.GetJson(staticData.URL.l_serverConnect);
		}

		public static string RequestLogin(LoginRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileLogin, Json.Serialize(data));
		}

		public static string RequestRegister(RegisterRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileRegister, Json.Serialize(data));
		}

		public static string RequestRemove(LoginRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileRemove, Json.Serialize(data));
		}

		public static string RequestAccount(LoginRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileGet, Json.Serialize(data));
		}

		public static string RequestChangeEmail(ChangeRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileChangeEmail, Json.Serialize(data));
		}

		public static string RequestChangePassword(ChangeRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileChangePassword, Json.Serialize(data));
		}

		public static string RequestWipe(RegisterRequestData data)
		{
			return request.PostJson(staticData.URL.l_profileChangeWipe, Json.Serialize(data));
		}
	}
}
