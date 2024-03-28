using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_HCI.Repositories;
using System.Windows.Controls;
using Projekat_HCI.View;
using System.Reflection;

namespace Projekat_HCI.ViewModel
{
    class PresentationViewModel : ViewModelBase
    {
        public RichTextBox EditRichTextBox { get; set; }
        
        public ViewModelCommands BackCommand => new ViewModelCommands(execute => GoBack());

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

        private string _newDate;
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
        private string[] parts;
        
        private string betterDateAndTime = "";
        public PresentationViewModel(BlenderManualViewModel blenderManualViewModel, RichTextBox richTextBox)
        {
            NewId = blenderManualViewModel.Id;
            NewHyperLink = blenderManualViewModel.HyperLink;
            ImagePath = blenderManualViewModel.ImagePath;
            
            parts = blenderManualViewModel.DateAdded.ToString().Split('/', ':',' ');
            
            betterDateAndTime = parts[0] + "." + parts[1] + "." + parts[2] +". " + parts[3] + ":" + parts[4] + " " + parts[6];

            NewDate = betterDateAndTime;
            EditRichTextBox = richTextBox;
            RTFFiles.LoadRtfFile(blenderManualViewModel.Id.ToString(), EditRichTextBox);
        }

        private void GoBack()
        {
            PresentationView.GoBackAnimation();
        }


    }
}
