using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TRPO12_2.Service;

namespace TRPO12_2.ValidationRules
{
    public class LoginValidation : ValidationRule
    {
        public PolzovatService service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length < 5)
            {
                return new ValidationResult(false, "Логин должен содержать минимум 5 символов");
            }

            string text = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                {
                    text += Char.ToLower(input[i]);
                }
                else
                {
                    text += input[i];
                }
            }

            ObservableCollection<Polzovat> st = service.Polzovats;

            foreach (var a in st)
            {
                string text2 = "";
                for (int i = 0; i < a.Login.Length; i++)
                {
                    if (!Char.IsUpper(a.Login[i]))
                    {
                        text2 += Char.ToLower(a.Login[i]);
                    }
                    else
                    {
                        text2 += a.Login[i];
                    }
                }
                if (text == text2)
                {
                    return new ValidationResult(false, "Нужен оригинальный логин");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
