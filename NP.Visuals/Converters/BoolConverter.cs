using NP.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class BoolConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public BoolConverter()
        {

        }

        public BoolConverter(T trueValue, T falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? TrueValue : FalseValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is T v)
            {
                return v.ObjEquals(TrueValue);
            }

            return value;
        }
    }

    public class BoolToDoubleConverter : BoolConverter<double>
    {
        public static BoolToDoubleConverter PositiveNegativeConverter { get; } =
            new BoolToDoubleConverter(1, -1);

        public BoolToDoubleConverter()
        {

        }

        public BoolToDoubleConverter(double trueValue, double falseValue) : 
            base(trueValue, falseValue)
        {

        }
    }
}
