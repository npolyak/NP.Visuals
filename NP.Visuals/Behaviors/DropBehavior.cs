using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NP.Visuals
{
    public class DropBehavior :
        Freezable,
        IVisualBehavior
    {
        #region TheDragDropCoordinator Property
        public DragDropCoordinator TheDragDropCoordinator
        {
            get;set;
        }
        #endregion TheDragDropCoordinator Property

        void UnsetDragDropCoordinatorAreaDropElement(FrameworkElement el)
        {
            this.TheDragDropCoordinator.TheDropAreaElements.Remove(el);
        }

        void SetDragDropCoordinatorAreaDropElement(FrameworkElement el)
        {
            UnsetDragDropCoordinatorAreaDropElement(el);

            this.TheDragDropCoordinator.TheDropAreaElements.Add(el);
        }

        public void Attach(FrameworkElement el)
        {
            SetDragDropCoordinatorAreaDropElement(el);
            el.Unloaded += El_Unloaded;
        }

        private void El_Unloaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement el = e.Source as FrameworkElement;
            Detach(el);
        }

        public void Detach(FrameworkElement el)
        {
            el.Unloaded -= El_Unloaded;
            UnsetDragDropCoordinatorAreaDropElement(el);
        }

        protected override Freezable CreateInstanceCore()
        {
            return this;
        }
    }
}
