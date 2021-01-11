//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using DLAPI;
//using DO;

//namespace DL
//{
//    sealed class DLXML : IDL
//    {
//        #region singelton
//        static readonly DLXML instance = new DLXML();
//        static DLXML() { }// static ctor to ensure instance init is done just before first usage
//        DLXML() { } // default => private
//        public static DLXML Instance { get => instance; }// The public Instance property to use
//        #endregion

//        #region DS XML Files
//        string busPath = @"BusXML.xml"; //XElement
//        string busStationPath = @"BusStationXML.xml"; //XMLSerializer
//        string followStationsPath = @"FollowStationsXML.xml"; //XMLSerializer
//        string lineBusPath = @"LineBusXML.xml"; //XMLSerializer
//        string lineStationPath = @"LineStationXML.xml"; //XMLSerializer
//        #endregion

//        #region Bus
//        public void addBus(DO.Bus bus)
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

//            XElement bus1 = (from item in busRootElem.Elements()
//                             where item.Element("numberLicense").Value == bus.numberLicense
//                             select item).FirstOrDefault();
//            if (bus1 != null)
//                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Duplicate bus");
//            XElement busElem = new XElement("Bus",
//                                   new XElement("numberLicense", bus.numberLicense),
//                                   new XElement("startActivity", bus.startActivity),
//                                   new XElement("sumKM", bus.sumKM),
//                                   new XElement("totalFuel", bus.totalFuel),
//                                   new XElement("Status", bus.Status.ToString()),
//                                   new XElement("sumKMFromLastTreat", bus.sumKMFromLastTreat),
//                                   new XElement("lastTreat", bus.lastTreat),
//                                   new XElement("deleted", bus.deleted));
//            busRootElem.Add(busElem);
//            XMLTools.SaveListToXMLElement(busRootElem, busPath);
//        }
//        public void updateBus(DO.Bus bus)
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

//            XElement bus1 = (from item in busRootElem.Elements()
//                             where item.Element("numberLicense").Value == bus.numberLicense
//                             select item).FirstOrDefault();

//            if (bus1 != null)
//            {
//                bus1.Element("numberLicense").Value = bus.numberLicense;
//                bus1.Element("startActivity").Value = bus.startActivity.ToString();
//                bus1.Element("sumKM").Value = bus.sumKM.ToString();
//                bus1.Element("totalFuel").Value = bus.totalFuel.ToString();
//                bus1.Element("Status").Value = bus.Status.ToString();
//                bus1.Element("sumKMFromLastTreat").Value = bus.sumKMFromLastTreat.ToString();
//                bus1.Element("lastTreat").Value = bus.lastTreat.ToString();
//                bus1.Element("deleted").Value = bus.deleted.ToString();
//                XMLTools.SaveListToXMLElement(busRootElem, busPath);
//            }
//            else
//                throw new DO.BadIdException(int.Parse(bus.numberLicense), $"bad numberLicense: {bus.numberLicense}");
//        }
//        public void deleteBus(DO.Bus bus)
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);
//            XElement bus1 = (from item in busRootElem.Elements()
//                             where item.Element("numberLicense").Value == bus.numberLicense
//                             select item).FirstOrDefault();
//            if (bus1 != null)
//            {
//                bus1.Element("deleted").Value = true.ToString();
//                XMLTools.SaveListToXMLElement(busRootElem, busPath);
//            }
//            else
//                throw new DO.BadIdException(int.Parse(bus.numberLicense), $"bad number license: {bus.numberLicense}");
//        }
//        public DO.Bus getBus(string numberLicense)
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);
//            Bus bus = (from item in busRootElem.Elements()
//                       where item.Element("numberLicense").Value == numberLicense
//                       select new Bus()
//                       {
//                           numberLicense = item.Element("numberLicense").Value,
//                           startActivity = DateTime.Parse(item.Element("startActivity").Value),
//                           sumKM = float.Parse(item.Element("sumKM").Value),
//                           totalFuel = int.Parse(item.Element("totalFuel").Value),
//                           Status = (Status)Enum.Parse(typeof(Status), item.Element("Status").Value),
//                           sumKMFromLastTreat = float.Parse(item.Element("sumKMFromLastTreat").Value),
//                           lastTreat = DateTime.Parse(item.Element("lastTreat").Value),
//                           deleted = bool.Parse(item.Element("deleted").Value)
//                       }).FirstOrDefault();

//            if (bus == null)
//                throw new DO.BadIdException(int.Parse(numberLicense), $"bad number license: {numberLicense}");
//            return bus;
//        }
//        public IEnumerable<DO.Bus> getAllBusses()
//        {
//            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

