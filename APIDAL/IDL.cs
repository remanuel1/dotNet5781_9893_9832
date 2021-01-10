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
        void addBus(Bus bus);
        void updateBus(Bus bus);
        void deleteBus(Bus bus);
        Bus getBus(string numberLicense);
        IEnumerable<Bus> getAllBusses();

        //method Bus In Driving
        /*
        void addBusInDriving(BusInDriving bus);
        void updateBusInDriving(BusInDriving bus);
        void deleteBusInDriving(BusInDriving bus);
        BusInDriving getBusInDriving(int identifyBus);
        IEnumerable<BusInDriving> getAllBusInDriving();*/

        //method bus station
        void addBusStation(BusStation busStation);
        void updateBusStation(BusStation busStation);
        void deleteBusStation(BusStation busStation);
        BusStation getBusStation(int numberStation);
        IEnumerable<BusStation> getAllBusStation();

        // method follow Stations 
        void addFollowStations(FollowStations Stations);
        void updateFollowStations(FollowStations Stations);
        void deleteFollowStations(FollowStations Stations);
        FollowStations getFollowStations(int numberStation1, int numberStation2);
        IEnumerable<FollowStations> getAllFollowStations();

        // metod line bus
        int addLineBus(LineBus lineBus);
        void updateLineBus(LineBus lineBus);
        void deleteLineBus(LineBus lineBus);
        LineBus getLineBus(int identifyBus);
        IEnumerable<LineBus> getAllLineBus();
        IEnumerable<LineBus> getLineBusInStation(int numberStation);


        /*// method line start driving
        void addLineStartDriving(LineStartDriving lineBus);
        void updateLineStartDriving(LineStartDriving lineBus);
        void deleteLineStartDriving(LineStartDriving lineBus);
        LineStartDriving readLineStartDriving(int identifyBus);
        IEnumerable<LineStartDriving> getLineStartDriving();*/

        // method Line station
        void addLineStation(LineStation lineStation);
        void updateLineStation(LineStation lineStationCurrent, LineStation lineStationNew);
        void deleteLineStation(LineStation lineStation);
        LineStation getLineStation(int numberStation, int identifyLine);
        LineStation getLineStationIndex(int numberStation, int numberInLine);
        IEnumerable<LineStation> getAllLineStation();
        IEnumerable<LineStation> getLineStationInLine(int identifyLine);
        IEnumerable<LineStation> getLineStationInStation(int numberStation);

    }
}
