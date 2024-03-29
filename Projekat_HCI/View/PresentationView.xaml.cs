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
    /// Interaction logic for PresentationView.xaml
    /// </summary>
    public partial class PresentationView : UserControl
    {
        private PresentationViewModel _presentationViewModel;
        
        private BlenderManualViewModel _blenderManualViewModel;

        public static TransitionControl _transitionControl;
        public PresentationView(TransitionControl transitionControl, BlenderManualViewModel blenderViewModel)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            _blenderManualViewModel = blenderViewModel;
            _presentationViewModel = new PresentationViewModel(blenderViewModel, PresentationRichTextBox);
            DataContext = _presentationViewModel;
        }

        public static void GoBackAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new GuestView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne, AnimationManager.SlideAnimationType.SlideDown);
        }

        private void PresentationRichTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
