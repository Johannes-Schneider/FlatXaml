using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatGroupBox : GroupBox
    {
        public FlatGroupBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.GroupBox] as System.Windows.Style;
        }
    }
}