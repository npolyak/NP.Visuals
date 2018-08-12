using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class SubtractMultiConverter : IMultiValueConverter
    {
        public static SubtractMultiConverter TheInstance { get; } =
            new SubtractMultiConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 1)
                return 0d;

            if (values[0] is double originalValue)
            {
                if (values.Length > 1)
                {
                    if (values[1] is double subtractValue)
                    {
                        return originalValue - subtractValue;
                    }
                }

                return originalValue;
            }

            return 0d;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
