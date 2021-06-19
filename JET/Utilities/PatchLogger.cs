using System.Reflection;
using UnityEngine;

namespace JET.Utilities
{
    public class PatchLogger
    {
        public static void LogTranspileSearchError(MethodBase transpileMethod)
        {
            Debug.LogError(GetErrorHeader(transpileMethod) + "Could not find reference code.");
        }

        public static void LogPatchErrorWithMessage(MethodBase method, string message)
        {
            Debug.LogError(GetErrorHeader(method) + message);
        }

        private static string GetErrorHeader(MethodBase method)
        {
            return "Patch " + method.DeclaringType.Name + "failed: ";
        }
    }
}
