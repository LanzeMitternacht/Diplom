using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowersShop
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Logger.LogApplicationStart();
                
                Logger.ClearOldLogs();
                
                if (!DatabaseManager.TestConnection())
                {
                    Logger.LogError("Не удалось подключиться к базе данных при запуске");
                    MessageBox.Show("Ошибка подключения к базе данных. Проверьте настройки подключения.", 
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                Logger.LogInfo("Подключение к базе данных успешно установлено");
                
                Task.Run(async () =>
                {
                    try
                    {
                        await BackupManager.CreateAutoBackupAsync();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Ошибка при автоматическом резервном копировании", ex);
                    }
                });
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                
                Application.Run(new Authentication());
            }
            catch (Exception ex)
            {
                Logger.LogError("Критическая ошибка при запуске приложения", ex);
                MessageBox.Show($"Критическая ошибка при запуске приложения: {ex.Message}", 
                              "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.LogApplicationEnd();
            }
        }
        
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.LogError("Необработанное исключение в потоке UI", e.Exception);
            MessageBox.Show($"Произошла ошибка: {e.Exception.Message}", 
                          "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.LogError("Необработанное исключение в домене приложения", (Exception)e.ExceptionObject);
            if (e.IsTerminating)
            {
                Logger.LogError("Приложение завершается из-за критической ошибки");
            }
        }
    }
}
