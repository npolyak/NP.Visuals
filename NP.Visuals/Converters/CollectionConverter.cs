using NP.Utilities;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class CollectionConverter : IMultiValueConverter
    {
        public static CollectionConverter Instance { get; } = 
            new CollectionConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.IsNullOrEmpty())
                return null;

            IEnumerable collection = values[0] as IEnumerable;

            return collection.CollectionToStr();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
