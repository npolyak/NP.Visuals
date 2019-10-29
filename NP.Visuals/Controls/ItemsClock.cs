using NP.Concepts;
using NP.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NP.Visuals.Controls
{
    public class ItemsClock : Control
    {
        public int NumberItems { get; private set; }

        #region ItemsSource Dependency Property
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register
        (
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(ItemsClock),
            new PropertyMetadata(default(IEnumerable), OnItemsSourceChanged)
        );

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemsClock itemsClock = (ItemsClock)d;

            itemsClock.SetClickItems();
        }

        private void SetClickItems()
        {
            IEnumerable itemsSource = this.ItemsSource;

            List<ICircularArrangedItem> clockItems = new List<ICircularArrangedItem>();
            
            if (itemsSource == null)
                return;

            NumberItems = itemsSource.Cast<object>().Count();

            double angleBetweenItems = 360.0 / NumberItems;

            double angle = 0;
            foreach(object item in itemsSource)
            {
                ICircularArrangedItem circularArrangedItem = item as ICircularArrangedItem;


                if (circularArrangedItem != null)
                {
                    circularArrangedItem.Angle = angle;
                }
                else
                {
                    circularArrangedItem = new ClockItem(angle, item);
                }

                clockItems.Add(circularArrangedItem);

                angle += angleBetweenItems;
            }

            TheClockItems = clockItems;
        }
        #endregion ItemsSource Dependency Property

        #region TheClockItems Dependency Property
        public IEnumerable<ICircularArrangedItem> TheClockItems
        {
            get { return (IEnumerable<ICircularArrangedItem>)GetValue(TheClockItemsPropertyKey.DependencyProperty); }
            private set { SetValue(TheClockItemsPropertyKey, value); }
        }

        public static readonly DependencyPropertyKey TheClockItemsPropertyKey =
        DependencyProperty.RegisterReadOnly
        (
            nameof(TheClockItems),
            typeof(IEnumerable<ICircularArrangedItem>),
            typeof(ItemsClock),
            new PropertyMetadata(default(IEnumerable<ICircularArrangedItem>))
        );
        #endregion TheClockItems Dependency Property


        #region ItemDataTemplate Dependency Property
        public DataTemplate ItemDataTemplate
        {
            get { return (DataTemplate)GetValue(ItemDataTemplateProperty); }
            set { SetValue(ItemDataTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemDataTemplateProperty =
        DependencyProperty.Register
        (
            nameof(ItemDataTemplate),
            typeof(DataTemplate),
            typeof(ItemsClock),
            new PropertyMetadata(default(DataTemplate))
        );
        #endregion ItemDataTemplate Dependency Property

        #region HandAngle Dependency Property
        public double HandAngle
        {
            get { return (double)GetValue(HandAngleProperty); }
            set { SetValue(HandAngleProperty, value); }
        }

        public static readonly DependencyProperty HandAngleProperty =
        DependencyProperty.Register
        (
            nameof(HandAngle),
            typeof(double),
            typeof(ItemsClock),
            new PropertyMetadata(default(double))
        );
        #endregion HandAngle Dependency Property

        #region NextHandAngle Dependency Property
        public double NextHandAngle
        {
            get { return (double)GetValue(NextHandAnglePropertyKey.DependencyProperty); }
            private set { SetValue(NextHandAnglePropertyKey, value); }
        }

        public static readonly DependencyPropertyKey NextHandAnglePropertyKey =
        DependencyProperty.RegisterReadOnly
        (
            nameof(NextHandAngle),
            typeof(double),
            typeof(ItemsClock),
            new PropertyMetadata(default(double), OnNexHandAngleChanged)
        );

        private static void OnNexHandAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ItemsClock)d).OnNextHandAngleChanged();
        }

        private void OnNextHandAngleChanged()
        {
            Storyboard storyboard = new Storyboard();
            Storyboard.SetTarget(storyboard, this);
            Storyboard.SetTargetProperty(storyboard, new PropertyPath(ItemsClock.HandAngleProperty));

            DoubleAnimation doubleAnimation = new DoubleAnimation();

            double startAngle = HandAngle.NormalizeAngle();
            doubleAnimation.From = startAngle;

            double endAngle = NextHandAngle.GetBestNorimalizedAngleAfterAngle(startAngle);

            doubleAnimation.To = endAngle;

            doubleAnimation.Duration = TimeSpan.FromSeconds(1);

            doubleAnimation.EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut };

            storyboard.Children.Add(doubleAnimation);

            storyboard.FillBehavior = FillBehavior.HoldEnd;

            storyboard.Begin();
        }

        #endregion NextHandAngle Dependency Property

        #region CurrentItem Dependency Property
        public object CurrentItem
        {
            get { return (object)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        public static readonly DependencyProperty CurrentItemProperty =
        DependencyProperty.Register
        (
            nameof(CurrentItem),
            typeof(object),
            typeof(ItemsClock),
            new PropertyMetadata(default(object), OnCurrentItemChanged)
        );

        private static void OnCurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ItemsClock)d).OnCurrentItemChanged(); 
        }

        private void OnCurrentItemChanged()
        {
            if (CurrentItem == null)
                return;

            int idx = this.TheClockItems
                            ?.Select((item, idx) => new { item, idx })
                            .FirstOrDefault(pair => CurrentItem.ObjEquals(pair.item.GetItemForComparison()))?.idx ?? -1 ;

            if (idx >= 0)
            {
                NextHandAngle = idx * (360.0 / NumberItems);
            }
        }
        #endregion CurrentItem Dependency Property

    }
}
