using NP.Utilities;
using NP.Visuals.Behaviors;
using System.Windows;

namespace NP.Visuals
{
    public class InverseBinding : IVisualBehavior
    {
        public FrameworkElement TheElement { get; private set; }

        bool _isDPChangeDetectionSet = false;
        DPChangeDetectionBehavior _dpDetectionBehavior = new DPChangeDetectionBehavior();
        void SetDPDetection()
        {
            if (_isDPChangeDetectionSet)
                return;

            if ((this.TheElement == null) || (this.TheDP == null))
                return;

            _isDPChangeDetectionSet = true;

            _dpDetectionBehavior.TheBindingSourceObject = this.TheElement;
            _dpDetectionBehavior.TheDP = this.TheDP;

            _dpDetectionBehavior.PropChangedEvent += 
                _dpDetectionBehavior_PropChangedEvent;
        }

        private void _dpDetectionBehavior_PropChangedEvent()
        {
            SetVal();
        }

        string _propName;
        public string PropName
        {
            get => _propName;

            set
            {
                if (_propName == value)
                    return;

                _propName = value;

                SetVal();
            }
        }

        DependencyProperty _dp;
        public DependencyProperty TheDP
        {
            get => _dp;
            set
            {
                if (_dp == value)
                    return;

                _dp = value;

                SetVal();
                SetDPDetection();
            }
        }

        private void SetVal()
        {
            if ((TheDP == null) || (TheElement?.DataContext == null) || PropName.IsNullOrEmpty())
                return;

            object dataContext = TheElement.DataContext;

            object val = TheElement.GetValue(TheDP);

            dataContext.SetCompoundPropValue(PropName, val);
        }

        public void Attach(FrameworkElement el)
        {
            TheElement = el;
            SetDPDetection();

            TheElement.DataContextChanged += 
                TheElement_DataContextChanged;

            SetVal();
        }

        private void TheElement_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetVal();
        }

        public void Detach(FrameworkElement el)
        {
            if (_dpDetectionBehavior != null)
            {
                _dpDetectionBehavior.PropChangedEvent -= 
                    _dpDetectionBehavior_PropChangedEvent;
            }

            TheElement.DataContextChanged -= 
                TheElement_DataContextChanged;
        }
    }
}
