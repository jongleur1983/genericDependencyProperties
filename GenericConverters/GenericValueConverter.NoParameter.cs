using System;
using System.Globalization;
using System.Windows.Data;

namespace GenericConverters
{
    public abstract class GenericValueConverter<TFrom, TTo> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the targetType Convert is called with has to be returned. Any derived types are okay as well, 
            // so we check if an assignment TTo to = (targetType) foo is possible.
            if (!typeof(TTo).IsAssignableFrom(targetType))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(targetType),
                    targetType,
                    "The targetType must match the generic TTo parameter of this converter.");
            }
            else
            {
                var from = (TFrom)System.Convert.ChangeType(value, typeof(TFrom));
                
                return this.Convert(from, culture);
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
            else
            {
                var from = (TTo)System.Convert.ChangeType(value, typeof(TFrom));

                return this.ConvertBack(from, culture);
            }
        }

        public abstract TTo Convert(TFrom from, CultureInfo culture);

        public abstract TFrom ConvertBack(TTo value, CultureInfo culture);
    }
}
