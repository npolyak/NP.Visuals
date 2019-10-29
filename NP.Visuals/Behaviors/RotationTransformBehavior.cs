using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NP.Visuals.Behaviors
{
    public static class RotationTransformBehavior
    {
        #region Angle attached Property
        public static double GetAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value)
        {
            obj.SetValue(AngleProperty, value);
        }

        public static readonly DependencyProperty AngleProperty =
        DependencyProperty.RegisterAttached
        (
            "Angle",
            typeof(double),
            typeof(RotationTransformBehavior),
            new PropertyMetadata(default(double), OnAngleChanged)
        );

        private static void OnAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            RotateTransform rotateTransform = el.RenderTransform as RotateTransform;

            if (rotateTransform == null)
            {
                rotateTransform = new RotateTransform();
                el.RenderTransform = rotateTransform;
            }

            rotateTransform.Angle = GetAngle(d);
        }
        #endregion Angle attached Property

    }
}
