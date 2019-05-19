using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class BoolOrMultiValueConverter<T> : IMultiValueConverter
    {
        public T TrueValue;
        public T FalseValue;

        public BoolOrMultiValueConverter(T trueValue, T falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return FalseValue;

            foreach(object val in values)
            {
                if (val is bool b)
                {
                    if (b)
                        return TrueValue;
                }
            }

            return FalseValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolOrToVisibilityMultiValueConveter : BoolOrMultiValueConverter<Visibility>
    {
        public static BoolOrToVisibilityMultiValueConveter Instance { get; } =
            new BoolOrToVisibilityMultiValueConveter();

        public BoolOrToVisibilityMultiValueConveter() : base(Visibility.Visible, Visibility.Collapsed)
        {
        }
    }
}
