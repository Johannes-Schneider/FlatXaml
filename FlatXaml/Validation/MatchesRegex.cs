using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FlatXaml.Validation
{
    public class MatchesRegex : ValidationRule
    {
        public string Regex { get; set; } = string.Empty;

        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var regex = new Regex(Regex);

            if (!regex.IsMatch(value?.ToString() ?? string.Empty))
            {
                return new ValidationResult(false, null);
            }

            return ValidationResult.ValidResult;
        }
    }
}