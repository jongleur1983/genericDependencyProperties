using System;
using System.Windows;
using GenericDependencyProperties.GenericCallback;

namespace GenericDependencyProperties.GenericMetadata
{
    public class GenericPropertyMetadata<TProperty, TOwner> : PropertyMetadata
        where TOwner : DependencyObject
    {
        public GenericPropertyMetadata()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with a specified default value for the dependency property that this metadata will be applied to. 
        /// </summary>
        /// <param name="defaultValue"></param>
        public GenericPropertyMetadata(TProperty defaultValue)
            : base(defaultValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyMetadata class with the specified default value and PropertyChangedCallback implementation reference.
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="callback"></param>
        public GenericPropertyMetadata(TProperty defaultValue, GenericPropertyChangedCallback<TOwner, TProperty> callback)
            : base(defaultValue)
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
            :base()
        {
            this.PropertyChangedCallback = callback;
        }

        /// <summary>
        /// Gets or sets the default value of the dependency property.
        /// </summary>
        public new TProperty DefaultValue
        {
            get
            {
                return (TProperty) base.DefaultValue;
            }
            set
            {
                base.DefaultValue = value;
            }
        }

        // TODO: public object IsSealed not yet overwritten, is not changed!?
        // Gets a value that determines whether the metadata has been applied to a property in some way, resulting in the immutable state of that metadata instance.
        // public bool IsSealed {get; }

        private GenericPropertyChangedCallback<TOwner, TProperty> genericChangeCallback;
        /// <summary>
        /// Gets or sets a reference to a PropertyChangedCallback implementation specified in this metadata.
        /// </summary>
        /// TODO: use a generic PropertyChangedCallback that accepts 
        public new GenericPropertyChangedCallback<TOwner, TProperty> PropertyChangedCallback
        {
            get
            {
                return this.genericChangeCallback;
            }
            set
            {
                this.genericChangeCallback = value;
                base.PropertyChangedCallback = WrappedPropertyChangedCallback;
            }
        }


        private void WrappedPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var typedDependencyObject = dependencyObject as TOwner;
            var typedArgs = new DependencyPropertyChangedEventArgs<TProperty>(
                dependencyPropertyChangedEventArgs.Property,
                (TProperty)dependencyPropertyChangedEventArgs.OldValue,
                (TProperty)dependencyPropertyChangedEventArgs.NewValue);

            this.genericChangeCallback(typedDependencyObject, typedArgs);
        }



        private GenericCoerceValueCallback<TOwner, TProperty> genericCoerceValueCallback;

        public new GenericCoerceValueCallback<TOwner, TProperty> CoerceValueCallback
        {
            get
            {
                return this.genericCoerceValueCallback;
            }
            set
            {
                this.genericCoerceValueCallback = value;
                base.CoerceValueCallback = WrappedCoerceValueCallback;
            }
        }

        private object WrappedCoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            var typedDependencyObject = dependencyObject as TOwner;
            var typedValue = (TProperty)baseValue;

            return this.genericCoerceValueCallback(typedDependencyObject, typedValue);
        }

        // <summary>
        // //Merges this metadata with the base metadata.
        // </summary>
        //protected virtual void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
        //{
        //    base.Merge(baseMetadata, dp);
        //}

        /// <summary>
        /// Called when this metadata has been applied to a property, which indicates that the metadata is being sealed.
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="targetType"></param>
        protected virtual void OnApply(DependencyProperty dp, Type targetType)
        {
            base.OnApply(dp, targetType);
        }
    }
}
