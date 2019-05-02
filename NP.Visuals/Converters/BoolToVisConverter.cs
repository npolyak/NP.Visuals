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
            new BoolToVisConverter(true, true);

        public static BoolToVisConverter TheInverseInstance { get; } =
            new BoolToVisConverter(false, true);

        public static BoolToVisConverter TheHiddenInstance { get; } =
            new BoolToVisConverter(true, false);

        public static BoolToVisConverter TheInverseHiddenInstance { get; } =
            new BoolToVisConverter(false, false);

        bool _isDirectOrInverse = true;
        bool _collapsedOrHidden = true;

        public BoolToVisConverter(bool directOrInverse, bool collapsedOrHidden)
        {
            _isDirectOrInverse = directOrInverse;
            _collapsedOrHidden = collapsedOrHidden;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;

            return val.ToVis(_isDirectOrInverse, _collapsedOrHidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
