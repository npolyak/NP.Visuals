using NP.Concepts.Behaviors;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace NP.Visuals.Utils
{
    public static class AlignmentHelpers
    {
        public static HorizontalAlignment[] AllHorizontalAlignments { get; } =
        {
            HorizontalAlignment.Left,
            HorizontalAlignment.Center,
            HorizontalAlignment.Right,
            HorizontalAlignment.Stretch
        };


        public static VerticalAlignment[] AllVerticalAlignments { get; } =
        {
            VerticalAlignment.Top,
            VerticalAlignment.Center,
            VerticalAlignment.Bottom,
            VerticalAlignment.Stretch
        };
    }
}
