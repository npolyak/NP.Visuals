using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NP.Visuals
{
    public class NegativeConverter : IValueConverter
    {
        public static NegativeConverter TheInstance { get; } =
            new NegativeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                return -((double)value);
            }

            if (value is decimal)
            {
                return -((decimal)value);
            }

            if (value is float)
            {
                return -((float)value);
            }

            if (value is int)
            {
                return -((int)value);
            }

            if (value is long)
            {
                return -((long)value);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
