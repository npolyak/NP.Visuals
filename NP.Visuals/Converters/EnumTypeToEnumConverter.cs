using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class EnumTypeToEnumConverter : IValueConverter
    {
        public static EnumTypeToEnumConverter Instance { get; } = new EnumTypeToEnumConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Type type)
            {
                if (!type.IsEnum)
                    return null;

                return Enum.GetValues(type);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
