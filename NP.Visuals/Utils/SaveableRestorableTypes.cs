using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            typeof(object)
        };
    }
}
