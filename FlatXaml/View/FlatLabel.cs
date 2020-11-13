using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatLabel : Label
    {
        public FlatLabel()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.Label] as System.Windows.Style;
        }
    }
}