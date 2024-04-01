using Microsoft.Win32;
using Projekat_HCI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_HCI.PathHandler
{
    public static class MyPath
    {
        public static string MyDirectoryPath()
        {
            return Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName;
        }
        public static string MyImages()
        {
            return Path.Combine(MyDirectoryPath(), "Images");
        } 

        public static void RecalculateImagePath(ObservableCollection<BlenderManualViewModel> BMData)
        {
            string[] temp;
            string newPath;
            string checkPath = MyImages();
               foreach(var bm in BMData)
            {
                temp = bm.ImagePath.Split('\\');
                
                newPath = Path.Combine(checkPath, temp[temp.Length - 1]);
                bm.ImagePath = newPath;
                
            }
        
        
        }
        

        

        public static string MyRTFData()
        {
            return Path.Combine(Path.Combine(MyDirectoryPath(), "Repositories"), "RTFData");
        }
        public static string MyXMLData()
        {
            return Path.Combine(Path.Combine(MyDirectoryPath(), "Repositories"), "XMLData");
        }
        public static string[] PathImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg)|*.png;*.jpg;*.jpeg";

            string DestinationToCopy = "";
            string ImageDestination = "";

            if (openFileDialog.ShowDialog() == true)
            {
                using (Stream fileStream = openFileDialog.OpenFile())
                {
                    string fileName = openFileDialog.SafeFileName;
                    DestinationToCopy = System.IO.Path.Combine(MyPath.MyImages(), fileName);
                    ImageDestination = openFileDialog.FileName;
                }
                return new string[] { ImageDestination, DestinationToCopy };
            }

            return new string[] { ImageDestination, DestinationToCopy };
        }

        public static void SaveToImages(string ImageDestinationOnDesktop,string DestinationToCopy)
        {
            try
           {
                if (!File.Exists(DestinationToCopy))
                {
                    File.Copy(ImageDestinationOnDesktop, DestinationToCopy, true);
                }
            }
           catch (IOException ex)
           {
               MessageBox.Show(ex.ToString());

           }
        }
    }
}
