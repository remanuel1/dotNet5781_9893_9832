using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_02_9893_9832
{
    class BusStation
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        public static int countKey = 0;
        public int BusStationKey
        {
            get; private set;
        }
        public double Latitude
        {
            get; private set;
        }
        public double Longitude
        {
            get; private set;
        }
        public string address
        {
            get; private set;
        }

        public BusStation(string _address = " ")
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
