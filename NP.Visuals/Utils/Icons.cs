using System.Windows;
using System.Windows.Media;

using static NP.IconStrs.IconStrings;

namespace NP.Visuals.Utils
{
    public static class Icons
    {
        public static Geometry ClearIcon { get; } =
            Geometry.Parse(ClearIconStr);

        public static Geometry UndoIcon { get; } =
            Geometry.Parse(UndoIconStr);

        public static Geometry RedoIcon { get; } =
            Geometry.Parse(RedoIconStr);

        public static Geometry SaveIcon { get; } =
            Geometry.Parse(SaveIconStr);

        public static Geometry OpenIcon { get; } =
            Geometry.Parse(OpenIconStr);

        public static Geometry EditIcon { get; } =
            Geometry.Parse(EditIconStr);

        public static Geometry ToolIcon { get; } =
            Geometry.Parse(ToolIconStr);

        public static Geometry UpArrow { get; } =
            Geometry.Parse(UpArrowStr);

        public static Geometry DownArrow { get; } =
            Geometry.Parse(DownArrowStr);

        public static Geometry LeftArrow { get; } =
            Geometry.Parse(LeftArrowStr);

        public static Geometry RightArrow { get; } =
            Geometry.Parse(RightArrowStr);

        public static Geometry InputArrow { get; } =
            Geometry.Parse(InputArrowStr);

        public static Geometry OutputArrow { get; } =
            Geometry.Parse(OutputArrowStr);

        public static Geometry TwoSidedHorizontalArrow { get; } =
            Geometry.Parse(TwoSidedHorizontalArrowStr);

        public static Geometry HorizontalAlignmentLeft { get; } =
            Geometry.Parse(HorizontalAlignmentLeftStr);

        public static Geometry HorizontalAlignmentCenter { get; } =
            Geometry.Parse(HorizontalAlignmentCenterStr);

        public static Geometry HorizontalAlignmentRight { get; } =
            Geometry.Parse(HorizontalAlignmentRightStr);

        public static Geometry HorizontalAlignmentStretch { get; } =
            Geometry.Parse(HorizontalAlignmentStretchStr);

        public static Geometry ToParent { get; } =
            Geometry.Parse(ToParentStr);

        public static Geometry VerticalAlignmentUp { get; } =
            Geometry.Parse(VerticalAlignmentUpStr);

        public static Geometry VerticalAlignmentCenter { get; } =
            Geometry.Parse(VerticalAlignmentCenterStr);

        public static Geometry VerticalAlignmentDown { get; } =
            Geometry.Parse(VerticalAlignmentDownStr);

        public static Geometry VerticalAlignmentStretch { get; } =
            Geometry.Parse(VerticalAlignmentStretchStr);

        public static Geometry Delete { get; } =
            Geometry.Parse(DeleteStr);

        public static Geometry XIcon { get; } =
            Geometry.Parse(XIconStr);

        public static Geometry FolderIcon { get; } =
            Geometry.Parse(OpenFolderIconStr);

        public static Geometry OpenFolderIcon { get; } =
            Geometry.Parse(OpenFolderIconStr);

        public static Geometry FlowerIcon { get; } =
            Geometry.Parse(FlowerIconStr);

        public static Geometry ToolsIcon { get; } =
            Geometry.Parse(ToolsIconStr);

        public static Geometry DollarIcon { get; } =
            Geometry.Parse(DollarIconStr);

        public static Geometry LighteningBolt { get; } =
            Geometry.Parse(LighteningBoltStr);

        public static Geometry ConnectionPoints { get; } =
            Geometry.Parse(ConnectionPointsStr);

        public static Geometry LambdaIcon { get; } =
            Geometry.Parse(LambdaStr);

        public static Geometry ToIcon(this HorizontalAlignment horizontalAlignment)
        {
            switch (horizontalAlignment)
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
