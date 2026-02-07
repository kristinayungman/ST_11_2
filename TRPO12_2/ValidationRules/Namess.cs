using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO12_2.ValidationRules
{
    public class Namess : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult(false, "Имя не может быть пустым");
            }

            return ValidationResult.ValidResult;
        }

    }
}
