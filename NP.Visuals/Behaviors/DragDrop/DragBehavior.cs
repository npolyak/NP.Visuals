using System.Windows;
using System.Windows.Input;
using NP.Visuals;
using NP.Visuals.Utils;

namespace NP.Visuals.Behaviors.DragDrop
{
    public class DragBehavior
    {
        public static Point DefaultStartBoundary { get; } = new Point(double.NegativeInfinity, double.NegativeInfinity);
        public static Point DefaultEndBoundary { get; } = new Point(double.NaN, double.NaN);

        #region IsDragOn attached Property
        public static bool GetIsDragOn(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragOnPropertyKey.DependencyProperty);
        }

        private static void SetIsDragOn(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragOnPropertyKey, value);
        }

        public static readonly DependencyPropertyKey IsDragOnPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragOn",
            typeof(bool),
            typeof(DragBehavior),
            new PropertyMetadata(default(bool))
        );
        #endregion IsDragOn attached Property

        #region AttachedToElement attached Property
        private static FrameworkElement GetAttachedToElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(AttachedToElementPropertyKey.DependencyProperty);
        }

        private static void SetAttachedToElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(AttachedToElementPropertyKey, value);
        }

        private static readonly DependencyPropertyKey AttachedToElementPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "AttachedToElement",
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(null)
        );
        #endregion AttachedToElement attached Property

        #region StartBoundaryPoint attached Property
        public static Point GetStartBoundaryPoint(DependencyObject obj)
        {
            return (Point)obj.GetValue(StartBoundaryPointProperty);
        }

        public static void SetStartBoundaryPoint(DependencyObject obj, Point value)
        {
            obj.SetValue(StartBoundaryPointProperty, value);
        }

        public static readonly DependencyProperty StartBoundaryPointProperty =
        DependencyProperty.RegisterAttached
        (
            "StartBoundaryPoint",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(DefaultStartBoundary)
        );
        #endregion StartBoundaryPoint attached Property

        #region EndBoundaryPoint attached Property
        public static Point GetEndBoundaryPoint(DependencyObject obj)
        {
            return (Point)obj.GetValue(EndBoundaryPointProperty);
        }

        public static void SetEndBoundaryPoint(DependencyObject obj, Point value)
        {
            obj.SetValue(EndBoundaryPointProperty, value);
        }

        public static readonly DependencyProperty EndBoundaryPointProperty =
        DependencyProperty.RegisterAttached
        (
            "EndBoundaryPoint",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(DefaultEndBoundary)
        );
        #endregion EndBoundaryPoint attached Property

        #region BounceBackAtDragEnd attached Property
        public static bool GetBounceBackAtDragEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(BounceBackAtDragEndProperty);
        }

        public static void SetBounceBackAtDragEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(BounceBackAtDragEndProperty, value);
        }

        public static readonly DependencyProperty BounceBackAtDragEndProperty =
        DependencyProperty.RegisterAttached
        (
            "BounceBackAtDragEnd",
            typeof(bool),
            typeof(DragBehavior),
            new PropertyMetadata(default(bool))
        );
        #endregion BounceBackAtDragEnd attached Property

        #region DraggedElement attached Property
        public static FrameworkElement GetDraggedElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(DraggedElementProperty);
        }

        public static void SetDraggedElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(DraggedElementProperty, value);
        }

        public static readonly DependencyProperty DraggedElementProperty =
        DependencyProperty.RegisterAttached
        (
            "DraggedElement",
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(null, OnDraggedElementChanged)
        );

        private static void OnDraggedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement oldDraggedElement = e.OldValue as FrameworkElement;

            if (oldDraggedElement != null)
            {
                SetAttachedToElement(oldDraggedElement, null);
                oldDraggedElement.MouseDown -= OnMouseDown;
            }

            FrameworkElement draggedElement = GetDraggedElement(d);

            if (draggedElement != null)
            {
                SetAttachedToElement(draggedElement, (FrameworkElement)d);
                draggedElement.MouseDown += OnMouseDown;
            }
        }

        private static void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement draggedElement = (FrameworkElement)sender;

            FrameworkElement attachedToElement = GetAttachedToElement(draggedElement);

            FrameworkElement dragContainerElement =
                GetDragContainerElement(attachedToElement);

            if (!draggedElement.CaptureMouse())
                return;

            Point startDragPoint = e.GetPosition(dragContainerElement);
            SetStartDragPoint(attachedToElement, startDragPoint);
            Point currentElementPoint = GetShift(attachedToElement);
            SetStartElementPoint(attachedToElement, currentElementPoint);
            Point startLocationWithinContainerElementPoint = draggedElement.TranslatePoint(new Point(), dragContainerElement);
            SetStartLocationWithinContainerElement(attachedToElement, startLocationWithinContainerElementPoint);

            SetCurrentlyDraggedElement(dragContainerElement, draggedElement);
            draggedElement.MouseMove += DraggedElement_MouseMove;
            draggedElement.MouseUp += DraggedElement_MouseUp;
        }

        static FrameworkElement SetCurrentShift(object sender, MouseEventArgs e)
        {
            FrameworkElement draggedElement = (FrameworkElement)sender;

            FrameworkElement attachedToElement = GetAttachedToElement(draggedElement);

            FrameworkElement dragContainerElement =
                GetDragContainerElement(attachedToElement);

            Point currentPosition = e.GetPosition(dragContainerElement);
            Point startPosition = GetStartDragPoint(attachedToElement);
            Point shift = currentPosition.Minus(startPosition);
            Point initialElementPoint = GetStartElementPoint(attachedToElement);

            Point totalShift = shift.Plus(initialElementPoint);

            Point startBoundaryPoint = GetStartBoundaryPoint(attachedToElement);
            Point endBoundaryPoint = GetEndBoundaryPoint(attachedToElement);

            Point initialElementPointWithRespectToContainer =
                GetStartLocationWithinContainerElement(attachedToElement);

            Point totalShiftWithRespectToContainer = shift.Plus(initialElementPointWithRespectToContainer);

            if ( (!startBoundaryPoint.Equals(DefaultStartBoundary)) ||
                 (!endBoundaryPoint.Equals(DefaultEndBoundary)) )
            {
                Rect boundary = 
                    new Rect
                    (
                        startBoundaryPoint.X, 
                        startBoundaryPoint.Y, 
                        endBoundaryPoint.X - startBoundaryPoint.X,
                        endBoundaryPoint.Y - startBoundaryPoint.Y);

                Point updateVector = 
                    totalShiftWithRespectToContainer.BoundaryUpdate(boundary);

                totalShiftWithRespectToContainer = totalShiftWithRespectToContainer.Plus(updateVector);

                totalShift = totalShift.Plus(updateVector);
            }

            SetTotalShiftWithRespectToContainer(attachedToElement, totalShiftWithRespectToContainer);

            SetShift(attachedToElement, totalShift);

            SetIsDragOn(attachedToElement, true);

            return draggedElement;
        }

        private static void DraggedElement_MouseMove(object sender, MouseEventArgs e)
        {
            SetCurrentShift(sender, e);
        }

        private static void DraggedElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement draggedElement = SetCurrentShift(sender, e);

            FrameworkElement attachedToElement = GetAttachedToElement(draggedElement);

            bool bounceBack = GetBounceBackAtDragEnd(attachedToElement);

            if (bounceBack)
            {
                Point startElementPoint = GetStartElementPoint(attachedToElement);

                SetShift(draggedElement, startElementPoint);
            }

            draggedElement.ReleaseMouseCapture();
            draggedElement.MouseMove -= DraggedElement_MouseMove;
            draggedElement.MouseUp -= DraggedElement_MouseUp;

            FrameworkElement dragContainerElement =
                GetDragContainerElement(attachedToElement);

            SetIsDragOn(attachedToElement, false);
            SetCurrentlyDraggedElement(dragContainerElement, null);
        }
        #endregion DraggedElement attached Property

        #region DragContainerElement attached Property
        public static FrameworkElement GetDragContainerElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(DragContainerElementProperty);
        }

        public static void SetDragContainerElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(DragContainerElementProperty, value);
        }

        public static readonly DependencyProperty DragContainerElementProperty =
        DependencyProperty.RegisterAttached
        (
            "DragContainerElement",
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(default(FrameworkElement))
        );
        #endregion DragContainerElement attached Property

        #region StartDragPoint attached Property
        public static Point GetStartDragPoint(DependencyObject obj)
        {
            return (Point)obj.GetValue(StartDragPointPropertyKey.DependencyProperty);
        }

        private static void SetStartDragPoint(DependencyObject obj, Point value)
        {
            obj.SetValue(StartDragPointPropertyKey, value);
        }

        public static readonly DependencyPropertyKey StartDragPointPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "StartDragPoint",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(new Point())
        );
        #endregion StartDragPoint attached Property

        #region StartElementPoint attached Property
        public static Point GetStartElementPoint(DependencyObject obj)
        {
            return (Point)obj.GetValue(StartElementPointPropertyKey.DependencyProperty);
        }

        private static void SetStartElementPoint(DependencyObject obj, Point value)
        {
            obj.SetValue(StartElementPointPropertyKey, value);
        }

        public static readonly DependencyPropertyKey StartElementPointPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "StartElementPoint",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(new Point())
        );
        #endregion StartElementPoint attached Property

        #region StartLocationWithinContainerElement attached Property
        public static Point GetStartLocationWithinContainerElement(DependencyObject obj)
        {
            return (Point)obj.GetValue(StartLocationWithinContainerElementProperty);
        }

        public static void SetStartLocationWithinContainerElement(DependencyObject obj, Point value)
        {
            obj.SetValue(StartLocationWithinContainerElementProperty, value);
        }

        public static readonly DependencyProperty StartLocationWithinContainerElementProperty =
        DependencyProperty.RegisterAttached
        (
            "StartLocationWithinContainerElement",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(default(Point))
        );
        #endregion StartLocationWithinContainerElement attached Property

        #region Shift attached Property
        public static Point GetShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(ShiftPropertyKey.DependencyProperty);
        }

        public static void SetShift(DependencyObject obj, Point value)
        {
            obj.SetValue(ShiftPropertyKey, value);
        }

        public static readonly DependencyPropertyKey ShiftPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "Shift",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(new Point())
        );
        #endregion Shift attached Property

        #region TotalShiftWithRespectToContainer attached Property
        public static Point GetTotalShiftWithRespectToContainer(DependencyObject obj)
        {
            return (Point)obj.GetValue(TotalShiftWithRespectToContainerProperty);
        }

        public static void SetTotalShiftWithRespectToContainer(DependencyObject obj, Point value)
        {
            obj.SetValue(TotalShiftWithRespectToContainerProperty, value);
        }

        public static readonly DependencyProperty TotalShiftWithRespectToContainerProperty =
        DependencyProperty.RegisterAttached
        (
            "TotalShiftWithRespectToContainer",
            typeof(Point),
            typeof(DragBehavior),
            new PropertyMetadata(DefaultEndBoundary)
        );
        #endregion TotalShiftWithRespectToContainer attached Property

        #region CurrentlyDraggedElement attached Property
        public static FrameworkElement GetCurrentlyDraggedElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(CurrentlyDraggedElementPropertyKey.DependencyProperty);
        }

        private static void SetCurrentlyDraggedElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(CurrentlyDraggedElementPropertyKey, value);
        }

        public static readonly DependencyPropertyKey CurrentlyDraggedElementPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "CurrentlyDraggedElement",
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(default(FrameworkElement))
        );
        #endregion CurrentlyDraggedElement attached Property
    }
}
