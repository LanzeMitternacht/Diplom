using System;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FlowersShop
{
    public static class BackupManager
    {
        public static async Task<bool> CreateBackupAsync(string databaseName = "FlowerShop")
        {
            try
            {
                Logger.LogInfo($"Начало создания резервной копии базы данных: {databaseName}");
                
                var backupPath = PathManager.GetBackupPath();
                var backupQuery = $@"
                    BACKUP DATABASE [{databaseName}] 
                    TO DISK = @BackupPath
                    WITH FORMAT, INIT, 
                    NAME = N'{databaseName} Full Database Backup', 
                    SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@BackupPath", backupPath }
                };
                
                await Task.Run(() => DatabaseManager.ExecuteNonQuery(backupQuery, parameters));
                
                Logger.LogInfo($"Резервная копия успешно создана: {backupPath}");
                Logger.LogInfo($"Размер файла резервной копии: {PathManager.GetFileSize(backupPath)}");
                
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при создании резервной копии базы данных", ex);
                return false;
            }
        }
        
        public static async Task<bool> RestoreBackupAsync(string backupFilePath, string databaseName = "FlowerShop")
        {
            try
            {
                Logger.LogInfo($"Начало восстановления базы данных из резервной копии: {backupFilePath}");
                
                if (!File.Exists(backupFilePath))
                {
                    Logger.LogError($"Файл резервной копии не найден: {backupFilePath}");
                    return false;
                }
                
                var setSingleUserQuery = $@"
                    ALTER DATABASE [{databaseName}] 
                    SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                
                var restoreQuery = $@"
                    RESTORE DATABASE [{databaseName}] 
                    FROM DISK = @BackupPath
                    WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5";
                
                var setMultiUserQuery = $@"
                    ALTER DATABASE [{databaseName}] 
                    SET MULTI_USER";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@BackupPath", backupFilePath }
                };
                
                await Task.Run(() =>
                {
                    DatabaseManager.ExecuteNonQuery(setSingleUserQuery);
                    DatabaseManager.ExecuteNonQuery(restoreQuery, parameters);
                    DatabaseManager.ExecuteNonQuery(setMultiUserQuery);
                });
                
                Logger.LogInfo($"База данных успешно восстановлена из резервной копии: {backupFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при восстановлении базы данных из резервной копии", ex);
                
                try
                {
                    var setMultiUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER";
                    DatabaseManager.ExecuteNonQuery(setMultiUserQuery);
                }
                catch{}
                
                return false;
            }
        }
        
        public static List<BackupInfo> GetAvailableBackups()
        {
            var backups = new List<BackupInfo>();
            
            try
            {
                var backupDirectory = PathManager.BackupDirectory;
                if (!Directory.Exists(backupDirectory))
                    return backups;
                
                var backupFiles = Directory.GetFiles(backupDirectory, "*.bak")
                                          .OrderByDescending(f => File.GetCreationTime(f));
                
                foreach (var backupFile in backupFiles)
                {
                    var fileInfo = new FileInfo(backupFile);
                    backups.Add(new BackupInfo
                    {
                        FilePath = backupFile,
                        FileName = fileInfo.Name,
                        CreationDate = fileInfo.CreationTime,
                        Size = fileInfo.Length,
                        SizeFormatted = PathManager.GetFileSize(backupFile)
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при получении списка резервных копий", ex);
            }
            
            return backups;
        }
        
        public static async Task<bool> CreateAutoBackupAsync()
        {
            try
            {
                Logger.LogInfo("Запуск автоматического резервного копирования");
                
                var lastBackup = GetLastBackupDate();
                var daysSinceLastBackup = (DateTime.Now - lastBackup).TotalDays;
                
                if (daysSinceLastBackup < 1) 
                {
                    Logger.LogInfo($"Последняя резервная копия была создана {lastBackup:yyyy-MM-dd HH:mm:ss}. Автоматическое резервное копирование пропущено.");
                    return true;
                }
                
                var success = await CreateBackupAsync();
                if (success)
                {
                    await CleanupOldBackupsAsync();
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при автоматическом резервном копировании", ex);
                return false;
            }
        }
        
        public static async Task CleanupOldBackupsAsync(int daysToKeep = 30)
        {
            try
            {
                Logger.LogInfo($"Начало очистки старых резервных копий (старше {daysToKeep} дней)");
                
                await Task.Run(() =>
                {
                    var backupDirectory = PathManager.BackupDirectory;
                    if (!Directory.Exists(backupDirectory))
                        return;
                    
                    var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
                    var backupFiles = Directory.GetFiles(backupDirectory, "*.bak");
                    
                    int deletedCount = 0;
                    foreach (var backupFile in backupFiles)
                    {
                        var fileInfo = new FileInfo(backupFile);
                        if (fileInfo.CreationTime < cutoffDate)
                        {
                            try
                            {
                                File.Delete(backupFile);
                                deletedCount++;
                                Logger.LogInfo($"Удалена старая резервная копия: {fileInfo.Name}");
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError($"Не удалось удалить старую резервную копию: {fileInfo.Name}", ex);
                            }
                        }
                    }
                    
                    Logger.LogInfo($"Очистка завершена. Удалено файлов: {deletedCount}");
                });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при очистке старых резервных копий", ex);
            }
        }
        
        private static DateTime GetLastBackupDate()
        {
            try
            {
                var backupDirectory = PathManager.BackupDirectory;
                if (!Directory.Exists(backupDirectory))
                    return DateTime.MinValue;
                
                var backupFiles = Directory.GetFiles(backupDirectory, "*.bak");
                if (backupFiles.Length == 0)
                    return DateTime.MinValue;
                
                return backupFiles.Max(f => File.GetCreationTime(f));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        
        public static async Task<bool> VerifyBackupAsync(string backupFilePath)
        {
            try
            {
                Logger.LogInfo($"Проверка целостности резервной копии: {backupFilePath}");
                
                if (!File.Exists(backupFilePath))
                {
                    Logger.LogError($"Файл резервной копии не найден: {backupFilePath}");
                    return false;
                }
                
                var verifyQuery = @"
                    RESTORE VERIFYONLY 
                    FROM DISK = @BackupPath";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@BackupPath", backupFilePath }
                };
                
                await Task.Run(() => DatabaseManager.ExecuteNonQuery(verifyQuery, parameters));
                
                Logger.LogInfo($"Резервная копия прошла проверку целостности: {backupFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при проверке целостности резервной копии: {backupFilePath}", ex);
                return false;
            }
        }
        
        public static async Task<BackupFileInfo> GetBackupInfoAsync(string backupFilePath)
        {
            try
            {
                var query = @"
                    RESTORE FILELISTONLY 
                    FROM DISK = @BackupPath";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@BackupPath", backupFilePath }
                };
                
                var result = await Task.Run(() => DatabaseManager.ExecuteQuery(query, parameters));
                
                var info = new BackupFileInfo
                {
                    FilePath = backupFilePath,
                    IsValid = true,
                    DatabaseFiles = new List<string>()
                };
                
                foreach (System.Data.DataRow row in result.Rows)
                {
                    info.DatabaseFiles.Add(row["LogicalName"].ToString());
                }
                
                return info;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при получении информации о резервной копии: {backupFilePath}", ex);
                return new BackupFileInfo { FilePath = backupFilePath, IsValid = false };
            }
        }
    }
    
    public class BackupInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public long Size { get; set; }
        public string SizeFormatted { get; set; }
    }
    
    public class BackupFileInfo
    {
        public string FilePath { get; set; }
        public bool IsValid { get; set; }
        public List<string> DatabaseFiles { get; set; } = new List<string>();
    }
} 