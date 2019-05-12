using NP.Concepts.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace NP.Visuals.Controls
{
    public class MultiSelectWithSearchControl : Control
    {
        #region TheVM Dependency Property
        public IMultiSelectionWithSearchVm TheVM
        {
            get { return (IMultiSelectionWithSearchVm)GetValue(TheVMProperty); }
            set { SetValue(TheVMProperty, value); }
        }

        public static readonly DependencyProperty TheVMProperty =
        DependencyProperty.Register
        (
            nameof(TheVM),
            typeof(IMultiSelectionWithSearchVm),
            typeof(MultiSelectWithSearchControl),
            new PropertyMetadata(default(IMultiSelectionWithSearchVm))
        );
        #endregion TheVM Dependency Property

        #region Title Dependency Property
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register
        (
            nameof(Title),
            typeof(string),
            typeof(MultiSelectWithSearchControl),
            new PropertyMetadata(default(string))
        );
        #endregion Title Dependency Property

        #region SelectedPaneHeight Dependency Property
        public double SelectedPaneHeight
        {
            get { return (double)GetValue(SelectedPaneHeightProperty); }
            set { SetValue(SelectedPaneHeightProperty, value); }
        }

        public static readonly DependencyProperty SelectedPaneHeightProperty =
        DependencyProperty.Register
        (
            nameof(SelectedPaneHeight),
            typeof(double),
            typeof(MultiSelectWithSearchControl),
            new PropertyMetadata(200d)
        );
        #endregion SelectedPaneHeight Dependency Property
    }
}
