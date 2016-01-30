using System.Globalization;

namespace GenericConverters.Converters
{
    public class AddOffsetConverter : GenericValueConverter<int, int, int>
    {
        public override int Convert(int from, int parameter, CultureInfo culture)
        {
            var offset = parameter;
            return from + offset;
        }

        public override int ConvertBack(int value, int parameter, CultureInfo culture)
        {
            var offset = parameter;
            return value - offset;
        }
    }
}