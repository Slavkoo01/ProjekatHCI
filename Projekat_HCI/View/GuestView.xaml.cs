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
    /// Interaction logic for GuestView.xaml
    /// </summary>
    public partial class GuestView : UserControl
    {
        private GuestViewModel _guestViewModel;

        static TransitionControl _transitionControl;


        public GuestView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            _guestViewModel = new GuestViewModel();
            DataContext = _guestViewModel;
        }

        public static void LogOutAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new LoginView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne, AnimationManager.SlideAnimationType.SlideDown);
        }

        public static void PresentationAnimation(BlenderManualViewModel blenderManualVieModel)
        {
            _transitionControl.ParentWindow.ChangeContent(new PresentationView(new TransitionControl(_transitionControl.ParentWindow), blenderManualVieModel), AnimationManager.SlideAnimationType.SlideUp);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;


            if (textBlock.Inlines.FirstOrDefault() is Hyperlink hyperlink)
            {
                if (hyperlink.DataContext is BlenderManualViewModel clickedItem)
                {
                    int index = GuestViewModel.BMData.IndexOf(clickedItem);

                    PresentationAnimation(GuestViewModel.BMData[index]);
                }
            }


        }

    }
}

