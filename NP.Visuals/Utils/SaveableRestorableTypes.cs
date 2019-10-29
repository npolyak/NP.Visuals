using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace NP.Visuals.Utils
{
    public static class SaveableRestorableTypes
    {
        public static Type[] Types { get; } =
        {
            typeof(double),
            typeof(string),
            typeof(int),
            typeof(bool),
            typeof(byte),
            typeof(DateTime),
            typeof(SolidColorBrush), 
            typeof(Color),
            typeof(decimal),
            typeof(Thickness),
            typeof(Brush),
            typeof(FontWeight),
            typeof(TextDecoration),
            typeof(Point)
        };

        public static bool IsSaveableRestorableType(this Type type)
        {
            return type.IsEnum || Types.Contains(type);
        }

        public static bool IsObjOfSaveableRestorableType(this object obj)
        {
            return obj.GetType().IsSaveableRestorableType();
        }
    }
}
