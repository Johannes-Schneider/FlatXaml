using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using FlatXaml.Style;
using FlatXaml.Theme;

namespace FlatXaml.View
{
    [TemplatePart(Name = "PART_BlurryBackground", Type = typeof(Rectangle))]
    public class FlatDialog : Window
    {
        public bool CancelOnBackgroundClick
        {
            get => (bool) GetValue(CancelOnBackgroundClickProperty);
            set => SetValue(CancelOnBackgroundClickProperty, value);
        }
        
        public static readonly DependencyProperty CancelOnBackgroundClickProperty = DependencyProperty.Register(nameof(CancelOnBackgroundClick), typeof(bool), typeof(FlatDialog), new PropertyMetadata(true));

        public bool CancelOnEscapePress
        {
            get => (bool) GetValue(CancelOnEscapePressProperty);
            set => SetValue(CancelOnEscapePressProperty, value);
        }
        
        public static readonly DependencyProperty CancelOnEscapePressProperty = DependencyProperty.Register(nameof(CancelOnEscapePress), typeof(bool), typeof(FlatDialog), new PropertyMetadata(true));

        private Rectangle? _blurryBackground;

        public FlatDialog()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.Dialog] as System.Windows.Style;
            WindowState = WindowState.Minimized;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Width = Owner?.Width ?? 400;
            Height = Owner?.Height ?? 400;
            Top = Owner?.Top ?? 0;
            Left = Owner?.Left ?? 0;
            WindowState = WindowState.Normal;
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _blurryBackground = GetTemplateChild("PART_BlurryBackground") as Rectangle ?? throw new Exception("Unable to get the PART_BlurryBackground template part!");
            
            _blurryBackground.MouseLeftButtonDown += BlurryBackground_OnMouseLeftButtonDown;
        }
        
        private void BlurryBackground_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!CancelOnBackgroundClick || _blurryBackground?.IsMouseDirectlyOver == false)
            {
                return;
            }

            DialogResult = false;
            Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
            if (e.Key == Key.Escape && CancelOnEscapePress)
            {
                DialogResult = false;
                Close();
            }
        }
    }
}