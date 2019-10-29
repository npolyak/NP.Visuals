using NP.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NP.Visuals.Behaviors
{
    public static class ImageSourceSettingBehavior
    {

        #region DefaultImageSource attached Property
        public static string GetDefaultImageSource(DependencyObject obj)
        {
            return (string)obj.GetValue(DefaultImageSourceProperty);
        }

        public static void SetDefaultImageSource(DependencyObject obj, string value)
        {
            obj.SetValue(DefaultImageSourceProperty, value);
        }

        public static readonly DependencyProperty DefaultImageSourceProperty =
        DependencyProperty.RegisterAttached
        (
            "DefaultImageSource",
            typeof(string),
            typeof(ImageSourceSettingBehavior),
            new PropertyMetadata(default(string), ResetImageSource)
        );
        #endregion DefaultImageSource attached Property


        #region IsImageSourceSettingBehaviorSet attached Property
        public static bool GetIsImageSourceSettingBehaviorSet(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsImageSourceSettingBehaviorSetProperty);
        }

        public static void SetIsImageSourceSettingBehaviorSet(DependencyObject obj, bool value)
        {
            obj.SetValue(IsImageSourceSettingBehaviorSetProperty, value);
        }

        public static readonly DependencyProperty IsImageSourceSettingBehaviorSetProperty =
        DependencyProperty.RegisterAttached
        (
            "IsImageSourceSettingBehaviorSet",
            typeof(bool),
            typeof(ImageSourceSettingBehavior),
            new PropertyMetadata(default(bool), ResetImageSource)
        );
        #endregion IsImageSourceSettingBehaviorSet attached Property


        #region TheImageSource attached Property
        public static string GetTheImageSource(DependencyObject obj)
        {
            return (string)obj.GetValue(TheImageSourceProperty);
        }

        public static void SetTheImageSource(DependencyObject obj, string value)
        {
            obj.SetValue(TheImageSourceProperty, value);
        }

        public static readonly DependencyProperty TheImageSourceProperty =
        DependencyProperty.RegisterAttached
        (
            "TheImageSource",
            typeof(string),
            typeof(ImageSourceSettingBehavior),
            new PropertyMetadata(default(string), ResetImageSource)
        );
        #endregion TheImageSource attached Property

        public static void ResetImageSource
        (
            DependencyObject dependencyObject, 
            DependencyPropertyChangedEventArgs e)
        {
            bool isImageSourceSettingBehaviorSet = 
                GetIsImageSourceSettingBehaviorSet(dependencyObject);

            if (!isImageSourceSettingBehaviorSet)
            {
                return;
            }

            Image image = (Image)dependencyObject;

            string imageSourceStr = 
                GetTheImageSource(dependencyObject);

            if (imageSourceStr.IsNullOrEmpty())
            {
                imageSourceStr = GetDefaultImageSource(dependencyObject);
            }

            if (imageSourceStr.IsNullOrEmpty())
            {
                return;
            }

            Uri uri = new Uri(imageSourceStr, UriKind.RelativeOrAbsolute);

            ImageSource imageSource = new BitmapImage(uri);

            image.Source = imageSource;
        }
    }
}
