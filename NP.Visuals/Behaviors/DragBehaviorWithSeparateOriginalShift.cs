using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public class DragBehaviorWithSeparateOriginalShift : DragBehavior
    {
        #region TheOriginalShift Dependency Property
        public Point TheOriginalShift
        {
            get { return (Point)GetValue(TheOriginalShiftProperty); }
            set { SetValue(TheOriginalShiftProperty, value); }
        }

        public static readonly DependencyProperty TheOriginalShiftProperty =
        DependencyProperty.Register
        (
            nameof(TheOriginalShift),
            typeof(Point),
            typeof(DragBehaviorWithSeparateOriginalShift),
            new PropertyMetadata(new Point(double.NaN, double.NaN))
        );
        #endregion TheOriginalShift Dependency Property

        protected override Point GetOriginalShift()
        {
            return TheOriginalShift;
        }
    }
}
