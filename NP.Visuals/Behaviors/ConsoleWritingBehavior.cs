using NP.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class ConsoleWritingBehavior
    {
        private class ConsoleWriter : ConsoleWriterBase
        {
            FrameworkElement _element { get; }

            protected override void WriteString(string str)
            {
                var consoleText = GetConsoleText(_element);

                consoleText += str;

                SetConsoleText(_element, consoleText);
            }

            public ConsoleWriter(FrameworkElement el)
            {
                _element = el;
            }
        }

        #region ConsoleText attached Property
        public static string GetConsoleText(DependencyObject obj)
        {
            return (string)obj.GetValue(ConsoleTextProperty);
        }

        public static void SetConsoleText(DependencyObject obj, string value)
        {
            obj.SetValue(ConsoleTextProperty, value);
        }

        public static readonly DependencyProperty ConsoleTextProperty =
        DependencyProperty.RegisterAttached
        (
            "ConsoleText",
            typeof(string),
            typeof(ConsoleWritingBehavior),
            new PropertyMetadata("")
        );
        #endregion ConsoleText attached Property


        #region IsSet attached Property
        public static bool GetIsSet(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSetProperty);
        }

        public static void SetIsSet(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSetProperty, value);
        }

        public static readonly DependencyProperty IsSetProperty =
        DependencyProperty.RegisterAttached
        (
            "IsSet",
            typeof(bool),
            typeof(ConsoleWritingBehavior),
            new PropertyMetadata(default(bool), OnIsSetChanged)
        );


        private static void OnIsSetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            bool isSet = GetIsSet(el);

            if (isSet)
            {
                ConsoleWriter consoleWriter = new ConsoleWriter(el);

                SetTheConsoleWriter(el, consoleWriter);
            }
        }
        #endregion IsSet attached Property

        #region TheConsoleWriter attached Property
        private static ConsoleWriter GetTheConsoleWriter(DependencyObject obj)
        {
            return (ConsoleWriter)obj.GetValue(TheConsoleWriterProperty);
        }

        private static void SetTheConsoleWriter(DependencyObject obj, ConsoleWriter value)
        {
            obj.SetValue(TheConsoleWriterProperty, value);
        }

        private static readonly DependencyProperty TheConsoleWriterProperty =
        DependencyProperty.RegisterAttached
        (
            "TheConsoleWriter",
            typeof(ConsoleWriter),
            typeof(ConsoleWritingBehavior),
            new PropertyMetadata(default(ConsoleWriter))
        );
        #endregion TheConsoleWriter attached Property

    }
}
