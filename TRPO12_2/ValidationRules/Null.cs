using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO12_2.ValidationRules
{
    public class Null : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Дата не выбрана");
            }

            if (value is DateTime selectedDate)
            {
                if (selectedDate < DateTime.Now)
                {
                    return new ValidationResult(false, "Дата создания не может быть раньше текущей даты и времени");
                }

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Некорректное значение даты");
        }
    }
}