using System;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Behaviors
{
    public class DPChangeDetectionBehavior : Freezable, IVisualBehavior, IDisposable
    {
        public event Action PropChangedEvent;

        public event Action<DependencyObject, DependencyProperty, object, object> DetailedPropChangedEvent;

        public bool IsSuspended
        {
            get { return (bool)GetValue(IsSuspendedProperty); }
            set { SetValue(IsSuspendedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSuspended.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSuspendedProperty =
            DependencyProperty.Register
            (
                "IsSuspended", 
                typeof(bool), 
                typeof(DPChangeDetectionBehavior), 
                new PropertyMetadata(false));


        #region TheTargetValue Dependency Property
        public object TheTargetValue
        {
            get { return (object)GetValue(TheTargetValueProperty); }
            set { SetValue(TheTargetValueProperty, value); }
        }

        public static readonly DependencyProperty TheTargetValueProperty =
        DependencyProperty.Register
        (
            nameof(TheTargetValueProperty),
            typeof(object),
            typeof(DPChangeDetectionBehavior),
            new PropertyMetadata(null, OnTargetValueChanged)
        );

        private static void OnTargetValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DPChangeDetectionBehavior)d).OnTargetValueChanged(e.OldValue);
        }

        private void OnTargetValueChanged(object oldValue)
        {
            if (IsSuspended)
                return;

            this.PropChangedEvent?.Invoke();

            object newValue = this.TheTargetValue;

            this.DetailedPropChangedEvent?.Invoke(TheBindingSourceObject, TheDP, oldValue, newValue);
        }
        #endregion TheTargetValue Dependency Property


        private static void TryDoBinding(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DPChangeDetectionBehavior)d).TryDoBinding();
        }

        private void TryDoBinding()
        {
            if ( (this.TheBindingSourceObject == null) || 
                 (this.TheDP == null) )
            {
                return;
            }

            Binding binding = new Binding();
            binding.Source = TheBindingSourceObject;
            binding.Path = new PropertyPath(TheDP);
            binding.Mode = BindingMode.OneWay;

            BindingOperations.SetBinding(this, TheTargetValueProperty, binding);
        }

        #region TheBindingSourceObject Dependency Property
        public DependencyObject TheBindingSourceObject
        {
            get { return (DependencyObject)GetValue(TheBindingSourceObjectProperty); }
            set { SetValue(TheBindingSourceObjectProperty, value); }
        }

        public static readonly DependencyProperty TheBindingSourceObjectProperty =
        DependencyProperty.Register
        (
            nameof(TheBindingSourceObject),
            typeof(DependencyObject),
            typeof(DPChangeDetectionBehavior),
            new PropertyMetadata(null, TryDoBinding)
        );
        #endregion TheBindingSourceObject Dependency Property

        #region TheDP Dependency Property
        public DependencyProperty TheDP
        {
            get { return (DependencyProperty)GetValue(TheDependencyPropertyProperty); }
            set { SetValue(TheDependencyPropertyProperty, value); }
        }

        public static readonly DependencyProperty TheDependencyPropertyProperty =
        DependencyProperty.Register
        (
            nameof(TheDP),
            typeof(DependencyProperty),
            typeof(DPChangeDetectionBehavior),
            new PropertyMetadata(null, TryDoBinding)
        );
        #endregion TheDependencyProperty Dependency Property


        #region TheCurrentObj Dependency Property
        public FrameworkElement TheCurrentObj
        {
            get { return (FrameworkElement)GetValue(TheCurrentObjProperty); }
            set { SetValue(TheCurrentObjProperty, value); }
        }

        public static readonly DependencyProperty TheCurrentObjProperty =
        DependencyProperty.Register
        (
            nameof(TheCurrentObj),
            typeof(FrameworkElement),
            typeof(DPChangeDetectionBehavior),
            new PropertyMetadata(null)
        );
        #endregion TheCurrentObj Dependency Property


        public void Attach(FrameworkElement obj, bool _ = true)
        {
            this.TheCurrentObj = obj;
        }

        public void Detach(FrameworkElement obj, bool _ = true)
        {
            this.TheCurrentObj = null;
        }

        protected override Freezable CreateInstanceCore()
        {
            return this;
        }

        public DPChangeDetectionBehavior()
        {

        }

        public void Dispose()
        {
            Detach(null);

            if (OnPropChanged != null)
            {
                PropChangedEvent -= OnPropChanged;
                OnPropChanged = null;
            }
        }

        private Action OnPropChanged;

        public DPChangeDetectionBehavior
        (
            DependencyObject sourceBindingObj,
            DependencyProperty dp,
            Action onPropChanged)
        {
            TheBindingSourceObject = sourceBindingObj;
            TheDP = dp;

            OnPropChanged = onPropChanged;

            if (OnPropChanged != null)
            {
                PropChangedEvent += OnPropChanged;
            }
        }
    }
}
