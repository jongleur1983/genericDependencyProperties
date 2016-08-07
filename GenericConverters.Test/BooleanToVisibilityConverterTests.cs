using System;
using System.Globalization;
using System.Windows;
using GenericConverters.ImprovedStandardConverters;
using Xunit;

namespace GenericConverters.Test
{
    public class BooleanToVisibilityConverterTests
    {
        [Theory]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedHidden, Visibility.Collapsed)]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedVisible, Visibility.Collapsed)]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenCollapsed, Visibility.Hidden)]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenVisible, Visibility.Hidden)]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleCollapsed, Visibility.Visible)]
        [InlineData(true, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleHidden, Visibility.Visible)]

        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedHidden, Visibility.Hidden)]
        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedVisible, Visibility.Visible)]
        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenCollapsed, Visibility.Collapsed)]
        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenVisible, Visibility.Visible)]
        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleCollapsed, Visibility.Collapsed)]
        [InlineData(false, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleHidden, Visibility.Hidden)]
        public void ConvertsCorrect(
            bool input,
            BooleanToVisibilityConverter.BooleanToVisibilityMapping parameter,
            Visibility expectedResult)
        {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.Convert(input, parameter, CultureInfo.InvariantCulture);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleHidden, true)]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleCollapsed, true)]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedVisible, false)]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenVisible, false)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedHidden, true)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedVisible, true)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenCollapsed, false)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleCollapsed, false)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenCollapsed, true)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenVisible, true)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedHidden, false)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleHidden, false)]
        
        public void ConvertsBackCorrect(
            Visibility input,
            BooleanToVisibilityConverter.BooleanToVisibilityMapping parameter,
            bool expectedResult)
        {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.ConvertBack(input, parameter, CultureInfo.InvariantCulture);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedHidden)]
        [InlineData(Visibility.Visible, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenCollapsed)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.HiddenVisible)]
        [InlineData(Visibility.Collapsed, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleHidden)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.VisibleCollapsed)]
        [InlineData(Visibility.Hidden, BooleanToVisibilityConverter.BooleanToVisibilityMapping.CollapsedVisible)]
        public void ContertBackThrowsCorrect(
            Visibility input,
            BooleanToVisibilityConverter.BooleanToVisibilityMapping parameter)
        {
            var converter = new BooleanToVisibilityConverter();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => converter.ConvertBack(
                    input,
                    parameter,
                    CultureInfo.InvariantCulture));
        }
    }
}
