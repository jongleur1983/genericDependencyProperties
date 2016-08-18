using System.Windows;
using GenericDependencyProperties.GenericMetadata;
using Xunit;

namespace GenericDependencyProperties.Test
{
    public class DependencyPropertyPropertyChangedCallbackTests
    {
        [Fact]
        public void PropertyChancedCallbackIsCalled()
        {
            var objectUnderTest = new FirstDependencyObject();
            Assert.Equal(
                FirstDependencyObject.DefaultTestValue,
                objectUnderTest.Test);

            objectUnderTest.Test = 42;
            Assert.Equal(
                42,
                objectUnderTest.Test);
            Assert.Equal(
                FirstDependencyObject.DefaultTestValue,
                objectUnderTest.LastValue);
        }

        public class FirstDependencyObject : DependencyObject
        {
            public const int DefaultTestValue = 5;

            public static readonly DependencyProperty dp = GenericDependencyProperty
                .Register<int, FirstDependencyObject>(
                    fdo => fdo.Test,
                    new GenericPropertyMetadata<int, FirstDependencyObject>(
                        DefaultTestValue,
                        Callback));

            private static void Callback(FirstDependencyObject d, DependencyPropertyChangedEventArgs<int> e)
            {
                d.LastValue = e.OldValue;
            }

            public int LastValue
            {
                get;
                set;
            }

            public int Test
            {
                get { return (int)this.GetValue(dp); }
                set { this.SetValue(dp, value); }
            }
        }
    }
}
