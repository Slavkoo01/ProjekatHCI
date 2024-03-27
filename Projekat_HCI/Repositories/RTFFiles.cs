using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using Projekat_HCI.PathHandler;
using System.Xml.Linq;
using Projekat_HCI.ViewModel;

namespace Projekat_HCI.Repositories
{
    static class RTFFiles
    {
        public static void SaveRichTextBoxContent(string Id, RichTextBox richTextBox)
        {
            string filePath = Path.Combine(MyPath.MyRTFData(), Id + ".rtf");

            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                textRange.Save(fileStream, DataFormats.Rtf);
            }

            //MessageBox.Show("Content saved to " + filePath);
        }

        public static void DeleteRTFFile(BlenderManualViewModel item)
        {
            string filePath = Path.Combine(MyPath.MyRTFData(), item.Id + ".rtf");
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                   
                }
            }
            catch (Exception)
            {
              
            }
        }

        public static void LoadRtfFile(string Id, RichTextBox richTextBox)
        {
            string filePath = Path.Combine(MyPath.MyRTFData(), Id + ".rtf");

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

                    try
                    {
                        textRange.Load(fileStream, DataFormats.Rtf);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error loading RTF file: " + ex.Message);
                    }
                }
            }
            else
            {
                //MessageBox.Show("File does not exist: " + filePath);
            }
        }

    }
}
