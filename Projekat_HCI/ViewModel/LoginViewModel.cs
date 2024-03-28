using Projekat_HCI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ViewModelCommands LoginCommand => new ViewModelCommands(execute => Login());

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



        private void Login()
        {
            LoginView.LogInAnimationAdmin();
        }
    }
}
