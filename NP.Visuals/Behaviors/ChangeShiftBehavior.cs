using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class ChangeShiftBehavior
    {

        #region InitUpdateShift attached Property
        public static Point GetInitUpdateShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(InitUpdateShiftProperty);
        }

        public static void SetInitUpdateShift(DependencyObject obj, Point value)
        {
            obj.SetValue(InitUpdateShiftProperty, value);
        }

        public static readonly DependencyProperty InitUpdateShiftProperty =
        DependencyProperty.RegisterAttached
        (
            "InitUpdateShift",
            typeof(Point),
            typeof(ChangeShiftBehavior),
            new PropertyMetadata(default(Point), SumUp)
        );
        #endregion InitUpdateShift attached Property


        #region InitialShift attached Property
        public static Point GetInitialShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(InitialShiftProperty);
        }

        public static void SetInitialShift(DependencyObject obj, Point value)
        {
            obj.SetValue(InitialShiftProperty, value);
        }

        public static readonly DependencyProperty InitialShiftProperty =
        DependencyProperty.RegisterAttached
        (
            "InitialShift",
            typeof(Point),
            typeof(ChangeShiftBehavior),
            new PropertyMetadata(default(Point), SumUp)
        );
        #endregion InitialShift attached Property


        #region Shift attached Property
        public static Point GetShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(ShiftProperty);
        }

        public static void SetShift(DependencyObject obj, Point value)
        {
            obj.SetValue(ShiftProperty, value);
        }

        public static readonly DependencyProperty ShiftProperty =
        DependencyProperty.RegisterAttached
        (
            "Shift",
            typeof(Point),
            typeof(ChangeShiftBehavior),
            new PropertyMetadata(default(Point), SumUp)
        );
        #endregion Shift attached Property

        public static void SumUp(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Point initShift = GetInitialShift(sender);
            Point initUpdateShift = GetInitUpdateShift(sender);
            Point shift = GetShift(sender);

            Point totalShift = initShift.Plus(shift).Plus(initUpdateShift);

            SetTotalShift(sender, totalShift);
        }

        #region TotalShift attached Property
        public static Point GetTotalShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(TotalShiftProperty);
        }

        public static void SetTotalShift(DependencyObject obj, Point value)
        {
            obj.SetValue(TotalShiftProperty, value);
        }

        public static readonly DependencyProperty TotalShiftProperty =
        DependencyProperty.RegisterAttached
        (
            "TotalShift",
            typeof(Point),
            typeof(ChangeShiftBehavior),
            new PropertyMetadata(default(Point))
        );
        #endregion TotalShift attached Property
    }
}
