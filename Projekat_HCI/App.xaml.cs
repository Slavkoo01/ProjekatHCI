using System.Configuration;
using System.Data;
using System.Windows;
using Projekat_HCI.View;
using Projekat_HCI.Repositories;
using Projekat_HCI.ViewModel;
using System.Collections.ObjectModel;
using Projekat_HCI.Model;

namespace Projekat_HCI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginViewModel.User = XMLFiles.DeSerializeUsers<ObservableCollection<UserModel>>();
        }
    }

}
