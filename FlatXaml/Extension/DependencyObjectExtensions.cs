using System.Linq;
using System.Windows;

namespace FlatXaml.Extension
{
    public static class DependencyObjectExtensions
    {
        public static bool HasValidationErrors(this DependencyObject thisDependencyObject)
        {
            return System.Windows.Controls.Validation.GetHasError(thisDependencyObject)
                   || LogicalTreeHelper.GetChildren(thisDependencyObject)
                                       .OfType<DependencyObject>()
                                       .Any(HasValidationErrors);
        }
    }
}