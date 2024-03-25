using Projekat_HCI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_HCI.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private static string _newId;
        public string NewId
        {
            get { return _newId; }
            set
            {
                _newId = value;
                OnPropertyChanged(nameof(NewId));
            }
        }
        private string _newHyperLink;
        public string NewHyperLink
        {
            get { return _newHyperLink; }
            set
            {
                _newHyperLink = value;
                OnPropertyChanged(nameof(NewHyperLink));
            }
        }

        private string _newDate = DateOnly.FromDateTime(DateTime.Today).ToString(); 
        public string NewDate
        {
            get { return _newDate; }
            set
            {
                _newDate = value;
                OnPropertyChanged(nameof(NewDate));
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public AddViewModel()
        {
            
        }

        public ViewModelCommands AddCommand => new ViewModelCommands(execute => AddItem());
        public ViewModelCommands BackCommand => new ViewModelCommands(execute => GoBack());
        private void AddItem()
        {           
            MessageBox.Show(NewId + " " + NewHyperLink + " " + NewDate);
        }
        private void GoBack()
        {
            AddView.GoBackAnimation();
        }



    }
}
