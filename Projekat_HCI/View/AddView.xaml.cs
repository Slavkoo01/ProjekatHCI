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

        //private AddViewModel _addViewModel;
       

        public AddView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            
            this.DataContext = new AddViewModel();
            //IdTextBox.DataContext = _addViewModel;
            //DateTextBox.DataContext = _addViewModel;
            //BackButton.DataContext = _addViewModel;
           // AddButton.DataContext = _addViewModel;
        }


        public static void GoBackAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new AdminView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne, AnimationManager.SlideAnimationType.SlideRight);
        }

        private void ImageGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            DefaultImage.Height = 200;
            DefaultImage.Width = 200;
        }

        private void ImageGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            DefaultImage.Height = 216;
            DefaultImage.Width = 216;
        }
    }
}
