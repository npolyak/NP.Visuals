using NP.Utilities;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace NP.Visuals.Utils
{
    public interface IDependencyPropertyInfo
    {
        bool IsReadOnly { get; }
        string PropName { get; }
        string PropFullName { get; }
        string PropFullDisplayName { get; }
        Type PropertyType { get; }
        object DefaultVal { get; }
        DependencyProperty SourceDP {get;}

        bool IsDefault { get; }
        bool IsNotDefault { get; }
        bool IsAttached { get; }
        BaseValueSource Source { get; }
        Type OwnerType { get; }

        object Value { get; }
    }

    public class UnmodifiableDependencyPropertyInfo : IDependencyPropertyInfo
    {
        public DependencyProperty SourceDP { get; }

        public DependencyObject SourceObj { get; }

        public bool IsReadOnly => SourceDP.ReadOnly;

        public string PropName => SourceDP.Name;

        public string PropFullName =>
            OwnerType.FullName + "." + PropName + "Property";

        public string PropFullDisplayName =>
            IsAttached ? OwnerType.Name + "." + PropName : PropName;

        public Type PropertyType => SourceDP.PropertyType;

        public object DefaultVal => SourceDP.DefaultMetadata?.DefaultValue;

        public bool IsDefault => Value.ObjEquals(DefaultVal);

        public bool IsNotDefault => !IsDefault;

        public bool IsAttached { get; }

        public BaseValueSource Source =>
            DependencyPropertyHelper.GetValueSource(SourceObj, SourceDP).BaseValueSource;

        public Type OwnerType => SourceDP.OwnerType;

        public object Value { get; }

        public UnmodifiableDependencyPropertyInfo(DependencyProperty sourceDP, DependencyObject sourceObj, bool isAttached)
        {
            SourceDP = sourceDP;

            SourceObj = sourceObj;

            IsAttached = isAttached;

            Value = SourceObj.GetValue(SourceDP);
        }
    }

    public class DependencyPropertyInfo : DependencyObject, IDependencyPropertyInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public DependencyProperty SourceDP { get; }

        public DependencyObject SourceObj { get; }

        public bool IsReadOnly => SourceDP.ReadOnly;

        public string PropName => SourceDP.Name;

        public string PropFullName =>
            IsAttached ? OwnerType.FullName + "." + PropName : PropName;

        public string PropFullDisplayName =>
            IsAttached ? OwnerType.Name + "." + PropName : PropName;

        public Type PropertyType => SourceDP.PropertyType;

        public object DefaultVal => SourceDP.DefaultMetadata?.DefaultValue;

        public bool IsDefault => Value.ObjEquals(DefaultVal);

        public bool IsNotDefault => !IsDefault;

        public bool IsAttached { get; }

        public BaseValueSource Source => 
            DependencyPropertyHelper.GetValueSource(SourceObj, SourceDP).BaseValueSource;

        public Type OwnerType => SourceDP.OwnerType;

        public DependencyPropertyInfo(DependencyProperty sourceDP, DependencyObject sourceObj, bool isAttached)
        {
            SourceDP = sourceDP;

            SourceObj = sourceObj;

            Binding valueBinding = new Binding();
            valueBinding.Source = sourceObj;
            valueBinding.Path = new PropertyPath(SourceDP);
            valueBinding.Mode = IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;

            BindingOperations.SetBinding(this, ValueProperty, valueBinding);

            IsAttached = isAttached;
        }

        #region Value Dependency Property
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register
        (
            nameof(Value),
            typeof(object),
            typeof(DependencyPropertyInfo),
            new PropertyMetadata(default(object), OnValChanged)
        );

        private static void OnValChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DependencyPropertyInfo)d).OnPropChanged();
        }

        private void OnPropChanged()
        {
            OnPropChanged(nameof(Source));
            OnPropChanged(nameof(IsDefault));
            OnPropChanged(nameof(IsNotDefault));
        }

        #endregion Value Dependency Property
    }
}
