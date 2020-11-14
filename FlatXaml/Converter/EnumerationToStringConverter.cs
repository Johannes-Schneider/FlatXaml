using System;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    public class EnumerationToStringConverter : IValueConverter
    {
        public Type Enumeration { get; set; }
        
        public ResourceManager Localization { get; set; }
        
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return Localization.GetString(value?.ToString() ?? string.Empty) ?? throw new Exception($"Unknown {Enumeration.Name} {value}!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string stringValue))
            {
                throw new ArgumentException($"{nameof(value)} must be of type {nameof(String)}!");
            }

            foreach (var member in Enum.GetValues(Enumeration))
            {
                if (member == null)
                {
                    continue;
                }
                
                if (stringValue.Equals(Localization.GetString(member.ToString() ?? string.Empty)))
                {
                    return member;
                }
            }
            
            throw new ArgumentException($"Unable to convert {stringValue} to {Enumeration.Name}!");
        }
    }
}