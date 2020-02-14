using NP.Utilities;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public static class ClearDPLocalValueBehavior
    {

        #region TheDP attached Property
        public static DependencyProperty[] GetTheDPs(DependencyObject obj)
        {
            return (DependencyProperty[])obj.GetValue(TheDPsProperty);
        }

        public static void SetTheDPs(DependencyObject obj, DependencyProperty value)
        {
            obj.SetValue(TheDPsProperty, value);
        }

        public static readonly DependencyProperty TheDPsProperty =
        DependencyProperty.RegisterAttached
        (
            "TheDPs",
            typeof(DependencyProperty[]),
            typeof(ClearDPLocalValueBehavior),
            new PropertyMetadata(null, OnTheDPsChanged)
        );

        private static void OnTheDPsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyProperty[] dps = GetTheDPs(d);

            foreach (var dp in dps.NullToEmpty())
            {
                d.ClearValue(dp);
            }
        }
        #endregion TheDP attached Property

    }
}
