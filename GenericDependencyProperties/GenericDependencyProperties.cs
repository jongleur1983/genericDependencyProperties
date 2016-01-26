using System;
using System.Diagnostics;
using System.Windows;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public static class GenericDependencyProperties
    {
        #region first level: replace propertyType and ownerType as generic arguments. Problem: typeMeta might be of wrong type
        [Obsolete("use the variants with generic PropertyMetadata instead")]
        public static DependencyProperty Register<TProperty, TOwner>(
            string name, 
            PropertyMetadata typeMetadata,
            ValidateValueCallback validateValueCallback = null)
        {
            return DependencyProperty.Register(name, typeof(TProperty), typeof(TOwner), typeMetadata, validateValueCallback);
        }

        // TODO: registerAttached, registerReadOnly, RegisterAttachedReadonly

        #endregion

        #region second level: omit the ownerType and use the one from Stack:

        // TODO: is this variant really hidden? how is TOwner be used when no type is given explicitly?
        [Obsolete("use the variants with generic PropertyMetadata instead")]
        public static DependencyProperty Register<TProperty>(
            string name,
            PropertyMetadata typeMetadata,
            ValidateValueCallback validateValueCallback = null)
        {
            var callingType = new StackTrace(true).GetFrame(1).GetType();
            return DependencyProperty.Register(name, typeof(TProperty), callingType, typeMetadata, validateValueCallback);
        }

        #endregion

        #region third level: keep the PropertyMetadata type save as well:

        public static DependencyProperty Register<TProperty, TOwner>(
            string name,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            ValidateValueCallback validateValueCallback = null) where TOwner : DependencyObject
        {
            return DependencyProperty.Register(
                name, 
                typeof (TProperty), 
                typeof (TOwner), 
                metadata,
                validateValueCallback); // TODO: can we make validateValueCallback generic as well?
        }
        #endregion

        #region fourth level: keep the ValidateValueCallback type save:
        #endregion

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
