using NP.Concepts;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NP.Visuals.Converters
{
    public class NotificationLevelConverter<TInput, TResult> : 
        IConverter<NotificationLevel, TResult>, 
        IValueConverter
    {
        public TInput DefaultValue { get; set; }
        public TInput WarningValue { get; set; }
        public TInput ErrorValue { get; set; }

        public Func<TInput, TResult> _inputToResultConverter;
        public NotificationLevelConverter(Func<TInput, TResult> converter)
        {
            _inputToResultConverter = converter;
        }

        private TInput ConvertImpl(NotificationLevel val) =>
            val switch
            {
                NotificationLevel.Error => ErrorValue,
                NotificationLevel.Warning => WarningValue,
                _ => DefaultValue
            };

        public TResult Convert(NotificationLevel val) =>
            _inputToResultConverter(ConvertImpl(val));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NotificationLevel val)
            {
                return Convert(val);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NotificationLevelToBrushConverter : NotificationLevelConverter<Color, Brush>, IValueConverter
    {
        public NotificationLevelToBrushConverter() : base(color => new SolidColorBrush(color))
        {
        }
    }
}
