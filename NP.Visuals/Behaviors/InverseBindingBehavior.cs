using NP.Utilities;
using System;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Behaviors
{
    public static class InverseBindingBehavior
    {

        #region TheConverter attached Property
        public static IValueConverter GetTheConverter(DependencyObject obj)
        {
            return (IValueConverter)obj.GetValue(TheConverterProperty);
        }

        public static void SetTheConverter(DependencyObject obj, IValueConverter value)
        {
            obj.SetValue(TheConverterProperty, value);
        }

        public static readonly DependencyProperty TheConverterProperty =
        DependencyProperty.RegisterAttached
        (
            "TheConverter",
            typeof(IValueConverter),
            typeof(InverseBindingBehavior),
            new PropertyMetadata(default(IValueConverter), OnDPChanged)
        );
        #endregion TheConverter attached Property

        #region TheDetectingProp attached Property
        public static object GetTheDetectingProp(DependencyObject obj)
        {
            return (object)obj.GetValue(TheDetectingPropProperty);
        }

        private static void SetTheDetectingProp(DependencyObject obj, object value)
        {
            obj.SetValue(TheDetectingPropProperty, value);
        }

        static readonly DependencyProperty TheDetectingPropProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDetectingProp",
            typeof(object),
            typeof(InverseBindingBehavior),
            new PropertyMetadata(default(object), OnDetectingPropertyChanged)
        );

        private static void OnDetectingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            object val = GetTheDetectingProp(el);

            if (val == null)
                return;

            object dataContext = el.DataContext;

            if (dataContext == null)
                return;

            string path = GetThePath(el);

            if (path == null)
                return;

            dataContext.SetCompoundPropValue(path, val);
        }
        #endregion TheDetectingProp attached Property


        #region TheDP attached Property
        public static DependencyProperty GetTheDP(DependencyObject obj)
        {
            return (DependencyProperty)obj.GetValue(TheDPProperty);
        }

        public static void SetTheDP(DependencyObject obj, DependencyProperty value)
        {
            obj.SetValue(TheDPProperty, value);
        }

        public static readonly DependencyProperty TheDPProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDP",
            typeof(DependencyProperty),
            typeof(InverseBindingBehavior),
            new PropertyMetadata(default(DependencyProperty), OnDPChanged)
        );

        private static void OnDPChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyProperty dp = GetTheDP(d);

            Binding binding = new Binding
            {
                Source = d,
                Mode = BindingMode.OneWay,
                Path = new PropertyPath(dp),
                Converter = GetTheConverter(d)
            };

            BindingOperations.SetBinding(d, TheDetectingPropProperty, binding);
        }
        #endregion TheDP attached Property


        #region ThePath attached Property
        public static string GetThePath(DependencyObject obj)
        {
            return (string)obj.GetValue(ThePathProperty);
        }

        public static void SetThePath(DependencyObject obj, string value)
        {
            obj.SetValue(ThePathProperty, value);
        }

        public static readonly DependencyProperty ThePathProperty =
        DependencyProperty.RegisterAttached
        (
            "ThePath",
            typeof(string),
            typeof(InverseBindingBehavior),
            new PropertyMetadata(default(string))
        );
        #endregion ThePath attached Property
    }
}
