using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace JET.Utilities.Patching
{
	public static class PatcherUtil
	{
		private static Harmony harmony;

		static PatcherUtil()
		{
			harmony = new Harmony("com.[JET]");
		}

		public static MethodInfo GetOriginalMethod<T>(string methodName)
		{
			return AccessTools.Method(typeof(T), methodName);
		}
		
		public static void PatchPrefix<T>() where T : AbstractPatch, new()
        {
			harmony.Patch(new T().TargetMethod(), prefix: new HarmonyMethod(typeof(T).GetMethod("Prefix")));
			Debug.LogError("[JET]: Applied prefix patch " + typeof(T).Name);
		}

		public static void PatchPostfix<T>() where T : AbstractPatch, new()
        {
			harmony.Patch(new T().TargetMethod(), postfix: new HarmonyMethod(typeof(T).GetMethod("Postfix")));
			Debug.LogError("[JET]: Applied postfix patch " + typeof(T).Name);
		}

		public static void Patch<T>() where T : GenericPatch<T>, new()
		{
			try
			{
				var patch = new T();
				if (patch.TargetMethod == null)
					throw new InvalidOperationException("TargetMethod is null");

				harmony.Patch(patch.TargetMethod,
							  prefix: patch.Prefix.ToHarmonyMethod(),
							  postfix: patch.Postfix.ToHarmonyMethod(),
							  transpiler: patch.Transpiler.ToHarmonyMethod(),
							  finalizer: patch.Finalizer.ToHarmonyMethod());
				Debug.LogError("[JET]: Applied patch " + typeof(T).Name);
			}
			catch (Exception ex)
			{
				Debug.LogError($"[JET]: Error in patch {typeof(T).Name}{Environment.NewLine}{ex}");
			}
		}
	}

	static class Extensions
	{
		public static HarmonyMethod ToHarmonyMethod(this MethodInfo methodInfo)
		{
			return methodInfo != null 
				? new HarmonyMethod(methodInfo)
				: null;
		}
	}
}
