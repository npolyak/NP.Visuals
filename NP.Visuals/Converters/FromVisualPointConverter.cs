namespace NP.Visuals.Converters
{
    public class FromVisualPointConverter : AssembledConverter
    {
        public static FromVisualPointConverter TheInstance { get; } = new FromVisualPointConverter();

        public FromVisualPointConverter() : base(new FromVisPointConverter(), new ToVisPointConverter())
        {
        }
    }
}
