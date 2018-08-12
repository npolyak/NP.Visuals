using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class ToStringConverter : IValueConverter
    {
        public static ToStringConverter TheInstance { get; } = new ToStringConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
