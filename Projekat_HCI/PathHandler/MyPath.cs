using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
               File.Copy(ImageDestinationOnDesktop, DestinationToCopy, true);
           }
           catch (IOException ex)
           {
               MessageBox.Show(ex.ToString());

           }
        }
    }
}
