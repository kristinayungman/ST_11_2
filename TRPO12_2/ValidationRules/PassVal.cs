using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO12_2.ValidationRules
{
    public class PassVal : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string ?? string.Empty;

            // Проверка длины
            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult(false, "Пароль не может быть пустым");

            if (password.Length < 8)
                return new ValidationResult(false, "Пароль должен содержать не менее 8 символов");

            // Проверка наличия цифр
            if (!Regex.IsMatch(password, @"\d"))
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну цифру");

            // Проверка наличия строчных букв
            if (!Regex.IsMatch(password, @"[a-zа-я]"))
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну строчную букву");

            // Проверка наличия заглавных букв
            if (!Regex.IsMatch(password, @"[A-ZА-Я]"))
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну заглавную букву");

            // Проверка наличия спецсимволов (все кроме букв и цифр)
            if (!Regex.IsMatch(password, @"[^a-zA-Zа-яА-Я0-9]"))
                return new ValidationResult(false, "Пароль должен содержать хотя бы один спецсимвол");

            return ValidationResult.ValidResult;
        }
    }
}
