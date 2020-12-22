using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace APIDAL
{
    public interface IDL
    {
        //method for Bus
        bool addBus(Bus bus);
        bool updateBus(Bus bus);
        void deleteBus(Bus bus);
        Bus readBus(int numberLicense);
        IEnumerable<Bus> getBusses();

        //method Bus In Driving
        bool addBusInDriving(BusInDriving bus);
        bool updateBusInDriving(BusInDriving bus);
        void deleteBusInDriving(BusInDriving bus);
        BusInDriving readBusInDriving(int identifyBus);
        IEnumerable<BusInDriving> getBusInDriving();

        //method bus station
        bool addBusStation(BusStation busStation);
        bool updateBusStation(BusStation busStation);
        void deleteBusStation(BusStation busStation);
        BusStation readBusStation(int numberStation);
        IEnumerable<BusStation> getBusStation();

        // method follow Stations 
        bool addConsecutiveStations(FollowStations Stations);
        bool updateFollowStations(FollowStations Stations);
        void deleteFollowStations(FollowStations Stations);
        FollowStations readFollowStations(int numberStation1, int numberStation2);
        IEnumerable<FollowStations> getFollowStations();

        // metod line bus
        bool addLineBus(LineBus lineBus);
        bool updateLineBuss(LineBus lineBus);
        void deleteLineBus(LineBus lineBus);
        LineBus readLineBus(int identifyBus);
        IEnumerable<LineBus> getLineBus();

        // method line start driving
        bool addLineStartDriving(LineStartDriving lineBus);
        bool updateLineStartDriving(LineStartDriving lineBus);
        void deleteLineStartDriving(LineStartDriving lineBus);
        LineStartDriving readLineStartDriving(int identifyBus);
        IEnumerable<LineStartDriving> getLineStartDriving();

        // method Line station
        bool addLineStation(LineStation lineStation);
        bool updateLineStation(LineStation lineStation);
        void deleteLineStation(LineStation lineStation);
        LineStation readLineStation(int identifyBus);
        IEnumerable<LineStation> getLineStation();

    }
}
