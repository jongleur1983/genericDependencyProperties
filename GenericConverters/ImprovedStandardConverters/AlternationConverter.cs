using System.Collections.Generic;
using System.Globalization;
using System.Windows.Markup;

namespace GenericConverters.ImprovedStandardConverters
{
    [ContentProperty("Values")]
    public class AlternationConverter<TTarget> : GenericValueConverter<int, TTarget>
    {
        public override TTarget Convert(int from, CultureInfo culture)
        {
            if (this.Values.Count > 0)
            {
                int index = from % this.Values.Count;

                if (index < 0) // Adjust for incorrect definition of the %-operator for negative arguments. 
                {
                    index += this.Values.Count;
                }

                return this.Values[index];
            }

            return default(TTarget);
        }

        public override int ConvertBack(TTarget value, CultureInfo culture)
        {
            return this.Values.IndexOf(value);
        }

        public IList<TTarget> Values { get; } = new List<TTarget>();
    }
}
