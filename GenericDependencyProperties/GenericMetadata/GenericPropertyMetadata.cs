using System.Windows;
using GenericDependencyProperties.GenericCallback;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericPropertyMetadata<TProperty, TOwner>
        where TOwner : DependencyObject
    {
        public GenericPropertyMetadata()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with a specified default value 
        /// for the dependency property that this metadata will be applied to. 
        /// </summary>
        /// <param name="defaultValue"></param>
        public GenericPropertyMetadata(TProperty defaultValue)
        {
            this.DefaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with the specified default value
        /// and PropertyChangedCallback implementation reference.
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="callback"></param>
        public GenericPropertyMetadata(TProperty defaultValue, GenericPropertyChangedCallback<TOwner, TProperty> callback)
            : this(defaultValue)
        {
            this.PropertyChangedCallback = callback;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with the specified default value and callbacks.
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="callback"></param>
        /// <param name="coerceValueCallback"></param>
        public GenericPropertyMetadata(
            TProperty defaultValue, 
            GenericPropertyChangedCallback<TOwner, TProperty> callback, 
            GenericCoerceValueCallback<TOwner, TProperty> coerceValueCallback)
            : this(defaultValue, callback)
        {
            this.CoerceValueCallback = coerceValueCallback;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with the specified PropertyChangedCallback implementation reference.
        /// </summary>
        /// <param name="callback"></param>
        public GenericPropertyMetadata(GenericPropertyChangedCallback<TOwner, TProperty> callback)
        {
            this.PropertyChangedCallback = callback;
        }

        /// <summary>
        /// Gets or sets the default value of the dependency property.
        /// </summary>
        public TProperty DefaultValue { get; set; }

        // TODO: do we need some kind of sealing? it's never attached to anything itself, so not probably not necessary?
        
        /// <summary>
        /// Gets or sets a reference to a PropertyChangedCallback implementation specified in this metadata.
        /// </summary>
        /// TODO: use a generic PropertyChangedCallback that accepts only the right types
        public GenericPropertyChangedCallback<TOwner, TProperty> PropertyChangedCallback { get; set; }


        protected void WrappedPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (this.PropertyChangedCallback != null)
            {
                var typedDependencyObject = dependencyObject as TOwner;
                var typedArgs = new DependencyPropertyChangedEventArgs<TProperty>(
                    dependencyPropertyChangedEventArgs.Property,
                    (TProperty)dependencyPropertyChangedEventArgs.OldValue,
                    (TProperty)dependencyPropertyChangedEventArgs.NewValue);

                this.PropertyChangedCallback(typedDependencyObject, typedArgs);
            }
        }

        public GenericCoerceValueCallback<TOwner, TProperty> CoerceValueCallback { get; set; }

        protected object WrappedCoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            var typedDependencyObject = dependencyObject as TOwner;
            var typedValue = (TProperty)baseValue;

            // TODO is this the intended usage of the CoerceValueCallback?
            if (this.CoerceValueCallback != null)
            {
                return this.CoerceValueCallback(typedDependencyObject, typedValue);
            }
            else
            {
                return typedValue;
            }
            
        }

        public virtual PropertyMetadata ToNonGeneric()
        {
            return new PropertyMetadata(
                this.DefaultValue, 
                this.WrappedPropertyChangedCallback, 
                this.WrappedCoerceValueCallback);
        }
    }
}
