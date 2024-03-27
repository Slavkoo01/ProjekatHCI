using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.Model
{
    [Serializable]
    public class BlenderManualModel
    {
        public int? Id { get; set; }
        public string? HyperLink { get; set; }
        public string? ImagePath { get; set; }
        public string? ContentPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public BlenderManualModel(int? id, string? hyperlink, string? imagePath, string? contentPath, DateTime? dateAdded)
        {
            Id = id;
            HyperLink = hyperlink;
            ImagePath = imagePath;
            ContentPath = contentPath;
            DateAdded = dateAdded;
        }

        public BlenderManualModel(BlenderManualModel _blenderManualModel)
        {
            this.Id = _blenderManualModel.Id;
            this.HyperLink = _blenderManualModel.HyperLink;
            this.ImagePath = _blenderManualModel.ImagePath;
            this.ContentPath = _blenderManualModel.ContentPath;
            this.DateAdded = _blenderManualModel.DateAdded;
        }

        public override string ToString()
        {
            return Id.ToString() + " " + HyperLink + " " + ImagePath + " " + ContentPath + " " + DateAdded.ToString();
        }

    }
}
