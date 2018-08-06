using NP.Utilities;
using System.Windows;

namespace NP.Visuals
{
    public static class PointExtensions
    {
        public static Point Times(this Point p, double coeff)
        {
            return new Point(p.X * coeff, p.Y * coeff);
        }

        public static Point Negative(this Point p)
        {
            return p.Times(-1);
        }

        public static Point Plus(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point Minus(this Point p1, Point p2)
        {
            return p1.Plus(p2.Negative());
        }

        public static Point ToNonNegative(this Point point)
        {
            return new Point(point.X.NonNegative(), point.Y.NonNegative());
        }
    }
}
