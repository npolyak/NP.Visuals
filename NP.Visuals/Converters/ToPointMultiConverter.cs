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
            double x = double.NaN;
            double y = double.NaN;
            if ((values == null) || (values.Length == 0))
            {
                return new Point(x, y); ;
            }

            if (values[0] is double actualX)
            {
                x = actualX;
            }

            if ((values.Length > 1) && (values[1] is double actualY))
            {
                y = actualY;
            }
            return new Point(x, y);
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
