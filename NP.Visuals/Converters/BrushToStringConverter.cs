using NP.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NP.Visuals.Converters
{
    public class BrushToStringConverter : IValueConverter
    {
        public static BrushToStringConverter TheInstance { get; } = 
            new BrushToStringConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.ToString().IsNullOrEmpty() != false)
                return null;

            try
            {
                Color color = (Color) ColorConverter.ConvertFromString(value.ToString());

                return new SolidColorBrush(color);
            }
            catch
            {
                return value;
            }
        }
    }
}
