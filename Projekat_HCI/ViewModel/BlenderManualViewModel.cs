﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Projekat_HCI.Model;

namespace Projekat_HCI.ViewModel
{
    class BlenderManualViewModel : ViewModelBase
    {
        private readonly BlenderManualModel _blenderManualModel;
       
        public int? Id => _blenderManualModel.Id;

        public string? Name => _blenderManualModel.Name;

        public string? ImagePath => _blenderManualModel.ImagePath;
        
        public string? ContentPath => _blenderManualModel.ContentPath;

        public DateOnly? DateAdded => _blenderManualModel.DateAdded;

        public BlenderManualViewModel(BlenderManualModel blenderManualModel)
        {
            _blenderManualModel = blenderManualModel;
        }
    }
}
