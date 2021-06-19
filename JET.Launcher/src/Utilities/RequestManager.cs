using System;
using JET.Utilities.HTTP;
using JET.Utilities.App;
using JET.Launcher.Structures;

namespace JET.Launcher.Utilities
{
    internal class RequestManager
    {
        internal static bool ServerConnectedProperly = false;
        internal static bool OngoingRequest = false;
        internal static void Busy() { OngoingRequest = true; }
        internal static void Free() { OngoingRequest = false; }

        private static readonly Request request = new Request(null, "https://127.0.0.1:443", false);
        internal static string GetBackendUrl() => request.RemoteEndPoint;
        internal static void ChangeBackendUrl(string remoteEndPoint) => request.RemoteEndPoint = remoteEndPoint;
        internal static void ChangeSession(string session) => request.Session = session;
        internal static string Connect() => request.GetJson(Global.URL.ServerConnect);
        internal static string Connect(string backend) => request.GetJson(backend + Global.URL.ServerConnect);
        private static string Login(RequestData.Login data) => request.PostJson(Global.URL.ProfileLogin, Json.Serialize(data));
        private static string Register(RequestData.Register data) => request.PostJson(Global.URL.ProfileRegister, Json.Serialize(data));
        internal static string RemoveProfile(RequestData.Login data) => request.PostJson(Global.URL.ProfileRemove, Json.Serialize(data));
        internal static string WipeProfile(RequestData.Register data) => request.PostJson(Global.URL.ProfileChangeWipe, Json.Serialize(data));
        private static string GetAccount(RequestData.Login data) => request.PostJson(Global.URL.ProfileGet, Json.Serialize(data));
        private static string ChangeEmail(RequestData.Change data) => request.PostJson(Global.URL.ProfileChangeEmail, Json.Serialize(data));
        private static string ChangePassword(RequestData.Change data) => request.PostJson(Global.URL.ProfileChangePassword, Json.Serialize(data));
        public static AccountInfo SelectedAccount { get; private set; }
        internal static int ProfileLogin(string email, string password)
        {
            string json;
            try
            {
                var sendData = new RequestData.Login(email, password);
                var returnData = Login(sendData);
                if (returnData == "FAILED")
                    return -1;
                json = GetAccount(sendData);
            } catch {
                return -2;
            }
            
            SelectedAccount = Json.Deserialize<AccountInfo>(json);
            ChangeSession(SelectedAccount.id);

            return 1;
        }
        internal static int ProfileRegister(string email, string password, string edition) {
            var data = new RequestData.Register(email, password, edition);
            
            try
            {
                var registerStatus = Register(data);

                if (registerStatus != "OK")
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }

            var loginStatus = ProfileLogin(email, password);

            switch (loginStatus)
            {
                case -1:
                    return -3;
                case -2:
                    return -2;
                default:
                    return 1;
            }
        }
        internal static int Remove()
        {
            var data = new RequestData.Login(SelectedAccount.email, SelectedAccount.password);

            try
            {
                var json = GetAccount(data);

                if (json != "OK")
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }

            SelectedAccount = null;

            return 1;
        }

        internal static int ChangeEmail(string email)
        {
            var data = new RequestData.Change(SelectedAccount.email, SelectedAccount.password, email);

            try
            {
                var json = ChangeEmail(data);

                if (json != "OK")
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }

            SelectedAccount.email = email;
            MainWindow.Instance.__LauncherConfigL.Email = email;
            return 1;
        }
        internal static int ChangePassword(string password)
        {
            var data = new RequestData.Change(SelectedAccount.email, SelectedAccount.password, password);

            try
            {
                var json = ChangePassword(data);

                if (json != "OK")
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }

            SelectedAccount.password = password;
            MainWindow.Instance.__LauncherConfigL.Password = password;
            return 1;
        }
        internal static int Wipe(string edition)
        {
            var data = new RequestData.Register(SelectedAccount.email, SelectedAccount.password, edition);

            try
            {
                var json = WipeProfile(data);

                if (json != "OK")
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }
            return 1;
        }
    }
}
