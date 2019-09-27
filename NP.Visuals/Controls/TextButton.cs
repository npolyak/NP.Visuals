using NP.Visuals.Utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class TextButton : Button
    {
        static TextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata
            (
                typeof(TextButton),
                new FrameworkPropertyMetadata(typeof(TextButton)));

            Application.Current.Resources.MergedDictionaries.Add
            (
                new ResourceDictionary
                {
                    Source = new Uri("/NP.Visuals;Component/Themes/ControlStylesAndTemplates.xaml", UriKind.RelativeOrAbsolute)
                });
        }

        public TextButton()
        {
            Command = new DelegateCommand(SetButtonTrigger);
        }

        #region ButtonTrigger Dependency Property
        public bool ButtonTrigger
        {
            get { return (bool)GetValue(ButtonTriggerProperty); }
            set { SetValue(ButtonTriggerProperty, value); }
        }

        public static readonly DependencyProperty ButtonTriggerProperty =
        DependencyProperty.Register
        (
            nameof(ButtonTrigger),
            typeof(bool),
            typeof(TextButton),
            new PropertyMetadata(default(bool))
        );
        #endregion ButtonTrigger Dependency Property

        public void SetButtonTrigger()
        {
            ButtonTrigger = true;
        }
    }
}
