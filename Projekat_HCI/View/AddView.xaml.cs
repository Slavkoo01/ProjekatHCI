using Projekat_HCI.CustomElements;
using Projekat_HCI.Model;
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

namespace Projekat_HCI.View
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        private static TransitionControl _transitionControl;

        private AddViewModel _addViewModel;

        public AddView(TransitionControl transitionControl)
        {
            InitializeComponent();

            CustomToolBar.RichTextBox = AddViewRichTextBox;
            _addViewModel = new AddViewModel();
            _addViewModel.richTextBox = AddViewRichTextBox;
            _transitionControl = transitionControl;
            DataContext = _addViewModel;
            
        }


        public static void GoBackAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new AdminView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne, AnimationManager.SlideAnimationType.SlideRight);
        }

        private void ImageGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            DefaultImage.Height = 195;
            DefaultImage.Width = 195;
        }

        private void ImageGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            DefaultImage.Height = 200;
            DefaultImage.Width = 200;
        }

         private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
         {
             object fontWeight = AddViewRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
             CustomToolBar.BoldToggleButton.IsChecked = (fontWeight != DependencyProperty.UnsetValue) && (fontWeight.Equals(FontWeights.Bold));

             object fontFamily = AddViewRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
             CustomToolBar.FontFamilyComboBox.SelectedItem = fontFamily;

             object fontItalic = AddViewRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
             CustomToolBar.ItalicToggleButton.IsChecked = (fontItalic != DependencyProperty.UnsetValue) && (fontItalic.Equals(FontStyles.Italic));

             object fontUnderline = AddViewRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
             CustomToolBar.UnderlineToggleButton.IsChecked = (fontUnderline != DependencyProperty.UnsetValue) && (fontUnderline.Equals(TextDecorations.Underline));

             object fontSize = AddViewRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
             CustomToolBar.FontSizeComboBox.SelectedItem = fontSize;

             object fontColor = AddViewRichTextBox.Selection.GetPropertyValue(Inline.ForegroundProperty);

            string[] MyColors;
            
            for (int i = 0; i < AddViewModel.ColorList.Count; i++)
            {
                MyColors = AddViewModel.ColorList[i].ToString().Split(' ');
                if (MyColors[MyColors.Count() - 2].Equals(fontColor.ToString()))
                {
                   CustomToolBar.TextColorComboBox.SelectedItem = AddViewModel.ColorList[i];
                }
                
            }

        }
    }
}
