using NP.Concepts;

namespace NP.Visuals.Controls
{
    public class ClockItem : ICircularArrangedItem
    {
        public double Angle { get; set; }

        public object Content { get; }

        public ClockItem(double angle, object content)
        {
            Angle = angle;
            Content = content;
        }
    }

    public static class CircularArrangedItemHelper
    {
        public static object GetItemForComparison(this ICircularArrangedItem circularArrangedItem)
        {
            if (circularArrangedItem is ClockItem clockItem)
            {
                return clockItem.Content;
            }

            return circularArrangedItem;
        }
    }
}
