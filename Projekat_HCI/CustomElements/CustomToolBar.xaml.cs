using Projekat_HCI.View;
using Projekat_HCI.ViewModel;
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
        
        public RichTextBox RichTextBox { get; set; }
        public CustomToolBar()
        {
            InitializeComponent();
            DataContext = new CustomToolBarViewModel();

            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            
            TextColorComboBox.ItemsSource = AddViewModel.ColorList;
            //FontSizeComboBox.ItemsSource = FontSize;
            //FontSizeComboBox.ItemsSource = Enumerable.Range(1, 48).Select(i => (double)i).ToList();
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }
        }

        private void TextColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextColorComboBox.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                var selectedColor = (Color)typeof(Colors).GetProperty(((dynamic)TextColorComboBox.SelectedItem).ColorName).GetValue(null);
                var brush = new SolidColorBrush(selectedColor);
                RichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, brush);
            }
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeComboBox.SelectedItem);
            }
        }

    }
}
