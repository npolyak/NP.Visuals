using NP.Utilities;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals
{
    public class UniformlySpreadingControl : ItemsControl
    {
        #region TheOrientation Dependency Property
        public Orientation TheOrientation
        {
            get { return (Orientation)GetValue(TheOrientationProperty); }
            set { SetValue(TheOrientationProperty, value); }
        }

        public static readonly DependencyProperty TheOrientationProperty =
        DependencyProperty.Register
        (
            nameof(TheOrientation),
            typeof(Orientation),
            typeof(UniformlySpreadingControl),
            new PropertyMetadata(Orientation.Vertical, OnOrientationChanged)
        );

        private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UniformlySpreadingControl)d).SetItemSize();
        }
        #endregion TheOrientation Dependency Property


        public UniformlySpreadingControl()
        {
            SizeChanged += UniformlySpreadingControl_SizeChanged;
        }

        private void UniformlySpreadingControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetItemSize();
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            SetItemSize();
        }

        #region ItemSize Dependency Property
        public double ItemSize
        {
            get { return (double)GetValue(ItemSizePropertyKey.DependencyProperty); }
            private set { SetValue(ItemSizePropertyKey, value); }
        }

        public static readonly DependencyPropertyKey ItemSizePropertyKey =
        DependencyProperty.RegisterReadOnly
        (
            nameof(ItemSize),
            typeof(double),
            typeof(UniformlySpreadingControl),
            new PropertyMetadata(double.NaN)
        );
        #endregion ItemSize Dependency Property



        void SetItemSize()
        {
            if ( Items.IsNullOrEmpty())
            {
                Visibility = Visibility.Collapsed;
                return;
            }

            double actualSize =
                (this.TheOrientation == Orientation.Vertical) ?
                    this.ActualHeight : this.ActualWidth;
            
            Visibility = Visibility.Visible;

            ItemSize = actualSize / this.Items.Count;
        }
    }
}
