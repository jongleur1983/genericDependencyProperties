using System.Globalization;

namespace GenericConverters.Converters
{
    public class AddOffsetConverter : GenericValueConverter<double, double, double>
    {
        public override double Convert(double from, double parameter, CultureInfo culture)
        {
            var offset = parameter;
            return from + offset;
        }

        public override double ConvertBack(double value, double parameter, CultureInfo culture)
        {
            var offset = parameter;
            return value - offset;
        }
    }
}