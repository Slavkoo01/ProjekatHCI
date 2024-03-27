using Accessibility;
using Projekat_HCI.Helper;
using Projekat_HCI.Model;
using Projekat_HCI.Repositories;
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

        }
        public ViewModelCommands AddCommand => new ViewModelCommands(execute => AddItem());
        public ViewModelCommands LogOutCommand => new ViewModelCommands(execute => LogOut());
        public ViewModelCommands SaveCommand => new ViewModelCommands(execute => Save());
        public ViewModelCommands DeleteCommand => new ViewModelCommands(execute => Delete());

        private void Delete()
        {
            for (int i = BMData.Count - 1; i >= 0; i--) 
            {
                if (BMData[i].IsChecked)
                {
                    BMData.RemoveAt(i);
                    RTFFiles.DeleteRTFFile(BMData[i]);
                }
            }
            GlobalVar.IsSaved = false;

        }

        public void Save()
        {
            XMLFiles _serializer = new XMLFiles();
            _serializer.SerializeObject();
            GlobalVar.IsSaved = true;
        }
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
