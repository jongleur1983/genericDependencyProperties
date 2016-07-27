using System;
using System.Diagnostics;
using System.Windows;
using GenericDependencyProperties.GenericMetadata;
using System.Linq.Expressions;

namespace GenericDependencyProperties
{
    public static partial class GenericDependencyProperty
    {
        public static DependencyProperty Register<TProperty, TOwner>(
            string name, 
            PropertyMetadata typeMetadata,
            ValidateValueCallback validateValueCallback = null)
        {
            return DependencyProperty.Register(name, typeof(TProperty), typeof(TOwner), typeMetadata, validateValueCallback);
        }

        // TODO: is this variant really hidden? how is TOwner be used when no type is given explicitly?
        public static DependencyProperty Register<TProperty>(
            string name,
            PropertyMetadata typeMetadata,
            ValidateValueCallback validateValueCallback = null)
        {
            var callingType = new StackTrace(true).GetFrame(1).GetType();
            return DependencyProperty.Register(name, typeof(TProperty), callingType, typeMetadata, validateValueCallback);
        }

        public static DependencyProperty Register<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            PropertyMetadata typeMetadata,
            ValidateValueCallback validateValueCallback = null)
        {
            var member = memberExpression.Body as MemberExpression;
            var propertyName = member?.Member.Name;

            if (propertyName == null)
            {
                throw new ArgumentException(
                    $"the {memberExpression} must be a valid MemberExpression.",
                    nameof(memberExpression));
            }

            return Register<TProperty, TOwner>(
                propertyName,
                typeMetadata,
                validateValueCallback);
        }

        public static DependencyProperty Register<TProperty, TOwner>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            ValidateValueCallback validateValueCallback = null) where TOwner : DependencyObject
        {
            return DependencyProperty.Register(
                name, 
                typeof (TProperty), 
                typeof (TOwner), 
                metadata.ToNonGeneric(),
                validateValueCallback); // TODO: can we make validateValueCallback generic as well? signature is object -> bool, it should be possible to use TProperty->bool (as it's the effective value)
        }

        public static DependencyProperty Register<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> accessorLambda,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            ValidateValueCallback validateValueCallback = null) where TOwner : DependencyObject
        {
            return Register(
                accessorLambda,
                metadata.ToNonGeneric(),
                validateValueCallback); // TODO: can we make validateValueCallback generic as well?
        }

        // TODO: fourth level: keep the ValidateValueCallback type save

        public static void test()
        {
            string name;
            Type propertyType, ownerType;
            PropertyMetadata typeMetadata;
            ValidateValueCallback validateValueCallback;

            //DependencyProperty.Register(name, propertyType, ownerType, typeMetadata, validateValueCallback);
        }
    }
}
