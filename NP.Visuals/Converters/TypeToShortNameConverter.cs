using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NP.Visuals
{
    public class TypeToShortNameConverter : IValueConverter
    {
        public static TypeToShortNameConverter TheInstance { get; } =
            new TypeToShortNameConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type type = value as Type;

            if (type == null)
                return value;

            return type.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
