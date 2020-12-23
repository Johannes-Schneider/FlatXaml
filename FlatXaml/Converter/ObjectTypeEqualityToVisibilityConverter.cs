using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class ObjectTypeEqualityToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Visible;
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;
        public Type? CompareTo { get; set; }
        
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType() == CompareTo ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}