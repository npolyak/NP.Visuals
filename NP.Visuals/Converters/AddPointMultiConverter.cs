using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class AddPointMultiConverter : IMultiValueConverter
    {
        public static AddPointMultiConverter Instance { get; } = 
            new AddPointMultiConverter();

        public object Convert
        (
            object[] values, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            Point result = new Point();
            if (values == null)
                return result;

            foreach (object obj in values)
            {
                if (obj is Point p)
                {
                    result = result.Plus(p);
                }
            }

            return result;
        }

        public object[] ConvertBack
        (
            object value, 
            Type[] targetTypes, 
            object parameter, 
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
