using System.Windows;

namespace GenericDependencyProperties.GenericCallback
{
    public delegate TProperty GenericCoerceValueCallback<in TOwner, TProperty>(
        TOwner d,
        TProperty baseValue)
        where TOwner : DependencyObject;
}
