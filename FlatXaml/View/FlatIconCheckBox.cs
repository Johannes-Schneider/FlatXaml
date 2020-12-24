using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlatXaml.Style;

namespace FlatXaml.View
{
    public class FlatIconCheckBox : CheckBox
    {
        public double IconSize
        {
            get => (double) GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }
        
        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(nameof(IconSize), typeof(double), typeof(FlatIconCheckBox));
        
    #region Checked

        public Geometry? IconWhenChecked
        {
            get => GetValue(IconWhenCheckedProperty) as Geometry;
            set => SetValue(IconWhenCheckedProperty, value);
        }

        public static readonly DependencyProperty IconWhenCheckedProperty = DependencyProperty.Register(nameof(IconWhenChecked), typeof(Geometry), typeof(FlatIconCheckBox));

        public Brush? IconForegroundWhenChecked
        {
            get => GetValue(IconForegroundWhenCheckedProperty) as Brush;
            set => SetValue(IconForegroundWhenCheckedProperty, value);
        }
        
        public static readonly DependencyProperty IconForegroundWhenCheckedProperty = DependencyProperty.Register(nameof(IconForegroundWhenChecked), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? IconBackgroundWhenChecked
        {
            get => GetValue(IconBackgroundWhenCheckedProperty) as Brush;
            set => SetValue(IconBackgroundWhenCheckedProperty, value);
        }
        
        public static readonly DependencyProperty IconBackgroundWhenCheckedProperty = DependencyProperty.Register(nameof(IconBackgroundWhenChecked), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? BackgroundWhenChecked
        {
            get => GetValue(BackgroundWhenCheckedProperty) as Brush;
            set => SetValue(BackgroundWhenCheckedProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenCheckedProperty = DependencyProperty.Register(nameof(BackgroundWhenChecked), typeof(Brush), typeof(FlatIconCheckBox));

    #endregion

    #region Not Checked

        public Geometry? IconWhenNotChecked
        {
            get => GetValue(IconWhenNotCheckedProperty) as Geometry;
            set => SetValue(IconWhenNotCheckedProperty, value);
        }

        public static readonly DependencyProperty IconWhenNotCheckedProperty = DependencyProperty.Register(nameof(IconWhenNotChecked), typeof(Geometry), typeof(FlatIconCheckBox));

        public Brush? IconForegroundWhenNotChecked
        {
            get => GetValue(IconForegroundWhenNotCheckedProperty) as Brush;
            set => SetValue(IconForegroundWhenNotCheckedProperty, value);
        }
        
        public static readonly DependencyProperty IconForegroundWhenNotCheckedProperty = DependencyProperty.Register(nameof(IconForegroundWhenNotChecked), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? IconBackgroundWhenNotChecked
        {
            get => GetValue(IconBackgroundWhenNotCheckedProperty) as Brush;
            set => SetValue(IconBackgroundWhenNotCheckedProperty, value);
        }
        
        public static readonly DependencyProperty IconBackgroundWhenNotCheckedProperty = DependencyProperty.Register(nameof(IconBackgroundWhenNotChecked), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? BackgroundWhenNotChecked
        {
            get => GetValue(BackgroundWhenNotCheckedProperty) as Brush;
            set => SetValue(BackgroundWhenNotCheckedProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenNotCheckedProperty = DependencyProperty.Register(nameof(BackgroundWhenNotChecked), typeof(Brush), typeof(FlatIconCheckBox));

    #endregion

    #region Disabled

        public Brush? IconForegroundWhenDisabled
        {
            get => GetValue(IconForegroundWhenDisabledProperty) as Brush;
            set => SetValue(IconForegroundWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty IconForegroundWhenDisabledProperty = DependencyProperty.Register(nameof(IconForegroundWhenDisabled), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? IconBackgroundWhenDisabled
        {
            get => GetValue(IconBackgroundWhenDisabledProperty) as Brush;
            set => SetValue(IconBackgroundWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty IconBackgroundWhenDisabledProperty = DependencyProperty.Register(nameof(IconBackgroundWhenDisabled), typeof(Brush), typeof(FlatIconCheckBox));

        public Brush? BackgroundWhenDisabled
        {
            get => GetValue(BackgroundWhenDisabledProperty) as Brush;
            set => SetValue(BackgroundWhenDisabledProperty, value);
        }
        
        public static readonly DependencyProperty BackgroundWhenDisabledProperty = DependencyProperty.Register(nameof(BackgroundWhenDisabled), typeof(Brush), typeof(FlatIconCheckBox));

    #endregion

        public FlatIconCheckBox()
        {
            Style = Application.Current?.Resources[FlatStyleKeys.IconCheckBox] as System.Windows.Style;
        }
    }
}