using NP.Visuals;
using NP.Visuals.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class PanelWithArrow : NPGrid
    {
        #region TheArrow Dependency Property
        public FrameworkElement TheArrow
        {
            get { return (FrameworkElement)GetValue(TheArrowProperty); }
            set { SetValue(TheArrowProperty, value); }
        }

        public static readonly DependencyProperty TheArrowProperty =
        DependencyProperty.Register
        (
            nameof(TheArrow),
            typeof(FrameworkElement),
            typeof(PanelWithArrow),
            new PropertyMetadata(null)
        );
        #endregion TheArrow Dependency Property

        ExposeElementBehavior<FrameworkElement> _exposeArrowBehavior =
            new ExposeElementBehavior<FrameworkElement>(TheArrowProperty, "PART_TheArrow");

        public PanelWithArrow()
        {
            _exposeArrowBehavior.Attach(this);
        }
    }
}
