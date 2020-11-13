using System.Windows;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatIconButton : FlatButton
    {
        public Geometry? Icon
        {
            get => GetValue(IconProperty) as Geometry;
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(FlatIconButton));

        public Geometry? IconWhenDisabled
        {
            get => GetValue(IconWhenDisabledProperty) as Geometry;
            set => SetValue(IconWhenDisabledProperty, value);
        }

        public static readonly DependencyProperty IconWhenDisabledProperty = DependencyProperty.Register(nameof(IconWhenDisabled), typeof(Geometry), typeof(FlatIconButton));

        public double IconSize
        {
            get => (double) GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(nameof(IconSize), typeof(double), typeof(FlatIconButton));

        public FlatIconButton()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.IconButton] as System.Windows.Style;
        }
    }
}