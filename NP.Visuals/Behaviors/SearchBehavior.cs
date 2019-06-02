using NP.Utilities;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class SearchBehavior
    {
        #region SearchStr attached Property
        public static string GetSearchStr(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchStrProperty);
        }

        public static void SetSearchStr(DependencyObject obj, string value)
        {
            obj.SetValue(SearchStrProperty, value);
        }

        public static readonly DependencyProperty SearchStrProperty =
        DependencyProperty.RegisterAttached
        (
            "SearchStr",
            typeof(string),
            typeof(SearchBehavior),
            new PropertyMetadata(default(string), CheckShouldShow)
        );
        #endregion SearchStr attached Property


        #region ValueToMatch attached Property
        public static object GetValueToMatch(DependencyObject obj)
        {
            return (object)obj.GetValue(ValueToMatchProperty);
        }

        public static void SetValueToMatch(DependencyObject obj, object value)
        {
            obj.SetValue(ValueToMatchProperty, value);
        }

        public static readonly DependencyProperty ValueToMatchProperty =
        DependencyProperty.RegisterAttached
        (
            "ValueToMatch",
            typeof(object),
            typeof(SearchBehavior),
            new PropertyMetadata(default(object), CheckShouldShow)
        );
        #endregion ValueToMatch attached Property


        #region ShowIfNoSearchString attached Property
        public static bool GetShowIfNoSearchString(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowIfNoSearchStringProperty);
        }

        public static void SetShowIfNoSearchString(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowIfNoSearchStringProperty, value);
        }

        public static readonly DependencyProperty ShowIfNoSearchStringProperty =
        DependencyProperty.RegisterAttached
        (
            "ShowIfNoSearchString",
            typeof(bool),
            typeof(SearchBehavior),
            new PropertyMetadata(true, CheckShouldShow)
        );
        #endregion ShowIfNoSearchString attached Property


        private static void CheckShouldShow(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SetShow(sender, IsMatching(sender));
        }

        private static bool IsMatching(DependencyObject sender)
        {
            string searchStr = GetSearchStr(sender);

            if (searchStr.IsNullOrWhiteSpace())
            {
                return GetShowIfNoSearchString(sender);
            }

            string matchValue = GetValueToMatch(sender).ToStr();

            if (matchValue.IsNullOrWhiteSpace())
            {
                return false;
            }

            bool matches =
                matchValue.ToString().Trim().ToLower().Contains(searchStr.Trim().ToLower());

            return matches;
        }

        #region Show attached Property
        public static bool GetShow(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowPropertyKey.DependencyProperty);
        }

        private static void SetShow(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowPropertyKey, value);
        }

        public static readonly DependencyPropertyKey ShowPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly
        (
            "Show",
            typeof(bool),
            typeof(SearchBehavior),
            new PropertyMetadata(default(bool))
        );
        #endregion Show attached Property

    }
}
