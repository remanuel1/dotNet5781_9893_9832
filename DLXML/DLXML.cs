using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    sealed class DLXML : IDL
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files
        string busPath = @"BusXML.xml"; //XElement
        string followStationsPath = @"FollowStationsXML.xml"; //XElement

        string busStationPath = @"BusStationXML.xml"; //XMLSerializer
        string lineBusPath = @"LineBusXML.xml"; //XMLSerializer
        string lineStationPath = @"LineStationXML.xml"; //XMLSerializer
        string exitLinePath = @"ExitLineXML.xml"; //XMLSerializer
        string userPath = @"UserXML.xml"; //XMLSerializer
        #endregion

        #region Bus
        public void addBus(DO.Bus bus)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            XElement bus1 = (from item in busRootElem.Elements()
                             where item.Element("numberLicense").Value == bus.numberLicense
                             select item).FirstOrDefault();
            if (bus1 != null)
                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Duplicate bus");
            XElement busElem = new XElement("Bus",
                                   new XElement("numberLicense", bus.numberLicense),
                                   new XElement("startActivity", bus.startActivity),
                                   new XElement("sumKM", bus.sumKM),
                                   new XElement("totalFuel", bus.totalFuel),
                                   new XElement("Status", bus.Status.ToString()),
                                   new XElement("sumKMFromLastTreat", bus.sumKMFromLastTreat),
                                   new XElement("lastTreat", bus.lastTreat),
                                   new XElement("deleted", "False"));
            busRootElem.Add(busElem);
            XMLTools.SaveListToXMLElement(busRootElem, busPath);
        }
        public void updateBus(DO.Bus bus)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            XElement bus1 = (from item in busRootElem.Elements()
                             where item.Element("numberLicense").Value == bus.numberLicense && item.Element("deleted").Value == "False"
                             select item).FirstOrDefault();

            if (bus1 != null)
            {
                bus1.Element("numberLicense").Value = bus.numberLicense;
                bus1.Element("startActivity").Value = bus.startActivity.ToString();
                bus1.Element("sumKM").Value = bus.sumKM.ToString();
                bus1.Element("totalFuel").Value = bus.totalFuel.ToString();
                bus1.Element("Status").Value = bus.Status.ToString();
                bus1.Element("sumKMFromLastTreat").Value = bus.sumKMFromLastTreat.ToString();
                bus1.Element("lastTreat").Value = bus.lastTreat.ToString();
                bus1.Element("deleted").Value = bus.deleted.ToString();
                XMLTools.SaveListToXMLElement(busRootElem, busPath);
            }
            else
                throw new DO.BadIdException(int.Parse(bus.numberLicense), $"bad numberLicense: {bus.numberLicense}");
        }
        public void deleteBus(DO.Bus bus)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);
            XElement bus1 = (from item in busRootElem.Elements()
                             where item.Element("numberLicense").Value == bus.numberLicense
                             select item).FirstOrDefault();
            if (bus1 != null)
            {
                bus1.Element("deleted").Value = true.ToString();
                XMLTools.SaveListToXMLElement(busRootElem, busPath);
            }
            else
                throw new DO.BadIdException(int.Parse(bus.numberLicense), $"bad number license: {bus.numberLicense}");
        }
        public DO.Bus getBus(string numberLicense)
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);
            Bus bus = (from item in busRootElem.Elements()
                       where item.Element("numberLicense").Value == numberLicense && item.Element("deleted").Value == false.ToString()
                       select new Bus()
                       {
                           numberLicense = item.Element("numberLicense").Value,
                           startActivity = DateTime.Parse(item.Element("startActivity").Value),
                           sumKM = float.Parse(item.Element("sumKM").Value),
                           totalFuel = int.Parse(item.Element("totalFuel").Value),
                           Status = (Status)Enum.Parse(typeof(Status), item.Element("Status").Value),
                           sumKMFromLastTreat = float.Parse(item.Element("sumKMFromLastTreat").Value),
                           lastTreat = DateTime.Parse(item.Element("lastTreat").Value),
                           deleted = bool.Parse(item.Element("deleted").Value)
                       }).FirstOrDefault();

            if (bus == null)
                throw new DO.BadIdException(int.Parse(numberLicense), $"bad number license: {numberLicense}");
            return bus;
        }
        public IEnumerable<DO.Bus> getAllBusses()
        {
            XElement busRootElem = XMLTools.LoadListFromXMLElement(busPath);

            return (from item in busRootElem.Elements()
                    where item.Element("deleted").Value == false.ToString()
                    select new Bus()
                    {
                        numberLicense = item.Element("numberLicense").Value,
                        startActivity = DateTime.Parse(item.Element("startActivity").Value),
                        sumKM = float.Parse(item.Element("sumKM").Value),
                        totalFuel = int.Parse(item.Element("totalFuel").Value),
                        Status = (Status)Enum.Parse(typeof(Status), item.Element("Status").Value),
                        sumKMFromLastTreat = float.Parse(item.Element("sumKMFromLastTreat").Value),
                        lastTreat = DateTime.Parse(item.Element("lastTreat").Value),
                        deleted = bool.Parse(item.Element("deleted").Value)
                    }
                   );
        }
        #endregion

        #region method bus station
        public void addBusStation(DO.BusStation busStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);

            if (ListBusStation.FirstOrDefault(p => p.numberStation == busStation.numberStation) != null)
                throw new DO.BadIdException(busStation.numberStation, "Duplicate Bus Station ");
            busStation.numberStation = ++XMLTools.numberBusStationID;
            ListBusStation.Add(busStation); //no need to Clone()
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);
        }
        public void updateBusStation(DO.BusStation busStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
            DO.BusStation station = ListBusStation.Find(p => p.numberStation == busStation.numberStation && p.deleted == false);
            if (station != null)
            {
                ListBusStation.Remove(station);
                ListBusStation.Add(busStation); //no nee to Clone()
            }
            else
                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);

        }
        public void deleteBusStation(DO.BusStation busStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
            if (ListBusStation.FirstOrDefault(p => p.numberStation == busStation.numberStation && p.deleted == false) == null)
                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
            ListBusStation.Find(p => p.numberStation == busStation.numberStation).deleted = true;
            XMLTools.SaveListToXMLSerializer(ListBusStation, busStationPath);
        }
        public DO.BusStation getBusStation(int numberStation)
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
            DO.BusStation busStation = ListBusStation.Find(p => p.numberStation == numberStation && p.deleted == false);
            if (busStation != null)
                return busStation;
            else
                throw new DO.BadIdException(numberStation, $"Number Station {numberStation} not exist.");
        }
        public IEnumerable<DO.BusStation> getAllBusStation()
        {
            List<BusStation> ListBusStation = XMLTools.LoadListFromXMLSerializer<BusStation>(busStationPath);
            return from busStation in ListBusStation
                   where busStation.deleted == false
                   select busStation;
        }

        public IEnumerable<DO.LineBus> getLineBusInStation(int numberStation)
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);

            return from lineBus in ListLineBus
                   let lineStation = getLineStation(numberStation, lineBus.identifyBus)
                   where lineBus.deleted == false && lineStation != null
                   select getLineBus(lineStation.identifyLine);
        }
        #endregion

        #region method follow Stations 
        public void addFollowStations(DO.FollowStations Stations)
        {
            XElement followStationRootElem = XMLTools.LoadListFromXMLElement(followStationsPath);

            XElement followStation1 = (from item in followStationRootElem.Elements()
                             where item.Element("numberStation1").Value == Stations.numberStation1.ToString()  && item.Element("numberStation2").Value == Stations.numberStation2.ToString()
                             select item).FirstOrDefault();
            if (followStation1 != null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2,  "exsits follow stations");
            XElement followStationElem = new XElement("followStation",
                                   new XElement("numberStation1", Stations.numberStation1),
                                   new XElement("numberStation2", Stations.numberStation2),
                                   new XElement("deleted", Stations.deleted),
                                   new XElement("distance", Stations.distance),
                                   new XElement("drivinngTime", Stations.drivinngTime.ToString()));
            followStationRootElem.Add(followStationElem);
            XMLTools.SaveListToXMLElement(followStationRootElem, followStationsPath);

        }

        public DO.FollowStations getFollowStations(int numberStation1, int numberStation2)
        {
            XElement followStationRootElem = XMLTools.LoadListFromXMLElement(followStationsPath);

            FollowStations followStation = (from item in followStationRootElem.Elements()
                                            where item.Element("numberStation1").Value == numberStation1.ToString() && item.Element("numberStation2").Value == numberStation2.ToString() ||
                                            item.Element("numberStation1").Value == numberStation2.ToString() && item.Element("numberStation2").Value == numberStation1.ToString()
                                            select new FollowStations()
                                            {
                                                numberStation1 = int.Parse(item.Element("numberStation1").Value),
                                                numberStation2 = int.Parse(item.Element("numberStation2").Value),
                                                deleted = bool.Parse(item.Element("deleted").Value),
                                                distance = double.Parse(item.Element("distance").Value),
                                                drivinngTime = TimeSpan.Parse(item.Element("drivinngTime").Value),
                                            }).FirstOrDefault();
            if (followStation == null)
                throw new DO.BadTwoIdException(numberStation1, numberStation2, "not exsits follow stations");
            return followStation;

        }
        public IEnumerable<DO.FollowStations> getAllFollowStations()
        {
            XElement followStationRootElem = XMLTools.LoadListFromXMLElement(followStationsPath);
            return from item in followStationRootElem.Elements()
                   select new FollowStations()
                   {
                       numberStation1 = int.Parse(item.Element("numberStation1").Value),
                       numberStation2 = int.Parse(item.Element("numberStation2").Value),
                       deleted = bool.Parse(item.Element("deleted").Value),
                       distance = double.Parse(item.Element("distance").Value),
                       drivinngTime = TimeSpan.Parse(item.Element("drivinngTime").Value),
                   };
        }
        #endregion

        #region metod line bus
        public int addLineBus(DO.LineBus lineBus)
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);
            if (ListLineBus.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus) != null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line exist");
            lineBus.identifyBus = ++XMLTools.numberBusLineID;
            ListLineBus.Add(lineBus);
            XMLTools.SaveListToXMLSerializer(ListLineBus, lineBusPath);
            return lineBus.identifyBus;
        }
        public void updateLineBus(DO.LineBus lineBus)
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);
            DO.LineBus line = ListLineBus.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false);
            if (line != null)
            {
                ListLineBus.Remove(line);
                ListLineBus.Add(lineBus);
            }
            else
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
            XMLTools.SaveListToXMLSerializer(ListLineBus, lineBusPath);
        }

        public void deleteLineBus(DO.LineBus lineBus)
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);

            if (ListLineBus.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");

            ListLineBus.Find(p => p.identifyBus == lineBus.identifyBus).deleted = true;
            XMLTools.SaveListToXMLSerializer(ListLineBus, lineBusPath);
        }
        public DO.LineBus getLineBus(int identifyBus)
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);

            DO.LineBus lineBus = ListLineBus.Find(p => p.identifyBus == identifyBus && p.deleted == false);
            if (lineBus != null)
                return lineBus;
            else
                throw new DO.BadIdException(identifyBus, $"IdentifyBus Line {identifyBus} not exist.");
        }
        public IEnumerable<DO.LineBus> getAllLineBus()
        {
            List<LineBus> ListLineBus = XMLTools.LoadListFromXMLSerializer<LineBus>(lineBusPath);

            double speed = 50;
            List<FollowStations> allFollow = new List<FollowStations>()
            {
                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38838,
                    distance = 600,
                    deleted = false,
                    drivinngTime= TimeSpan.FromMinutes(600/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.5246485,
                    drivinngTime= TimeSpan.FromMinutes(0.5246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38840,
                    distance = 0.002805851,
                    drivinngTime= TimeSpan.FromMinutes(0.002805851/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38841,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38842,
                    distance = 0.00244128,
                    drivinngTime= TimeSpan.FromMinutes(0.00244128/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38844,
                    distance = 0.010054293,
                    drivinngTime= TimeSpan.FromMinutes(0.010054293/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38845,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38846,
                    distance = 0.002443647,
                    drivinngTime= TimeSpan.FromMinutes(0.002443647/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38855,
                    distance = 0.009417107,
                    drivinngTime= TimeSpan.FromMinutes(0.009417107/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38856,
                    distance = 0.023780807,
                    drivinngTime= TimeSpan.FromMinutes(0.023780807/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38841,
                    distance = 0.017798742,
                    drivinngTime= TimeSpan.FromMinutes(0.017798742/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38873,
                    distance = 0.022190982,
                    drivinngTime= TimeSpan.FromMinutes(0.022190982/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38875,
                    distance = 0.016084788,
                    drivinngTime= TimeSpan.FromMinutes(0.016084788/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38876,
                    distance = 0.006921277,
                    drivinngTime= TimeSpan.FromMinutes(0.006921277/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38832,
                    distance = 0.028697987,
                    drivinngTime= TimeSpan.FromMinutes(0.028697987/speed),
                },

                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38838,
                    distance = 0.013278373,
                    drivinngTime= TimeSpan.FromMinutes(0.013278373/speed),
                },

                new FollowStations
                {
                    numberStation1= 38859,
                    numberStation2= 38860,
                    distance = 0.038160813,
                    drivinngTime= TimeSpan.FromMinutes(0.038160813/speed),
                },

                new FollowStations
                {
                    numberStation1= 38860,
                    numberStation2= 38861,
                    distance = 0.005391981,
                    drivinngTime= TimeSpan.FromMinutes(0.005391981/speed),
                },

                new FollowStations
                {
                    numberStation1= 38861,
                    numberStation2= 38862,
                    distance = 0.003055605,
                    drivinngTime= TimeSpan.FromMinutes(0.003055605/speed),
                },

                new FollowStations
                {
                    numberStation1= 38862,
                    numberStation2= 38863,
                    distance = 0.002878635,
                    drivinngTime= TimeSpan.FromMinutes(0.002878635/speed),
                },

                new FollowStations
                {
                    numberStation1= 38863,
                    numberStation2= 38864,
                    distance = 0.002243189,
                    drivinngTime= TimeSpan.FromMinutes(0.002243189/speed),
                },

                new FollowStations
                {
                    numberStation1= 38864,
                    numberStation2= 38865,
                    distance = 0.310031995,
                    drivinngTime= TimeSpan.FromMinutes(0.310031995/speed),
                },

                new FollowStations
                {
                    numberStation1= 38865,
                    numberStation2= 38866,
                    distance = 0.019539281,
                    drivinngTime= TimeSpan.FromMinutes(0.019539281/speed),
                },

                new FollowStations
                {
                    numberStation1= 38866,
                    numberStation2= 38867,
                    distance = 0.130845993,
                    drivinngTime= TimeSpan.FromMinutes(0.130845993/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38869,
                    distance = 0.479117916,
                    drivinngTime= TimeSpan.FromMinutes(0.479117916/speed),
                },

                new FollowStations
                {
                    numberStation1= 38869,
                    numberStation2= 38846,
                    distance = 0.494588271,
                    drivinngTime= TimeSpan.FromMinutes(0.494588271/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38845,
                    distance = 0.002443647,
                    drivinngTime= TimeSpan.FromMinutes(0.002443647/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38844,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38842,
                    distance = 0.010054293,
                    drivinngTime= TimeSpan.FromMinutes(0.010054293/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38841,
                    distance = 0.00244128,
                    drivinngTime= TimeSpan.FromMinutes(0.00244128/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38840,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38839,
                    distance = 0.002805851,
                    drivinngTime= TimeSpan.FromMinutes(0.002805851/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38838,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38837,
                    distance = 0.044533026,
                    drivinngTime= TimeSpan.FromMinutes(0.044533026/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38836,
                    distance = 0.120559064,
                    drivinngTime= TimeSpan.FromMinutes(0.120559064/speed),
                },

                new FollowStations
                {
                    numberStation1= 38836,
                    numberStation2= 38880,
                    distance = 0.095691574,
                    drivinngTime= TimeSpan.FromMinutes(0.095691574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38880,
                    numberStation2= 38881,
                    distance = 0.098658406,
                    drivinngTime= TimeSpan.FromMinutes(0.098658406/speed),
                },

                new FollowStations
                {
                    numberStation1= 38881,
                    numberStation2= 38883,
                    distance = 0.010839727,
                    drivinngTime= TimeSpan.FromMinutes(0.010839727/speed),
                },

                new FollowStations
                {
                    numberStation1= 38883,
                    numberStation2= 38884,
                    distance = 0.0048824,
                    drivinngTime= TimeSpan.FromMinutes(0.0048824/speed),
                },

                new FollowStations
                {
                    numberStation1= 38884,
                    numberStation2= 38885,
                    distance = 0.002361177,
                    drivinngTime= TimeSpan.FromMinutes(0.002361177/speed),
                },

                new FollowStations
                {
                    numberStation1= 38885,
                    numberStation2= 38886,
                    distance = 0.002591482,
                    drivinngTime= TimeSpan.FromMinutes(0.002591482/speed),
                },

                new FollowStations
                {
                    numberStation1= 38886,
                    numberStation2= 38887,
                    distance = 0.002278754,
                    drivinngTime= TimeSpan.FromMinutes(0.002278754/speed),
                },

                new FollowStations
                {
                    numberStation1= 38887,
                    numberStation2= 38888,
                    distance = 0.00158888,
                    drivinngTime= TimeSpan.FromMinutes(0.00158888/speed),
                },

                new FollowStations
                {
                    numberStation1= 38888,
                    numberStation2= 38889,
                    distance = 0.012050884,
                    drivinngTime= TimeSpan.FromMinutes(0.012050884/speed),
                },

                new FollowStations
                {
                    numberStation1= 38889,
                    numberStation2= 38890,
                    distance = 0.002504912,
                    drivinngTime= TimeSpan.FromMinutes(0.002504912/speed),
                },

                new FollowStations
                {
                    numberStation1= 38884,
                    numberStation2= 38885,
                    distance = 0.002361177,
                    drivinngTime= TimeSpan.FromMinutes(0.002361177/speed),
                },

                new FollowStations
                {
                    numberStation1= 38885,
                    numberStation2= 38883,
                    distance = 0.006830095,
                    drivinngTime= TimeSpan.FromMinutes(0.006830095/speed),
                },

                new FollowStations
                {
                    numberStation1= 38883,
                    numberStation2= 38886,
                    distance = 0.008716686,
                    drivinngTime= TimeSpan.FromMinutes(0.008716686/speed),
                },

                new FollowStations
                {
                    numberStation1= 38886,
                    numberStation2= 38887,
                    distance = 0.002278754,
                    drivinngTime= TimeSpan.FromMinutes(0.002278754/speed),
                },

                new FollowStations
                {
                    numberStation1= 38887,
                    numberStation2= 38888,
                    distance = 0.00158888,
                    drivinngTime= TimeSpan.FromMinutes(0.00158888/speed),
                },

                new FollowStations
                {
                    numberStation1= 38888,
                    numberStation2= 38881,
                    distance = 0.004349328,
                    drivinngTime= TimeSpan.FromMinutes(0.004349328/speed),
                },

                new FollowStations
                {
                    numberStation1= 38881,
                    numberStation2= 38890,
                    distance = 0.008586347,
                    drivinngTime= TimeSpan.FromMinutes(0.008586347/speed),
                },

                new FollowStations
                {
                    numberStation1= 38890,
                    numberStation2= 38889,
                    distance = 0.002504912,
                    drivinngTime= TimeSpan.FromMinutes(0.002504912/speed),
                },

                new FollowStations
                {
                    numberStation1= 38889,
                    numberStation2= 38855,
                    distance = 0.058294652,
                    drivinngTime= TimeSpan.FromMinutes(0.058294652/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38844,
                    distance = 0.005167764,
                    drivinngTime= TimeSpan.FromMinutes(0.005167764/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38845,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38840,
                    distance = 0.006656221,
                    drivinngTime= TimeSpan.FromMinutes(0.006656221/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38841,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38846,
                    distance = 0.008145975,
                    drivinngTime= TimeSpan.FromMinutes(0.008145975/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38842,
                    distance = 0.008145975,
                    drivinngTime= TimeSpan.FromMinutes(0.008145975/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38879,
                    distance = 0.04110075,
                    drivinngTime= TimeSpan.FromMinutes(0.04110075/speed),
                },

                new FollowStations
                {
                    numberStation1= 38879,
                    numberStation2= 38880,
                    distance = 0.005284236,
                    drivinngTime= TimeSpan.FromMinutes(0.005284236/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38873,
                    distance = 0.011705368,
                    drivinngTime= TimeSpan.FromMinutes(0.011705368/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38834,
                    distance = 0.016780379,
                    drivinngTime= TimeSpan.FromMinutes(0.016780379/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38875,
                    distance = 0.021185537,
                    drivinngTime= TimeSpan.FromMinutes(0.021185537/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38872,
                    distance = 0.041672295,
                    drivinngTime= TimeSpan.FromMinutes(0.041672295/speed),
                },

                new FollowStations
                {
                    numberStation1= 38872,
                    numberStation2= 38876,
                    distance = 0.048392316,
                    drivinngTime= TimeSpan.FromMinutes(0.048392316/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38852,
                    distance = 0.02213966,
                    drivinngTime= TimeSpan.FromMinutes(0.02213966/speed),
                },

                new FollowStations
                {
                    numberStation1= 38852,
                    numberStation2= 38854,
                    distance = 0.057002492,
                    drivinngTime= TimeSpan.FromMinutes(0.057002492/speed),
                },

                new FollowStations
                {
                    numberStation1= 38854,
                    numberStation2= 38847,
                    distance = 0.073758262,
                    drivinngTime= TimeSpan.FromMinutes(0.073758262/speed),
                },

                new FollowStations
                {
                    numberStation1= 38847,
                    numberStation2= 38833,
                    distance = 0.020235053,
                    drivinngTime= TimeSpan.FromMinutes(0.020235053/speed),
                },

                new FollowStations
                {
                    numberStation1= 38833,
                    numberStation2= 38865,
                    distance = 0.114946041,
                    drivinngTime= TimeSpan.FromMinutes(0.114946041/speed),
                },

                new FollowStations
                {
                    numberStation1= 38865,
                    numberStation2= 38866,
                    distance = 0.019539281,
                    drivinngTime= TimeSpan.FromMinutes(0.019539281/speed),
                },

                new FollowStations
                {
                    numberStation1= 38866,
                    numberStation2= 38877,
                    distance = 0.08174347,
                    drivinngTime= TimeSpan.FromMinutes(0.08174347/speed),
                },

                new FollowStations
                {
                    numberStation1= 38877,
                    numberStation2= 38831,
                    distance = 0.108157927,
                    drivinngTime= TimeSpan.FromMinutes(0.108157927/speed),
                },

                new FollowStations
                {
                    numberStation1= 38864,
                    numberStation2= 38878,
                    distance = 0.059967716,
                    drivinngTime= TimeSpan.FromMinutes(0.059967716/speed),
                },

                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38856,
                    distance = 0.008603002,
                    drivinngTime= TimeSpan.FromMinutes(0.008603002/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38873,
                    distance = 0.011705368,
                    drivinngTime= TimeSpan.FromMinutes(0.011705368/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38834,
                    distance = 0.016780379,
                    drivinngTime= TimeSpan.FromMinutes(0.016780379/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38875,
                    distance = 0.021185537,
                    drivinngTime= TimeSpan.FromMinutes(0.021185537/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38872,
                    distance = 0.041672295,
                    drivinngTime= TimeSpan.FromMinutes(0.041672295/speed),
                },

                new FollowStations
                {
                    numberStation1= 38872,
                    numberStation2= 38876,
                    distance = 0.048392316,
                    drivinngTime= TimeSpan.FromMinutes(0.048392316/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38852,
                    distance = 0.02213966,
                    drivinngTime= TimeSpan.FromMinutes(0.02213966/speed),
                },

                new FollowStations
                {
                    numberStation1= 38831,
                    numberStation2= 38864,
                    distance = 0.11614573,
                    drivinngTime= TimeSpan.FromMinutes(0.11614573/speed),
                }
            };
            XElement root = new XElement(followStationsPath);

            root.Add(XMLTools.ToXML(allFollow[0]));
            for (int i = 1; i < allFollow.Count(); i++)
            {
                root.Add(XMLTools.ToXML(allFollow[i]));
            }
            XMLTools.SaveListToXMLElement(root, followStationsPath);
            XMLTools.LoadListFromXMLElement(followStationsPath);

            return from line in ListLineBus
                   where line.deleted == false
                   orderby line.numberLine
                   select line;

            

        }
        #endregion

        #region method line start driving
        /* // כרגע לא ממומש - יציאת קו
        bool addLineStartDriving(LineStartDriving lineBus);
        bool updateLineStartDriving(LineStartDriving lineBus);
        void deleteLineStartDriving(LineStartDriving lineBus);
        LineStartDriving readLineStartDriving(int identifyBus);
        IEnumerable<LineStartDriving> getLineStartDriving();
        */
        #endregion

        #region method Line station
        public void addLineStation(DO.LineStation lineStation)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            if (ListLineStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.numberStation == lineStation.numberStation) != null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line station exist");

            ListLineStation.Add(lineStation);
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }
        public void updateLineStation(DO.LineStation lineStationCurrent, DO.LineStation lineStationNew)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            if (ListLineStation.FirstOrDefault(p => p.identifyLine == lineStationCurrent.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStationCurrent.identifyLine, "these line not exist");
            ListLineStation.Remove(lineStationCurrent);
            ListLineStation.Add(lineStationNew);
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }
        public void deleteLineStation(DO.LineStation lineStation)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            if (ListLineStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line not exist");
            ListLineStation.Find(p => p.identifyLine == lineStation.identifyLine).deleted = true;
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);

        }
        public DO.LineStation getLineStation(int numberStation, int identifyLine)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            DO.LineStation lineStation = ListLineStation.Find(p => p.numberStation == numberStation && p.identifyLine == identifyLine && p.deleted == false);
            if (lineStation != null)
                return lineStation;
            else
                throw new DO.BadIdException(numberStation, $"IdentifyBus Line {numberStation} not exist.");
        }

        public DO.LineStation getLineStationIndex(int identifyLine, int numberInLine)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            DO.LineStation lineStation = ListLineStation.Find(p => p.identifyLine == identifyLine && p.numberStationInLine == numberInLine && p.deleted == false);
            if (lineStation != null)
                return lineStation;
            else
                throw new DO.BadIdException(identifyLine, $"IdentifyBus Line {identifyLine} not exist.");
        }
        public IEnumerable<DO.LineStation> getAllLineStation()
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            return from lineStation in ListLineStation
                   where lineStation.deleted == false
                   select lineStation;
        }

        public IEnumerable<DO.LineStation> getLineStationInLine(int identifyLine)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            return from lineStation in ListLineStation
                   where lineStation.identifyLine == identifyLine && lineStation.deleted == false
                   orderby lineStation.numberStationInLine
                   select lineStation;

        }
        public IEnumerable<DO.LineStation> getLineStationInStation(int numberStation)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            return from lineStation in ListLineStation
                   where lineStation.numberStation == numberStation && lineStation.deleted == false && getLineBus(lineStation.identifyLine).deleted == false
                   select lineStation;

        }
        public IEnumerable<DO.LineStation> getAllLineStationBy(Predicate<DO.LineStation> predicate)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);

            return from lineStation in ListLineStation
                   where predicate(lineStation) && lineStation.deleted == false && getLineBus(lineStation.identifyLine).deleted == false
                   select lineStation;

        }

        #endregion

        #region exit line
        public void deleteExitLine(DO.ExitLine exitLine)
        {

        }
        public DO.ExitLine getExitLineBy(Predicate<DO.ExitLine> predicate)
        {
            return null;

        }
        public IEnumerable<DO.ExitLine> getAllExitLine()
        {
            return null;
            /*List<ExitLine> ListExitLine = XMLTools.LoadListFromXMLSerializer<ExitLine>(exitLinePath);

            return from item in ListExitLine
                   orderby item.identifyBus, item.startTime
                   select item;*/
        }
        public IEnumerable<DO.ExitLine> getAllExitLineBy(int identifyBus)
        {
            XElement exitLineRootElem = XMLTools.LoadListFromXMLElement(exitLinePath);
            return from item in exitLineRootElem.Elements()
                   where item.Element("identifyBus").Value == identifyBus.ToString()
                   orderby item.Element("identifyBus").Value, item.Element("startTime").Value
                   select new ExitLine()
                   {
                       identifyBus = int.Parse(item.Element("identifyBus").Value),
                       startTime = TimeSpan.Parse(item.Element("startTime").Value),
                       endTime = TimeSpan.Parse(item.Element("endTime").Value),
                       frequency = int.Parse(item.Element("frequency").Value)
                   };
        }

        #endregion

        #region user
        public void addUser(User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if (ListUser.FirstOrDefault(p => p.userName == user.userName) != null)
                throw new DO.BadUserException(user.name);
            ListUser.Add(user);
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }
        public void deleteUser(User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if (ListUser.FirstOrDefault(p => p.userName == user.userName) == null)
                throw new DO.BadUserException(user.name);
            ListUser.Remove(user);
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }
        public void updateUser(User userCurrent, User userNew)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if (ListUser.FirstOrDefault(p => p.userName == userCurrent.userName) == null)
                throw new DO.BadUserException(userCurrent.name);
            ListUser.Remove(userCurrent);
            ListUser.Add(userNew);
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }
        public User getUser(string userName)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            DO.User user = ListUser.Find(p => p.userName == userName);
            if (user != null)
                return user;
            else
                throw new DO.BadUserException(userName);
        }

        public User getUserByMail(string userMail)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);

            DO.User user = ListUser.Find(p => p.mail == userMail);
            if (user != null)
                return user;
            else
                throw new DO.BadUserException(userMail);
        }

        public IEnumerable<User> getAllUserBy(Predicate<User> predicate)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            return from item in ListUser
                   where predicate(item)
                   orderby item.name
                   select item;
        }
        #endregion

    }
}
