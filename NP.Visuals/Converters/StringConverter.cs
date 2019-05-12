using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class StringConverter : IValueConverter
    {
        public static StringConverter ToLower { get; } =
            new StringConverter((str) => str.ToLower());

        public static StringConverter ToUpper { get; } =
            new StringConverter((str) => str.ToUpper());

        Func<string, string> _convertFn;

        public StringConverter(Func<string, string> convertFn)
        {
            _convertFn = convertFn;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return _convertFn(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
