using NP.Visuals.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals
{
    public class BoolToVisConverter : IValueConverter
    {
        public static BoolToVisConverter TheInstance { get; } =
            new BoolToVisConverter(true);

        public static BoolToVisConverter TheInverseInstance { get; } =
            new BoolToVisConverter(false);

        bool _isDirectOrInverse = true;

        public BoolToVisConverter(bool directOrInverse)
        {
            _isDirectOrInverse = directOrInverse;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;

            return val.ToVis(_isDirectOrInverse);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
