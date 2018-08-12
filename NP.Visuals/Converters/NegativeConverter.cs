using NP.Visuals.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals
{
    public class NegativeConverter : IValueConverter
    {
        public static NegativeConverter TheInstance { get; } =
            new NegativeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return -d;
            }

            if (value is decimal v)
            {
                return -v;
            }

            if (value is float f)
            {
                return -f;
            }

            if (value is int i)
            {
                return -i;
            }

            if (value is long l)
            {
                return -l;
            }

            if (value is Point p)
            {
                return p.Negative();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
