using System.Windows;
using System.Windows.Controls;
using FlatXaml.Model;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatProgression : Control
    {
        public Progression? Progression
        {
            get => GetValue(ProgressionProperty) as Progression;
            set => SetValue(ProgressionProperty, value);
        }

        public static readonly DependencyProperty ProgressionProperty = DependencyProperty.Register(nameof(Progression), typeof(Progression), typeof(FlatProgression));

        public FlatProgression()
        {
            Progression = new Progression();
            Style = Application.Current?.Resources[FlatStyleKeys.Progression] as System.Windows.Style;
        }
    }
}