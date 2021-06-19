using JET.Launcher.Utilities;
using System;
using System.IO;

namespace JET.Launcher.Utilities
{
    /// <summary>
    /// LogManager
    /// </summary>
    public class LogManager
    {
        private static LogManager _instance;
        public static LogManager Instance => _instance ?? (_instance = new LogManager());
        private string filepath;
        public LogManager()
        {
            filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs_Launcher");
        }

        public void Write(string text)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var filename = Path.Combine(filepath, $"{DateTime.Now:yyyyMMdd}.log");
            File.AppendAllLines(filename, new[] { $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{text}" });
        }

        public void Debug(string text) => Write($"[Debug] {text}");

        public void Info(string text) => Write($"[Info] {text}");

        public void Warning(string text) => Write($"[Warning] {text}");

        public void Error(string text) => Write($"[Error] {text}");
    }
    
}
