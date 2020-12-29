using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion


        # region method Bus
        public void addBus(DO.Bus bus)
        {
            if (DataSource.allBuses.FirstOrDefault(p => p.numberLicense == bus.numberLicense) != null)
                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Duplicate number License");
            DataSource.allBuses.Add(bus.Clone());
        }
        public void updateBus(DO.Bus bus)
        {
            if (DataSource.allBuses.FirstOrDefault(p => p.numberLicense == bus.numberLicense && p.deleted==false) == null)
                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Bus no exist");
            DataSource.allBuses.Remove(bus);
            DataSource.allBuses.Add(bus.Clone());
        }
        public void deleteBus(DO.Bus bus)
        {
            if (DataSource.allBuses.FirstOrDefault(p => p.numberLicense == bus.numberLicense && p.deleted == false) == null)
                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Bus no exist");
            DataSource.allBuses.Find(p => p.numberLicense == bus.numberLicense).deleted = true;
        }
        public DO.Bus getBus(string numberLicense)
        {
            DO.Bus bus = DataSource.allBuses.Find(p => p.numberLicense == numberLicense && p.deleted == false);
            if (bus != null)
                return bus.Clone();
            else
                throw new DO.BadIdException(int.Parse(numberLicense), $"Number License {numberLicense} not exist.");
        }
        public IEnumerable<DO.Bus> getAllBusses()
        {
            return from bus in DataSource.allBuses
                   where bus.deleted==false
                   select bus.Clone();
        }
        #endregion

        #region BUS IN DRIVING - BONUS
        /* אוטובוס בנסיעה, בונוס מורכב כרגע לא עושות
         //method Bus In Driving
         public bool addBusInDriving(DO.BusInDriving bus)
         {

         }
         public bool updateBusInDriving(DO.BusInDriving bus)
         {

         }
         public void deleteBusInDriving(DO.BusInDriving bus)
         {

         }
         public DO.BusInDriving readBusInDriving(int identifyBus)
         {

         }
         public IEnumerable<DO.BusInDriving> getBusInDriving()
         {

         }
        */
        #endregion

        #region method bus station
        public void addBusStation(DO.BusStation busStation)
        {
            if (DataSource.allBusesStations.FirstOrDefault(p => p.numberStation == busStation.numberStation) != null)
                throw new DO.BadIdException(busStation.numberStation, "Duplicate Bus Station ");
            DataSource.allBusesStations.Add(busStation.Clone());
        }
        public void updateBusStation(DO.BusStation busStation)
        {
            if (DataSource.allBusesStations.FirstOrDefault(p => p.numberStation == busStation.numberStation && p.deleted == false) == null)
                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
            DataSource.allBusesStations.Remove(busStation);
            DataSource.allBusesStations.Add(busStation.Clone());
        }
        public void deleteBusStation(DO.BusStation busStation)
        {
            if (DataSource.allBusesStations.FirstOrDefault(p => p.numberStation == busStation.numberStation && p.deleted == false) == null)
                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
            DataSource.allBusesStations.Find(p => p.numberStation == busStation.numberStation).deleted = true;
        }
        public DO.BusStation getBusStation(int numberStation)
        {
            DO.BusStation busStation = DataSource.allBusesStations.Find(p => p.numberStation == numberStation && p.deleted == false);
            if (busStation != null)
                return busStation.Clone();
            else
                throw new DO.BadIdException(numberStation, $"Number Station {numberStation} not exist.");
        }
        public IEnumerable<DO.BusStation> getAllBusStation()
        {
            return from busStation in DataSource.allBusesStations
                   where busStation.deleted == false
                   select busStation.Clone();
        }
        #endregion

        #region method follow Stations 
        public void addFollowStations(DO.FollowStations Stations)
        {
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2) != null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station exist"); 
            DataSource.allFollowStations.Add(Stations.Clone());
        }
        public void updateFollowStations(DO.FollowStations Stations)
        {
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2 && p.deleted == false) == null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station not exist");
            DataSource.allFollowStations.Remove(Stations);
            DataSource.allFollowStations.Add(Stations.Clone());
        }
        public void deleteFollowStations(DO.FollowStations Stations)
        {
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2 && p.deleted == false) == null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station not exist");
            DataSource.allFollowStations.Find(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2).deleted = true;
        }
        public DO.FollowStations getFollowStations(int numberStation1, int numberStation2)
        {
            DO.FollowStations followStations = DataSource.allFollowStations.Find(p => p.numberStation1 == numberStation1 && p.numberStation2 == numberStation2 && p.deleted == false);
            if (followStations != null)
                return followStations.Clone();
            else
                throw new DO.BadTwoIdException(numberStation1, numberStation2, $"Number Stations {numberStation1}, {numberStation2} not exist.");
        }
        public IEnumerable<DO.FollowStations> getAllFollowStations()
        {
            return from followStation in DataSource.allFollowStations
                   where followStation.deleted == false
                   select followStation.Clone();
        }
        #endregion

        #region metod line bus
        public void addLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus) != null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line exist");
            DataSource.allLines.Add(lineBus.Clone());
        }
        public void updateLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
            DataSource.allLines.Remove(lineBus);
            DataSource.allLines.Add(lineBus.Clone());
        }
        public void deleteLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
            DataSource.allLines.Find(p => p.identifyBus == lineBus.identifyBus).deleted = true;
        }
        public DO.LineBus getLineBus(int identifyBus)
        {
            DO.LineBus lineBus = DataSource.allLines.Find(p => p.identifyBus== identifyBus && p.deleted == false);
            if (lineBus != null)
                return lineBus.Clone();
            else
                throw new DO.BadIdException(identifyBus, $"IdentifyBus Line {identifyBus} not exist.");
        }
        public IEnumerable<DO.LineBus> getAllLineBus()
        {
            return from line in DataSource.allLines
                   where line.deleted == false
                   select line.Clone();
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
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine) != null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line station exist");
            DataSource.allLinesStation.Add(lineStation.Clone());
        }
        public void updateLineStation(DO.LineStation lineStation)
        {
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line not exist");
            DataSource.allLinesStation.Remove(lineStation);
            DataSource.allLinesStation.Add(lineStation.Clone());
        }
        public void deleteLineStation(DO.LineStation lineStation)
        {
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line not exist");
            DataSource.allLinesStation.Find(p => p.identifyLine == lineStation.identifyLine).deleted = true;
        }
        public DO.LineStation getLineStation(int identifyLine)
        {
            DO.LineStation lineStation = DataSource.allLinesStation.Find(p => p.identifyLine == identifyLine && p.deleted == false);
            if (lineStation != null)
                return lineStation.Clone();
            else
                throw new DO.BadIdException(identifyLine, $"IdentifyBus Line {identifyLine} not exist.");
        }
        public IEnumerable<DO.LineStation> getAllLineStation()
        {
            return from lineStation in DataSource.allLinesStation
                   where lineStation.deleted == false
                   select lineStation.Clone();
        }
        #endregion
    }
}
