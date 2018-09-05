using System.Windows;
namespace NP.Visuals.Controls
{
    public class LabeledControl : LabelContainer
    {
        #region LabelPartWidth Dependency Property
        public double LabelPartWidth
        {
            get { return (double)GetValue(LabelPartWidthProperty); }
            set { SetValue(LabelPartWidthProperty, value); }
        }

        public static readonly DependencyProperty LabelPartWidthProperty =
        DependencyProperty.Register
        (
            nameof(LabelPartWidth),
            typeof(double),
            typeof(LabeledControl),
            new PropertyMetadata(double.NaN)
        );
        #endregion LabelPartWidth Dependency Property

        #region TheValueTemplate Dependency Property
        public DataTemplate TheValueTemplate
        {
            get { return (DataTemplate)GetValue(TheValueTemplateProperty); }
            set { SetValue(TheValueTemplateProperty, value); }
        }

        public static readonly DependencyProperty TheValueTemplateProperty =
        DependencyProperty.Register
        (
            nameof(TheValueTemplate),
            typeof(DataTemplate),
            typeof(LabeledControl),
            new PropertyMetadata(null)
        );
        #endregion TheValueTemplate Dependency Property

        #region TheValue Dependency Property
        public object TheValue
        {
            get { return (object)GetValue(TheValueProperty); }
            set { SetValue(TheValueProperty, value); }
        }

        public static readonly DependencyProperty TheValueProperty =
        DependencyProperty.Register
        (
            nameof(TheValue),
            typeof(object),
            typeof(LabeledControl),
            new PropertyMetadata(null)
        );
        #endregion TheValue Dependency Property
    }
}
