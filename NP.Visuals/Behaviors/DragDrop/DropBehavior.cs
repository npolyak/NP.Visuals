using NP.Visuals.Utils;
using System;
using System.Windows;
using System.Windows.Input;

namespace NP.Visuals.Behaviors.DragDrop
{
    public static class DropBehavior
    {
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
            typeof(DropBehavior),
            new PropertyMetadata(default(FrameworkElement), OnDraggedElementChanged)
        );

        private static void OnDraggedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement oldEl = e.OldValue as FrameworkElement;
            FrameworkElement attachedToElement = (FrameworkElement)d;

            MouseEventHandler onMouseMove =
                (sender, args) =>
                {
                    FrameworkElement attachedToEl = attachedToElement;
                    SetMousePosition(sender, attachedToEl);
                };

            MouseButtonEventHandler onMouseUp = null;
            onMouseUp = (sender, args) =>
                {
                    FrameworkElement attachedToEl = attachedToElement;
                    OnMouseUp(sender, attachedToEl);
                    FrameworkElement draggedElement = (FrameworkElement)sender;

                    draggedElement.MouseMove -= onMouseMove;
                    draggedElement.MouseUp -= onMouseUp;
                };


            if (oldEl != null)
            {
                oldEl.MouseUp -= onMouseUp;
                oldEl.MouseMove -= onMouseMove;
            }

            FrameworkElement newEl = e.NewValue as FrameworkElement;

