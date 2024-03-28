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
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        private static TransitionControl _transitionControl;

        private BlenderManualViewModel _blenderViweModel;

        private EditViewModel _editViewModel;

        public EditView(TransitionControl transitionControl, BlenderManualViewModel blenderViewModel, int index)
        {
            InitializeComponent();
            _blenderViweModel = blenderViewModel;
            CustomToolBar.RichTextBox = EditViewRichTextBox;
            _editViewModel = new EditViewModel(blenderViewModel, index, EditViewRichTextBox);
            WordCountTextBlock.Text = CountWords(EditViewRichTextBox).ToString();
            _transitionControl = transitionControl;
            DataContext = _editViewModel;
        }


        public static void GoBackAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new AdminView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne, AnimationManager.SlideAnimationType.SlideLeft);
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
            object fontWeight = EditViewRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            CustomToolBar.BoldToggleButton.IsChecked = (fontWeight != DependencyProperty.UnsetValue) && (fontWeight.Equals(FontWeights.Bold));

            object fontFamily = EditViewRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            CustomToolBar.FontFamilyComboBox.SelectedItem = fontFamily;

            object fontItalic = EditViewRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            CustomToolBar.ItalicToggleButton.IsChecked = (fontItalic != DependencyProperty.UnsetValue) && (fontItalic.Equals(FontStyles.Italic));

            object fontUnderline = EditViewRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            CustomToolBar.UnderlineToggleButton.IsChecked = (fontUnderline != DependencyProperty.UnsetValue) && (fontUnderline.Equals(TextDecorations.Underline));

            object fontSize = EditViewRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            CustomToolBar.FontSizeComboBox.SelectedItem = fontSize;

            object fontColor = EditViewRichTextBox.Selection.GetPropertyValue(Inline.ForegroundProperty);

            string[] MyColors;

            for (int i = 0; i < EditViewModel.ColorList.Count; i++)
            {
                MyColors = EditViewModel.ColorList[i].ToString().Split(' ');
                if (MyColors[MyColors.Count() - 2].Equals(fontColor.ToString()))
                {
                    CustomToolBar.TextColorComboBox.SelectedItem = AddViewModel.ColorList[i];
                }

            }
            WordCountTextBlock.Text = CountWords(EditViewRichTextBox).ToString();


        }

        private int CountWords(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string text = textRange.Text.Trim();


            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '?', '.', '!' }, StringSplitOptions.RemoveEmptyEntries);


            int wordCount = words.Length;

            return wordCount;
        }
    }
}
