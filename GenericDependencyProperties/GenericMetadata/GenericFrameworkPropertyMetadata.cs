using System.Windows;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericFrameworkPropertyMetadata<TProperty, TOwner> : GenericUIPropertyMetadata<TProperty, TOwner> 
        where TOwner : FrameworkElement
    {
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
