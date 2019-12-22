using NP.Utilities;
using System;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class SingleArgMethodCallingBehavior
    {

        #region TheRoutedEvent attached Property
        public static RoutedEvent GetTheRoutedEvent(DependencyObject obj)
        {
            return (RoutedEvent)obj.GetValue(TheRoutedEventProperty);
        }

        public static void SetTheRoutedEvent(DependencyObject obj, RoutedEvent value)
        {
            obj.SetValue(TheRoutedEventProperty, value);
        }

        public static readonly DependencyProperty TheRoutedEventProperty =
        DependencyProperty.RegisterAttached
        (
            "TheRoutedEvent",
            typeof(RoutedEvent),
            typeof(SingleArgMethodCallingBehavior),
            new PropertyMetadata(default(RoutedEvent), OnRoutedEventChanged)
        );

        private static void OnRoutedEventChanged
        (
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            RoutedEvent routedEvent = e.OldValue as RoutedEvent;
            
            if (routedEvent != null)
            {
                el.RemoveHandler(routedEvent, (RoutedEventHandler) OnRoutedEventCaught);
            }

            routedEvent = GetTheRoutedEvent(d);
           
            if (routedEvent != null)
            {
                el.AddHandler(routedEvent, (RoutedEventHandler) OnRoutedEventCaught);
            }
        }
        #endregion TheRoutedEvent attached Property

        static void OnRoutedEventCaught(object sender, RoutedEventArgs args)
        {
            DependencyObject control = (DependencyObject)sender;

            object targetObject = GetTargetObject(control);

            string methodName = GetMethodName(control);

            object arg = GetArgValue(control);

            targetObject.CallMethod(methodName, false, false, arg);
        }

        #region TargetObject attached Property
        public static object GetTargetObject(DependencyObject obj)
        {
            return (object)obj.GetValue(TargetObjectProperty);
        }

        public static void SetTargetObject(DependencyObject obj, object value)
        {
            obj.SetValue(TargetObjectProperty, value);
        }

        public static readonly DependencyProperty TargetObjectProperty =
        DependencyProperty.RegisterAttached
        (
            "TargetObject",
            typeof(object),
            typeof(SingleArgMethodCallingBehavior),
            new PropertyMetadata(default(object))
        );
        #endregion TargetObject attached Property


        #region MethodName attached Property
        public static string GetMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(MethodNameProperty);
        }

        public static void SetMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(MethodNameProperty, value);
        }

        public static readonly DependencyProperty MethodNameProperty =
        DependencyProperty.RegisterAttached
        (
            "MethodName",
            typeof(string),
            typeof(SingleArgMethodCallingBehavior),
            new PropertyMetadata(default(string))
        );
        #endregion MethodName attached Property


        #region ArgValue attached Property
        public static object GetArgValue(DependencyObject obj)
        {
            return (object)obj.GetValue(ArgValueProperty);
        }

        public static void SetArgValue(DependencyObject obj, object value)
        {
            obj.SetValue(ArgValueProperty, value);
        }

        public static readonly DependencyProperty ArgValueProperty =
        DependencyProperty.RegisterAttached
        (
            "ArgValue",
            typeof(object),
            typeof(SingleArgMethodCallingBehavior),
            new PropertyMetadata(default(object))
        );
        #endregion ArgValue attached Property
    }
}
