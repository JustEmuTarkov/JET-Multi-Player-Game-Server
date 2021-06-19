using System.Reflection;

namespace JET.Utilities.Patching
{
	public abstract class AbstractPatch
	{
		public string methodName;
		public BindingFlags flags;

		public abstract MethodInfo TargetMethod();
	}
}
