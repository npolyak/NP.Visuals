using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class SelectableItemControl : ContentControl
    {
        #region IsItemSelected Dependency Property
        public bool IsItemSelected
        {
            get { return (bool)GetValue(IsItemSelectedProperty); }
            set { SetValue(IsItemSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsItemSelectedProperty =
        DependencyProperty.Register
        (
            nameof(IsItemSelected),
            typeof(bool),
            typeof(SelectableItemControl),
            new PropertyMetadata(default(bool))
        );
        #endregion IsItemSelected Dependency Property

        #region CheckBoxMargin Dependency Property
        public Thickness CheckBoxMargin
        {
            get { return (Thickness)GetValue(CheckBoxMarginProperty); }
            set { SetValue(CheckBoxMarginProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxMarginProperty =
        DependencyProperty.Register
        (
            nameof(CheckBoxMargin),
            typeof(Thickness),
            typeof(SelectableItemControl),
            new PropertyMetadata(default(Thickness))
        );
        #endregion CheckBoxMargin Dependency Property

    }
}