//            return (from item in busRootElem.Elements()
//                    select new Bus()
//                    {
//                        numberLicense = item.Element("numberLicense").Value,
//                        startActivity = DateTime.Parse(item.Element("startActivity").Value),
//                        sumKM = float.Parse(item.Element("sumKM").Value),
//                        totalFuel = int.Parse(item.Element("totalFuel").Value),
//                        Status = (Status)Enum.Parse(typeof(Status), item.Element("Status").Value),
//                        sumKMFromLastTreat = float.Parse(item.Element("sumKMFromLastTreat").Value),
//                        lastTreat = DateTime.Parse(item.Element("lastTreat").Value),
//                        deleted = bool.Parse(item.Element("deleted").Value)
//                    }
//                   );
//        }
//        #endregion

//        #region method bus station
//        public void addBusStation(DO.BusStation busStation)
//        {
//            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);

//            if (ListBusStation.FirstOrDefault(p => p.numberStation == busStation.numberStation) != null)
//                throw new DO.BadIdException(busStation.numberStation, "Duplicate Bus Station ");
//            busStation.numberStation = ++XMLTools.numberBusStationID;
//            ListBusStation.Add(busStation); //no need to Clone()
//            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);
//        }
//        public void updateBusStation(DO.BusStation busStation)
//        {
//            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
//            DO.BusStation station = ListBusStation.Find(p => p.numberStation == busStation.numberStation && p.deleted == false);
//            if (station != null)
//            {
//                ListBusStation.Remove(station);
//                ListBusStation.Add(busStation); //no nee to Clone()
//            }
//            else
//                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
//            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);

//        }
//        public void deleteBusStation(DO.BusStation busStation)
//        {
//            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
//            if (ListBusStation.FirstOrDefault(p => p.numberStation == busStation.numberStation && p.deleted == false) == null)
//                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
//            ListBusStation.Find(p => p.numberStation == busStation.numberStation).deleted = true;
//            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);
//        }
//        public DO.BusStation getBusStation(int numberStation)
//        {
//            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
//            DO.BusStation busStation = ListBusStation.Find(p => p.numberStation == numberStation && p.deleted == false);
//            if (busStation != null)
//                return busStation;
//            else
//                throw new DO.BadIdException(numberStation, $"Number Station {numberStation} not exist.");
//        }
//        public IEnumerable<DO.BusStation> getAllBusStation()
//        {
//            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
//            return from busStation in ListBusStation
//                   where busStation.deleted == false
//                   select busStation;
//        }

//        public IEnumerable<DO.LineBus> getLineBusInStation(int numberStation)
//        {
//            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);

//            return from lineBus in ListLineBus
//                   let lineStation = getLineStation(numberStation, lineBus.identifyBus)
//                   where lineBus.deleted == false && lineStation != null
//                   select getLineBus(lineStation.identifyLine);
//        }
//        #endregion

//        #region method follow Stations 
//        public void addFollowStations(DO.FollowStations Stations)
//        {
//            List<FollowStations> ListfollowStation = XMLTools.LoadListFromXMLSerializer<FollowStations>(followStationsPath);

//            if (ListfollowStation.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2) != null)
//                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station exist");
//            ListfollowStation.Add(Stations);
//            XMLTools.SaveListToXMLSerializer(ListfollowStation, followStationsPath);

//        }

//        public DO.FollowStations getFollowStations(int numberStation1, int numberStation2)
//        {
//            List<FollowStations> ListfollowStation = XMLTools.LoadListFromXMLSerializer<FollowStations>(followStationsPath);
//            DO.FollowStations followStations = ListfollowStation.Find(p => p.numberStation1 == numberStation1 && p.numberStation2 == numberStation2 && p.deleted == false);
//            if (followStations == null)
//                followStations = ListfollowStation.Find(p => p.numberStation1 == numberStation2 && p.numberStation2 == numberStation1 && p.deleted == false);
//            if (followStations != null)
//                return followStations;
//            else
//                throw new DO.BadTwoIdException(numberStation1, numberStation2, $"Number Stations {numberStation1}, {numberStation2} not exist.");
//        }
//        public IEnumerable<DO.FollowStations> getAllFollowStations()
//        {
//            List<FollowStations> ListfollowStation = XMLTools.LoadListFromXMLSerializer<FollowStations>(followStationsPath);
//            return from followStation in ListfollowStation
//                   where followStation.deleted == false
//                   select followStation;
//        }
//        #endregion

