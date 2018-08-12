using System;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public class SizeSettingBehavior
    {
        #region InitialSize attached Property
        public static Point GetInitialSize(DependencyObject obj)
        {
            return (Point)obj.GetValue(InitialSizeProperty);
        }

        public static void SetInitialSize(DependencyObject obj, Point value)
        {
            obj.SetValue(InitialSizeProperty, value);
        }

        public static readonly DependencyProperty InitialSizeProperty =
        DependencyProperty.RegisterAttached
        (
            "InitialSize",
            typeof(Point),
            typeof(SizeSettingBehavior),
            new PropertyMetadata(default(Point), OnSizeChanged)
        );

        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetSize(d);
        }
        #endregion InitialSize attached Property

        static void SetSize(DependencyObject d)
        {
            Point initialSize = GetInitialSize(d);
            Point realSize = GetRealSize(d);

            FrameworkElement el = (FrameworkElement)d;

            el.Width = double.IsNaN(realSize.X) ? initialSize.X : realSize.X;
            el.Height = double.IsNaN(realSize.Y) ? initialSize.Y : realSize.Y;
        }

        #region RealSize attached Property
        public static Point GetRealSize(DependencyObject obj)
        {
            return (Point)obj.GetValue(RealSizeProperty);
        }

        public static void SetRealSize(DependencyObject obj, Point value)
        {
            obj.SetValue(RealSizeProperty, value);
        }

        public static readonly DependencyProperty RealSizeProperty =
        DependencyProperty.RegisterAttached
        (
            "RealSize",
            typeof(Point),
            typeof(SizeSettingBehavior),
            new PropertyMetadata(new Point(double.NaN, double.NaN), OnSizeChanged)
        );
        #endregion RealSize attached Property
    }
}
