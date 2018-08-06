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
    public class AngleToPointConverter : IMultiValueConverter
    {
        public static AngleToPointConverter TheInstance { get; } =
            new AngleToPointConverter();

        const double TO_RADS_CONVERSION_FACTOR = 2 * Math.PI / 360d;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values == null) || (values.Length < 2) || (!(values[0] is double)) || (!(values[1] is double)))
                return new Point();

            double angle = (double) values[0];

            //angle = angle % 360d;

            double radius = (double)values[1];

            if (values.Length == 4)
            {
                double endAngle = (double)values[2];

                //endAngle = endAngle % 360d;

                double weight = System.Convert.ToDouble(values[3]);

                angle = (angle + endAngle) * weight;
            }

            double factor = radius;
            if (parameter != null)
                factor *= System.Convert.ToDouble(parameter);

            Point result = 
                new Point
                (
                    factor * Math.Cos(angle * TO_RADS_CONVERSION_FACTOR), 
                    factor * Math.Sin(angle * TO_RADS_CONVERSION_FACTOR));

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
