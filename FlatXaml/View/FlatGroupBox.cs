using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatGroupBox : GroupBox
    {
        public bool CanCollapse
        {
            get => (bool) GetValue(CanCollapseProperty);
            set => SetValue(CanCollapseProperty, value);
        }
        
        public static readonly DependencyProperty CanCollapseProperty = DependencyProperty.Register(nameof(CanCollapse), typeof(bool), typeof(FlatGroupBox));

        public bool IsCollapsed
        {
            get => (bool) GetValue(IsCollapsedProperty);
            set => SetValue(IsCollapsedProperty, value);
        }
        
        public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty.Register(nameof(IsCollapsed), typeof(bool), typeof(FlatGroupBox));
        
        public FlatGroupBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.GroupBox] as System.Windows.Style;
        }
    }
}