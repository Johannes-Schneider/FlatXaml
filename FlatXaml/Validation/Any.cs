using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace FlatXaml.Validation
{
    public class Any : ValidationRule
    {
        public ValidationRule[] Rules { get; set; } = System.Array.Empty<ValidationRule>();
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Rules?.Any(rule => rule.Validate(value, cultureInfo).IsValid) == true)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, null);
        }
    }
}