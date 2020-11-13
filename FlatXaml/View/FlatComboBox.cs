using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatComboBox : ComboBox
    {
        public FlatComboBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.ComboBox] as System.Windows.Style;
        }
    }
}