            if (newEl != null)
            {

                SetMousePosition(newEl, attachedToElement);
                newEl.MouseMove += onMouseMove;

                newEl.MouseUp += onMouseUp;
            }
        }

        private static bool SetMousePosition(object sender, FrameworkElement attachedToEl)
        {
            FrameworkElement draggedEl = (FrameworkElement)sender;

            FrameworkElement containerEl = GetContainerElement(attachedToEl);

            Point mousePositionWithRespectToContainerElement = 
                Mouse.GetPosition(containerEl);

            SetMousePositionWithinContainerElement
            (
                attachedToEl, 
                mousePositionWithRespectToContainerElement);

            bool isDragAbove = containerEl.Contains(mousePositionWithRespectToContainerElement);

            SetIsDragAbove(attachedToEl, isDragAbove);

            bool result = 
                SetWhetherCanDrop(draggedEl, attachedToEl, mousePositionWithRespectToContainerElement);

            if (result)
            {
                IDropPositionChooser dropPositonChooser = GetTheDropPositionChooser(attachedToEl);

                if (dropPositonChooser != null)
                {
                    Point dropPoint =
                        dropPositonChooser.GetPositionWithinDropDontainer
                        (
                            draggedEl,
                            containerEl,
                            mousePositionWithRespectToContainerElement);

                    SetDropPosition(attachedToEl, dropPoint);
                }
            }

            return result;
        }

        private static void OnMouseUp(object sender, FrameworkElement attachedToEl)
        {
            FrameworkElement draggedEl = (FrameworkElement)sender;

            bool canDrop = SetMousePosition(draggedEl, attachedToEl);

            if (canDrop)
            {
                FrameworkElement containerEl = GetContainerElement(attachedToEl);

                // drop
                IDropOperation dropOperation = GetTheDropOperation(attachedToEl);

                Point mousePositionWithinContainerElement = GetMousePositionWithinContainerElement(attachedToEl);

                dropOperation.Drop(draggedEl, containerEl, mousePositionWithinContainerElement);

                SetCanDrop(attachedToEl, false);
            }

            SetIsDragAbove(attachedToEl, false);
        }
        #endregion DraggedElement attached Property

        private static bool SetWhetherCanDrop
        (
            FrameworkElement draggedElement, 
            FrameworkElement attachedToEl,
            Point mousePositionWithinContainer)
        {
            FrameworkElement containerEl = GetContainerElement(attachedToEl);

            bool isDragAbove = GetIsDragAbove(attachedToEl);

            ICanDropChecker canDropChecker = GetTheCanDropChecker(attachedToEl);

            bool canDrop = isDragAbove && (canDropChecker?.CanDrop(draggedElement, containerEl, mousePositionWithinContainer) ?? true);

            SetCanDrop(attachedToEl, canDrop);

            return canDrop;
        }

        #region ContainerElement attached Property
        public static FrameworkElement GetContainerElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(ContainerElementProperty);
        }

        public static void SetContainerElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(ContainerElementProperty, value);
        }

        public static readonly DependencyProperty ContainerElementProperty =
        DependencyProperty.RegisterAttached
        (
            "ContainerElement",
            typeof(FrameworkElement),
            typeof(DropBehavior),
            new PropertyMetadata(default(FrameworkElement))
        );
        #endregion ContainerElement attached Property

        #region MousePositionWithinContainerElement attached Property
        public static Point GetMousePositionWithinContainerElement(DependencyObject obj)
        {
            return (Point)obj.GetValue(MousePositionWithinContainerElementProperty);
        }

        public static void SetMousePositionWithinContainerElement(DependencyObject obj, Point value)
        {
            obj.SetValue(MousePositionWithinContainerElementProperty, value);
        }

        public static readonly DependencyProperty MousePositionWithinContainerElementProperty =
        DependencyProperty.RegisterAttached
        (
            "MousePositionWithinContainerElement",
            typeof(Point),
            typeof(DropBehavior),
            new PropertyMetadata(default(Point))
        );
        #endregion MousePositionWithinContainerElement attached Property

        #region DropPosition attached Property
        public static Point GetDropPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(DropPositionProperty);
        }

        public static void SetDropPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(DropPositionProperty, value);
        }

        public static readonly DependencyProperty DropPositionProperty =
        DependencyProperty.RegisterAttached
        (
            "DropPosition",
            typeof(Point),
            typeof(DropBehavior),
            new PropertyMetadata(default(Point))
        );
        #endregion DropPosition attached Property

        #region IsDragAbove attached Property
        public static bool GetIsDragAbove(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragAbovePropertyKey.DependencyProperty);
        }

        private static void SetIsDragAbove(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragAbovePropertyKey, value);
        }

        public static readonly DependencyPropertyKey IsDragAbovePropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragAbove",
            typeof(bool),
            typeof(DropBehavior),
            new PropertyMetadata(default(bool))
        );
        #endregion IsDragAbove attached Property

        #region CanDrop attached Property
        public static bool GetCanDrop(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanDropPropertyKey.DependencyProperty);
        }

        private static void SetCanDrop(DependencyObject obj, bool value)
        {
            obj.SetValue(CanDropPropertyKey, value);
        }

        public static readonly DependencyPropertyKey CanDropPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "CanDrop",
            typeof(bool),
            typeof(DropBehavior),
            new PropertyMetadata(default(bool))
        );
        #endregion CanDrop attached Property

        #region TheCanDropChecker attached Property
        public static ICanDropChecker GetTheCanDropChecker(DependencyObject obj)
        {
            return (ICanDropChecker)obj.GetValue(TheCanDropCheckerProperty);
        }

        public static void SetTheCanDropChecker(DependencyObject obj, CanDropChecker value)
        {
            obj.SetValue(TheCanDropCheckerProperty, value);
        }

        public static readonly DependencyProperty TheCanDropCheckerProperty =
        DependencyProperty.RegisterAttached
        (
            "TheCanDropChecker",
            typeof(ICanDropChecker),
            typeof(DropBehavior),
            new PropertyMetadata(default(ICanDropChecker))
        );
        #endregion TheCanDropChecker attached Property

        #region TheDropOperation attached Property
        public static IDropOperation GetTheDropOperation(DependencyObject obj)
        {
            return (IDropOperation)obj.GetValue(TheDropOperationProperty);
        }

        public static void SetTheDropOperation(DependencyObject obj, IDropOperation value)
        {
            obj.SetValue(TheDropOperationProperty, value);
        }

        public static readonly DependencyProperty TheDropOperationProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDropOperation",
            typeof(IDropOperation),
            typeof(DropBehavior),
            new PropertyMetadata(default(IDropOperation))
        );
        #endregion TheDropOperation attached Property

        #region TheDropPositionChooser attached Property
        public static IDropPositionChooser GetTheDropPositionChooser(DependencyObject obj)
        {
            return (IDropPositionChooser)obj.GetValue(TheDropPositionChooserProperty);
        }

        public static void SetTheDropPositionChooser(DependencyObject obj, IDropPositionChooser value)
        {
            obj.SetValue(TheDropPositionChooserProperty, value);
        }

        public static readonly DependencyProperty TheDropPositionChooserProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDropPositionChooser",
            typeof(IDropPositionChooser),
            typeof(DropBehavior),
            new PropertyMetadata(default(IDropPositionChooser))
        );
        #endregion TheDropPositionChooser attached Property
    }
}
