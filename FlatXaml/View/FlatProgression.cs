using System;
using System.Windows;
using System.Windows.Controls;
using FlatXaml.Annotations;
using FlatXaml.Model;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatProgression : Control
    {
        [NotNull]
        public Progression Progression
        {
            get => GetValue(ProgressionProperty) as Progression ?? throw new NullReferenceException($"{nameof(Progression)} must not be {null}!");
            set => SetValue(ProgressionProperty, value ?? throw new ArgumentNullException(nameof(value)));
        }

        public static readonly DependencyProperty ProgressionProperty = DependencyProperty.Register(nameof(Progression), typeof(Progression), typeof(FlatProgression));

        public FlatProgression()
        {
            Progression = new Progression();
            Style = Application.Current?.Resources[FlatStyleKeys.Progression] as System.Windows.Style;
        }
    }
}