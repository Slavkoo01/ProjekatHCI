using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.Model
{
    class BlenderManualModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public string? ContentPath { get; set; }
        public DateOnly? DateAdded { get; set; }
        public BlenderManualModel(int? id, string? name, string? imagePath, string? contentPath, DateOnly? dateAdded)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
            ContentPath = contentPath;
            DateAdded = dateAdded;
        }

    }
}
