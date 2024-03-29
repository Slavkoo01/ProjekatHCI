using Notification.Wpf;
using Projekat_HCI.Helper;
using Projekat_HCI.Model;
using Projekat_HCI.Repositories;
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

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _loginViewModel.LogInPassword = PasswordTextBox.Password;
        }
        private void UsernameValidation(string Error)
        {
            UsernameError.Text = Error;
            UsernameError.Opacity = 1;
        }
        private void PasswordValidation(string Error)
        {
            PasswordError.Text = Error;
            PasswordError.Opacity = 1;
        }
        private void ValidationClear()
        {
            UsernameError.Opacity = 0;
            PasswordError.Opacity = 0;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
           
            string LogInUsername = UsernameTextBox.Text;
            string LogInPassword = PasswordTextBox.Password;
            ValidationClear();
            if (string.IsNullOrEmpty(LogInUsername) && string.IsNullOrEmpty(LogInPassword))
            {

                UsernameValidation("Enter Username");
                PasswordValidation("Enter Password");
                Toast.ShowToastNotification(new ToastNotification("Log in Failed", "Username and password fields must not be empty", NotificationType.Error));
                return;
            }
            if (string.IsNullOrEmpty(LogInUsername))
            {
                UsernameValidation("Enter Username");
                Toast.ShowToastNotification(new ToastNotification("Log in Failed", "Username field must not be empty", NotificationType.Error));
                return;
            }
            else if (string.IsNullOrEmpty(LogInPassword))
            {
                PasswordValidation("Enter Password");
                Toast.ShowToastNotification(new ToastNotification("Log in Failed", "Password field must not be empty", NotificationType.Error));
                return;
            }
           





            UserModel NewUser = new UserModel(LogInUsername, LogInPassword);
            foreach (var user in LoginViewModel.User)
            {
                if (user.Equals(NewUser))
                {
                    NewUser.Role = user.Role;
                    break;
                }
            }
            if (NewUser.Role == UserRole.Admin)
            {
                Toast.ShowToastNotification(new ToastNotification("Success", "You loged in as administrator", NotificationType.Success));
                GlobalVar.role = UserRole.Admin;
                XMLFiles.LoadDataFromXML(UserRole.Admin);
                LoginView.LogInAnimationAdmin();
            }
            else if (NewUser.Role == UserRole.Guest)
            {
                Toast.ShowToastNotification(new ToastNotification("Success", "You loged in as guest", NotificationType.Success));
                GlobalVar.role = UserRole.Guest;
                XMLFiles.LoadDataFromXML(UserRole.Guest);
                LoginView.LogInAnimationGuest();
            }
            else
            {
                Toast.ShowToastNotification(new ToastNotification("Log in Failed", "Username or password are incorrect", NotificationType.Error));
                GlobalVar.role = UserRole.Unknown;
                return;
            }




        }
    }
}
