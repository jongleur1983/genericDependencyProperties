using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenericDependencyProperties.GenericCallback;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public partial class GenericDependencyProperty
    {
        // DependencyProperty.RegisterReadOnly(stringName, typePropertyType, typeOwnerType, propertyMetadata);
        public static DependencyPropertyKey RegisterReadOnly<TProperty, TOwner>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterReadOnly(
                name,
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric());
        }
        
        // DependencyProperty.RegisterReadOnly(stringName, typePropertyType, typeOwnerType, propertyMetadata, validateValueCallback)
        public static DependencyPropertyKey RegisterReadOnly<TProperty, TOwner>(
            string name, 
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterReadOnly(
                name,
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }

        // DependencyProperty.RegisterReadOnly(stringName, typePropertyType, typeOwnerType, propertyMetadata);
        public static DependencyPropertyKey RegisterReadOnly<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterReadOnly(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric());
        }

        // DependencyProperty.RegisterReadOnly(stringName, typePropertyType, typeOwnerType, propertyMetadata, validateValueCallback)
        public static DependencyPropertyKey RegisterReadOnly<TProperty, TOwner>(
            Expression<Func<TOwner, TProperty>> memberExpression,
            GenericPropertyMetadata<TProperty, TOwner> propertyMetadata,
            ValidateValueCallback<TProperty> validateValueCallback)
            where TOwner : DependencyObject
        {
            return DependencyProperty.RegisterReadOnly(
                GetNameFromExpression(memberExpression),
                typeof(TProperty),
                typeof(TOwner),
                propertyMetadata.ToNonGeneric(),
                GetBoxedValidateValueCallback(validateValueCallback));
        }

    }
}
