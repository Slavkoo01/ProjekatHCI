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
using System.Collections;
using System.ComponentModel;
using Notification.Wpf;

namespace Projekat_HCI.ViewModel
{
    public class AddViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private bool ImageWarning = true;
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
        private ErrorViewModel _errorViewModel;
        public AddViewModel()
        {
            _errorViewModel = new ErrorViewModel();
            _errorViewModel.ErrorsChanged += ErrorViewModel_ErrorsChanged;
            NewId = "";
            NewHyperLink = "";
        }
        #region ErrorHandling
        private void ErrorViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errorViewModel.HasErrors;

        private bool Validate()
        {
            bool isValid = true;
            //HYPERLINK VALIDACIJA
            if (string.IsNullOrWhiteSpace(NewHyperLink))
            {
                _errorViewModel.ClearError(nameof(NewHyperLink));
                _errorViewModel.AddError(nameof(NewHyperLink), "Hyperlink is required.");
                isValid = false;
            }
            else if (NewHyperLink.Length > 25)
            {
                _errorViewModel.ClearError(nameof(NewHyperLink));
                _errorViewModel.AddError(nameof(NewHyperLink), "Hyperlink cannot be longer than 25 characters.");
                isValid = false;
            }
            else
            {
                _errorViewModel.ClearError(nameof(NewHyperLink));
            }

            //ID VALIDACIJA
            if (string.IsNullOrWhiteSpace(NewId))
            {
                _errorViewModel.ClearError(nameof(NewId));
                _errorViewModel.AddError(nameof(NewId), "ID is required.");
                isValid = false;
            }
            else if (!int.TryParse(NewId, out int idValue) || idValue <= 0)
            {
                _errorViewModel.ClearError(nameof(NewId));
                _errorViewModel.AddError(nameof(NewId), "ID must be a positive integer.");
                isValid = false;
            }
            else if (AdminViewModel.BMData.Any(item => item.Id == NewId))
            {
                _errorViewModel.ClearError(nameof(NewId));
                _errorViewModel.AddError(nameof(NewId), "An object with the same ID already exists.");
                isValid = false;
            }
            else
            {
                _errorViewModel.ClearError(nameof(NewId));
            }
            if (!isValid)
            {
            Toast.ShowToastNotification(new ToastNotification("Error", "Failed to add an item", NotificationType.Error));
            }




            return isValid;
        }

        #endregion

        
        public ViewModelCommands AddCommand => new ViewModelCommands(execute => AddItem());
        public ViewModelCommands BackCommand => new ViewModelCommands(execute => GoBack());
        public ViewModelCommands AddImageCommand => new ViewModelCommands(execute => AddImage());

        private void AddImage()
        {
            paths = MyPath.PathImage();
            ImagePath = paths != null && paths[0] != "" ? paths[0] : "/Images/Default.png";
            ImageWarning = true;
        }
       
        private void AddItem()
        {
            if (!Validate()) 
            {
                return;
            } 
                
            

            if (paths != null)
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

            if (Item.ImagePath == "/Images/Default.png" && ImageWarning)
            {
                Toast.ShowToastNotification(new ToastNotification("Warning", "Your image is set to default. Click Add one more time to confirm", NotificationType.Warning));
                ImageWarning = false;
                return;
            }

            AdminViewModel.BMData.Add(Item);

            RTFFiles.SaveRichTextBoxContent(NewId.ToString(), richTextBox);

            

            GlobalVar.IsSaved = false;
            Toast.ShowToastNotification(new ToastNotification("Success", "An item successfully added", NotificationType.Success));
            GoBack();

        }
        private void GoBack()
        {
            AddView.GoBackAnimation();
        }

       

    }
}
