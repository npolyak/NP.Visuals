using NP.Concepts.Behaviors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class ToSingleSelectableCollectionConverter<T> : IValueConverter
    {
        public static ToSingleSelectableCollectionConverter<T> Instance { get; } =
            new ToSingleSelectableCollectionConverter<T>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<T> vals = value as IEnumerable<T>;

            if (vals == null)
                return null;

            return new SingleSelectionCollection<T>(vals);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SingleSelectionHorizontalAlignmentCollectionConverter : 
        ToSingleSelectableCollectionConverter<HorizontalAlignment>
    {

    }

    public class SingleSelectionVerticalAlignmentCollectionConverter :
        ToSingleSelectableCollectionConverter<VerticalAlignment>
    {

    }
}
