using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Projekat_HCI.PathHandler;
using Projekat_HCI.Model;
using Projekat_HCI.ViewModel;
using System.Windows;

namespace Projekat_HCI.Repositories
{
    internal class XMLFiles
    {
        public ObservableCollection<BlenderManualViewModel> serializableObject = AdminViewModel.BMData;

        public void SerializeObject()
        {
            string fileName = Path.Combine(MyPath.MyXMLData(), "BlenderManualXMLData.xml");

            if (serializableObject == null) { return; }
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch(Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
            
        }

        

        public static T DeSerializeObject<T>()
        {
            string fileName = Path.Combine(MyPath.MyXMLData(), "BlenderManualXMLData.xml");
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                // Log exception here
            }

            return objectOut;
        }

        public static void LoadDataFromXML()
        {
            ObservableCollection<BlenderManualViewModel> list = DeSerializeObject<ObservableCollection<BlenderManualViewModel>>();
           if(list != null)
            {
                AdminViewModel.BMData.Clear();
                foreach (BlenderManualViewModel item in list)
                {
                    AdminViewModel.BMData.Add(item);
                }
            }
            else
            {
                return;
            }

        }

    }
}
