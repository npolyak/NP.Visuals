using NP.Utilities;
using System;
using System.IO;
using System.Net.Cache;
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


        #region ResetTrigger attached Property
        public static bool GetResetTrigger(DependencyObject obj)
        {
            return (bool)obj.GetValue(ResetTriggerProperty);
        }

        public static void SetResetTrigger(DependencyObject obj, bool value)
        {
            obj.SetValue(ResetTriggerProperty, value);
        }

        public static readonly DependencyProperty ResetTriggerProperty =
        DependencyProperty.RegisterAttached
        (
            "ResetTrigger",
            typeof(bool),
            typeof(ImageSourceSettingBehavior),
            new PropertyMetadata(default(bool), OnResetTriggerChanged)
        );

        private static void OnResetTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ResetImageSource(d, e);
        }
        #endregion ResetTrigger attached Property


        public static void ResetImageSource
        (
            DependencyObject dependencyObject, 
            DependencyPropertyChangedEventArgs e)
        {
            bool isImageSourceSettingBehaviorSet = 
                GetIsImageSourceSettingBehaviorSet(dependencyObject);

            Image image = (Image)dependencyObject;

            if (!isImageSourceSettingBehaviorSet)
            {
                return;
            }

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

            if (File.Exists(imageSourceStr))
            {
                imageSourceStr = Path.GetFullPath(imageSourceStr);
            }

            Uri uri = new Uri(imageSourceStr, UriKind.RelativeOrAbsolute);

            BitmapImage bitmapImage = new BitmapImage(uri);

            //bitmapImage.BeginInit();
            ////bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //bitmapImage.UriSource = uri;
            //bitmapImage.EndInit();

            image.Source = bitmapImage;
        }
    }
}
