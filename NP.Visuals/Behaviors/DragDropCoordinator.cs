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
    public class DragDropCoordinator : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public FrameworkElement TheCurrentDragElement { get; private set; }
        public FrameworkElement TheCurrentContainingElement { get; private set; }

        public List<FrameworkElement> TheDropAreaElements { get; } = 
            new List<FrameworkElement>();

        #region TheCurrentDropAreaElement Property
        private FrameworkElement _currentDropAreaElement;
        public FrameworkElement TheCurrentDropAreaElement
        {
            get
            {
                return this._currentDropAreaElement;
            }
            private set
            {
                if (this._currentDropAreaElement == value)
                {
                    return;
                }

                if (_currentDropAreaElement != null)
                    AttachedProps.SetCanDrop(_currentDropAreaElement, false);

                this._currentDropAreaElement = value;

                if (_currentDropAreaElement != null) 
                    AttachedProps.SetCanDrop(_currentDropAreaElement, CanDrop);

                OnPropertyChanged(nameof(IsAboveDropArea));
            }
        }
        #endregion TheCurrentDropAreaElement Property

        public virtual bool CanDrop => true;

        public DragDropCoordinator()
        {
            DragCueMovedEvent += DragDropCoordinator_DragCueMovedEvent;
            DragEndedEvent += DragDropCoordinator_DragEndedEvent;
        }

        private void DragDropCoordinator_DragCueMovedEvent()
        {
            PingIsAboveDropArea();
        }

        private void DragDropCoordinator_DragEndedEvent()
        {
            OnDragEnded();
        }

        protected virtual void OnDragEnded() { }

        bool IsAboveDropAreaOfAnElement(FrameworkElement dropAreaElement)
        {
            if (dropAreaElement == null)
                return false;

            Point mousePosition = Mouse.GetPosition(dropAreaElement);

            bool isAboveDropArea =
                (mousePosition.X > 0) &&
                (mousePosition.Y > 0) &&
                (mousePosition.X < dropAreaElement.ActualWidth) &&
                (mousePosition.Y < dropAreaElement.ActualHeight);

            if (mousePosition.X > 0)
            {

            }

            return isAboveDropArea;
        }

        public bool IsAboveDropArea =>
            this.TheCurrentDropAreaElement != null;


        void PingIsAboveDropArea()
        {
            this.TheCurrentDropAreaElement = null;
            foreach (var dropAreaElement in TheDropAreaElements)
            {
                if (IsAboveDropAreaOfAnElement(dropAreaElement))
                {
                    this.TheCurrentDropAreaElement = dropAreaElement;
                    break;
                }
            }
        }

        public event Action DragStartedEvent;
        public event Action DragEndedEvent;
        public event Action DragCueMovedEvent;

        public void StartDrag(FrameworkElement dragElement, FrameworkElement containingElement)
        {
            this.TheCurrentDragElement = dragElement;
            this.TheCurrentContainingElement = containingElement;

            PingIsAboveDropArea();

            DragStartedEvent?.Invoke();
        }

        public void EndDrag()
        {
            if (!this.IsAboveDropArea)
            {
                return;
            }

            DragEndedEvent?.Invoke();

            this.TheCurrentDropAreaElement = null;
        }

        public void MoveDragCue() => DragCueMovedEvent?.Invoke();
    }
}
