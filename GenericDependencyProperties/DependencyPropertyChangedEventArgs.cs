using System.Windows;

namespace GenericDependencyProperties
{
    public struct DependencyPropertyChangedEventArgs<TProperty>
    {
        public DependencyPropertyChangedEventArgs(
            DependencyProperty property,
            TProperty oldValue,
            TProperty newValue)
        {
            this.DependencyProperty = property;
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }

        public DependencyPropertyChangedEventArgs(DependencyPropertyChangedEventArgs args)
        {
            this.NewValue = (TProperty) args.NewValue;
            this.OldValue = (TProperty) args.OldValue;
            this.DependencyProperty = args.Property;
        }

        public TProperty NewValue { get; private set; }

        public TProperty OldValue { get; private set; }

        public DependencyProperty DependencyProperty { get; private set; }

        public DependencyPropertyChangedEventArgs AsNonGeneric()
        {
            return new DependencyPropertyChangedEventArgs(
                this.DependencyProperty, 
                this.OldValue, 
                this.NewValue);
        }
    }
}