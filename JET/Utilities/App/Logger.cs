using System;
using UnityEngine;

namespace JET.Utilities.App
{
    public class Logger
    {
        private static void Log(string type, string text)
        {
            Debug.LogError($"{type} | {text}");
        }

        public static void LogData(string text)
        {
            Debug.LogError($"{text}");
        }

        public static void LogInfo(string text)
        {
            Log("INFO", text);
        }

        public static void LogWarning(string text)
        {
            Log("WARNING", text);
        }

        public static void LogError(string text)
        {
            Log("ERROR", text);
        }
    }
}
