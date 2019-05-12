using System;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class RoutedEventReactionBehavior
    {
        public static FrameworkElement GetObjectToDetectEventOn(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(ObjectToDetectEventOnProperty);
        }

        public static void SetObjectToDetectEventOn(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(ObjectToDetectEventOnProperty, value);
        }

        // Using a DependencyProperty as the backing store for ObjectToDetectEventOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectToDetectEventOnProperty =
            DependencyProperty.RegisterAttached
            (
                "ObjectToDetectEventOn", 
                typeof(FrameworkElement), 
                typeof(RoutedEventReactionBehavior), 
                new PropertyMetadata(null, SetEventDetection));



        public static RoutedEvent GetTheEventToDetect(DependencyObject obj)
        {
            return (RoutedEvent)obj.GetValue(TheEventToDetectProperty);
        }

        public static void SetTheEventToDetect(DependencyObject obj, RoutedEvent value)
        {
            obj.SetValue(TheEventToDetectProperty, value);
        }

        // Using a DependencyProperty as the backing store for TheEventToDetect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheEventToDetectProperty =
            DependencyProperty.RegisterAttached
            (
                "TheEventToDetect", 
                typeof(RoutedEvent), 
                typeof(RoutedEventReactionBehavior), 
                new PropertyMetadata(null, SetEventDetection));

        public static void SetEventDetection(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement objectToDetectEventOn =
                GetObjectToDetectEventOn(sender);

            if (objectToDetectEventOn == null)
                return;

            RoutedEvent routedEvent = GetTheEventToDetect(sender);

            if (routedEvent == null)
                return;

            FrameworkElement currentEl = (FrameworkElement)sender;
            void Handler(object obj, RoutedEventArgs routedEventArgs)
            {
                routedEventArgs.RoutedEvent = DetectedEvent;
                currentEl.RaiseEvent(routedEventArgs);
            }

            objectToDetectEventOn.AddHandler(routedEvent, (RoutedEventHandler) Handler);
        }

        public static readonly RoutedEvent DetectedEvent = EventManager.RegisterRoutedEvent
        (
            "Detect",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(RoutedEventReactionBehavior));
    }
}
