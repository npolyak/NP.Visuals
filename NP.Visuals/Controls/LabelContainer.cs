using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class LabelContainer : Control
    {
        #region TheLabel Dependency Property
        public string TheLabel
        {
            get { return (string)GetValue(TheLabelProperty); }
            set { SetValue(TheLabelProperty, value); }
        }

        public static readonly DependencyProperty TheLabelProperty =
        DependencyProperty.Register
        (
            nameof(TheLabel),
            typeof(string),
            typeof(LabelContainer),
            new PropertyMetadata(null)
        );
        #endregion TheLabel Dependency Property

    }
}
