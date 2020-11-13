using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatIcon : Control
    {
        public Geometry? Source
        {
            get => GetValue(SourceProperty) as Geometry;
            set => SetValue(SourceProperty, value);
        }
        
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(Geometry), typeof(FlatIcon));

        public FlatIcon()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.Icon] as System.Windows.Style;
        }
    }
}