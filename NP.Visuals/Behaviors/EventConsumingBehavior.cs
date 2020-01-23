using System;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public class EventConsumingBehavior
    {

        #region EventToConsume attached Property
        public static RoutedEvent GetEventToConsume(DependencyObject obj)
        {
            return (RoutedEvent)obj.GetValue(EventToConsumeProperty);
        }

        public static void SetEventToConsume(DependencyObject obj, RoutedEvent value)
        {
            obj.SetValue(EventToConsumeProperty, value);
        }

        public static readonly DependencyProperty EventToConsumeProperty =
        DependencyProperty.RegisterAttached
        (
            "EventToConsume",
            typeof(RoutedEvent),
            typeof(EventConsumingBehavior),
            new PropertyMetadata(default(RoutedEvent), OnEventChanged)
        );

        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;
            RoutedEvent routedEvent = GetEventToConsume(el);

            if (routedEvent != null)
            {
                el.RemoveHandler(routedEvent, (RoutedEventHandler)OnEvent);
                el.AddHandler(routedEvent, (RoutedEventHandler)OnEvent);
            }
        }
        #endregion EventToConsume attached Property

        static void OnEvent(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
