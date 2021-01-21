using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatGridSplitter : GridSplitter
    {
        public Brush? BackgroundWhenHovered
        {
            get => GetValue(BackgroundWhenHoveredProperty) as Brush;
            set => SetValue(BackgroundWhenHoveredProperty, value);
        }

        public static readonly DependencyProperty BackgroundWhenHoveredProperty = DependencyProperty.Register(nameof(BackgroundWhenHovered), typeof(Brush), typeof(FlatGridSplitter));

        public FlatGridSplitter()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.GridSplitter] as System.Windows.Style;
        }
    }
}