using System.Windows;

namespace GenericDependencyProperties
{
    public delegate void GenericPropertyChangedCallback<in TOwner, TProperty>(
        TOwner d,
        DependencyPropertyChangedEventArgs<TProperty> e)
        where TOwner : DependencyObject;
}
