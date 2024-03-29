using Notification.Wpf;
using Projekat_HCI.Helper;
using Projekat_HCI.PathHandler;
using Projekat_HCI.Repositories;
using Projekat_HCI.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekat_HCI.ViewModel
{
    public class EditViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public EditViewModel(BlenderManualViewModel blenderManualViewModel, int index, RichTextBox richTextBox) {
            _errorViewModel = new ErrorViewModel();
            _errorViewModel.ErrorsChanged += ErrorViewModel_ErrorsChanged;
            NewId = blenderManualViewModel.Id;
            NewHyperLink = blenderManualViewModel.HyperLink;
            ImagePath = blenderManualViewModel.ImagePath;
            _index = index;
            EditRichTextBox = richTextBox;
            RTFFiles.LoadRtfFile(blenderManualViewModel.Id.ToString(), EditRichTextBox);
        }
        private int _index;

        public RichTextBox EditRichTextBox { get; set; }

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
            if (!isValid)
            {
                Toast.ShowToastNotification(new ToastNotification("Error", "Failed to edit an item", NotificationType.Error));
            }



            return isValid;
        }

        #endregion


        public ViewModelCommands EditCommand => new ViewModelCommands(execute => EditItem());
        public ViewModelCommands BackCommand => new ViewModelCommands(execute => GoBack());
        public ViewModelCommands AddImageCommand => new ViewModelCommands(execute => AddImage());

        private void AddImage()
        {
            paths = MyPath.PathImage();
            ImagePath = paths != null && paths[0] != "" ? paths[0] : "/Images/Default.png";
        }

        private void EditItem()
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
                    paths != null ? paths[1] : ImagePath,
                    NewId.ToString(),
                    DateTime.Now
                )
            );
            AdminViewModel.BMData[_index] = Item;

            RTFFiles.SaveRichTextBoxContent(NewId.ToString(), EditRichTextBox);

            GlobalVar.IsSaved = false;

            Toast.ShowToastNotification(new ToastNotification("Success", "Sucessfully edited an item", NotificationType.Success));

            GoBack();

        }
        private void GoBack()
        {
            EditView.GoBackAnimation();
        }
    }
}
