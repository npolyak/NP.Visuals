namespace NP.Visuals.Converters
{
    public class ToVisualPointConverter : AssembledConverter
    {
        public static ToVisualPointConverter TheInstance { get; } = new ToVisualPointConverter();

        public ToVisualPointConverter() : base(new ToVisPointConverter(), new FromVisPointConverter())
        {
        }
    }
}
