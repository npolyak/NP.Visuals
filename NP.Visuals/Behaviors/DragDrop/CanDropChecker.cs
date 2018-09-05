using System;
using System.Windows;

namespace NP.Visuals.Behaviors.DragDrop
{
    public interface ICanDropChecker
    {
        bool CanDrop
        (
            FrameworkElement draggedElement, 
            FrameworkElement dropContainer,
            Point mousePositionWithinDropContainer);
    }

    public class CanDropChecker : ICanDropChecker
    {
        public Func<FrameworkElement, FrameworkElement, Point, bool> CanDropDelegate { get; }

        public CanDropChecker(Func<FrameworkElement, FrameworkElement, Point, bool> canDropDelegate)
        {
            CanDropDelegate = canDropDelegate;
        }

        public bool CanDrop
        (
            FrameworkElement draggedElement, 
            FrameworkElement dropContainer,
            Point mousePositionWithinDropContainer)
        {
            return CanDropDelegate.Invoke
            (
                draggedElement, 
                dropContainer,
                mousePositionWithinDropContainer) == true;
        }
    }
}
