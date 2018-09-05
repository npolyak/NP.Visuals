using System.Windows;

namespace NP.Visuals.Behaviors.DragDrop
{
    public interface IDropPositionChooser
    {
        Point GetPositionWithinDropDontainer
        (
            FrameworkElement droppedElement,
            FrameworkElement dropContainer,
            Point mousePositionWithRespectToContainer);
    }
}
