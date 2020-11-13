using System.Windows;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatTextButton : FlatButton
    {
        public string Text
        {
            get => GetValue(TextProperty) as string ?? string.Empty;
            set => SetValue(TextProperty, value);
        }
        
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(FlatTextButton));

        public FlatTextButton()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.TextButton] as System.Windows.Style;
        }
    }
}