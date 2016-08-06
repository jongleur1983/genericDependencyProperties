using System.Windows;
using GenericDependencyProperties.GenericCallback;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericFrameworkPropertyMetadata<TProperty, TOwner> : GenericUIPropertyMetadata<TProperty, TOwner> 
        where TOwner : FrameworkElement
    {
        public GenericFrameworkPropertyMetadata()
            : base()
        {
        }

        public GenericFrameworkPropertyMetadata(
            GenericPropertyChangedCallback<TOwner, TProperty> propertyChangedCallback)
            : base(propertyChangedCallback)
        {
        }

        public GenericFrameworkPropertyMetadata(
            GenericPropertyChangedCallback<TOwner, TProperty> propertyChangedCallback,
            GenericCoerceValueCallback<TOwner, TProperty> coerceValueCallback)
            :base(propertyChangedCallback)
        {
            this.CoerceValueCallback = coerceValueCallback;
        }

        public GenericFrameworkPropertyMetadata(TProperty defaultValue)
            :base(defaultValue)
        {
            
        }

        public GenericFrameworkPropertyMetadata(
            TProperty defaultValue,
            FrameworkPropertyMetadataOptions flags)
            :base(defaultValue)
        {
            this.Flags = flags;
        }

        public override PropertyMetadata ToNonGeneric()
        {
            return new FrameworkPropertyMetadata(
                this.DefaultValue,
                this.Flags,
                this.WrappedPropertyChangedCallback,
                this.WrappedCoerceValueCallback,
                this.IsAnimationProhibited);
        }

        public FrameworkPropertyMetadataOptions Flags { get; set; }
    }
}
