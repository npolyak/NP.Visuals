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
    public class MarginMultiConverter : IMultiValueConverter
    {
        public static double Zero { get; } = 0d;

        public static MarginMultiConverter TheInstance { get; } =
            new MarginMultiConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return new Thickness();

            double originalHorizontalShift = 0, originalVerticalShift = 0;

            if (values[0] is double horizontalShift)
            {
                if (values[1] is double verticalShift)
                {
                    if (values.Length >= 3)
                    {
                        if (values[2] is double)
                        {
                            originalHorizontalShift = (double)values[2];
                        }

                        if (values.Length >= 4)
                        {
                            originalVerticalShift = (double)values[3];
                        }
                    }

                    return new Thickness(originalHorizontalShift + horizontalShift, originalVerticalShift + verticalShift, 0, 0);
                }
            }


            return new Thickness();
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
