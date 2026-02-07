using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using TRPO12_2.Service;

namespace TRPO12_2.ValidationRules
{
    public class EmailVal : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;

            if (string.IsNullOrWhiteSpace(email))
                return new ValidationResult(false, "Поле почты не может быть пустым");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return new ValidationResult(false, "Неверный формат email адреса");

            return ValidationResult.ValidResult;
        }
    }
}

