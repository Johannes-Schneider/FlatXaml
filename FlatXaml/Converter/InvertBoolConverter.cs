using System;
using System.Globalization;
using System.Windows.Data;

namespace FlatXaml.Converter
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       bool boolValue => !boolValue,
                       _ => false,
                   };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
                   {
                       bool boolValue => !boolValue,
                       _ => false,
                   };
        }
    }
}