using NP.Utilities;
using NP.Utilities.FolderUtils;
using System;
using System.Runtime.Serialization;
using System.Windows;

namespace NP.Visuals.Behaviors
{
    public class WindowsParamFileInfo
    {
        public string RelativePath { get; set; }

        public string FileName { get; set; }

        public string RealFileName => $"{FileName}.Window";

        Window _window;
        public Window TheWindow 
        {
            get => _window; 
            internal set
            {
                _window = value;

                _windowCoordsSaverRestorer = new ItemToFolderSaverRestorer(RelativePath);
            }
        }

        private ItemToFolderSaverRestorer _windowCoordsSaverRestorer;

        public void Restore()
        {
            string str = _windowCoordsSaverRestorer.RestoreStr(RealFileName);

            if (str == null)
            {
                return;
            }

            WindowCoords winCoords = 
                XmlSerializationUtils.Deserialize<WindowCoords>(str);

            TheWindow.Left = winCoords.Left;
            TheWindow.Top = winCoords.Top;
            TheWindow.Width = winCoords.Width;
            TheWindow.Height = winCoords.Height;
        }

        public void Save()
        {
            WindowCoords winCoords = new WindowCoords(TheWindow);

            string str = XmlSerializationUtils.Serialize(winCoords);

            if (!str.IsNullOrEmpty())
            {
                _windowCoordsSaverRestorer.SaveStr(RealFileName, str);
            }
        }
    }

    public static class WindowLocationBehavior
    {
        #region TheWindowsLocationInfo attached Property
        public static WindowsParamFileInfo GetTheWindowsLocationInfo(DependencyObject obj)
        {
            return (WindowsParamFileInfo)obj.GetValue(TheWindowsLocationInfoProperty);
        }

        public static void SetTheWindowsLocationInfo(DependencyObject obj, WindowsParamFileInfo value)
        {
            obj.SetValue(TheWindowsLocationInfoProperty, value);
        }

        public static readonly DependencyProperty TheWindowsLocationInfoProperty =
        DependencyProperty.RegisterAttached
        (
            "TheWindowsLocationInfo",
            typeof(WindowsParamFileInfo),
            typeof(WindowLocationBehavior),
            new PropertyMetadata(default(WindowsParamFileInfo), OnWindowsParamFileInfoChanged)
        );

        private static void OnWindowsParamFileInfoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WindowsParamFileInfo windowsParamFileInfo = e.NewValue as WindowsParamFileInfo;

            if (windowsParamFileInfo != null)
            {
                windowsParamFileInfo.TheWindow = (Window)d;

                windowsParamFileInfo.Restore();
            }
        }
        #endregion TheWindowsLocationInfo attached Property
    }
}
