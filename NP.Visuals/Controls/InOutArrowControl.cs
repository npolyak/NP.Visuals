using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class InOutArrowControl : Control
    {
        #region IsIn Dependency Property
        public bool IsIn
        {
            get { return (bool)GetValue(IsInProperty); }
            set { SetValue(IsInProperty, value); }
        }

        public static readonly DependencyProperty IsInProperty =
        DependencyProperty.Register
        (
            nameof(IsIn),
            typeof(bool),
            typeof(InOutArrowControl),
            new PropertyMetadata(true)
        );
        #endregion IsIn Dependency Property

    }
}
