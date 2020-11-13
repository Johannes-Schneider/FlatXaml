using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    [ValueConversion(typeof(ICollection), typeof(Visibility))]
    public class IsEmptyToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Collapsed;
        public Visibility FalseValue { get; set; } = Visibility.Visible;
        
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       string stringValue => stringValue.Length == 0 ? TrueValue : FalseValue,
                       ICollection collectionValue => collectionValue.Count == 0 ? TrueValue : FalseValue,
                       _ => throw new ArgumentException($"{nameof(IsEmptyToVisibilityConverter)} does not support values of type {value?.GetType().Name}!"),
                   };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}