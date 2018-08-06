using NP.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NP.Visuals
{
    public class NonNegativeDragBehavior : DragBehavior
    {
        protected override void SetTheShift(Point shift)
        {
            shift = shift.ToNonNegative();

            base.SetTheShift(shift);
        }
    }
}
