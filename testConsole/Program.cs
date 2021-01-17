using System;
using BLAPI;
using DLAPI;
using DO;
using System.Xml.Linq;

namespace testConsole
{
    class Program
    {
        static IBL mybl;
        static IDL mydl;

        static void Main(string[] args)
        {

            mybl = BLFactory.GetBL();
            //mydl = DLFactory.GetDal();
            //mydl.getAllLineBus();
            /*string busPath = @"BusXML.xml"; //XElement
            string busStationPath = @"BusStationXML.xml"; //XMLSerializer
            string followStationsPath = @"FollowStationsXML.xml"; //XMLSerializer
            string lineBusPath = @"LineBusXML.xml"; //XMLSerializer
            string lineStationPath = @"LineStationXML.xml"; //XMLSerializer
            string exitLinePath = @"ExitLineXML.xml"; //XMLSerializer
            //XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);
            //XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);

           TimeSpan time = TimeSpan.Parse("08:00:00");
            mybl.GetLineTimingsForStation(38844, time);*/

        }
    }
}
