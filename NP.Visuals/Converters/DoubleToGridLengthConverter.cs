using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class DoubleToGridLengthConverter : IValueConverter
    {
        public static DoubleToGridLengthConverter Instance { get; } =
            new DoubleToGridLengthConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return new GridLength(d);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GridLength gridLength)
            {
                if (!gridLength.IsAbsolute)
                    return null;

                return gridLength.Value;
            }

            return null;
        }
    }
}
