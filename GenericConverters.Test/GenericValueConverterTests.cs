using System.Globalization;
using System.Windows.Data;
using GenericConverters.Converters;
using Xunit;

namespace GenericConverters.Test
{
    public class GenericValueConverterTests
    {
        [Fact]
        public void Convert()
        {
            var addOffsetConverter = new AddOffsetConverter();
            var converterAsValueConverter = addOffsetConverter as IValueConverter;
            Assert.Equal(
                converterAsValueConverter.Convert(
                    15,
                    typeof(double),
                    3,
                    CultureInfo.InvariantCulture),
                addOffsetConverter.Convert(
                    15,
                    3,
                    CultureInfo.InvariantCulture));
            
        }

        [Theory]
        [InlineData(0, 15)]
        [InlineData(2, 290)]
        [InlineData(3, 48)]
        [InlineData(2, 36)]
        [InlineData(3, 31)]
        [InlineData(4, 21)]
        [InlineData(23, 31)]
        [InlineData(24, 11)]
        [InlineData(10, 211)]
        [InlineData(9, 121)]
        public void ConvertTheory(int value, double offset)
        {
            var addOffsetConverter = new AddOffsetConverter();
            var nonGenericConverter = addOffsetConverter as IValueConverter;

            Assert.Equal(
                nonGenericConverter.Convert(value, typeof(double), offset, CultureInfo.InvariantCulture), 
                addOffsetConverter.Convert(value, offset, CultureInfo.InvariantCulture));
            Assert.Equal(
                nonGenericConverter.ConvertBack(value, typeof(double), offset, CultureInfo.InvariantCulture), 
                addOffsetConverter.ConvertBack(value, offset, CultureInfo.InvariantCulture));
        }
    }
}
