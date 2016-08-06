using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GenericDependencyProperties.GenericCallback;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericUIPropertyMetadata<TProperty, TOwner> : GenericPropertyMetadata<TProperty,TOwner> 
        where TOwner : UIElement
    {
        public GenericUIPropertyMetadata()
            :base()
        {
            
        }

        public GenericUIPropertyMetadata(
            GenericPropertyChangedCallback<TOwner, TProperty> propertyChangedCallback)
            : base(propertyChangedCallback)
        {

        }

        public GenericUIPropertyMetadata(TProperty defaultValue)
            :base(defaultValue)
        {
            
        }

        public GenericUIPropertyMetadata(
            TProperty defaultValue,
            GenericPropertyChangedCallback<TOwner, TProperty>  propertyChangedCallback)
            :base(defaultValue, propertyChangedCallback)
        {
            
        }

        public GenericUIPropertyMetadata(
            TProperty defaultValue,
            GenericPropertyChangedCallback<TOwner, TProperty> propertyChangedCallback,
            GenericCoerceValueCallback<TOwner, TProperty> coerceValueCallback)
            :base(defaultValue, propertyChangedCallback, coerceValueCallback)
        {
        }

        public bool IsAnimationProhibited { get; set; }

        public override PropertyMetadata ToNonGeneric()
        {
            return new UIPropertyMetadata(
                this.DefaultValue, 
                this.WrappedPropertyChangedCallback, 
                this.WrappedCoerceValueCallback, 
                this.IsAnimationProhibited);
        }
    }
}
