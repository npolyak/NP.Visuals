using NP.Utilities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class PointToNonNegativeMarginConverter : IValueConverter
    {
        public static PointToNonNegativeMarginConverter TheInstance { get; } =
            new PointToNonNegativeMarginConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double x = 0, y = 0;

            if (value is Point p)
            {
                x = p.X;
                y = p.Y;
            }
            else if (value is Point2D p2D)
            {
                x = p2D.X;
                y = p2D.Y;
            }
            
            return new Thickness(x.NonNegative(), y.NonNegative(), 0d, 0d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
