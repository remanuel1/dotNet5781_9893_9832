using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLAPI
{
    public interface IBL
    {
        #region Bus

        void insertBus(Bus bus);
        void updateBus(Bus bus);
        void deleteBus(Bus bus);
        Bus getBus(string numberLicense);
        IEnumerable<Bus> getAllBusses();
        void refuel(Bus bus);
        void treat(Bus bus);
        IEnumerable<Bus> getAllBussesBy(IOrderedEnumerable<string> elements);
        #endregion

        #region BusStation
        void insertBusStation(BusStation bus);
        void updateBusStation(BusStation bus);
        void deleteBusStation(BusStation bus);
        BusStation getBusStation(int numberStation);
        IEnumerable<BusStation> getAllBusStations();
        IEnumerable<int> getLineInBusStations(BusStation station);
        #endregion

        #region LineBus
        int insertLineBus(LineBus bus);
        void updateLineBus(LineBus bus);
        void deleteLineBus(LineBus bus);
        LineBus getLineBus(int identifyBus);
        IEnumerable<LineBus> getAllLineBus();
        IEnumerable<BusStation> getStationInLineBus(LineBus lineBus);
        void addStationToLine(LineBus line, BusStation station, int indexInLine);
        void deleteStationInLine(LineBus line, LineStation station);

        #endregion

        #region Follow Stations
        void insertFollowStations(int station1, int station2);
        FollowStations getFollowStations(int station1, int station2);
        //void updateFollowStations(FollowStations stations);
        //void deleteFollowStations(FollowStations stations);
        //IEnumerable<FollowStations> getAllFollowStations();
        #endregion

        #region Line Station
        void insertLineStation(LineStation line);
        void updateLineStation(LineStation lineStationCurrent, LineStation lineStationNew);
        void deleteLineStation(LineStation line);
        LineStation getLineStation(int identifyBus, int numberStation);
        IEnumerable<LineStation> getAllLineStation();
        IEnumerable<LineStation> getLineStationsForLine(int identifyBus);

        #endregion

        #region LineTiming
        IEnumerable<LineTiming> GetLineTimingsForStation(int numberStation, TimeSpan time);

        #endregion

        #region User
        void addUser(User user);
        void deleteUser(User user);
        void updateUser(User userCurrent, User userNew);
        User getUser(string userName);
        User getUserByMail(string userMail);
        IEnumerable<User> getAllUserBy(Predicate<User> predicate);
        #endregion
    }
}
