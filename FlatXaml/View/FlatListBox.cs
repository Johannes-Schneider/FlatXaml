using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatListBox : ListBox
    {
        public FlatListBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.ListBoxStyle] as System.Windows.Style;
        }
    }
}