using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NP.Visuals
{
    public class InverseBoolConverter : IValueConverter
    {
        public static InverseBoolConverter TheInstance { get; } = 
            new InverseBoolConverter();

        object Invert(object value)
        {
            if (value is bool)
            {
                bool b = (bool)value;

                return !b;
            }

            return value;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Invert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Invert(value);
        }
    }
}
