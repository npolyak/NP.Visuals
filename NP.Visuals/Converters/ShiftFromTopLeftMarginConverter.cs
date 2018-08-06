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
    public class ShiftFromTopLeftMarginConverter : IValueConverter
    {
        public static ShiftFromTopLeftMarginConverter TheInstance { get; } =
            new ShiftFromTopLeftMarginConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
                return new Thickness();

            double doubleVal = (double)value;

            return new Thickness(doubleVal, doubleVal, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
