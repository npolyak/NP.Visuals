using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class FactorConverter : IValueConverter
    {
        public static FactorConverter TheDoubleConverter { get; } =
            new FactorConverter { TheFactor = 2d };

        public double TheFactor { get; private set; } = 1d;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
                return 0d;

            return ((double)value) * TheFactor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
