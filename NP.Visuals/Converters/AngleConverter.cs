using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NP.Visuals
{
    public class AngleConverter : IValueConverter
    {
        public static IValueConverter TheInstance { get; } = new AngleConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double factor = 360d;
            if (parameter != null)
            {
                bool par = System.Convert.ToBoolean(parameter);

                if (!par)
                {
                    factor = -factor;
                }
            }

            if (value == null)
                return 0;

            double dVal = (double)value;

            return dVal *  factor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
