using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class MultiplyMultiValueConverter : IMultiValueConverter
    {
        public static MultiplyMultiValueConverter Instance { get; } = 
            new MultiplyMultiValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return 0d;

            double result = 1d;

            foreach(object valObj in values)
            {
                if (valObj is double d)
                {
                    result *= d;
                }
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
