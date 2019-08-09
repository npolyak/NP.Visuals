using System.Windows;
using System.Windows.Media;

namespace NP.Visuals.Utils
{
    public static class Icons
    {
        public static Geometry ClearIcon { get; } =
            Geometry.Parse("M11, 0 L18, 7 L11, 7 z M0, 0 L10, 0 L10, 7 L10, 8 L18, 8 L18, 21 L0, 21 z");

        public static Geometry UndoIcon { get; } =
            Geometry.Parse("M4.2667065,0 L8.4021349,0 L5.2587953,4.1229997 L13.039669,4.1229997 C16.905663,4.1229997 20.039669,7.2570057 20.039669,11.122999 C20.039669,14.988993 16.905663,18.122999 13.039669,18.122999 L11.825022,18.122999 L11.825022,14.123001 L13.039669,14.123001 C14.696525,14.123001 16.039671,12.779856 16.039671,11.123001 C16.039671,9.4661465 14.696525,8.1230011 13.039669,8.1230011 L5.2947307,8.1230011 L8.4021349,12.248009 L4.2667065,12.248009 L0,5.9990273 z");

        public static Geometry RedoIcon { get; } =
            Geometry.Parse("M12,0 L16,0 L20,6 L16,12 L12,12 L14.666667,8 L7,8 C5.3431458,8 4,9.3431454 4,11 C4,12.656855 5.3431458,14 7,14 L8,14 L8,18 L7,18 C3.1340067,18 0,14.865993 0,11 C0,7.134007 3.1340067,4 7,4 L14.666667,4 z");

        public static Geometry SaveIcon { get; } =
            Geometry.Parse("F1 M0,0 L22,0 L22,22 L16,22 L16,15 L6,15 L6,22 L0,22 L0,0 z M8,22 L8,19 L12,19 L12,22 L8,22 z M5,2 L5,8 L18,8 L18,2 L5,2 z");

        public static Geometry OpenIcon { get; } =
            Geometry.Parse("M10,0L17,0C17.5523,1.19209e-007 18,0.447715 18,1L18.5,3L21,3C21.5523,3 22,3.44772 22,4L22,18C22,18.5523 21.5523,19 21,19L1,19C0.447715,19 0,18.5523 0,18L0,4C0,3.44772 0.447715,3 1,3L8.5,3L9,1C9,0.447715 9.44771,1.19209e-007 10,0z");

        public static Geometry EditIcon { get; } =
            Geometry.Parse("M0.5,16 L3.333,18.42 L0,19.5 z M14.5,0 L18.5,3.5 L5.5,17.25 L1.375,13.75 z");

        public static Geometry ToolIcon { get; } =
            Geometry.Parse("M23,4C23,4 18,10 18,10 18,10 13,5 13,5 13,5 19,0 19,0 18,0 17,0 16,0 11,0 7,3 7,8 7,9 7,10 8,11 8,11 1,18 1,18 1,18 0,20 1,22 3,24 5,22 5,22 5,22 12,15 12,15 13,16 14,16 16,16 20,16 24,12 24,8 24,6 24,5 23,4 23,4 23,4 23,4z");

        public static Geometry UpArrow { get; } =
            Geometry.Parse("M-10,0L0,-10L10,0");

        public static Geometry DownArrow { get; } =
            Geometry.Parse("M-10,0L0,10L10,0");

        public static Geometry LeftArrow { get; } =
            Geometry.Parse("M0,10L-10,0L0,-10");

        public static Geometry RightArrow { get; } =
            Geometry.Parse("M0,10L10,0L0,-10");

        public static Geometry HorizontalAlignmentLeft { get; } =
            Geometry.Parse("M0,0 L2,0 L2,3 L12,3 L12,9 L2,9 L2,12 L0,12 L0,9 L0,3 z");

        public static Geometry HorizontalAlignmentCenter { get; } =
            Geometry.Parse("M5,0 L7,0 L7,3 L12,3 L12,9 L7,9 L7,12 L5,12 L5,9 L0,9 L0,3 L5,3 z");

        public static Geometry HorizontalAlignmentRight { get; } =
            Geometry.Parse("M10,0 L12,0 L12,3 L12,9 L12,12 L10,12 L10,9 L0,9 L0,3 L10,3 z");

        public static Geometry HorizontalAlignmentStretch { get; } =
            Geometry.Parse("M0,0 L2,0 L2,3 L10,3 L10,0 L12,0 L12,3 L12,9 L12,12 L10,12 L10,9 L2,9 L2,12 L0,12 L0,9 L0,3 z");

        public static Geometry ToParent { get; } =
            Geometry.Parse("M0,0L12,0 12,12 0,12z M1,3L11,3 11,11 1,11z");

        public static Geometry VerticalAlignmentUp { get; } =
            Geometry.Parse("M0,0 L3,0 L9,0 L12,0 L12,2 L9,2 L9,12 L3,12 L3,2 L0,2 z");

        public static Geometry VerticalAlignmentCenter { get; } =
            Geometry.Parse("M3,0L9,0 9,5 12,5 12,7 9,7 9,12 3,12 3,7 0,7 0,5 3,5z");

        public static Geometry VerticalAlignmentDown { get; } =
            Geometry.Parse("M3,0L9,0 9,10 12,10 12,12 9,12 3,12 0,12 0,10 3,10z");

        public static Geometry VerticalAlignmentStretch { get; } =
            Geometry.Parse("M0,0 L3,0 L9,0 L12,0 L12,2 L9,2 L9,10 L12,10 L12,12 L9,12 L3,12 L0,12 L0,10 L3,10 L3,2 L0,2 z");

        public static Geometry Delete { get; } =
            Geometry.Parse("M0,1L3,1 3,0 9,0 9,1 12,1 12,2 0,2z M1,3L2,3 2,10 4,10 4,3 5,3 5,10 7,10 7,3 8,3 8,10 10,10 10,3 11,3 11,12 1,12zz");

        public static Geometry XIcon { get; } =
            Geometry.Parse("M13.46,12L19,17.54V19H17.54L12,13.46L6.46,19H5V17.54L10.54,12L5,6.46V5H6.46L12,10.54L17.54,5H19V6.46L13.46,12Z");

        public static Geometry ToIcon(this HorizontalAlignment horizontalAlignment)
        {
            switch(horizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    return HorizontalAlignmentLeft;
                case HorizontalAlignment.Center:
                    return HorizontalAlignmentCenter;
                case HorizontalAlignment.Right:
                    return HorizontalAlignmentRight;
                case HorizontalAlignment.Stretch:
                    return HorizontalAlignmentStretch;
            }

            return null;
        }

        public static Geometry ToIcon(this VerticalAlignment verticalAlignment)
        {
            switch (verticalAlignment)
            {
                case VerticalAlignment.Top:
                    return VerticalAlignmentUp;
                case VerticalAlignment.Center:
                    return VerticalAlignmentCenter;
                case VerticalAlignment.Bottom:
                    return VerticalAlignmentDown;
                case VerticalAlignment.Stretch:
                    return VerticalAlignmentStretch;
            }

            return null;
        }
    }
}
