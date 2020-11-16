using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatBadge : ContentControl
    {
        public FlatBadge()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.Badge] as System.Windows.Style;
        }
    }
}