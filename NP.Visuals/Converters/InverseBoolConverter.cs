using System.Windows.Data;

namespace NP.Visuals.Converters
{
    public class InverseBoolConverter : BoolConverter<bool>, IValueConverter
    {
        public static InverseBoolConverter TheInstance { get; } = 
            new InverseBoolConverter();

        public InverseBoolConverter() : base(false, true)
        {
        }
    }
}
