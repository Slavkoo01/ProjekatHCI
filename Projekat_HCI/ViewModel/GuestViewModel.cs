using Projekat_HCI.Helper;
using Projekat_HCI.Repositories;
using Projekat_HCI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.ViewModel
{
    public class GuestViewModel
    {
        private static readonly ObservableCollection<BlenderManualViewModel> _bMData = new ObservableCollection<BlenderManualViewModel>();

        public static ObservableCollection<BlenderManualViewModel> BMData => _bMData;

        public GuestViewModel()
        {

        }

        public ViewModelCommands LogOutCommand => new ViewModelCommands(execute => LogOut());

        private void LogOut()
        {
            GuestView.LogOutAnimation();
        }

    }
}
