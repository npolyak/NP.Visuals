using NP.Visuals.Utils;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class HorizontalAlignmentToIconConverter : IValueConverter
    {
        public static HorizontalAlignmentToIconConverter Instance { get; } =
            new HorizontalAlignmentToIconConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HorizontalAlignment horizontalAlignment)
            {
                return horizontalAlignment.ToIcon();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
