using Accessibility;
using Projekat_HCI.Model;
using Projekat_HCI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_HCI.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        private static readonly ObservableCollection<BlenderManualViewModel> _bMData = new ObservableCollection<BlenderManualViewModel>();

        public static ObservableCollection<BlenderManualViewModel> BMData => _bMData;
     
        public AdminViewModel()
        {

            BMData.Add(new BlenderManualViewModel(new BlenderManualModel(1,"Test", "/Images/LazarArt2ExtendedFlipped.png", "",DateOnly.FromDateTime(DateTime.Today))));
            BMData.Add(new BlenderManualViewModel(new BlenderManualModel(1,"Test", "/Images/LazarArt2ExtendedFlipped.png", "",DateOnly.FromDateTime(DateTime.Today))));
            BMData.Add(new BlenderManualViewModel(new BlenderManualModel(1,"Test", "/Images/LazarArt2ExtendedFlipped.png", "",DateOnly.FromDateTime(DateTime.Today))));

        }
        public ViewModelCommands AddCommand => new ViewModelCommands(execute => AddItem());
        public ViewModelCommands LogOutCommand => new ViewModelCommands(execute => LogOut());
        private void AddItem()
        {
            AdminView.AddAnimation();
        }
        private void LogOut()
        {
            AdminView.LogOutAnimation();
        }



    }
}
