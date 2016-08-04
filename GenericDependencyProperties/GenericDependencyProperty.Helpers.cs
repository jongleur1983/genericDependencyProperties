using System;
using System.Windows;
using GenericDependencyProperties.GenericCallback;

namespace GenericDependencyProperties
{
    public static partial class GenericDependencyProperty
    {
        /// <summary>
        /// Return a non-generic <see cref="ValidateValueCallback"/> that calls the given generic variant.
        /// The returned callback applies type casting. This may throw a <see cref="InvalidCastException"/>,
        /// as it would be thrown on non-generic implementations usually.
        /// </summary>
        /// <typeparam name="TProperty">the Type of the <see cref="DependencyProperty"/></typeparam>
        /// <param name="genericCallback">the generic variant of the callback to be called.</param>
        /// <returns></returns>
        private static ValidateValueCallback GetBoxedValidateValueCallback<TProperty>(ValidateValueCallback<TProperty> genericCallback)
        {
            if (genericCallback == null)
            {
                // TODO: if nothing specific, check for the correct type - what could happen (UnsetValue... check before!)
                return null; // return value => value is TProperty;
            }
            else
            {
                return value => genericCallback((TProperty) value);
            }
        }
    }
}
