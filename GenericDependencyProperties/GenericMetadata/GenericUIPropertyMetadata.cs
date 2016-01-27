using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericUIPropertyMetadata<TProperty, TOwner> : GenericPropertyMetadata<TProperty,TOwner> 
        where TOwner : DependencyObject
    {
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
