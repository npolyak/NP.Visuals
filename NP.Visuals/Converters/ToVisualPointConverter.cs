﻿using NP.Utilities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals
{
    public class ToVisualPointConverter : IValueConverter
    {
        public static ToVisualPointConverter TheInstance { get; } = new ToVisualPointConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Point2D point = value as Point2D;

            return point.ToPoint();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Point))
                return new Point2D();

            Point p = (Point)value;

            return p.ToPoint2D();
        }
    }


    public static class PointConversionUtils
    {
        public static Point ToPoint(this Point2D point)
        {
            if (point == null)
                return new Point();

            return new Point(point.X, point.Y);
        }

        public static Point2D ToPoint2D(this Point point)
        {
            return new Point2D(point.X, point.Y);
        }

        // returns the vector needed the add to d so that it would fit the Rectangle
        // if d is within the interval, 0 is returned.
        public static Point BoundaryUpdate(this Point point, Rect boundary)
        {
            Point result =
                new Point
                (
                    point.X.BoundaryUpdate(boundary.X, boundary.Width),
                    point.Y.BoundaryUpdate(boundary.Y, boundary.Height));

            return result;
        }
    }
}
