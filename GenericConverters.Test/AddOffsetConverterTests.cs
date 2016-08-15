using System.Globalization;
using GenericConverters.Converters;
using Xunit;

namespace GenericConverters.Test
{
    public class AddOffsetConverterTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 0)]
        [InlineData(0, 0.7)]
        [InlineData(0, -0.2)]
        [InlineData(0.3, 0)]
        [InlineData(222220, 555550)]
        [InlineData(232530, -1232523520)]
        [InlineData(0143, 1214.13120)]
        [InlineData(3140, 44.0)]
        [InlineData(-3453.50, 3.14)]
        [InlineData(-42, -23)]
        public void TestAddingOffset(
            double input,
            double parameter)
        {
            var converter = new AddOffsetConverter();
            Assert.Equal(input + parameter, converter.Convert(input, parameter, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 0)]
        [InlineData(0, 0.7)]
        [InlineData(0, -0.2)]
        [InlineData(0.3, 0)]
        [InlineData(222220, 555550)]
        [InlineData(232530, -1232523520)]
        [InlineData(0143, 1214.13120)]
        [InlineData(3140, 44.0)]
        [InlineData(-3453.50, 3.14)]
        [InlineData(-42, -23)]
        public void TestConvertBack(
            double input,
            double parameter)
        {
            var converter = new AddOffsetConverter();
            Assert.Equal(input - parameter, converter.ConvertBack(input, parameter, CultureInfo.InvariantCulture));
        }
    }
}
