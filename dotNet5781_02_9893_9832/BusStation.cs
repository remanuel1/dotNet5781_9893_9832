using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_02_9893_9832
{
    //A class that represents a bus station
    public class BusStation
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        public static int countKey = 0;
        public int BusStationKey //Station number
        {
            get; private set;
        }
        public double Latitude //Latitude of the station
        {
            get; private set;
        }
        public double Longitude //Longitude of the station
        {
            get; private set;
        }
        public string address //Address of the station

        {
            get; private set;
        }

        public BusStation(string _address = " ") //constructor
        {
            BusStationKey = countKey;
            countKey++;
            address = _address;
            Latitude = r.NextDouble() * (33.3 - 31) + 31; // in israel territory
            Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3; // in israel territory
        }
        public override string ToString()
        {
            return "Bus Station Code: "+ BusStationKey + ", " + Latitude + ", " + Longitude;

        }

    }

}
