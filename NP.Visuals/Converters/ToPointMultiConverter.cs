using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class ToPointMultiConverter : IMultiValueConverter
    {
        public static ToPointMultiConverter TheInstance { get; } =
            new ToPointMultiConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return new Point(double.NaN, double.NaN);

            if (values[0] is double X)
            {
                if (values[1] is double Y)
                {
                    return new Point(X, Y);
                }
            }

            return new Point(double.NaN, double.NaN);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is Point p)
            {
                return new object[] { p.X, p.Y };
            }

            return new object[] { double.NaN, double.NaN };
        }
    }
}
