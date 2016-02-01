using System.Globalization;

namespace GenericConverters.Converters
{
    public class MultiplyConverter : GenericValueConverter<double, double, double>
    {
        public override double Convert(double from, double parameter, CultureInfo culture)
        {
            var factor = parameter;
            return from * factor;
        }

        public override double ConvertBack(double value, double parameter, CultureInfo culture)
        {
            var factor = parameter;
            return value / factor;
        }
    }
}