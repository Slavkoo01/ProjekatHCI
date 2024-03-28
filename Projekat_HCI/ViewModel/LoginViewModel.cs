using Projekat_HCI.Repositories;
using Projekat_HCI.View;
using Projekat_HCI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekat_HCI.Helper;

namespace Projekat_HCI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public static ObservableCollection<UserModel> User = new ObservableCollection<UserModel>();

        private string _logInPassword;
        public string LogInPassword
        {
            get { return _logInPassword; }
            set
            {
                if (_logInPassword != value)
                {
                    _logInPassword = value;
                    OnPropertyChanged(nameof(LogInPassword));
                }
            }
        }
        private string _logInUsername;
        public string LogInUsername
        {
            get { return _logInUsername; }
            set
            {
                if (_logInUsername != value)
                {
                    _logInUsername = value;
                    OnPropertyChanged(nameof(LogInUsername));
                }
            }
        }
        public ViewModelCommands LoginCommand => new ViewModelCommands(execute => Login());



        private void Login()
        {
            
            UserModel NewUser = new UserModel(LogInUsername,LogInPassword);
            foreach (var user in User)
            {
                if (user.Equals(NewUser))
                {
                    NewUser.Role = user.Role;
                    break;
                }
            }
            if(NewUser.Role == UserRole.Admin)
            {
                GlobalVar.role = UserRole.Admin;
                XMLFiles.LoadDataFromXML(UserRole.Admin);
                LoginView.LogInAnimationAdmin();
            }
            else if(NewUser.Role == UserRole.Guest)
            {
                GlobalVar.role = UserRole.Guest;
                XMLFiles.LoadDataFromXML(UserRole.Guest);
                LoginView.LogInAnimationGuest();
            }
            else
            {
                GlobalVar.role = UserRole.Unknown;
                return;
            }

        }
    }
}
