using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public static class FileLogger
    {
        private static string _logFilePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["LogFilePath"]);
        private const long MaxLogFileSize = 50 * 1024 * 1024; // 50 MB

        // Check if the log file path is configured properly in Web.config
        static FileLogger()
        {
            if (string.IsNullOrEmpty(_logFilePath))
            {
                throw new InvalidOperationException("Log file path is not configured properly in Web.config.");
            }
        }

        public static void WriteLog(string folder, string message, LogLevel level = LogLevel.Info)
        {
            try
            {
                string fullFolderPath = Path.Combine(_logFilePath, folder);
                if (!Directory.Exists(fullFolderPath))
                {
                    Directory.CreateDirectory(fullFolderPath);
                }

                string logFileName = Path.Combine(fullFolderPath, $"{DateTime.Now:ddMMyyyy}.txt");

                // Check if the log file size exceeds the threshold (50 MB)
                if (File.Exists(logFileName) && new FileInfo(logFileName).Length > MaxLogFileSize)
                {
                    CompressLogFile(logFileName);
                }

                using (StreamWriter sw = new StreamWriter(logFileName, true))
                {
                    sw.WriteLine($"\n{DateTime.Now:dd/MM/yyyy HH:mm:ss} [{level}] --> {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log: {ex.Message}");
            }
        }

        private static void CompressLogFile(string logFileName)
        {
            try
            {
                string archiveFileName = Path.Combine(Path.GetDirectoryName(logFileName), $"{Path.GetFileNameWithoutExtension(logFileName)}_{DateTime.Now:yyyyMMdd_HHmmss}.zip");

                using (FileStream fs = new FileStream(archiveFileName, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry zipEntry = archive.CreateEntry(Path.GetFileName(logFileName));

                    using (StreamWriter writer = new StreamWriter(zipEntry.Open()))
                    using (StreamReader reader = new StreamReader(logFileName))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }

                File.Delete(logFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error compressing log file: {ex.Message}");
            }
        }
    }
}
