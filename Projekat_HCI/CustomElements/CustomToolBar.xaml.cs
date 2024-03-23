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

namespace Projekat_HCI.CustomElements
{
    /// <summary>
    /// Interaction logic for CustomToolBar.xaml
    /// </summary>
    public partial class CustomToolBar : UserControl
    {
        public CustomToolBar()
        {
            InitializeComponent();
            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);

            var colorList = typeof(Colors).GetProperties()
                                          .Where(p => p.PropertyType == typeof(Color))
                                          .OrderBy(p => p.Name)
                                          .Select(p => new { ColorName = p.Name, ColorValue = (Color)p.GetValue(null) })
                                          .ToList();
            TextColorComboBox.ItemsSource = colorList;

            FontSizeComboBox.ItemsSource = Enumerable.Range(1, 48).Select(i => (double)i).ToList();
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
