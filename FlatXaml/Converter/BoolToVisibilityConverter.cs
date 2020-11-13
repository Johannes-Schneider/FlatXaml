using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Visible;
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;


        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       bool boolValue => boolValue ? TrueValue : FalseValue,
                       _ => throw new ArgumentException($"{nameof(BoolToVisibilityConverter)} does not support values of type {value?.GetType().Name}!"),
                   };
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       Visibility visibilityValue when visibilityValue == TrueValue => true,
                       Visibility visibilityValue when visibilityValue == FalseValue => false,
                       Visibility => throw new ArgumentOutOfRangeException($"{nameof(value)} is neither {nameof(TrueValue)} nor {nameof(FalseValue)}!"),
                       _ => throw new ArgumentException($"{nameof(BoolToVisibilityConverter)} does not support values of type {value?.GetType().Name}!"),
                   };
        }
    }
}