using NP.Visuals.Utils;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class VerticalAlignmentToIconConverter : IValueConverter
    {
        public static VerticalAlignmentToIconConverter Instance { get; } =
            new VerticalAlignmentToIconConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VerticalAlignment verticalAlignment)
            {
                return verticalAlignment.ToIcon();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
