using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Behaviors
{
    public class DPChangeDetectionBehavior : Freezable, IVisualBehavior
    {
        public event Action PropChangedEvent;

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
            ((DPChangeDetectionBehavior)d).OnTargetValueChanged();
        }

        private void OnTargetValueChanged()
        {
            this.PropChangedEvent?.Invoke();
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


        public void Attach(FrameworkElement obj)
        {
            this.TheCurrentObj = obj;
        }

        public void Detach(FrameworkElement obj)
        {
            this.TheCurrentObj = null;
        }

        protected override Freezable CreateInstanceCore()
        {
            return this;
        }
    }
}
