using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowersShop
{
    public partial class Authentication : Form
    {
        private int _loginAttempts = 0;
        private const int MaxLoginAttempts = 5;
        private DateTime _lastFailedAttempt = DateTime.MinValue;
        
        public Authentication()
        {
            InitializeComponent();
            Logger.LogInfo("Открыта форма аутентификации");
        }

        private void BEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (_loginAttempts >= MaxLoginAttempts)
                {
                    var timeSinceLastAttempt = DateTime.Now - _lastFailedAttempt;
                    if (timeSinceLastAttempt.TotalMinutes < 5) 
                    {
                        var remainingTime = TimeSpan.FromMinutes(5) - timeSinceLastAttempt;
                        MessageBox.Show($"Слишком много неудачных попыток входа. Повторите через {remainingTime.Minutes}:{remainingTime.Seconds:D2}", 
                                      "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Logger.LogWarning($"Заблокированная попытка входа с логином: {TBLogin.Text}");
                        return;
                    }
                    else
                    {
                        _loginAttempts = 0;
                    }
                }
                
                var loginValidation = InputValidator.ValidateName(TBLogin.Text, "Логин");
                if (!loginValidation.IsValid)
                {
                    MessageBox.Show(loginValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var passwordValidation = InputValidator.ValidatePassword(TBPassword.Text);
                if (!passwordValidation.IsValid)
                {
                    MessageBox.Show(passwordValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(TBLogin.Text) || string.IsNullOrWhiteSpace(TBPassword.Text))
                {
                    MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                const string query = "SELECT Id, FName, SName, Password FROM Staff WHERE FName = @Login";
                var parameters = new Dictionary<string, object>
                {
                    { "@Login", InputValidator.SanitizeInput(TBLogin.Text) }
                };
                
                var result = DatabaseManager.ExecuteQuery(query, parameters);
                
                if (result.Rows.Count == 0)
                {
                    HandleFailedLogin("Пользователь не найден");
                    return;
                }
                
                var row = result.Rows[0];
                var storedPassword = row["Password"].ToString();
                var userId = Convert.ToInt32(row["Id"]);
                var userName = row["FName"].ToString() + " " + row["SName"].ToString();
                
                if (string.IsNullOrEmpty(storedPassword))
                {
                    HandleFailedLogin("Ошибка в данных пользователя");
                    return;
                }
                
                if (VerifyHashedPassword(storedPassword, TBPassword.Text))
                {
                    Logger.LogUserAction(userName, "Успешный вход в систему");
                    Logger.LogInfo($"Пользователь {userName} (ID: {userId}) успешно вошел в систему");
                    
                    _loginAttempts = 0;
                    
                    this.Hide();
                    var shop = new Shop(userId, userName);
                    shop.ShowDialog();
                    this.Close();
                }
                else
                {
                    HandleFailedLogin("Неверный пароль");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при аутентификации", ex);
                MessageBox.Show("Произошла ошибка при входе в систему. Попробуйте еще раз.", 
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void HandleFailedLogin(string reason)
        {
            _loginAttempts++;
            _lastFailedAttempt = DateTime.Now;
            
            Logger.LogWarning($"Неудачная попытка входа. Логин: {TBLogin.Text}, Причина: {reason}, Попытка: {_loginAttempts}");
            
            if (_loginAttempts >= MaxLoginAttempts)
            {
                MessageBox.Show("Превышено максимальное количество попыток входа. Доступ заблокирован на 5 минут.", 
                              "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var remainingAttempts = MaxLoginAttempts - _loginAttempts;
                MessageBox.Show($"{reason}. Осталось попыток: {remainingAttempts}", 
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            TBPassword.Clear();
            TBLogin.Focus();
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return Equals(buffer3, buffer4);
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Пользователь закрыл форму аутентификации");
            Close();
        }

        private void BQrCode_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogInfo("Открытие формы добавления персонала из окна аутентификации");
                var addStaff = new AddStaff();
                addStaff.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при открытии формы добавления персонала", ex);
                MessageBox.Show("Ошибка при открытии формы добавления персонала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.LogInfo("Форма аутентификации закрыта");
            base.OnFormClosed(e);
        }
    }
}
