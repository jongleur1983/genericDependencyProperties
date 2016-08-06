using System.Windows;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties
{
    public static partial class GenericDependencyProperty 
    {
        public static DependencyProperty AddOwner<TOwner>(this DependencyProperty original)
            where TOwner : DependencyObject
        {
            return original.AddOwner(typeof(TOwner));
        }

        public static DependencyProperty AddOwner<TOwner, TProperty>(
            this DependencyProperty original,
            GenericPropertyMetadata<TProperty, TOwner> metadata)
            where TOwner : DependencyObject
        {
            return original.AddOwner(typeof(TOwner), metadata.ToNonGeneric());
        }
    }
}
