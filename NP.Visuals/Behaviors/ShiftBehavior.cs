using System;
using System.Windows;
using System.Windows.Media;

namespace NP.Visuals.Behaviors
{
    public static class ShiftBehavior
    {
        #region Position attached Property
        public static Point GetPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(PositionProperty);
        }

        public static void SetPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(PositionProperty, value);
        }

        public static readonly DependencyProperty PositionProperty =
        DependencyProperty.RegisterAttached
        (
            "Position",
            typeof(Point),
            typeof(ShiftBehavior),
            new PropertyMetadata(default(Point), OnPositionChanged)
        );

        private static void OnPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            TranslateTransform translateTransform = el.RenderTransform as TranslateTransform;

            if (translateTransform == null)
            {
                translateTransform = new TranslateTransform();
                el.RenderTransform = translateTransform;
            }

            Point position = GetPosition(el);

            translateTransform.X = position.X;
            translateTransform.Y = position.Y;
        }
        #endregion Position attached Property

    }
}
