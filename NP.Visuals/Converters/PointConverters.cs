using NP.Concepts;
using NP.Utilities;
using NP.Visuals.Utils;
using System.Windows;

namespace NP.Visuals.Converters
{
    public class ToVisPointConverter : IConverter
    {
        public object Convert(object value)
        {
            Point2D point = value as Point2D;

            return point?.ToPoint();
        }
    }

    public class FromVisPointConverter : IConverter
    {
        public object Convert(object value)
        {
            if (!(value is Point))
                return new Point2D();

            Point p = (Point)value;

            return p.ToPoint2D();
        }
    }
}
