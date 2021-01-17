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
            if (DataSource.allBuses.FirstOrDefault(p => p.numberLicense == bus.numberLicense && p.deleted == false) == null)
                throw new DO.BadIdException(int.Parse(bus.numberLicense), "Bus no exist");
            int index = DataSource.allBuses.FindIndex(p => p.numberLicense == bus.numberLicense && p.deleted == false);
            DataSource.allBuses[index] = bus.Clone();
            //DataSource.allBuses.Remove(bus);
            //DataSource.allBuses.Add(bus.Clone());
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
            return (from DO.Bus bus in DataSource.allBuses
                   where bus.deleted == false
                   select bus.Clone()).ToList();
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
            busStation.numberStation = ++DS.Config.numberBusStationID;
            DataSource.allBusesStations.Add(busStation.Clone());
        }
        public void updateBusStation(DO.BusStation busStation)
        {
            if (DataSource.allBusesStations.FirstOrDefault(p => p.numberStation == busStation.numberStation && p.deleted == false) == null)
                throw new DO.BadIdException(busStation.numberStation, "Bus Station not exist");
            int index = DataSource.allBusesStations.FindIndex(p => p.numberStation == busStation.numberStation && p.deleted == false);
            DataSource.allBusesStations[index] = busStation.Clone();
            //DataSource.allBusesStations.Remove(busStation);
            //DataSource.allBusesStations.Add(busStation.Clone());
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
            return (from busStation in DataSource.allBusesStations
                   where busStation.deleted == false
                   select busStation.Clone()).ToList();
        }

        public IEnumerable<DO.LineBus> getLineBusInStation(int numberStation)
        {
            return (from lineBus in DataSource.allLines
                   let lineStation = getLineStation(numberStation, lineBus.identifyBus)
                   where lineBus.deleted == false && lineStation != null
                   select getLineBus(lineStation.identifyLine).Clone()).ToList();
        }
        #endregion

        #region method follow Stations 
        public void addFollowStations(DO.FollowStations Stations)
        {
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2) != null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station exist");
            DataSource.allFollowStations.Add(Stations.Clone());
        }
        /*public void updateFollowStations(DO.FollowStations Stations)
        {
            // not needed (?)
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2 && p.deleted == false) == null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station not exist");
            DataSource.allFollowStations.Remove(Stations);
            DataSource.allFollowStations.Add(Stations.Clone());
        }
        public void deleteFollowStations(DO.FollowStations Stations)
        {
            // not needed (?)
            if (DataSource.allFollowStations.FirstOrDefault(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2 && p.deleted == false) == null)
                throw new DO.BadTwoIdException(Stations.numberStation1, Stations.numberStation2, "these follow station not exist");
            DataSource.allFollowStations.Find(p => p.numberStation1 == Stations.numberStation1 && p.numberStation2 == Stations.numberStation2).deleted = true;
        }*/

        public DO.FollowStations getFollowStations(int numberStation1, int numberStation2)
        {
            DO.FollowStations followStations = DataSource.allFollowStations.Find(p => p.numberStation1 == numberStation1 && p.numberStation2 == numberStation2 && p.deleted == false);
            if (followStations == null)
                followStations = DataSource.allFollowStations.Find(p => p.numberStation1 == numberStation2 && p.numberStation2 == numberStation1 && p.deleted == false);
            if (followStations != null)
                return followStations.Clone();
            else
                throw new DO.BadTwoIdException(numberStation1, numberStation2, $"Number Stations {numberStation1}, {numberStation2} not exist.");
        }
        public IEnumerable<DO.FollowStations> getAllFollowStations()
        {
            return (from followStation in DataSource.allFollowStations
                   where followStation.deleted == false
                   select followStation.Clone()).ToList();
        }
        #endregion

        #region metod line bus
        public int addLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus) != null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line exist");
            lineBus.identifyBus = ++DS.Config.numberBusLineID;
            DataSource.allLines.Add(lineBus.Clone());
            return lineBus.identifyBus;
        }
        public void updateLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
            int index = DataSource.allLines.FindIndex(p => p.identifyBus == lineBus.identifyBus && p.deleted == false);
            DataSource.allLines[index] = lineBus;

        }
        public void deleteLineBus(DO.LineBus lineBus)
        {
            if (DataSource.allLines.FirstOrDefault(p => p.identifyBus == lineBus.identifyBus && p.deleted == false) == null)
                throw new DO.BadIdException(lineBus.identifyBus, "these line not exist");
            DataSource.allLines.Find(p => p.identifyBus == lineBus.identifyBus).deleted = true;
        }
        public DO.LineBus getLineBus(int identifyBus)
        {
            DO.LineBus lineBus = DataSource.allLines.Find(p => p.identifyBus == identifyBus && p.deleted == false);
            if (lineBus != null)
                return lineBus.Clone();
            else
                throw new DO.BadIdException(identifyBus, $"IdentifyBus Line {identifyBus} not exist.");
        }
        public IEnumerable<DO.LineBus> getAllLineBus()
        {
            return (from line in DataSource.allLines
                   where line.deleted == false
                   orderby line.numberLine
                   select line.Clone()).ToList();
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
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.numberStation == lineStation.numberStation) != null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line station exist");
            DataSource.allLinesStation.Add(lineStation.Clone());
        }
        public void updateLineStation(DO.LineStation lineStationCurrent, DO.LineStation lineStationNew)
        {
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStationCurrent.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStationCurrent.identifyLine, "these line not exist");
            //DataSource.allLinesStation.Remove(old);
            //DataSource.allLinesStation.Add(lineStation.Clone());
            int index = DataSource.allLinesStation.FindIndex(p => p.identifyLine == lineStationCurrent.identifyLine && p.numberStation == lineStationCurrent.numberStation);
            DataSource.allLinesStation[index] = lineStationNew.Clone();
        }
        public void deleteLineStation(DO.LineStation lineStation)
        {
            if (DataSource.allLinesStation.FirstOrDefault(p => p.identifyLine == lineStation.identifyLine && p.deleted == false) == null)
                throw new DO.BadIdException(lineStation.identifyLine, "these line not exist");
            //DataSource.allLinesStation.Find(p => p.identifyLine == lineStation.identifyLine).deleted = true;
            int index = DataSource.allLinesStation.FindIndex(p => p.identifyLine == lineStation.identifyLine && p.numberStation == lineStation.numberStation);
            DataSource.allLinesStation[index].deleted = true;
        }
        public DO.LineStation getLineStation(int numberStation, int identifyLine)
        {
            DO.LineStation lineStation = DataSource.allLinesStation.Find(p => p.numberStation == numberStation && p.identifyLine == identifyLine && p.deleted == false);
            if (lineStation != null)
                return lineStation.Clone();
            else
                throw new DO.BadIdException(numberStation, $"IdentifyBus Line {numberStation} not exist.");
        }

        public DO.LineStation getLineStationIndex(int identifyLine, int numberInLine)
        {
            DO.LineStation lineStation = DataSource.allLinesStation.Find(p => p.identifyLine == identifyLine && p.numberStationInLine == numberInLine && p.deleted == false);
            if (lineStation != null)
                return lineStation.Clone();
            else
                throw new DO.BadIdException(identifyLine, $"IdentifyBus Line {identifyLine} not exist.");
        }
        public IEnumerable<DO.LineStation> getAllLineStation()
        {
            return (from lineStation in DataSource.allLinesStation
                   where lineStation.deleted == false
                   select lineStation.Clone()).ToList();
        }

        public IEnumerable<DO.LineStation> getLineStationInLine(int identifyLine)
        {
            return (from lineStation in DataSource.allLinesStation
                    where lineStation.identifyLine == identifyLine && lineStation.deleted == false
                    orderby lineStation.numberStationInLine
                    select lineStation.Clone()).ToList();
            
        }
        public IEnumerable<DO.LineStation> getLineStationInStation(int numberStation)
        {
            return (from lineStation in DataSource.allLinesStation
                   where lineStation.numberStation == numberStation && lineStation.deleted == false && getLineBus(lineStation.identifyLine).deleted == false
                   select lineStation.Clone()).ToList();

        }

        public IEnumerable<DO.LineStation> getAllLineStationBy(Predicate<DO.LineStation> predicate)
        {
            return (from lineStation in DataSource.allLinesStation
                    where predicate(lineStation) && lineStation.deleted == false && getLineBus(lineStation.identifyLine).deleted == false
                    select lineStation.Clone()).ToList();

        }
        #endregion


        #region exit line
        public void deleteExitLine(DO.ExitLine exitLine)
        {

            if (DataSource.allExitLines.FirstOrDefault(p => p.identifyBus == exitLine.identifyBus) == null)
                throw new DO.BadIdException(exitLine.identifyBus, "these exit line not exists");
            int index = DataSource.allExitLines.FindIndex(p => p.identifyBus == exitLine.identifyBus && p.startTime == exitLine.startTime);
            DataSource.allExitLines.RemoveAt(index);
        }
        public DO.ExitLine getExitLineBy(Predicate<DO.ExitLine> predicate)
        {
            return (from item in DataSource.allExitLines
                   where predicate(item)
                   select item.Clone()).FirstOrDefault();
        }
        public IEnumerable<DO.ExitLine> getAllExitLine()
        {
            return (from item in DataSource.allExitLines
                   orderby item.identifyBus, item.startTime
                   select item.Clone()).ToList();
        }
        public IEnumerable<DO.ExitLine> getAllExitLineBy(int identifyBus)
        {
            return (from item in DataSource.allExitLines
                    where item.identifyBus == identifyBus
                    orderby item.identifyBus, item.startTime
                    select item.Clone()).ToList(); ;
        }

        #endregion

        public void addUser(DO.User user)
        {
            if (DataSource.allUsers.FirstOrDefault(p => p.userName == user.userName) != null)
                ;//throw new DO.(user.userName, "these exit line not exists");
            DataSource.allUsers.Add(user.Clone());
        }
        public void deleteUser(DO.User user)
        {
            if (DataSource.allUsers.FirstOrDefault(p => p.userName == user.userName) == null)
                ;// throw new DO.BadIdException(exitLine.identifyBus, "these exit line not exists");
            int index = DataSource.allUsers.FindIndex(p => p.userName == user.userName);
            DataSource.allUsers.RemoveAt(index);
        }
        public void updateUser(DO.User userCurrent, DO.User userNew)
        {
            if (DataSource.allUsers.FirstOrDefault(p => p.userName == userCurrent.userName) == null)
                ;// throw new DO.BadIdException(exitLine.identifyBus, "these exit line not exists");
            if (DataSource.allUsers.FirstOrDefault(p => p.userName == userNew.userName) != null)
                ;// throw new DO.BadIdException(exitLine.identifyBus, "these exit line not exists");
            int index = DataSource.allUsers.FindIndex(p => p.userName == userCurrent.userName);
            DataSource.allUsers[index] = userNew.Clone();
        }
        public DO.User getUser(string userName)
        {
            return (from user in DataSource.allUsers
                    where user.userName == userName
                    select user.Clone()).FirstOrDefault();
        }
        public DO.User getUserByMail(string userMail)
        {
            return null;
        }
        public IEnumerable<DO.User> getAllUserBy(Predicate<DO.User> predicate)
        {
            return (from user in DataSource.allUsers
                    where predicate(user)
                    select user.Clone()).ToList();
        }
    }
}
