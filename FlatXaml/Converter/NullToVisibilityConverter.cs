using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullToVisibilityConverter : IValueConverter
    {
        public Visibility IsNullValue { get; set; } = Visibility.Collapsed;
        public Visibility IsNotNullValue { get; set; } = Visibility.Visible;
        
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? IsNullValue : IsNotNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}