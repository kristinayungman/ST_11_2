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
    public class GroupNameValidation : ValidationRule
    {
        public GroupService service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Название группы не может быть пустым");
            }

            if (input.Length < 3)
            {
                return new ValidationResult(false, "Название группы должно содержать минимум 3 символа");
            }

            if (input.Length > 100)
            {
                return new ValidationResult(false, "Название группы не может превышать 100 символов");
            }

            string normalizedInput = input.ToLowerInvariant();
            ObservableCollection<InterestGroup> existingGroups = service.InterestGroups;

            foreach (var group in existingGroups)
            {
                string normalizedGroupName = group.Title?.ToLowerInvariant() ?? "";

                if (normalizedInput == normalizedGroupName)
                {
                    return new ValidationResult(false, "Группа с таким названием уже существует");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
