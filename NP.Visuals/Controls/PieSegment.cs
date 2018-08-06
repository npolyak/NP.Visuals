using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace NP.Visuals.Controls
{
    public class PieSegment : Control
    {
        #region InnerRadius Dependency Property
        public double InnerRadius
        {
            get { return (double)GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public static readonly DependencyProperty InnerRadiusProperty =
        DependencyProperty.Register
        (
            nameof(InnerRadius),
            typeof(double),
            typeof(PieSegment),
            new PropertyMetadata(0d)
        );
        #endregion InnerRadius Dependency Property

        
        #region OuterRadius Dependency Property
        public double OuterRadius
        {
            get { return (double)GetValue(OuterRadiusProperty); }
            set { SetValue(OuterRadiusProperty, value); }
        }

        public static readonly DependencyProperty OuterRadiusProperty =
        DependencyProperty.Register
        (
            nameof(OuterRadius),
            typeof(double),
            typeof(PieSegment),
            new PropertyMetadata(0d)
        );
        #endregion OuterRadius Dependency Property

        
        #region StartAngle Dependency Property
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty =
        DependencyProperty.Register
        (
            nameof(StartAngle),
            typeof(double),
            typeof(PieSegment),
            new PropertyMetadata(0d)
        );
        #endregion StartAngle Dependency Property


        #region EndAngle Dependency Property
        public double EndAngle
        {
            get { return (double)GetValue(EndAngleProperty); }
            set { SetValue(EndAngleProperty, value); }
        }

        public static readonly DependencyProperty EndAngleProperty =
        DependencyProperty.Register
        (
            nameof(EndAngle),
            typeof(double),
            typeof(PieSegment),
            new PropertyMetadata(0d)
        );
        #endregion EndAngle Dependency Property
    }
}
