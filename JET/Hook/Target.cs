using NLog.Targets;
using JET.Utilities.Hook;

namespace JET.Hook
{
	[Target("JET")]
	public sealed class Target : TargetWithLayout
	{
		public Target()
		{
			Loader<Instance>.Load();
		}
	}
}
