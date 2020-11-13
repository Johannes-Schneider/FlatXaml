using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatInputHintTextBox : TextBox
    {
        public string? InputHintText
        {
            get => GetValue(InputHintTextProperty) as string;
            set => SetValue(InputHintTextProperty, value);
        }

        public static readonly DependencyProperty InputHintTextProperty = DependencyProperty.Register(nameof(InputHintText), typeof(string), typeof(FlatInputHintTextBox));

        public Brush? BorderBrushWhenValid
        {
            get => GetValue(BorderBrushWhenValidProperty) as Brush;
            set => SetValue(BorderBrushWhenValidProperty, value);
        }

        public static readonly DependencyProperty BorderBrushWhenValidProperty = DependencyProperty.Register(nameof(BorderBrushWhenValid), typeof(Brush), typeof(FlatInputHintTextBox));

        public Brush? BorderBrushWhenNotValid
        {
            get => GetValue(BorderBrushWhenNotValidProperty) as Brush;
            set => SetValue(BorderBrushWhenNotValidProperty, value);
        }

        public static readonly DependencyProperty BorderBrushWhenNotValidProperty = DependencyProperty.Register(nameof(BorderBrushWhenNotValid), typeof(Brush), typeof(FlatInputHintTextBox));

        public FlatInputHintTextBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.InputHintTextBox] as System.Windows.Style;
        }
    }
}