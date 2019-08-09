using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public abstract class BoolMulitValueConverter<T> : IMultiValueConverter
    {
        public T TrueValue { get; }
        public T FalseValue { get; }

        protected virtual T DefaultValue => FalseValue;
        protected virtual T OKValue => TrueValue;

        protected abstract bool ReturnOK(bool b);

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return DefaultValue;

            foreach(var val in values)
            {
                if (val is bool b)
                {
                    if (ReturnOK(b))
                        return OKValue;
                }
            }

            return DefaultValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public BoolMulitValueConverter(T trueValue, T falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }
    }

    public class BoolOrMultiValueConverter<T> : BoolMulitValueConverter<T>
    {
        public BoolOrMultiValueConverter(T trueValue, T falseValue) : base(trueValue, falseValue)
        {
        }

        protected override bool ReturnOK(bool b)
        {
            return b;
        }
    }

    public class BoolAndMultiValueConverter<T> : BoolMulitValueConverter<T>
    {
        protected override T DefaultValue => TrueValue;
        protected override T OKValue => FalseValue;

        public BoolAndMultiValueConverter(T trueValue, T falseValue) : base(trueValue, falseValue)
        {
        }

        protected override bool ReturnOK(bool b)
        {
            return !b;
        }
    }

    public class BoolAndMultiValueConveter : BoolAndMultiValueConverter<bool>
    {
        public static BoolAndMultiValueConveter Instance { get; } =
            new BoolAndMultiValueConveter();

        public BoolAndMultiValueConveter() : base(true, false)
        {
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

    public class BoolAndToVisibilityMultiValueConveter : BoolAndMultiValueConverter<Visibility>
    {
        public static BoolAndToVisibilityMultiValueConveter Instance { get; } =
            new BoolAndToVisibilityMultiValueConveter();

        public BoolAndToVisibilityMultiValueConveter() : base(Visibility.Visible, Visibility.Collapsed)
        {
        }
    }
}
