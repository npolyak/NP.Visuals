using System.Windows;
using System.Xml.Serialization;

namespace NP.Visuals.Behaviors
{
    public class WindowCoords
    {
        [XmlAttribute]
        public double Left { get; set; }

        [XmlAttribute]
        public double Top { get; set; }

        [XmlAttribute] 
        public double Width { get; set; }

        [XmlAttribute]
        public double Height { get; set; }

        public WindowCoords()
        {

        }

        public WindowCoords(double left, double top, double width, double height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public WindowCoords(Window w) :
            this(w.Left, w.Top, w.ActualWidth, w.ActualHeight)
        {

        }
    }
}
