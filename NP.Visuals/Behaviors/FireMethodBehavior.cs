using NP.Utilities;
using System;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class FireMethodBehavior
    {
        #region Trigger attached Property
        public static bool GetTrigger(DependencyObject obj)
        {
            return (bool)obj.GetValue(TriggerProperty);
        }

        public static void SetTrigger(DependencyObject obj, bool value)
        {
            obj.SetValue(TriggerProperty, value);
        }

        public static readonly DependencyProperty TriggerProperty =
        DependencyProperty.RegisterAttached
        (
            "Trigger",
            typeof(bool),
            typeof(FireMethodBehavior),
            new PropertyMetadata(default(bool), OnTriggerChanged)
        );

        private static void OnTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string methodName = GetMethodName(d)?.Trim();

            if (methodName.IsNullOrWhiteSpace())
                return;

            d.CallMethod(methodName, false, false);
        }
        #endregion Trigger attached Property


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
            typeof(FireMethodBehavior),
            new PropertyMetadata(default(string))
        );
        #endregion MethodName attached Property


    }
}
