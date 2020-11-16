using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class EqualityToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Visible;
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;
        public object? CompareTo { get; set; }
        
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(CompareTo) == true ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}