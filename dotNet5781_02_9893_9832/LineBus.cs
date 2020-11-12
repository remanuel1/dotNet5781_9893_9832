using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Data;

namespace dotNet5781_02_9893_9832
{
    public enum allArea {north, center, south, general};
    class LineBus : IComparable
    {
        static Random r = new Random(DateTime.Now.Millisecond);

        // iner class for station line bus
        public class StationLineBus
        {
            public BusStation busStation
            {
                get; set;
            }
            public double distanceBetweenLastStation
            {
                get; set;
            }
            public TimeSpan timeRideFromLastStation
            {
                get; set;
            }

            // constractor of station line bus
            public StationLineBus(BusStation bus)
            {
                busStation = bus;
                distanceBetweenLastStation = 0;
                timeRideFromLastStation = TimeSpan.Zero;
            }


        }
        //properties:
        public List<StationLineBus> listOfBus
        {
            get; set;
        }
        public int numberBus
        {
            get; set;
        }
        public StationLineBus firstStation
        {
            get; set;
        }
        public StationLineBus lastStation
        {
            get; set;
        }
        public allArea area
        {
            get; set;
        }

        // all func in LineBus
        public LineBus(BusStation sor, BusStation des)
        {
            StationLineBus sor1 = new StationLineBus(sor);
            StationLineBus des1 = new StationLineBus(des);
            var s1 = new GeoCoordinate(sor1.busStation.Latitude, sor1.busStation.Longitude);
            var d1 = new GeoCoordinate(des1.busStation.Latitude, des1.busStation.Longitude);
            des1.distanceBetweenLastStation = d1.GetDistanceTo(s1);
            des1.timeRideFromLastStation = timeBetTowLineBusStation(sor1, des1);
            listOfBus = new List<StationLineBus>();
            listOfBus.Add(sor1);
            firstStation = sor1;
            listOfBus.Add(des1);
            lastStation = des1;
            numberBus = r.Next(1, 999);
            area = (allArea)r.Next(0, 3);

        }
        public override string ToString()
        {
            string help = "Bus Number: " + numberBus + "\n";
            help += " the area is: " + area + "\n";
            help += " all the station: ";
            foreach (StationLineBus item in listOfBus)
                help += item.busStation.BusStationKey + " -> ";
            return help;

        }
        public void addstation(BusStation station)
        {
            StationLineBus add = new StationLineBus(station);
            Console.WriteLine("in this line there are " + listOfBus.Count + "stations, where you want to add this station? [1-" + (listOfBus.Count+1) + "]\n");
            int index = int.Parse(Console.ReadLine());
            if (index < 0 || index-1 > listOfBus.Count)
            {
                throw new NumberStationNotFoundExeption();
            }
            if (!findStation(add))
            {
                listOfBus.Insert(index-1, add);
                if (index == 1)
                {
                    firstStation = listOfBus[0];
                }
                if (index == listOfBus.Count)
                {
                    lastStation = listOfBus[index-1];
                }
                if (index != 1)
                {
                    listOfBus[index - 1].distanceBetweenLastStation = distanceBetTowLineBusStation(listOfBus[index - 1], listOfBus[index - 2]);
                    listOfBus[index - 1].timeRideFromLastStation = timeBetTowLineBusStation(listOfBus[index - 1], listOfBus[index - 2]);
                }
                if (index != listOfBus.Count)
                {
                    listOfBus[index].distanceBetweenLastStation = distanceBetTowLineBusStation(listOfBus[index], listOfBus[index - 1]);
                    listOfBus[index].timeRideFromLastStation = timeBetTowLineBusStation(listOfBus[index], listOfBus[index - 1]);
                }

            }
            else
                Console.WriteLine("the station is exist in this line.\n");
        }
        public void deleteStation(StationLineBus station)
        {
            findStation(station);
            int index = listOfBus.IndexOf(station);
            if(listOfBus.Count>2 && listOfBus.Remove(station))
            {
                if(index==0)
                {
                    listOfBus[index].distanceBetweenLastStation = 0;
                    listOfBus[index].timeRideFromLastStation = TimeSpan.Zero;
                    firstStation = listOfBus[index];
                }
                // remove bus from the end.
                if (index == listOfBus.Count+1)
                {
                    lastStation = listOfBus[index - 1];
                }
                if(index>0 && index< listOfBus.Count + 1)
                {
                    listOfBus[index].distanceBetweenLastStation = distanceBetTowLineBusStation(listOfBus[index - 1], listOfBus[index]);
                    listOfBus[index].timeRideFromLastStation = timeBetTowLineBusStation(listOfBus[index - 1], listOfBus[index]);
                }

            }

        }

        public bool findStation (StationLineBus station)
        {
            foreach (StationLineBus item in listOfBus)
                if (item.busStation.BusStationKey == station.busStation.BusStationKey)
                    return true;
            // the station not exist
            return false;
            //throw new ObjectNotFoundExeption();
        }

        public bool stationInLineBus (int code)
        {
            foreach (StationLineBus item in listOfBus)
                if (item.busStation.BusStationKey == code)
                    return true;
            return false;
        }

        public StationLineBus getStation(int code)
        {
            foreach (StationLineBus item in listOfBus)
                if (item.busStation.BusStationKey == code)
                    return item;
            // the station not exist
            throw new ObjectNotFoundExeption();
        }

        public int getIndexOfStation(int code)
        {
            for (int i = 0; i < listOfBus.Count; i++)
                if (listOfBus[i].busStation.BusStationKey == code)
                    return i;
            return -1;
        }

        public double distanceBetTowLineBusStation(StationLineBus station1, StationLineBus station2)
        {
            var s1 = new GeoCoordinate(station1.busStation.Latitude, station1.busStation.Longitude);
            var d1 = new GeoCoordinate(station2.busStation.Latitude, station2.busStation.Longitude);
            return d1.GetDistanceTo(s1);
        }

        public TimeSpan timeBetTowLineBusStation(StationLineBus station1, StationLineBus station2)
        {
            return TimeSpan.FromMinutes((distanceBetTowLineBusStation(station1, station2)) / 100);
        }

        public LineBus subLineBus (StationLineBus station1, StationLineBus station2)
        {
            LineBus subLine = new LineBus(station1.busStation, station2.busStation);
            subLine.numberBus = numberBus;
            int index1 = listOfBus.IndexOf(station1);
            int index2 = listOfBus.IndexOf(station2);
            if (index1 != -1 && index2 != -1 && index2>index1)
            {
                int help = 1;
                for (int i = index1 + 1; i < index2; i++)
                {
                    subLine.listOfBus.Insert(help, listOfBus[i]);
                    help++;
                }
                return subLine;
            }
            throw new ObjectNotFoundExeption();
        }
        public TimeSpan totalTimeDriving ()
        {
            TimeSpan time = TimeSpan.Zero;
            foreach (StationLineBus item in listOfBus)
                time += item.timeRideFromLastStation;
            return time;
        }

        public int CompareTo(object obj)
        {
            LineBus s = (LineBus)obj;
            return this.totalTimeDriving().CompareTo(s.totalTimeDriving());
        }





    }
}
