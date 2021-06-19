namespace JET.OldLauncher
{
	public struct LoginRequestData
	{
		public string email;
		public string password;

		public LoginRequestData(string email, string password)
		{
			this.email = email;
			this.password = password;
		}
	}
}
