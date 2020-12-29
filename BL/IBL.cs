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
        #endregion

        #region BusStation
        void insertBusStation(BusStation bus);
        void updateBusStation(BusStation bus);
        void deleteBusStation(BusStation bus);
        BusStation getBusStation(int numberStation);
        IEnumerable<BusStation> getAllBusStations();
        #endregion

        #region Driving
        /*void insertDriving(Driving drive);
        void updateDriving(Driving drive);
        void deleteDriving(Driving drive);
        IEnumerable<Driving> getAllDriving();*/

        #endregion

        #region LineBus
        void insertLineBus(LineBus bus);
        void updateLineBus(LineBus bus);
        void deleteLineBus(LineBus bus);
        LineBus getLineBus(int identifyBus);
        IEnumerable<LineBus> getAllLineBus();
        IEnumerable<BusStation> getStationInLineBus(LineBus lineBus);
        void addStationtoLine(LineBus line, BusStation station, int indexInLine);

        #endregion

        #region Follow Stations
        void insertFollowStations(BusStation station1, BusStation station2);
        //void updateFollowStations(FollowStations stations);
        //void deleteFollowStations(FollowStations stations);
        //IEnumerable<FollowStations> getAllFollowStations();
        #endregion

        #region Line Station
        void insertLineStation(LineStation line);
        void updateLineStation(LineStation line);
        void deleteLineStation(LineStation line);
        IEnumerable<LineStation> getAllLineStation();
        #endregion


    }
}
