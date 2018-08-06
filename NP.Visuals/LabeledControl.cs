using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals
{
    public class LabeledControl : Control
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
            typeof(LabeledControl),
            new PropertyMetadata(null)
        );
        #endregion TheLabel Dependency Property


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
