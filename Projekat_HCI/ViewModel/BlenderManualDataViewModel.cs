using Accessibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.ViewModel
{
    class BlenderManualDataViewModel
    {
        private readonly ObservableCollection<BlenderManualViewModel> _bMData;

        public IEnumerable<BlenderManualViewModel> BMData => _bMData;

        public BlenderManualDataViewModel()
        {
            _bMData = new ObservableCollection<BlenderManualViewModel>();

            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"Slavko","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
            _bMData.Add(new BlenderManualViewModel((new Model.BlenderManualModel(1,"AAA","/Images/LazarArt2ExtendedFlipped.png","",DateOnly.FromDateTime(DateTime.Now)))));
        }
    }
}
