using System;
using System.Globalization;
using System.Windows.Data;

namespace GenericConverters
{
    public abstract class GenericValueConverter<TFrom, TTo, TParameter> : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the targetType Convert is called with has to be returned. Any derived types are okay as well, 
            // so we check if an assignment TTo to = (targetType) foo is possible.
            if (!typeof (TTo).IsAssignableFrom(targetType))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(targetType),
                    targetType,
                    "The targetType must match the generic TTo parameter of this converter.");
            }
            else
            {
                var from = (TFrom) System.Convert.ChangeType(value, typeof(TFrom));
                var param = (TParameter) System.Convert.ChangeType(parameter, typeof(TParameter));

                return this.Convert(from, param, culture);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the targetType Convert is called with has to be returned. Any derived types are okay as well, 
            // so we check if an assignment TTo to = (targetType) foo is possible.
            if (!typeof(TFrom).IsAssignableFrom(targetType))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(targetType),
                    targetType,
                    "The targetType must match the generic TFrom parameter of this converter.");
            }
            else if (!(parameter is TParameter))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(parameter),
                    typeof(TParameter),
                    "the parameter must match the generic TParameter of this conveter.");
            }
            else
            {
                var from = (TTo)System.Convert.ChangeType(value, typeof(TFrom));
                var param = (TParameter) parameter;

                return this.ConvertBack(from, param, culture);
            }
        }

        public abstract TTo Convert(TFrom from, TParameter parameter, CultureInfo culture);

        public abstract TFrom ConvertBack(TTo value, TParameter parameter, CultureInfo culture);
    }
}
