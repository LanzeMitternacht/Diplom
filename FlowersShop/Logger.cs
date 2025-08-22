using System;
using System.IO;
using System.Text;
using System.Threading;

namespace FlowersShop
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug
    }
    
    public static class Logger
    {
        private static readonly object _lockObject = new object();
        private static readonly string _logFilePath;
        
        static Logger()
        {
            _logFilePath = PathManager.GetLogPath();
        }
        
        public static void LogInfo(string message)
        {
            WriteLog(LogLevel.Info, message, null);
        }
        
        public static void LogWarning(string message)
        {
            WriteLog(LogLevel.Warning, message, null);
        }
        
        public static void LogError(string message, Exception exception = null)
        {
            WriteLog(LogLevel.Error, message, exception);
        }
        
        public static void LogDebug(string message)
        {
            #if DEBUG
            WriteLog(LogLevel.Debug, message, null);
            #endif
        }
        
        private static void WriteLog(LogLevel level, string message, Exception exception)
        {
            try
            {
                lock (_lockObject)
                {
                    var logEntry = new StringBuilder();
                    logEntry.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] [{Thread.CurrentThread.ManagedThreadId}]");
                    logEntry.AppendLine($"Сообщение: {message}");
                    
                    if (exception != null)
                    {
                        logEntry.AppendLine($"Исключение: {exception.GetType().Name}");
                        logEntry.AppendLine($"Описание: {exception.Message}");
                        logEntry.AppendLine($"StackTrace: {exception.StackTrace}");
                        
                        if (exception.InnerException != null)
                        {
                            logEntry.AppendLine($"Внутреннее исключение: {exception.InnerException.GetType().Name}");
                            logEntry.AppendLine($"Описание внутреннего исключения: {exception.InnerException.Message}");
                        }
                    }
                    
                    logEntry.AppendLine(new string('-', 80));
                    
                    var directory = Path.GetDirectoryName(_logFilePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    
                    File.AppendAllText(_logFilePath, logEntry.ToString(), Encoding.UTF8);
                }
            }
            catch{}
        }
        
        public static void LogUserAction(string userName, string action)
        {
            LogInfo($"Пользователь '{userName}' выполнил действие: {action}");
        }
        
        public static void LogDatabaseOperation(string operation, string tableName, bool success)
        {
            var status = success ? "успешно" : "с ошибкой";
            LogInfo($"Операция БД '{operation}' в таблице '{tableName}' выполнена {status}");
        }
        
        public static void LogFileOperation(string operation, string filePath, bool success)
        {
            var status = success ? "успешно" : "с ошибкой";
            LogInfo($"Файловая операция '{operation}' для файла '{filePath}' выполнена {status}");
        }
        
        public static void LogApplicationStart()
        {
            LogInfo("=== ЗАПУСК ПРИЛОЖЕНИЯ FlowersShop ===");
            LogInfo($"Версия: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
            LogInfo($"Операционная система: {Environment.OSVersion}");
            LogInfo($"Пользователь: {Environment.UserName}");
            LogInfo($"Машина: {Environment.MachineName}");
            LogInfo($"Рабочая директория: {Environment.CurrentDirectory}");
        }
        
        public static void LogApplicationEnd()
        {
            LogInfo("=== ЗАВЕРШЕНИЕ РАБОТЫ ПРИЛОЖЕНИЯ FlowersShop ===");
        }
        
        public static string GetLogContent(int lastLines = 100)
        {
            try
            {
                if (!File.Exists(_logFilePath))
                    return "Файл логов не найден.";
                
                var lines = File.ReadAllLines(_logFilePath, Encoding.UTF8);
                if (lines.Length <= lastLines)
                    return string.Join(Environment.NewLine, lines);
                
                var result = new string[lastLines];
                Array.Copy(lines, lines.Length - lastLines, result, 0, lastLines);
                return string.Join(Environment.NewLine, result);
            }
            catch (Exception ex)
            {
                return $"Ошибка при чтении логов: {ex.Message}";
            }
        }
        
        public static void ClearOldLogs(int daysToKeep = 30)
        {
            try
            {
                var logsDirectory = PathManager.LogsDirectory;
                if (!Directory.Exists(logsDirectory))
                    return;
                
                var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
                var logFiles = Directory.GetFiles(logsDirectory, "*.log");
                
                foreach (var logFile in logFiles)
                {
                    var fileInfo = new FileInfo(logFile);
                    if (fileInfo.CreationTime < cutoffDate)
                    {
                        try
                        {
                            File.Delete(logFile);
                            LogInfo($"Удален старый файл логов: {Path.GetFileName(logFile)}");
                        }
                        catch (Exception ex)
                        {
                            LogError($"Не удалось удалить старый файл логов: {Path.GetFileName(logFile)}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Ошибка при очистке старых логов", ex);
            }
        }
    }
} 