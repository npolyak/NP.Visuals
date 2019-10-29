using NP.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class ChooseFirstValueMultiConverter : IMultiValueConverter
    {
        public static ChooseFirstValueMultiConverter Instance { get; } =
            new ChooseFirstValueMultiConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.IsNullOrEmpty())
                return null;

            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value, 0 };
        }
    }
}
