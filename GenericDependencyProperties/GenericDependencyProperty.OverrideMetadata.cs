using System.Windows;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public static partial class GenericDependencyProperty
    {
        public static void OverrideMetadata<TOwner, TProperty>(
            this DependencyProperty dp,
            GenericPropertyMetadata<TProperty, TOwner> metadata)
            where TOwner : DependencyObject
        {
            dp.OverrideMetadata(
                typeof(TOwner),
                metadata.ToNonGeneric());
        }

        public static void OverrideMetadata<TOwner, TProperty>(
            this DependencyProperty dp,
            GenericPropertyMetadata<TProperty, TOwner> metadata,
            DependencyPropertyKey dependencyPropertyKey)
            where TOwner: DependencyObject
        {
            dp.OverrideMetadata(
                typeof(TOwner),
                metadata.ToNonGeneric(), 
                dependencyPropertyKey);
        }
    }
}
