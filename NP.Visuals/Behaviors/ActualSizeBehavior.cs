using System.Windows;

namespace NP.Visuals.Behaviors
{
    public class ActualSizeBehavior
    {
        #region IsSet attached Property
        public static bool GetIsSet(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSetProperty);
        }

        public static void SetIsSet(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSetProperty, value);
        }

        public static readonly DependencyProperty IsSetProperty =
        DependencyProperty.RegisterAttached
        (
            "IsSet",
            typeof(bool),
            typeof(ActualSizeBehavior),
            new PropertyMetadata(default(bool), OnIsSetChanged)
        );

        private static void OnIsSetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isSet = GetIsSet(d);

            if (isSet)
            {
                FrameworkElement el = (FrameworkElement)d;

                SetActualSize(el);

                el.SizeChanged -= El_SizeChanged;
                el.SizeChanged += El_SizeChanged;
            }
        }

        private static void El_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetActualSize(sender);
        }
        #endregion IsSet attached Property

        static void SetActualSize(object elObj)
        {
            FrameworkElement el = (FrameworkElement) elObj;

            SetActualSize(el, new Point(el.ActualWidth, el.ActualHeight));
        }

        #region ActualSize attached Property
        public static Point GetActualSize(DependencyObject obj)
        {
            return (Point)obj.GetValue(ActualSizePropertyKey.DependencyProperty);
        }

        public static void SetActualSize(DependencyObject obj, Point value)
        {
            obj.SetValue(ActualSizePropertyKey, value);
        }

        public static readonly DependencyPropertyKey ActualSizePropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "ActualSize",
            typeof(Point),
            typeof(ActualSizeBehavior),
            new PropertyMetadata(default(Point))
        );
        #endregion ActualSize attached Property
    }
}
