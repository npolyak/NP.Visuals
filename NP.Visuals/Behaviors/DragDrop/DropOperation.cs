using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NP.Visuals.Behaviors.DragDrop
{
    public interface IDropOperation
    {
        void Drop
        (
            FrameworkElement droppedElement, 
            FrameworkElement dropContainer, 
            Point mousePositionWithRespectToContainer);
    }

    public class DropOperation : IDropOperation
    {
        public Action<FrameworkElement, FrameworkElement, Point> DropOperationDelegate { get; }

        public DropOperation(Action<FrameworkElement, FrameworkElement, Point> dropOperationDelegate)
        {
            DropOperationDelegate = dropOperationDelegate;
        }

        public void Drop
        (
            FrameworkElement droppedElement, 
            FrameworkElement dropContainer,
            Point mousePositionWithRespectToContainer
        )
        {
            DropOperationDelegate.Invoke(droppedElement, dropContainer, mousePositionWithRespectToContainer);
        }
    }
}
