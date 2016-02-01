using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenericDependencyProperties;
using GenericDependencyProperties.GenericMetadata;

namespace GenericDependencyProperties.Examples
{
    /// <summary>
    /// Interaktionslogik für SampleUserControl.xaml
    /// </summary>
    public partial class SampleUserControl : UserControl
    {
        public static DependencyProperty SatelliteRadiusProperty = GenericDependencyProperty.Register(
            "SatelliteRadius",
            new GenericPropertyMetadata<double, SampleUserControl>(20)
            );

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
