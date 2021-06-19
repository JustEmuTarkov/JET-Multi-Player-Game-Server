namespace JET.OldLauncher
{
	public class AccountInfo
	{
		public string id;
		public string nickname;
		public string email;
		public string password;
		public bool wipe;
		public string edition;

		public AccountInfo()
		{
			id = "";
			nickname = "";
			email = "";
			password = "";
			wipe = false;
			edition = "";
		}
	}
}
