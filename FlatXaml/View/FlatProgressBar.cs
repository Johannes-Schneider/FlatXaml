using System.Windows;
using System.Windows.Controls;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatProgressBar : ProgressBar
    {
        public FlatProgressBar()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.ProgressBar] as System.Windows.Style;
        }
    }
}