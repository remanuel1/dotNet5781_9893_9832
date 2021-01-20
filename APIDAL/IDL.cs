using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    public interface IDL
    {
        //method for Bus
        #region bus
        void addBus(Bus bus);
        void updateBus(Bus bus);
        void deleteBus(Bus bus);
        Bus getBus(string numberLicense);
        IEnumerable<Bus> getAllBusses();
        #endregion

        //method bus station
        #region bus station
        void addBusStation(BusStation busStation);
        void updateBusStation(BusStation busStation);
        void deleteBusStation(BusStation busStation);
        BusStation getBusStation(int numberStation);
        IEnumerable<BusStation> getAllBusStation();
        #endregion

        // method follow Stations 
        #region follow Stations 
        void addFollowStations(FollowStations Stations);
        FollowStations getFollowStations(int numberStation1, int numberStation2);
        IEnumerable<FollowStations> getAllFollowStations();
        #endregion

        // metod line bus
        #region line bus
        int addLineBus(LineBus lineBus);
        void updateLineBus(LineBus lineBus);
        void deleteLineBus(LineBus lineBus);
        LineBus getLineBus(int identifyBus);
        IEnumerable<LineBus> getAllLineBus();
        IEnumerable<LineBus> getLineBusInStation(int numberStation);
        #endregion


        // method Line station
        #region Line station
        void addLineStation(LineStation lineStation);
        void updateLineStation(LineStation lineStationCurrent, LineStation lineStationNew);
        void deleteLineStation(LineStation lineStation);
        LineStation getLineStation(int numberStation, int identifyLine);
        LineStation getLineStationIndex(int numberStation, int numberInLine);
        IEnumerable<LineStation> getAllLineStation();
        IEnumerable<LineStation> getLineStationInLine(int identifyLine);
        IEnumerable<LineStation> getLineStationInStation(int numberStation);
        IEnumerable<LineStation> getAllLineStationBy(Predicate<LineStation> predicate);
        #endregion

        // method exit Line
        #region exit Line
        void deleteExitLine(ExitLine exitLine);
        ExitLine getExitLineBy(Predicate<ExitLine> predicate);
        IEnumerable<ExitLine> getAllExitLine();
        IEnumerable<ExitLine> getAllExitLineBy(int identifyLine);
        #endregion

        // method User
        #region User
        void addUser(User user);
        void deleteUser(User user);
        void updateUser(User userCurrent, User userNew);
        User getUser(string userName);
        User getUserByMail(string userMail);
        IEnumerable<User> getAllUser();
        #endregion


    }
}
