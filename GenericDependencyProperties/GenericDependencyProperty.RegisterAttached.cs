using System;
using System.Linq.Expressions;
using System.Windows;
using GenericDependencyProperties.GenericCallback;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public partial class GenericDependencyProperty
    {
        //DependencyProperty.RegisterAttached(name, typeof(string), typeof(GenericDependencyProperty));
        public static DependencyProperty RegisterAttached<TProperty, TOwner>(string name)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttached(
                name,
                typeof(TProperty),
                typeof(TOwner));
        }

        // DependencyProperty.RegisterAttached(name, typeof(TProperty), typeof(TOwner), propertyMetadata);
        public static DependencyProperty RegisterAttached<TProperty, TOwner>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata)
            where TOwner : DependencyObject

        {
            return DependencyProperty.RegisterAttached(
                name,
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric());
        }

        // DependencyProperty.RegisterAttached(name, typeof(TProperty), typeof(TOwner), PropertyMetadata, validateValueCallback);
        public static DependencyProperty RegisterAttached<TProperty, TOwner> (
            string name,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttached(
                name,
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }

        //DependencyProperty.RegisterAttached(name, typeof(string), typeof(GenericDependencyProperty));
        public static DependencyProperty RegisterAttached<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttached(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner));
        }

        // DependencyProperty.RegisterAttached(name, typeof(TProperty), typeof(TOwner), propertyMetadata);
        public static DependencyProperty RegisterAttached<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata)
            where TOwner : DependencyObject

        {
            return DependencyProperty.RegisterAttached(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric());
        }

        // DependencyProperty.RegisterAttached(name, typeof(TProperty), typeof(TOwner), PropertyMetadata, validateValueCallback);
        public static DependencyProperty RegisterAttached<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterAttached(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }
    }
}
