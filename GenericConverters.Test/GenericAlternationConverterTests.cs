using System.Globalization;
using System.Windows;
using GenericConverters.ImprovedStandardConverters;
using Xunit;

namespace GenericConverters.Test
{
    public class GenericAlternationConverterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(-2)]
        public void ConvertWithEmptyValuesShouldReturnTypesDefault(
            int index)
        {
            var converter = new AlternationConverter<int>();
            Assert.Equal(0, converter.Convert(index, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(-2)]
        public void ConvertWithSingleValueShouldAlwaysReturnIt(
            int index)
        {
            var converter = new AlternationConverter<int>();
            converter.Values.Add(42);

            Assert.Equal(42, converter.Convert(index, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(-2, true)]
        public void ConvertWithTwoValuesShouldAlternateThose(
            int index,
            bool expected)
        {
            var converter = new AlternationConverter<bool>();
            converter.Values.Add(true);
            converter.Values.Add(false);

            Assert.Equal(expected, converter.Convert(index, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(-1, Visibility.Hidden)]
        [InlineData(0, Visibility.Visible)]
        [InlineData(1, Visibility.Collapsed)]
        [InlineData(2, Visibility.Hidden)]
        [InlineData(3, Visibility.Visible)]
        [InlineData(4, Visibility.Collapsed)]
        [InlineData(5, Visibility.Hidden)]
        [InlineData(6, Visibility.Visible)]
        public void ConvertWithThreeValuesWorksAsExpected(
            int index,
            Visibility expected)
        {
            var converter = new AlternationConverter<Visibility>();
            converter.Values.Add(Visibility.Visible);
            converter.Values.Add(Visibility.Collapsed);
            converter.Values.Add(Visibility.Hidden);

            Assert.Equal(
                expected,
                converter.Convert(index, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(Visibility.Visible)]
        [InlineData(Visibility.Hidden)]
        [InlineData(Visibility.Collapsed)]
        public void ConvertBackWithValueNotFoundShouldReturnMinus1(
            Visibility value)
        {
            var converter = new AlternationConverter<Visibility>();
            Assert.Equal(-1, converter.ConvertBack(value, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(Visibility.Visible, 0)]
        [InlineData(Visibility.Collapsed, 1)]
        [InlineData(Visibility.Hidden, 2)]
        public void ConvertBackWorksAsExpected(
            Visibility value,
            int expectedIndex)
        {
            var converter = new AlternationConverter<Visibility>();
            converter.Values.Add(Visibility.Visible);
            converter.Values.Add(Visibility.Collapsed);
            converter.Values.Add(Visibility.Hidden);

            Assert.Equal(expectedIndex, converter.ConvertBack(value, CultureInfo.InvariantCulture));
        }
    }
}
