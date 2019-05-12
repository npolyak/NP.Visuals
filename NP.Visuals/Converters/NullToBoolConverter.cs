using NP.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public static NullToBoolConverter Instance { get; } = 
            new NullToBoolConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            if (value is string str)
            {
                return !str.IsNullOrEmpty();
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