//        #region metod line bus
//        public int addLineBus(DO.LineBus lineBus)
//        {
//            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);
//            if (ListLineBus.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus) != null)
//                throw new DO.BadIdException(lineBus.identifyBus, "these line exist");
//            lineBus.identifyBus = ++XMLTools.numberBusLineID;
//            ListLineBus.Add(lineBus);
//            XMLTools.SaveListToXMLSerializer(ListLineBus, lineBusPath);
//            return lineBus.identifyBus;
//        }
//        public void updateLineBus(DO.LineBus lineBus)
//        {
//            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);
//            DO.LineBus line = ListLineBus.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false);
//            if (line != null)
//            {
//                ListLineBus.Remove(line);
//                ListLineBus.Add(lineBus);
//            }
//            else
//                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
//            XMLTools.SaveListToXMLSerializer(ListLineBus, lineBusPath);
//        }
//        public void deleteLineBus(DO.LineBus lineBus)
//        {
//            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
//                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
//            DataSource.allLines.Find(p => p.identifyBus == lineBus.identifyBus).deleted = true;
//        }
//        public DO.LineBus getLineBus(int identifyBus)
//        {
//            DO.LineBus lineBus = DataSource.allLines.Find(p => p.identifyBus == identifyBus && p.deleted == false);
//            if (lineBus != null)
//                return lineBus.Clone();
//            else
//                throw new DO.BadIdException(identifyBus, $"IdentifyBus Line {identifyBus} not exist.");
//        }
//        public IEnumerable<DO.LineBus> getAllLineBus()
//        {
//            return (from line in DataSource.allLines
//                    where line.deleted == false
//                    orderby line.numberLine
//                    select line.Clone()).ToList();
//        }
//        #endregion

//        #region method line start driving
//        /* // כרגע לא ממומש - יציאת קו
//        bool addLineStartDriving(LineStartDriving lineBus);
//        bool updateLineStartDriving(LineStartDriving lineBus);
//        void deleteLineStartDriving(LineStartDriving lineBus);
//        LineStartDriving readLineStartDriving(int identifyBus);
//        IEnumerable<LineStartDriving> getLineStartDriving();
//        */
//        #endregion

//        #region method Line station
//        public void addLineStation(DO.LineStation lineStation)
//        {
//            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.numberStation == lineStation.numberStation) != null)
//                throw new DO.BadIdException(lineStation.identifyLine, "these line station exist");
//            DataSource.allLinesStation.Add(lineStation.Clone());
//        }
//        public void updateLineStation(DO.LineStation lineStationCurrent, DO.LineStation lineStationNew)
//        {
//            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStationCurrent.identifyLine && p.deleted == false) == null)
//                throw new DO.BadIdException(lineStationCurrent.identifyLine, "these line not exist");
//            //DataSource.allLinesStation.Remove(old);
//            //DataSource.allLinesStation.Add(lineStation.Clone());
//            int index = DataSource.allLinesStation.FindIndex(p => p.identifyLine == lineStationCurrent.identifyLine && p.numberStation == lineStationCurrent.numberStation);
//            DataSource.allLinesStation[index] = lineStationNew.Clone();
//        }
//        public void deleteLineStation(DO.LineStation lineStation)
//        {
//            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.deleted == false) == null)
//                throw new DO.BadIdException(lineStation.identifyLine, "these line not exist");
//            //DataSource.allLinesStation.Find(p => p.identifyLine == lineStation.identifyLine).deleted = true;
//            int index = DataSource.allLinesStation.FindIndex(p => p.identifyLine == lineStation.identifyLine && p.numberStation == lineStation.numberStation);
//            DataSource.allLinesStation[index].deleted = true;
//        }
//        public DO.LineStation getLineStation(int numberStation, int identifyLine)
//        {
//            DO.LineStation lineStation = DataSource.allLinesStation.Find(p => p.numberStation == numberStation && p.identifyLine == identifyLine && p.deleted == false);
//            if (lineStation != null)
//                return lineStation.Clone();
//            else
//                throw new DO.BadIdException(numberStation, $"IdentifyBus Line {numberStation} not exist.");
//        }

//        public DO.LineStation getLineStationIndex(int identifyLine, int numberInLine)
//        {
//            DO.LineStation lineStation = DataSource.allLinesStation.Find(p => p.identifyLine == identifyLine && p.numberStationInLine == numberInLine && p.deleted == false);
//            if (lineStation != null)
//                return lineStation.Clone();
//            else
//                throw new DO.BadIdException(identifyLine, $"IdentifyBus Line {identifyLine} not exist.");
//        }
//        public IEnumerable<DO.LineStation> getAllLineStation()
//        {
//            return (from lineStation in DataSource.allLinesStation
//                    where lineStation.deleted == false
//                    select lineStation.Clone()).ToList();
//        }

//        public IEnumerable<DO.LineStation> getLineStationInLine(int identifyLine)
//        {
//            return (from lineStation in DataSource.allLinesStation
//                    where lineStation.identifyLine == identifyLine && lineStation.deleted == false
//                    orderby lineStation.numberStationInLine
//                    select lineStation.Clone()).ToList();

//        }
//        public IEnumerable<DO.LineStation> getLineStationInStation(int numberStation)
//        {
//            return (from lineStation in DataSource.allLinesStation
//                    where lineStation.numberStation == numberStation && lineStation.deleted == false && getLineBus(lineStation.identifyLine).deleted == false
//                    select lineStation.Clone()).ToList();

//        }
//        #endregion
//    }
//}
