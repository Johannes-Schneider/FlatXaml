using System;
using System.CodeDom;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(double), typeof(double))]
    [ValueConversion(typeof(double), typeof(CornerRadius))]
    public class MultiplyDoubleConverter : IValueConverter
    {
        public double Factor { get; set; } = 1.0d;

        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       double doubleValue when targetType == typeof(double) => doubleValue * Factor,
                       double doubleValue when targetType == typeof(CornerRadius) => new CornerRadius(doubleValue * Factor),
                       double => throw new ArgumentOutOfRangeException($"{nameof(MultiplyDoubleConverter)} does not support the {nameof(targetType)} {targetType}!"),
                       _ => throw new ArgumentException($"{nameof(MultiplyDoubleConverter)} does not support values of type {value?.GetType().Name}!"),
                   };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}