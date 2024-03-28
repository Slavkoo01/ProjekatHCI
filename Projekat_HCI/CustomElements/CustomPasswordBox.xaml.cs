﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace Projekat_HCI.CustomElements
{
    public partial class CustomPasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox));

        public string Password1
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value);               }
        }
        public CustomPasswordBox()
        {
            InitializeComponent();
            PasswordTextBox.PasswordChanged += OnPasswordChanged;
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password1 = PasswordTextBox.Password;
        }
    }
}
