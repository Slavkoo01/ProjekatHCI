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
        public ViewModelCommands DeleteCommand => new ViewModelCommands(execute => Delete());

        private void Delete()
        {
            ObservableCollection<BlenderManualViewModel> temp = new ObservableCollection<BlenderManualViewModel>();
              for (int i = 0; i < BMData.Count; i++) 
              {
                
                  if (BMData[i].IsChecked)
                  {
                      RTFFiles.DeleteRTFFile(BMData[i]);

                  }
                  else
                  {
                        temp.Add(BMData[i]);
                  }
              }
               BMData.Clear();
               foreach(var item in temp)
               {
                BMData.Add(item);
               }
              GlobalVar.IsSaved = false;
            
            
        }

        private void AddItem()
        {
            AdminView.AddAnimation();
        }
        private void LogOut()
        {
            if (!GlobalVar.IsSaved)
            {
                XMLFiles _serializer = new XMLFiles();
                _serializer.SerializeObject();
            }
            AdminView.LogOutAnimation();
        }
        


    }
}
