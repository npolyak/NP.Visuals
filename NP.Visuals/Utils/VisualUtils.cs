using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NP.Visuals.Utils
{
    public static class VisualUtils
    {
        static ThicknessConverter _thicknessConverter = new ThicknessConverter();

        static FontFamilyConverter _fontFamilyConverter = new FontFamilyConverter();

        static FontWeightConverter _fontWeightConverter = new FontWeightConverter();

        public static Visibility ToVis(this bool? b, bool directOrInverse = true, bool collapsedOrHidden = true)
        {
            if (b == null)
                b = false;

            if (!directOrInverse)
                b = !b;

            Visibility falseValue =
                collapsedOrHidden ? Visibility.Collapsed : Visibility.Hidden;

            return (b == true) ? Visibility.Visible : falseValue;
        }

        public static string ToLongStr(this DependencyProperty dp)
        {
            return dp.OwnerType.FullName + "." + dp.Name + "Property";
        }

        public static object GetDPValueFromStr(this DependencyProperty dp, string str)
        {
            Type type = dp.PropertyType;

            if (type.IsEnum)
            {
                return Enum.Parse(type, str);
            }

            if (type == typeof(double))
            {
                return double.Parse(str);
            }

            if (type == typeof(float))
            {
                return float.Parse(str);
            }

            if (type == typeof(decimal))
            {
                return decimal.Parse(str);
            }

            if (type == typeof(string))
            {
                return str;
            }

            if (type == typeof(byte))
            {
                return byte.Parse(str);
            }

            if (type == typeof(int))
            {
                return int.Parse(str);
            }

            if (type == typeof(char))
            {
                return char.Parse(str);
            }

            if (type == typeof(Brush))
            {
                if (string.IsNullOrEmpty(str))
                    return null;

                Color color = (Color) ColorConverter.ConvertFromString(str);

                return new SolidColorBrush(color);
            }

            if (type == typeof(Thickness))
            {
                return _thicknessConverter.ConvertFromString(str);
            }

            if (type == typeof(FontFamily))
            {
                return _fontFamilyConverter.ConvertFromString(str);
            }

            if (type == typeof(FontWeight))
            {
                return _fontWeightConverter.ConvertFromString(str);
            }

            return str;
        }
    }
}
