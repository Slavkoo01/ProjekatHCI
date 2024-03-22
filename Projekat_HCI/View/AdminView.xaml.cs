using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekat_HCI.View;
using Projekat_HCI.ViewModel;

namespace Projekat_HCI.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        private BlenderManualDataViewModel _blenderManualDataViewModel;
        
        TransitionControl _transitionControl;
        public AdminView()
        {
            InitializeComponent();
            _blenderManualDataViewModel = new BlenderManualDataViewModel();
            AdminDataGrid.DataContext = _blenderManualDataViewModel;
            AdminDataGrid.ItemsSource = _blenderManualDataViewModel.BMData;
        }

        public AdminView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            _blenderManualDataViewModel = new BlenderManualDataViewModel(); // Initialize _blenderManualDataViewModel
            AdminDataGrid.DataContext = _blenderManualDataViewModel;
            AdminDataGrid.ItemsSource = _blenderManualDataViewModel.BMData;
        }

        

        public void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new LoginView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne,AnimationManager.SlideAnimationType.SlideDown);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _transitionControl.ParentWindow.ChangeContent(new AddView(new TransitionControl(_transitionControl.ParentWindow)), AnimationManager.SlideAnimationType.SlideLeft);
        }
    }
}
