using System;
using System.Linq.Expressions;
using System.Windows;
using GenericDependencyProperties.GenericCallback;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public partial class GenericDependencyProperty
    {
        public static DependencyPropertyKey RegisterAttachedReadOnly<TOwner, TProperty>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> metadata)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttachedReadOnly(
                name,
                typeof(TProperty),
                typeof(TOwner),
                metadata.ToNonGeneric());
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly<TOwner, TProperty>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> metadata)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttachedReadOnly(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                metadata.ToNonGeneric());
        }


        // DependencyProperty.RegisterAttachedReadOnly(stringName, propertyType, ownerType, propertyMetadata, validateValueCallback)
        public static DependencyPropertyKey RegisterAttachedReadOnly<TOwner, TProperty>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttachedReadOnly(
                name,
                typeof(TProperty),
                typeof(TOwner),
                metadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly<TOwner, TProperty>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttachedReadOnly(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                metadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }
    }
}
