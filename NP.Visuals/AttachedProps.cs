using NP.Visuals.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals
{
    public static class AttachedProps
    {
        #region TheShift attached Property
        public static Point GetTheShift(DependencyObject obj)
        {
            return (Point)obj.GetValue(TheShiftProperty);
        }

        public static void SetTheShift(DependencyObject obj, Point value)
        {
            obj.SetValue(TheShiftProperty, value);
        }

        public static readonly DependencyProperty TheShiftProperty =
        DependencyProperty.RegisterAttached
        (
            "TheShift",
            typeof(Point),
            typeof(AttachedProps),
            new PropertyMetadata(new Point())
        );
        #endregion TheShift attached Property



        #region OriginalPosition attached Property
        public static Point GetOriginalPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(OriginalPositionProperty);
        }

        public static void SetOriginalPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(OriginalPositionProperty, value);
        }

        public static readonly DependencyProperty OriginalPositionProperty =
        DependencyProperty.RegisterAttached
        (
            "OriginalPosition",
            typeof(Point),
            typeof(AttachedProps),
            new PropertyMetadata(new Point())
        );
        #endregion OriginalPosition attached Property

        #region CanDrop attached Property
        public static bool GetCanDrop(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanDropProperty);
        }

        public static void SetCanDrop(DependencyObject obj, bool value)
        {
            obj.SetValue(CanDropProperty, value);
        }

        public static readonly DependencyProperty CanDropProperty =
        DependencyProperty.RegisterAttached
        (
            "CanDrop",
            typeof(bool),
            typeof(AttachedProps),
            new PropertyMetadata(false)
        );
        #endregion CanDrop attached Property


        #region TheAttachedBehavior attached Property
        public static IVisualBehavior GetTheAttachedBehavior(DependencyObject obj)
        {
            return (IVisualBehavior)obj.GetValue(TheAttachedBehaviorProperty);
        }

        public static void SetTheAttachedBehavior(DependencyObject obj, IVisualBehavior value)
        {
            obj.SetValue(TheAttachedBehaviorProperty, value);
        }

        public static readonly DependencyProperty TheAttachedBehaviorProperty =
        DependencyProperty.RegisterAttached
        (
            "TheAttachedBehavior",
            typeof(IVisualBehavior),
            typeof(AttachedProps),
            new PropertyMetadata(null, SwitchVisualBehavior)
        );


        public static void SwitchVisualBehavior(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IVisualBehavior oldBehavior = e.OldValue as IVisualBehavior;

            FrameworkElement el = (FrameworkElement)d;

            if (oldBehavior != null)
            {
                oldBehavior.Detach(el);
            }

            IVisualBehavior newBehavior = e.NewValue as IVisualBehavior;

            if (newBehavior != null)
            {
                newBehavior.Attach(el);
            }    
        }
        #endregion TheAttachedBehavior attached Property


        #region TheBehaviors attached Property
        public static IEnumerable<IVisualBehavior> GetTheBehaviors(DependencyObject obj)
        {
            return (IEnumerable<IVisualBehavior>)obj.GetValue(TheBehaviorsProperty);
        }

        public static void SetTheBehaviors(DependencyObject obj, IEnumerable<IVisualBehavior> value)
        {
            obj.SetValue(TheBehaviorsProperty, value);
        }

        public static readonly DependencyProperty TheBehaviorsProperty =
        DependencyProperty.RegisterAttached
        (
            "TheBehaviors",
            typeof(BehaviorCollection),
            typeof(AttachedProps),
            new PropertyMetadata(null, OnTheBehaviorsChanged)
        );

        private static void OnTheBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IEnumerable<IVisualBehavior> oldBehaviors = e.OldValue as IEnumerable<IVisualBehavior>;

            FrameworkElement el = (FrameworkElement)d;

            if (oldBehaviors != null)
            {
                foreach (var behavior in oldBehaviors)
                {
                    behavior.Detach(el);
                }
            }

            IEnumerable<IVisualBehavior> newBehaviors = e.NewValue as IEnumerable<IVisualBehavior>;

            if (newBehaviors != null)
            {
                foreach (var behavior in newBehaviors)
                {
                    behavior.Attach(el);
                }
            }
        }
        #endregion TheBehaviors attached Property


        #region TheContent attached Property
        public static object GetTheContent(DependencyObject obj)
        {
            return (object)obj.GetValue(TheContentProperty);
        }

        public static void SetTheContent(DependencyObject obj, object value)
        {
            obj.SetValue(TheContentProperty, value);
        }

        public static readonly DependencyProperty TheContentProperty =
        DependencyProperty.RegisterAttached
        (
            "TheContent",
            typeof(object),
            typeof(AttachedProps),
            new PropertyMetadata(null)
        );
        #endregion TheContent attached Property

        #region TheContentTemplate attached Property
        public static DataTemplate GetTheContentTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(TheContentTemplateProperty);
        }

        public static void SetTheContentTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(TheContentTemplateProperty, value);
        }

        public static readonly DependencyProperty TheContentTemplateProperty =
        DependencyProperty.RegisterAttached
        (
            "TheContentTemplate",
            typeof(DataTemplate),
            typeof(AttachedProps),
            new PropertyMetadata(null)
        );
        #endregion TheContentTemplate attached Property


        #region TheContextMenu attached Property
        public static ContextMenu GetTheContextMenu(DependencyObject obj)
        {
            return (ContextMenu)obj.GetValue(TheContextMenuProperty);
        }

        public static void SetTheContextMenu(DependencyObject obj, ContextMenu value)
        {
            obj.SetValue(TheContextMenuProperty, value);
        }

        public static readonly DependencyProperty TheContextMenuProperty =
        DependencyProperty.RegisterAttached
        (
            "TheContextMenu",
            typeof(ContextMenu),
            typeof(AttachedProps),
            new PropertyMetadata(null, OnTheContextMenuChanged)
        );

        private static void OnTheContextMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement el = (FrameworkElement)d;

            ContextMenu menu = e.NewValue as ContextMenu;

            SetTheParent(menu, el);

            el.ContextMenu = menu;
        }
        #endregion TheContextMenu attached Property


        #region TheParent attached Property
        public static object GetTheParent(DependencyObject obj)
        {
            return (object)obj.GetValue(TheParentProperty);
        }

        public static void SetTheParent(DependencyObject obj, object value)
        {
            obj.SetValue(TheParentProperty, value);
        }

        public static readonly DependencyProperty TheParentProperty =
        DependencyProperty.RegisterAttached
        (
            "TheParent",
            typeof(object),
            typeof(AttachedProps),
            new PropertyMetadata(null)
        );
        #endregion TheParent attached Property


        #region TheRelayObject attached Property
        public static object GetTheRelayObject(DependencyObject obj)
        {
            return (object)obj.GetValue(TheRelayObjectProperty);
        }

        public static void SetTheRelayObject
        (
            DependencyObject obj, 
            object value
        )
        {
            obj.SetValue(TheRelayObjectProperty, value);
        }

        public static readonly DependencyProperty TheRelayObjectProperty =
        DependencyProperty.RegisterAttached
        (
            "TheRelayObject",
            typeof(object),
            typeof(AttachedProps),
            new PropertyMetadata(null)
        );
        #endregion TheRelayObject attached Property
    }
}
