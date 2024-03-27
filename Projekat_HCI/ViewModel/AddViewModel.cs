using Microsoft.Win32;
using Projekat_HCI.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Projekat_HCI.PathHandler;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using Projekat_HCI.Repositories;
using Projekat_HCI.Helper;

namespace Projekat_HCI.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public RichTextBox richTextBox {  get; set; }

        private string[] paths = null;

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

        private string _newDate = DateTime.Now.ToString(); 
        public string NewDate
        {
            get { return _newDate; }
            set
            {
                _newDate = value;
                OnPropertyChanged(nameof(NewDate));
            }
        }

        private string _imagePath = "/Images/AddDefault.png";
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        private static List<object> _colorList = typeof(Colors).GetProperties()
            .Where(p => p.PropertyType == typeof(Color))
            .OrderBy(p => p.Name)
            .Select(p => new { ColorName = p.Name, ColorValue = (Color)p.GetValue(null) })
            .Cast<object>()
            .ToList();

        public static List<object> ColorList
        {
            get { return _colorList; }
            set { _colorList = value; }
        }


        public ViewModelCommands AddCommand => new ViewModelCommands(execute => AddItem());
        public ViewModelCommands BackCommand => new ViewModelCommands(execute => GoBack());
        public ViewModelCommands AddImageCommand => new ViewModelCommands(execute => AddImage());

        private void AddImage()
        {
            paths = MyPath.PathImage();
            ImagePath = paths != null && paths[0] != "" ? paths[0] : "/Images/Default.png";          
        }

        private void AddItem()
        {
            if(paths != null)
            {
                MyPath.SaveToImages(paths[0], paths[1]);
            }
            BlenderManualViewModel Item = new BlenderManualViewModel(
                new Model.BlenderManualModel(
                    int.Parse(NewId),
                    NewHyperLink,
                    paths != null ? paths[1] : "/Images/Default.png",
                    NewId.ToString(),
                    DateTime.Now
                )
            );
            AdminViewModel.BMData.Add(Item);

            RTFFiles.SaveRichTextBoxContent(NewHyperLink, richTextBox);

            NewId = "";
            NewHyperLink = "";

            GlobalVar.IsSaved = false;

            GoBack();

        }
        private void GoBack()
        {
            AddView.GoBackAnimation();
        }

       

    }
}
