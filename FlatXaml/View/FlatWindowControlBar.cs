using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatWindowControlBar : ContentControl
    {
        public bool CanClose
        {
            get => (bool) GetValue(CanCloseProperty);
            set => SetValue(CanCloseProperty, value);
        }
        
        public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register(nameof(CanClose), typeof(bool), typeof(FlatWindowControlBar), new PropertyMetadata(true));

        public bool CanMaximize
        {
            get => (bool) GetValue(CanMaximizeProperty);
            set => SetValue(CanMaximizeProperty, value);
        }
        
        public static readonly DependencyProperty CanMaximizeProperty = DependencyProperty.Register(nameof(CanMaximize), typeof(bool), typeof(FlatWindowControlBar), new PropertyMetadata(true));

        public bool CanMinimize
        {
            get => (bool) GetValue(CanMinimizeProperty);
            set => SetValue(CanMinimizeProperty, value);
        }
        
        public static readonly DependencyProperty CanMinimizeProperty = DependencyProperty.Register(nameof(CanMinimize), typeof(bool), typeof(FlatWindowControlBar), new PropertyMetadata(true));

        public bool CanOpenSettings
        {
            get => (bool) GetValue(CanOpenSettingsProperty);
            set => SetValue(CanOpenSettingsProperty, value);
        }
        
        public static readonly DependencyProperty CanOpenSettingsProperty = DependencyProperty.Register(nameof(CanOpenSettings), typeof(bool), typeof(FlatWindowControlBar), new PropertyMetadata(false));

        public ICommand? OpenSettingsCommand
        {
            get => GetValue(OpenSettingsCommandProperty) as ICommand;
            set => SetValue(OpenSettingsCommandProperty, value);
        }
        
        public static readonly DependencyProperty OpenSettingsCommandProperty = DependencyProperty.Register(nameof(OpenSettingsCommand), typeof(ICommand), typeof(FlatWindowControlBar));

        public object? OpenSettingsCommandParameter
        {
            get => GetValue(OpenSettingsCommandParameterProperty);
            set => SetValue(OpenSettingsCommandParameterProperty, value);
        }
        
        public static readonly DependencyProperty OpenSettingsCommandParameterProperty = DependencyProperty.Register(nameof(OpenSettingsCommandParameter), typeof(object), typeof(FlatWindowControlBar));

        public FlatWindowControlBar()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.WindowControlBar] as System.Windows.Style;
        }
    }
}