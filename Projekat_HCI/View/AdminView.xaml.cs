﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Projekat_HCI.Repositories;
using Projekat_HCI.View;
using Projekat_HCI.ViewModel;

namespace Projekat_HCI.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        private AdminViewModel _adminViewModel;
        
        static TransitionControl _transitionControl;
       
        
        public AdminView(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
            _adminViewModel = new AdminViewModel();
            DataContext = _adminViewModel;
        }

       public static void LogOutAnimation()
        {
            var transControl = new TransitionControl(_transitionControl.ParentWindow);
            var screenOne = new LoginView(transControl);
            _transitionControl.ParentWindow.ChangeContent(screenOne,AnimationManager.SlideAnimationType.SlideDown);
        }

       

        public static void AddAnimation() 
        {
            _transitionControl.ParentWindow.ChangeContent(new AddView(new TransitionControl(_transitionControl.ParentWindow)), AnimationManager.SlideAnimationType.SlideLeft);
        }
        public static void EditAnimation(int index, BlenderManualViewModel blenderManualVieModel)
        {
            _transitionControl.ParentWindow.ChangeContent(new EditView(new TransitionControl(_transitionControl.ParentWindow), blenderManualVieModel, index), AnimationManager.SlideAnimationType.SlideRight);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;

            
                if (textBlock.Inlines.FirstOrDefault() is Hyperlink hyperlink)
                {
                    if (hyperlink.DataContext is BlenderManualViewModel clickedItem)
                    {
                        int index = AdminViewModel.BMData.IndexOf(clickedItem);

                        EditAnimation(index, AdminViewModel.BMData[index]);
                        
                        
                        //AdminDataGrid.Items.Refresh();
                    }
                }

            
        }

    }
}
