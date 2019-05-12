using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class NumberToThicknessConverter : IValueConverter
    {
        public static NumberToThicknessConverter Instance { get; } =
            new NumberToThicknessConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = System.Convert.ToDouble(value);

            return new Thickness(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
