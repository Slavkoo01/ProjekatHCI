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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Notification.Wpf;
using Projekat_HCI.Helper;
using Projekat_HCI.Repositories;
using Projekat_HCI.ViewModel;

namespace Projekat_HCI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly AnimationManager _animationManager;

        
       

        public MainWindow()
        {
            InitializeComponent();
            
            _animationManager = new AnimationManager(TransitionContainer);
            ChangeContent(new LoginView(new TransitionControl(this)), AnimationManager.SlideAnimationType.SlideLeft);
        }

        public void ChangeContent(UIElement newContent, AnimationManager.SlideAnimationType animationType)
        {
            _animationManager.ChangeContent(newContent, animationType);
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
                if (!GlobalVar.IsSaved && GlobalVar.role == Model.UserRole.Admin)
                {
                    XMLFiles _serializer = new XMLFiles();
                    _serializer.SerializeObject();
                }
            
            Close();
        }

       
    }
}
