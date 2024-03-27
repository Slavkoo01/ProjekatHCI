using System.Configuration;
using System.Data;
using System.Windows;
using Projekat_HCI.View;
using Projekat_HCI.Repositories;

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


            XMLFiles.LoadDataFromXML();
        }
    }

}
