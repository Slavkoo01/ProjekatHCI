using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Projekat_HCI.Model;
namespace Projekat_HCI.ViewModel
{
    [Serializable]
    public class BlenderManualViewModel : ViewModelBase
    {
        private BlenderManualModel _blenderManualModel;

        public BlenderManualModel BlenderManualModel { get { return _blenderManualModel; } }
        
        [XmlIgnore]
        private bool _isChecked;

        [XmlIgnore]
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
        public string? Id { get; set; }
        public string? HyperLink { get; set; }
        public string? ImagePath { get; set; }
        public string? ContentPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public BlenderManualViewModel(BlenderManualModel blenderManualModel)
        {
            _blenderManualModel = blenderManualModel;
            Id = blenderManualModel.Id.ToString();
            HyperLink = blenderManualModel.HyperLink;
            ImagePath = blenderManualModel.ImagePath;
            ContentPath = blenderManualModel.ContentPath;
            DateAdded = blenderManualModel.DateAdded; 
        }
        public BlenderManualViewModel() { }
        
        public override string ToString()
        {
            return Id + " " + HyperLink + " " + IsChecked.ToString();
        }
      }
}
