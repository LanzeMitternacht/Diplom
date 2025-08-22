using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;

namespace FlowersShop
{
    public static class InputValidator
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        private static readonly Regex PhoneRegex = new Regex(
            @"^(\+7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$",
            RegexOptions.Compiled);
        
        private static readonly Regex NameRegex = new Regex(
            @"^[a-zA-Zа-яА-ЯёЁ\s\-']{2,50}$",
            RegexOptions.Compiled);
        
        private static readonly string[] SqlInjectionKeywords = 
        {
            "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "CREATE", "ALTER", 
            "EXEC", "EXECUTE", "UNION", "SCRIPT", "DECLARE", "CAST", "CONVERT",
            "--", "/*", "*/", "xp_", "sp_", "TRUNCATE", "BACKUP", "RESTORE"
        };
        
        public static ValidationResult ValidateName(string name, string fieldName = "Имя")
        {
            if (string.IsNullOrWhiteSpace(name))
                return ValidationResult.Error($"{fieldName} не может быть пустым");
            
            if (name.Length < 2)
                return ValidationResult.Error($"{fieldName} должно содержать минимум 2 символа");
            
            if (name.Length > 50)
                return ValidationResult.Error($"{fieldName} не должно превышать 50 символов");
            
            if (!NameRegex.IsMatch(name))
                return ValidationResult.Error($"{fieldName} содержит недопустимые символы");
            
            if (ContainsSqlInjection(name))
                return ValidationResult.Error($"{fieldName} содержит недопустимые команды");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return ValidationResult.Error("Email не может быть пустым");
            
            if (!EmailRegex.IsMatch(email))
                return ValidationResult.Error("Неверный формат email адреса");
            
            if (ContainsSqlInjection(email))
                return ValidationResult.Error("Email содержит недопустимые символы");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return ValidationResult.Error("Телефон не может быть пустым");
            
            var cleanPhone = Regex.Replace(phone, @"[\s\-\(\)]", "");
            
            if (!PhoneRegex.IsMatch(phone))
                return ValidationResult.Error("Неверный формат номера телефона");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return ValidationResult.Error("Пароль не может быть пустым");
            
            if (password.Length < 6)
                return ValidationResult.Error("Пароль должен содержать минимум 6 символов");
            
            if (password.Length > 100)
                return ValidationResult.Error("Пароль не должен превышать 100 символов");
            
            if (ContainsSqlInjection(password))
                return ValidationResult.Error("Пароль содержит недопустимые символы");
            
            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);
            
            if (!hasLetter || !hasDigit)
                return ValidationResult.Warning("Рекомендуется использовать буквы и цифры в пароле");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidatePrice(string priceText)
        {
            if (string.IsNullOrWhiteSpace(priceText))
                return ValidationResult.Error("Цена не может быть пустой");
            
            if (!decimal.TryParse(priceText, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal price))
                return ValidationResult.Error("Неверный формат цены");
            
            if (price < 0)
                return ValidationResult.Error("Цена не может быть отрицательной");
            
            if (price > 1000000)
                return ValidationResult.Error("Цена слишком большая");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidateQuantity(string quantityText)
        {
            if (string.IsNullOrWhiteSpace(quantityText))
                return ValidationResult.Error("Количество не может быть пустым");
            
            if (!int.TryParse(quantityText, out int quantity))
                return ValidationResult.Error("Неверный формат количества");
            
            if (quantity < 0)
                return ValidationResult.Error("Количество не может быть отрицательным");
            
            if (quantity > 100000)
                return ValidationResult.Error("Количество слишком большое");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidateProductName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return ValidationResult.Error("Название товара не может быть пустым");
            
            if (productName.Length < 2)
                return ValidationResult.Error("Название товара должно содержать минимум 2 символа");
            
            if (productName.Length > 100)
                return ValidationResult.Error("Название товара не должно превышать 100 символов");
            
            if (ContainsSqlInjection(productName))
                return ValidationResult.Error("Название товара содержит недопустимые символы");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
                return ValidationResult.Success(); 
            
            if (position.Length > 100)
                return ValidationResult.Error("Должность не должна превышать 100 символов");
            
            if (ContainsSqlInjection(position))
                return ValidationResult.Error("Должность содержит недопустимые символы");
            
            return ValidationResult.Success();
        }
        
        private static bool ContainsSqlInjection(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            
            var upperInput = input.ToUpper();
            return SqlInjectionKeywords.Any(keyword => upperInput.Contains(keyword));
        }
        
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            return input.Replace("'", "''")  
                       .Replace("--", "")    
                       .Replace("/*", "")    
                       .Replace("*/", "")   
                       .Replace(";", "")   
                       .Trim();
        }
        
        public static ValidationResult ValidateId(string idText, string fieldName = "ID")
        {
            if (string.IsNullOrWhiteSpace(idText))
                return ValidationResult.Error($"{fieldName} не может быть пустым");
            
            if (!int.TryParse(idText, out int id))
                return ValidationResult.Error($"Неверный формат {fieldName}");
            
            if (id <= 0)
                return ValidationResult.Error($"{fieldName} должен быть положительным числом");
            
            return ValidationResult.Success();
        }
        
        public static ValidationResult ValidateProductType(string productType)
        {
            if (string.IsNullOrWhiteSpace(productType))
                return ValidationResult.Error("Тип товара должен быть выбран");
            
            var validTypes = new[] { "Цветы", "Декорации", "Садовая утварь" };
            if (!validTypes.Contains(productType))
                return ValidationResult.Error("Выбран недопустимый тип товара");
            
            return ValidationResult.Success();
        }
    }
    
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string Message { get; private set; }
        public ValidationSeverity Severity { get; private set; }
        
        private ValidationResult(bool isValid, string message, ValidationSeverity severity)
        {
            IsValid = isValid;
            Message = message;
            Severity = severity;
        }
        
        public static ValidationResult Success()
        {
            return new ValidationResult(true, "", ValidationSeverity.None);
        }
        
        public static ValidationResult Error(string message)
        {
            return new ValidationResult(false, message, ValidationSeverity.Error);
        }
        
        public static ValidationResult Warning(string message)
        {
            return new ValidationResult(true, message, ValidationSeverity.Warning);
        }
    }
    
    public enum ValidationSeverity
    {
        None,
        Warning,
        Error
    }
} 