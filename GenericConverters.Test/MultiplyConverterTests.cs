using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericConverters.Converters;
using Xunit;

namespace GenericConverters.Test
{
    public class MultiplyConverterTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, double.NaN)]
        [InlineData(double.NaN, 0)]
        [InlineData(0, double.NegativeInfinity)]
        [InlineData(0, double.PositiveInfinity)]
        [InlineData(0, double.Epsilon)]
        [InlineData(10, 0)]
        [InlineData(10, double.NaN)]
        [InlineData(double.NaN, 10)]
        [InlineData(10, double.NegativeInfinity)]
        [InlineData(10, double.PositiveInfinity)]
        [InlineData(10, double.Epsilon)]
        [InlineData(10, 0)]
        [InlineData(10, double.NaN)]
        [InlineData(double.NaN, 10)]
        [InlineData(10, double.NegativeInfinity)]
        [InlineData(10, double.PositiveInfinity)]
        [InlineData(10, double.Epsilon)]
        public void ConvertTest(double input, double parameter)
        {
            var converter = new MultiplyConverter();
            Assert.Equal(
                input * parameter, 
                converter.Convert(input, parameter, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, double.NaN)]
        [InlineData(double.NaN, 0)]
        [InlineData(0, double.NegativeInfinity)]
        [InlineData(0, double.PositiveInfinity)]
        [InlineData(0, double.Epsilon)]
        [InlineData(10, 0)]
        [InlineData(10, double.NaN)]
        [InlineData(double.NaN, 10)]
        [InlineData(10, double.NegativeInfinity)]
        [InlineData(10, double.PositiveInfinity)]
        [InlineData(10, double.Epsilon)]
        [InlineData(10, 0)]
        [InlineData(10, double.NaN)]
        [InlineData(double.NaN, 10)]
        [InlineData(10, double.NegativeInfinity)]
        [InlineData(10, double.PositiveInfinity)]
        [InlineData(10, double.Epsilon)]
        public void ConvertBackTest(double output, double parameter)
        {
            var converter = new MultiplyConverter();
            Assert.Equal(
                output / parameter,
                converter.ConvertBack(output, parameter, CultureInfo.InvariantCulture));
        }
    }
}
