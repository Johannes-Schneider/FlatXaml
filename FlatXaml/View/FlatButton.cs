using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatButton : Button
    {
        public Brush? BackgroundWhenHovered
        {
            get => GetValue(BackgroundWhenHoveredProperty) as Brush;
            set => SetValue(BackgroundWhenHoveredProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenHoveredProperty = DependencyProperty.Register(nameof(BackgroundWhenHovered), typeof(Brush), typeof(FlatIconButton));

        public Brush? BackgroundWhenPressed
        {
            get => GetValue(BackgroundWhenPressedProperty) as Brush;
            set => SetValue(BackgroundWhenPressedProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenPressedProperty = DependencyProperty.Register(nameof(BackgroundWhenPressed), typeof(Brush), typeof(FlatIconButton));

        public Brush? BackgroundWhenDisabled
        {
            get => GetValue(BackgroundWhenDisabledProperty) as Brush;
            set => SetValue(BackgroundWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenDisabledProperty = DependencyProperty.Register(nameof(BackgroundWhenDisabled), typeof(Brush), typeof(FlatIconButton));

        public Brush? ForegroundWhenHovered
        {
            get => GetValue(ForegroundWhenHoveredProperty) as Brush;
            set => SetValue(ForegroundWhenHoveredProperty, value);
        }
        
        public static readonly DependencyProperty ForegroundWhenHoveredProperty = DependencyProperty.Register(nameof(ForegroundWhenHovered), typeof(Brush), typeof(FlatIconButton));

        public Brush? ForegroundWhenPressed
        {
            get => GetValue(ForegroundWhenPressedProperty) as Brush;
            set => SetValue(ForegroundWhenPressedProperty, value);
        }
        
        public static readonly DependencyProperty ForegroundWhenPressedProperty = DependencyProperty.Register(nameof(ForegroundWhenPressed), typeof(Brush), typeof(FlatIconButton));

        public Brush? ForegroundWhenDisabled
        {
            get => GetValue(ForegroundWhenDisabledProperty) as Brush;
            set => SetValue(ForegroundWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty ForegroundWhenDisabledProperty = DependencyProperty.Register(nameof(ForegroundWhenDisabled), typeof(Brush), typeof(FlatIconButton));

        public Brush? BorderBrushWhenHovered
        {
            get => GetValue(BorderBrushWhenHoveredProperty) as Brush;
            set => SetValue(BorderBrushWhenHoveredProperty, value);
        }
        
        public static readonly DependencyProperty BorderBrushWhenHoveredProperty = DependencyProperty.Register(nameof(BorderBrushWhenHovered), typeof(Brush), typeof(FlatIconButton));

        public Brush? BorderBrushWhenPressed
        {
            get => GetValue(BorderBrushWhenPressedProperty) as Brush;
            set => SetValue(BorderBrushWhenPressedProperty, value);
        }
        
        public static readonly DependencyProperty BorderBrushWhenPressedProperty = DependencyProperty.Register(nameof(BorderBrushWhenPressed), typeof(Brush), typeof(FlatIconButton));

        public Brush? BorderBrushWhenDisabled
        {
            get => GetValue(BorderBrushWhenDisabledProperty) as Brush;
            set => SetValue(BorderBrushWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty BorderBrushWhenDisabledProperty = DependencyProperty.Register(nameof(BorderBrushWhenDisabled), typeof(Brush), typeof(FlatIconButton));

        public FlatButton()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.Button] as System.Windows.Style;
        }
    }
}