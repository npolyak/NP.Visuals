using NP.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class LastLinkConverter : IValueConverter
    {
        public static LastLinkConverter LastPeriodLinkConverter { get; } =
            new LastLinkConverter(".");

        public string Separator { get; }
        public LastLinkConverter(string separator)
        {
            Separator = separator;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value?.ToString();

            if (str == null)
                return str;

            return str.SubstrFromTo(Separator, "`", false);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
