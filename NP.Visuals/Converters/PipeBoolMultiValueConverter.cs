using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    /// <summary>
    /// pipes the bools consecutively with each 'false' 
    /// value inverting the result
    /// </summary>
    public class PipeBoolMultiValueConverter : IMultiValueConverter
    {
        public static PipeBoolMultiValueConverter Instance { get; } =
            new PipeBoolMultiValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = true;
            if (values == null)
                return result;

            foreach (var val in values)
            {
                if (val is bool b && !b)
                {
                    result = !result;
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
