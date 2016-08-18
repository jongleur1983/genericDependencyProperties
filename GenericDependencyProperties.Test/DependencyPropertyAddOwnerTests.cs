using System.Windows;
using Xunit;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties.Test
{
    public class AddOwnerTests
    {
        [Fact]
        public void AddADependencyPropertyToSecondDependencyObjectWithDifferentDefaultValue()
        {
            var defaultValue = 5d;
            FirstDepenencyObject.dp.AddOwner<SecondDependencyObject, double>(
                new GenericPropertyMetadata<double, SecondDependencyObject>(defaultValue));

            var sdo = new SecondDependencyObject();

            Assert.Equal(defaultValue, sdo.GetValue(FirstDepenencyObject.dp));
        }

        [Fact]
        public void AddADependencyPropertyToSecondDependencyObjectWithSameDefaultValue()
        {
            var defaultValue = 5d;
            FirstDepenencyObject.dp.AddOwner<ThirdDependencyObject>();

            var sdo = new ThirdDependencyObject();

            Assert.Equal(
                FirstDepenencyObject.dp.DefaultMetadata.DefaultValue,
                sdo.GetValue(FirstDepenencyObject.dp));
        }

        public class FirstDepenencyObject : DependencyObject
        {
            public static readonly DependencyProperty dp = DependencyProperty.Register(
                "Test",
                typeof(double),
                typeof(FirstDepenencyObject),
                new PropertyMetadata(20d));
        }

        public class SecondDependencyObject : DependencyObject
        {
        }

        public class ThirdDependencyObject : DependencyObject
        {
        }
    }
}
