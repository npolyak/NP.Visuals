using NP.Utilities;
using System.Windows;

namespace NP.Visuals.Utils
{

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

        public static Rect ToRect(this Point point1, Point point2)
        {
            return new Rect(point1, point2);
        }

        public static Rect ToRect(this Point endPoint)
        {
            return (new Point()).ToRect(endPoint);
        }

        public static Rect ToRect(this FrameworkElement el)
        {
            return (new Point(el.ActualWidth, el.ActualHeight)).ToRect();
        }

        public static bool Contains(this FrameworkElement el, Point p)
        {
            return el.ToRect().Contains(p);
        }
    }
}
