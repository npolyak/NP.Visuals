using NP.Concepts;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class AssembledConverter : IValueConverter
    {
        IConverter _directConverter;
        IConverter _inverseConverter;

        public AssembledConverter
        (
            IConverter directConverter, 
            IConverter inverseConverter)
        {
            _directConverter = directConverter;
            _inverseConverter = inverseConverter;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _directConverter.Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _inverseConverter.Convert(value);
        }
    }
}
