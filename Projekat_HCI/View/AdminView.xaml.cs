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
using Projekat_HCI.View;
using Projekat_HCI.ViewModel;

namespace Projekat_HCI.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }
        TransitionControl _transitionControl;
        public AdminView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
        }

        

        public void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new LoginView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne,AnimationManager.SlideAnimationType.SlideDown);
        }

        
    }
}
