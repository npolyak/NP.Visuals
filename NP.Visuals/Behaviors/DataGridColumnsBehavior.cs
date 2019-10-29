using NP.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Behaviors
{
    public class DataGridColumnCollection : ObservableCollection<DataGridColumn>
    {

    }

    public static class DataGridColumnsBehavior
    {

        #region DataGridColumns attached Property
        public static ObservableCollection<DataGridColumn> GetDataGridColumns(DependencyObject obj)
        {
            return (ObservableCollection<DataGridColumn>)obj.GetValue(DataGridColumnsProperty);
        }

        public static void SetDataGridColumns(DependencyObject obj, ObservableCollection<DataGridColumn> value)
        {
            obj.SetValue(DataGridColumnsProperty, value);
        }

        public static readonly DependencyProperty DataGridColumnsProperty =
        DependencyProperty.RegisterAttached
        (
            "DataGridColumns",
            typeof(ObservableCollection<DataGridColumn>),
            typeof(DataGridColumnsBehavior),
            new PropertyMetadata(default(ObservableCollection<DataGridColumn>), OnDataGridColumnsChanged)
        );

        private static void OnDataGridColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)d;

            dataGrid.Columns.Clear();

            ObservableCollection<DataGridColumn> columns = GetDataGridColumns(dataGrid);

            if (columns != null)
            {
                dataGrid.Columns.AddAll(columns);
            }
        }
        #endregion DataGridColumns attached Property

    }
}
