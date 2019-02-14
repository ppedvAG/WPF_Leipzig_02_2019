using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validierung
{
    public class StringNotTooLongRule : ValidationRule
    {
        public int MaxLength { get; set; } = 10;
        public int MinLength { get; set; } = 4;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString().Length > MaxLength || value.ToString().Length < MinLength)
            {
                return new ValidationResult(false, $"Name muss zwischen {MinLength} und {MaxLength} sein");
            }
            return ValidationResult.ValidResult;
        }
    }
}
