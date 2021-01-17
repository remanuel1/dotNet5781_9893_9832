using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DL
{
    public static class XMLTools
    {
        static string dir = @"xml\";
        static XMLTools()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
        #region SaveLoadWithXElement
        public static void SaveListToXMLElement(XElement rootElem, string filePath)
        {
            try
            {
                rootElem.Save(dir + filePath);
            }
            catch (Exception ex)
            {
                throw new DO.XMLFileLoadCreateException(filePath, $"fail to create xml file: {filePath}", ex);
            }
        }

        public static XElement LoadListFromXMLElement(string filePath)
        {
            try
            {
                if (File.Exists(dir + filePath))
                {
                    return XElement.Load(dir + filePath);
                }
                else
                {
                    XElement rootElem = new XElement(dir + filePath);
                    rootElem.Save(dir + filePath);
                    return rootElem;
                }
            }
            catch (Exception ex)
            {
                throw new DO.XMLFileLoadCreateException(filePath, $"fail to load xml file: {filePath}", ex);
            }
        }

        /*public static XElement ToXML(this DO.ExitLine line)
        {
            XElement result = new XElement("ExitLine",
                new XElement("identifyBus", line.identifyBus),
                new XElement("startTime", line.startTime.ToString()),
                new XElement("endTime", line.endTime.ToString()),
                new XElement("frequency", line.frequency));
            return result;
        }*/

        public static XElement ToXML(this DO.FollowStations follow)
        {
            XElement result = new XElement("FollowStations",
                new XElement("numberStation1", follow.numberStation1.ToString()),
                new XElement("numberStation2", follow.numberStation2.ToString()),
                new XElement("deleted", follow.deleted.ToString()),
                new XElement("drivinngTime", follow.drivinngTime.ToString()),
                new XElement("distance", follow.distance.ToString()));
            return result;
        }

        /*public static XElement ToXML(this DO.Bus bus)
        {
            XElement result = new XElement("Bus",
                new XElement("numberLicense", bus.numberLicense.ToString()),
                new XElement("startActivity", bus.startActivity.ToString()),
                new XElement("sumKM", bus.sumKM.ToString()),
                new XElement("totalFuel", bus.totalFuel.ToString()),
                new XElement("Status", bus.Status.ToString()),
                new XElement("sumKMFromLastTreat", bus.sumKMFromLastTreat.ToString()),
                new XElement("lastTreat", bus.lastTreat.ToString()),
                new XElement("deleted", bus.deleted.ToString()));

            return result;
        }*/
        #endregion

        #region SaveLoadWithXMLSerializer
        public static void SaveListToXMLSerializer<T>(List<T> list, string filePath)
        {
            try
            {
                FileStream file = new FileStream(dir + filePath, FileMode.Create);
                XmlSerializer x = new XmlSerializer(list.GetType());
                x.Serialize(file, list);
                file.Close();
            }
            catch (Exception ex)
            {
                throw new DO.XMLFileLoadCreateException(filePath, $"fail to create xml file: {filePath}", ex);
            }
        }
        public static List<T> LoadListFromXMLSerializer<T>(string filePath)
        {
            try
            {
                if (File.Exists(dir + filePath))
                {
                    List<T> list;
                    XmlSerializer x = new XmlSerializer(typeof(List<T>));
                    FileStream file = new FileStream(dir + filePath, FileMode.Open);
                    list = (List<T>)x.Deserialize(file);
                    file.Close();
                    return list;
                }
                else
                    return new List<T>();
            }
            catch (Exception ex)
            {
                throw new DO.XMLFileLoadCreateException(filePath, $"fail to load xml file: {filePath}", ex);
            }
        }
        #endregion

        public static int numberBusLineID { get; set; } = 1010;
        public static int numberBusStationID { get; set; } = 3890;

    }
}
