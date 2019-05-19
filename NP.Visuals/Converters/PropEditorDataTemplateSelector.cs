using NP.Visuals.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NP.Visuals.Converters
{
    // receives and object of type DependencyPropertyInfo
    public class PropEditorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StandardTemplate { get; set; }

        public DataTemplate BoolTemplate { get; set; }

        public DataTemplate EnumTemplate { get; set; }

        public DataTemplate BrushTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DependencyPropertyInfo dpInfo)
            {
                Type propType = dpInfo.PropertyType;

                if (propType == typeof(bool))
                    return BoolTemplate;

                if (propType.IsEnum)
                    return EnumTemplate;

                if (typeof(Brush).IsAssignableFrom(propType))
                    return BrushTemplate;
            }

            return StandardTemplate;
        }
    }
}
