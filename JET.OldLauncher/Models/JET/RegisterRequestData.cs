namespace JET.OldLauncher
{
	public struct RegisterRequestData
	{
		public string email;
		public string password;
		public string edition;

		public RegisterRequestData(string email, string password, string edition)
		{
			this.email = email;
			this.password = password;
			this.edition = edition;
		}
	}
}
