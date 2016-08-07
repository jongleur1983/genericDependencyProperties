using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace GenericConverters.ImprovedStandardConverters
{
    public class BooleanToVisibilityConverter : GenericValueConverter<bool, Visibility, BooleanToVisibilityConverter.BooleanToVisibilityMapping>
    {
        public enum BooleanToVisibilityMapping : byte
        {
            // decoded bitwise to:
            // - true is visible
            // - true is collapsed
            // - true is hidden
            // - false is visible
            // - false is collapsed
            // - false is hidden
            VisibleHidden    = (1 << 0) | (0 << 1) | (0 << 2) | (0 << 3) | (0 << 4) | (1 << 5),
            VisibleCollapsed = (1 << 0) | (0 << 1) | (0 << 2) | (0 << 3) | (1 << 4) | (0 << 5),
            HiddenVisible    = (0 << 0) | (0 << 1) | (1 << 2) | (1 << 3) | (0 << 4) | (0 << 5),
            HiddenCollapsed  = (0 << 0) | (0 << 1) | (1 << 2) | (0 << 3) | (1 << 4) | (0 << 5),
            CollapsedVisible = (0 << 0) | (1 << 1) | (0 << 2) | (1 << 3) | (0 << 4) | (0 << 5),
            CollapsedHidden  = (0 << 0) | (1 << 1) | (0 << 2) | (0 << 3) | (0 << 4) | (1 << 5)
        }

        public override Visibility Convert(bool @from, BooleanToVisibilityMapping parameter, CultureInfo culture)
        {
            if (@from)
            {
                var trueEncoding = (byte) parameter & 7; //((1 << 0) | (1 << 1) | (1 << 2));
                if (trueEncoding == 1)
                {
                    return Visibility.Visible;
                } 
                else if (trueEncoding == 2)
                {
                    return Visibility.Collapsed;
                }
                else if (trueEncoding == 4)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    throw new InvalidEnumArgumentException(nameof(parameter), (int)parameter, typeof(BooleanToVisibilityMapping));
                }
            }
            else
            {
                var falseEncoding = (byte) parameter & 56; //((1 << 3) | (1 << 4) | (1 << 5));
                if (falseEncoding == 8)
                {
                    return Visibility.Visible;
                }
                else if (falseEncoding == 16)
                {
                    return Visibility.Collapsed;
                }
                else if (falseEncoding == 32)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    throw new InvalidEnumArgumentException(nameof(parameter), (int)parameter, typeof(BooleanToVisibilityMapping));
                }
            }
        }

        public override bool ConvertBack(Visibility value, BooleanToVisibilityMapping parameter, CultureInfo culture)
        {
            if (value == Visibility.Visible)
            {
                if (parameter == BooleanToVisibilityMapping.VisibleCollapsed
                    || parameter == BooleanToVisibilityMapping.VisibleHidden)
                {
                    return true;
                }
                else if (parameter == BooleanToVisibilityMapping.CollapsedVisible
                         || parameter == BooleanToVisibilityMapping.HiddenVisible)
                {
                    return false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"With parameter={parameter} the value {value} has no valid mapping");
                }
            }
            else if (value == Visibility.Hidden)
            {
                if (parameter == BooleanToVisibilityMapping.HiddenCollapsed
                    || parameter == BooleanToVisibilityMapping.HiddenVisible)
                {
                    return true;
                }
                else if (parameter == BooleanToVisibilityMapping.CollapsedHidden
                         || parameter == BooleanToVisibilityMapping.VisibleHidden)
                {
                    return false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"With parameter={parameter} the value {value} has no valid mapping");
                }
            }
            else if (value == Visibility.Collapsed)
            {
                if (parameter == BooleanToVisibilityMapping.CollapsedHidden
                    || parameter == BooleanToVisibilityMapping.CollapsedVisible)
                {
                    return true;
                }
                else if (parameter == BooleanToVisibilityMapping.HiddenCollapsed
                         || parameter == BooleanToVisibilityMapping.VisibleCollapsed)
                {
                    return false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"With parameter={parameter} the value {value} has no valid mapping");
                }
            }
            else
            {
                throw new InvalidEnumArgumentException(
                    nameof(value),
                    (int)value,
                    typeof(Visibility));
            }
        }
    }
}
