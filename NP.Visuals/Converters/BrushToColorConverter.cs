using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NP.Visuals.Converters
{
    public class BrushToColorConverter : IValueConverter
    {
        public static BrushToColorConverter TheInstance { get; } = 
            new BrushToColorConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as SolidColorBrush != null ? (value as SolidColorBrush).Color : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }
}
