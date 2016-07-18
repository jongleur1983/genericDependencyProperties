using System.Globalization;
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
            Assert.Equal(18, addOffsetConverter.Convert(15, 3, CultureInfo.InvariantCulture));
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
        public void ConvertTheory(int value, int offset)
        {
            var addOffsetConverter = new AddOffsetConverter();
            Assert.Equal(
                value + offset, 
                addOffsetConverter.Convert(value, offset, CultureInfo.InvariantCulture));
            Assert.Equal(
                value, 
                addOffsetConverter.ConvertBack(value + offset, offset, CultureInfo.InvariantCulture));
        }
    }
}
