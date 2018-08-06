using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NP.Visuals.Utils
{
    public static class VisualUtils
    {
        public static Visibility ToVis(this bool? b, bool directOrInverse = true)
        {
            if (b == null)
                b = false;

            if (!directOrInverse)
                b = !b;

            return (b == true) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
