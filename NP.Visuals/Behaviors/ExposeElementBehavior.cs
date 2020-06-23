using NP.Paradigms.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NP.Visuals
{
    public class ExposeElementBehavior<ExposedElementType> : IVisualBehavior
        where ExposedElementType : FrameworkElement
    {
        FrameworkElement _el;
        DependencyProperty _dp;
        string _exposedElementName;
        public ExposeElementBehavior
        (
            DependencyProperty dp, 
            string exposedElementName = null
        )
        {
            _dp = dp;
            _exposedElementName = exposedElementName;
        }

        public void Attach(FrameworkElement el, bool _ = true)
        {
            _el = el;
            _el.LayoutUpdated += El_LayoutUpdated;
        }

        private async void El_LayoutUpdated(object sender, EventArgs e)
        {
            Detach(_el);

            Func<ExposedElementType, bool> predicate = (exposedEl) => true;

            if (_exposedElementName != null )
            {
                predicate = (exposedEl) => exposedEl.Name == _exposedElementName;
            }

            ExposedElementType exposedElement =
                _el.VisualDescendants<ExposedElementType>().FirstOrDefault(predicate);

            if (exposedElement != null)
            {

                if (_dp == null)
                {
                    ExposedElementAttachedProp<ExposedElementType>
                        .SetTheExposedElement(_el, exposedElement);
                }
                else
                {
                    _el.SetValue(_dp, exposedElement);
                }
                return;
            }

            await Task.Delay(200);
            Attach(_el);
        }

        public void Detach(FrameworkElement el, bool _ = true)
        {
            _el.LayoutUpdated -= El_LayoutUpdated;
        }
    }

    public static class ExposedElementAttachedProp<ExposedElementType>
        where ExposedElementType : FrameworkElement
    {
        #region TheExposedElement attached Property
        public static ExposedElementType GetTheExposedElement(DependencyObject obj)
        {
            return (ExposedElementType)obj.GetValue(TheExposedElementProperty);
        }

        public static void SetTheExposedElement(DependencyObject obj, ExposedElementType value)
        {
            obj.SetValue(TheExposedElementProperty, value);
        }

        public static readonly DependencyProperty TheExposedElementProperty =
        DependencyProperty.RegisterAttached
        (
            "TheExposedElement",
            typeof(ExposedElementType),
            typeof(ExposedElementAttachedProp<ExposedElementType>),
            new PropertyMetadata(null)
        );
        #endregion TheExposedElement attached Property
    }
}
