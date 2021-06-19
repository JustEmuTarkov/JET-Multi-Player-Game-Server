using System;
using System.IO;

namespace JET.OldLauncher.Controllers
{
    /// <summary>
    /// LogManager
    /// </summary>
    public class LogManager
    {
        private static LogManager _instance;
        public static LogManager Instance => _instance ?? (_instance = new LogManager());
        private string filepath;
        private static StaticData staticData = new StaticData();
        public LogManager()
        {
            filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, staticData.LOG.logs);
        }

        public void Write(string text)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string filename = Path.Combine(filepath, $"{DateTime.Now:yyyyMMdd}{staticData.LOG.logs_ext}");
            File.AppendAllLines(filename, new []{ $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{text}" });
        }

        public void Debug(string text) => Write($"{staticData.LOG.debug}{text}");

        public void Info(string text)=> Write($"{staticData.LOG.info}{text}");

        public void Warning(string text) => Write($"{staticData.LOG.warning}{text}");

        public void Error(string text) => Write($"{staticData.LOG.error}{text}");
    }
}
