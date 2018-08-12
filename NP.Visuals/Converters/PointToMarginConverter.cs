using NP.Utilities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class PointToMarginConverter : IValueConverter
    {
        public static PointToMarginConverter TheInstance { get; } =
            new PointToMarginConverter(false);
        public static PointToMarginConverter TheNonNegativeInstance { get; } =
                new PointToMarginConverter(true);

        bool _nonNegativeOnly;

        public PointToMarginConverter(bool nonNegativeOnly)
        {
            _nonNegativeOnly = nonNegativeOnly;
        }

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

            if (_nonNegativeOnly)
            {
                x = x.NonNegative();
                y = y.NonNegative();
            }
            
            return new Thickness(x, y, 0d, 0d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
