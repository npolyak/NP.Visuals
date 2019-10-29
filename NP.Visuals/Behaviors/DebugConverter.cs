using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Behaviors
{
    public class DebugConverter : IValueConverter
    {
        public static DebugConverter Instance { get; } = 
            new DebugConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
