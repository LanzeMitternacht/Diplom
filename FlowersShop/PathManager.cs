using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FlowersShop
{
    public static class PathManager
    {
        private static readonly string ApplicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        public static string DataDirectory => EnsureDirectoryExists(Path.Combine(ApplicationDirectory, "Data"));
        public static string BarcodeDirectory => EnsureDirectoryExists(Path.Combine(DataDirectory, "Barcode"));
        public static string QrCodeDirectory => EnsureDirectoryExists(Path.Combine(DataDirectory, "QrCode"));
        public static string ReportsDirectory => EnsureDirectoryExists(Path.Combine(DataDirectory, "Reports"));
        public static string BackupDirectory => EnsureDirectoryExists(Path.Combine(DataDirectory, "Backup"));
        public static string LogsDirectory => EnsureDirectoryExists(Path.Combine(DataDirectory, "Logs"));
        
        public static string ConfigFile => Path.Combine(ApplicationDirectory, "FlowersShop.exe.config");
        
        public static string GetBarcodePath(string productName)
        {
            var fileName = SanitizeFileName(productName) + ".png";
            return Path.Combine(BarcodeDirectory, fileName);
        }
        
        public static string GetQrCodePath(string staffName)
        {
            var fileName = SanitizeFileName(staffName) + ".png";
            return Path.Combine(QrCodeDirectory, fileName);
        }
        
        public static string GetReportPath(string reportName)
        {
            var fileName = SanitizeFileName(reportName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
            return Path.Combine(ReportsDirectory, fileName);
        }
        
        public static string GetBackupPath()
        {
            var fileName = "FlowerShop_Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            return Path.Combine(BackupDirectory, fileName);
        }
        
        public static string GetLogPath()
        {
            var fileName = "FlowersShop_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            return Path.Combine(LogsDirectory, fileName);
        }
        
        public static string GetSystemFontPath(string fontName = "arial.ttf")
        {
            var systemFontsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontName);
            if (File.Exists(systemFontsPath))
                return systemFontsPath;
            
            var alternatePaths = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Fonts", fontName),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Fonts", fontName),
                Path.Combine(ApplicationDirectory, "Fonts", fontName)
            };
            
            foreach (var path in alternatePaths)
            {
                if (File.Exists(path))
                    return path;
            }
            
            return systemFontsPath;
        }
        
        private static string EnsureDirectoryExists(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Не удалось создать директорию: {path}", ex);
            }
            return path;
        }
        
        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return "unnamed";
                
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (var invalidChar in invalidChars)
            {
                fileName = fileName.Replace(invalidChar, '_');
            }
            
            fileName = fileName.Replace(' ', '_')
                              .Replace("\\", "_")
                              .Replace("/", "_");
            
            if (fileName.Length > 100)
                fileName = fileName.Substring(0, 100);
                
            return fileName;
        }
        
        public static bool IsDirectoryWritable(string directoryPath)
        {
            try
            {
                var testFile = Path.Combine(directoryPath, "test_write_" + Guid.NewGuid().ToString() + ".tmp");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public static string GetFileSize(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                    return "Файл не найден";
                    
                var size = fileInfo.Length;
                string[] sizes = { "Б", "КБ", "МБ", "ГБ" };
                int order = 0;
                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size = size / 1024;
                }
                
                return $"{size:0.##} {sizes[order]}";
            }
            catch
            {
                return "Неизвестно";
            }
        }
    }
} 