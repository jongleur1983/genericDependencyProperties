using System.Globalization;
using System.Windows;

namespace GenericConverters.ImprovedStandardConverters
{
    public class BooleanToVisibilityConverter : GenericValueConverter<bool?, Visibility>
    {
        public override Visibility Convert(bool? from, CultureInfo culture)
        {
            return from == true
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        public override bool? ConvertBack(Visibility value, CultureInfo culture)
        {
            return value == Visibility.Visible;
        }
    }
}
