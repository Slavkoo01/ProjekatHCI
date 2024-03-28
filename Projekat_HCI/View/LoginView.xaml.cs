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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel _loginViewModel;
        public LoginView()
        {
            InitializeComponent();
        }
        static TransitionControl _transitionControl;
        public LoginView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            _loginViewModel = new LoginViewModel();
            DataContext = _loginViewModel;
        }
        public static void LogInAnimationAdmin()
        {
            _transitionControl.ParentWindow.ChangeContent(new AdminView(new TransitionControl(_transitionControl.ParentWindow)), AnimationManager.SlideAnimationType.SlideUp);
        }public static void LogInAnimationGuest()
        {
            _transitionControl.ParentWindow.ChangeContent(new GuestView(new TransitionControl(_transitionControl.ParentWindow)), AnimationManager.SlideAnimationType.SlideUp);
        }
        
    }
}
