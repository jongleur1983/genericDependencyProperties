using System.Windows;
using System.Windows.Controls;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties.Examples
{
    /// <summary>
    /// Interaktionslogik für SampleUserControl.xaml
    /// </summary>
    public partial class SampleUserControl : UserControl
    {
        public static DependencyProperty SatelliteRadiusProperty = GenericDependencyProperty.Register(
            x => x.SatelliteRadius,
            new GenericPropertyMetadata<double, SampleUserControl>(20)
            );

        public static DependencyProperty FooProperty = GenericDependencyProperty.Register(
            nameof(SatelliteRadius),
            new GenericPropertyMetadata<double, SampleUserControl>());

        public double SatelliteRadius
        {
            get
            {
                return (double) this.GetValue(SatelliteRadiusProperty); // TODO: can we get rid of the cast as well? not yet as the dependencyProperty itself is untyped
            }
            set
            {
                this.SetValue(SatelliteRadiusProperty, value);
            }
        }

        //public static DependencyProperty HeadlineProperty = GenericDependencyProperties.Register(
        //    "Headline", 
        //    new GenericPropertyMetadata<string, SampleUserControl>("defaultHeadline"));

        public SampleUserControl()
        {
            InitializeComponent();
        }
    }
}
