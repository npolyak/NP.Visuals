using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NP.Visuals
{
    public class DragBehavior : 
        Freezable, 
        IVisualBehavior
    {
        #region TheDraggedElement attached Property
        public static FrameworkElement GetTheDraggedElement(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(TheDraggedElementProperty);
        }

        public static void SetTheDraggedElement(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(TheDraggedElementProperty, value);
        }

        public static readonly DependencyProperty TheDraggedElementProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDraggedElement",
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(null)
        );
        #endregion TheDraggedElement attached Property


        #region TheDragDropCoordinator Property
        public DragDropCoordinator TheDragDropCoordinator
        {
            get;set;
        }
        #endregion TheDragDropCoordinator Property

        protected FrameworkElement TheElement { get; private set; } = null;

        public bool ShouldResetShift { get; set; } = false;

        Popup ThePopup => TheMovingElement as Popup;

        #region TheContainingElement Dependency Property
        public FrameworkElement TheContainingElement
        {
            get { return (FrameworkElement)GetValue(TheContainingElementProperty); }
            set { SetValue(TheContainingElementProperty, value); }
        }

        public static readonly DependencyProperty TheContainingElementProperty =
        DependencyProperty.Register
        (
            nameof(TheContainingElement),
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(null)
        );
        #endregion TheContainingElement Dependency Property

        #region TheMovingElement Dependency Property
        public FrameworkElement TheMovingElement
        {
            get { return (FrameworkElement)GetValue(TheMovingElementProperty); }
            set { SetValue(TheMovingElementProperty, value); }
        }

        public static readonly DependencyProperty TheMovingElementProperty =
        DependencyProperty.Register
        (
            nameof(TheMovingElement),
            typeof(FrameworkElement),
            typeof(DragBehavior),
            new PropertyMetadata(null)
        );
        #endregion TheMovingElement Dependency Property


        public void Attach(FrameworkElement el)
        {
            el.MouseDown += _el_MouseDown;
        }

        public void Detach(FrameworkElement el)
        {
            el.MouseDown -= _el_MouseDown;
        }

        protected virtual Point GetOriginalShift()
        {
            return AttachedProps.GetTheShift(TheMovingElement);
        }

        protected virtual Point GetOriginalMousePosition(MouseButtonEventArgs e)
        {
            return e.GetPosition(TheContainingElement);
        }

        Point _originalShift;
        Point _originalMousePosition;

        bool _isWithinDrag = false;
        private void _el_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TheMovingElement == null)
                return;

            TheElement = sender as FrameworkElement;

            _isWithinDrag = true;
            OnStartDrag(e);

            SetTheDraggedElement(TheMovingElement, TheElement);
            _originalShift = GetOriginalShift();
            _originalMousePosition = GetOriginalMousePosition(e);

            TheElement.CaptureMouse();

            Popup popup = TheElement as Popup;

            if (this.ThePopup != null)
            {
                this.ThePopup.IsOpen = true;
            }

            this.TheDragDropCoordinator?.StartDrag(TheElement, TheContainingElement);

            TheElement.MouseMove += _el_MouseMove;
            TheElement.MouseUp += _el_MouseUp;
            TheElement.MouseWheel += TheElement_MouseWheel;
        }

        private async void TheElement_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            SetPosition(e);
            await Task.Delay(500);

            SetPosition(e);
        }

        public virtual void OnStartDrag(MouseButtonEventArgs e)
        {

        }

        protected virtual void ResetShift()
        {
            AttachedProps.SetTheShift(TheMovingElement, new Point());
        }

        private void _el_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TheElement.ReleaseMouseCapture();
                TheElement.MouseWheel -= TheElement_MouseWheel;
                TheElement.MouseMove -= _el_MouseMove;
                TheElement.MouseUp -= _el_MouseUp;

                SetPosition(e);

                if (ShouldResetShift)
                    ResetShift();

                if (this.ThePopup != null)
                {
                    this.ThePopup.IsOpen = false;
                }

                this.TheDragDropCoordinator?.EndDrag();

                TheElement = null;
            }
            finally
            {
                SetTheDraggedElement(TheMovingElement, null);

                _isWithinDrag = false;
            }
        }

        protected virtual void SetTheShift(Point shift)
        {
            AttachedProps.SetTheShift
            (
                TheMovingElement,
                shift
            );
        }

        protected void SetPosition(MouseEventArgs e)
        {
            if (!_isWithinDrag)
                return;

            Point currentMousePosition =
                e.GetPosition(TheContainingElement);

            Point delta = currentMousePosition.Minus(_originalMousePosition);

            Point newShift = _originalShift.Plus(delta);

            SetTheShift(newShift);

            this.TheDragDropCoordinator?.MoveDragCue();
        }

        private void _el_MouseMove(object sender, MouseEventArgs e)
        {
            SetPosition(e);
        }

        protected override Freezable CreateInstanceCore()
        {
            return this;
        }
    }
}
