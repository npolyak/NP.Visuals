using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
