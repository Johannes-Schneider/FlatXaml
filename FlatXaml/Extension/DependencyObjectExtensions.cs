using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FlatXaml.Extension
{
    public static class DependencyObjectExtensions
    {
        public static bool HasValidationErrors(this DependencyObject thisDependencyObject)
        {
            if (thisDependencyObject is Control {IsEnabled: false})
            {
                return false;
            }
            
            return System.Windows.Controls.Validation.GetHasError(thisDependencyObject)
                   || LogicalTreeHelper.GetChildren(thisDependencyObject)
                                       .OfType<DependencyObject>()
                                       .Any(HasValidationErrors);
        }
    }
}