using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    public class ListOfBusStation
    {
        //Characteristic of a list of bus stops
        public List<BusStation> total
        {
            get; set;
        }

        //constructor
        public ListOfBusStation()
        {
            total = new List<BusStation>();
        }

        // A function that adds a bus stop
        public void addBusStation()
        {
            string data = " ";
            Console.WriteLine("did you want to enter station address? [yes/no]"); //Option to enter an address
            data = Console.ReadLine();
            if (data == "yes")
            {
                Console.WriteLine("enter station address");
                data = Console.ReadLine();
            }
            BusStation station = new BusStation(data); //Create a station
            total.Add(station); //Add the station to the list
        }

        public void remove(BusStation stationToDelete)
        {
            foreach (BusStation item in total) //Go over the list
                if (item.BusStationKey == stationToDelete.BusStationKey) //If we arrived at the requested station
                    total.Remove(item);
        }

        // A function that receives a station code and returns true or false if the station is present
        public bool search(int code)
        {
            foreach(BusStation bus in total)
                if(bus.BusStationKey==code)
                    return true;
            return false;
        }

        //A function that receives a station code and returns the station
        public BusStation GetStation(int code)
        {
            foreach (BusStation bus in total)
                if (bus.BusStationKey == code)
                    return bus;
            return null;
        }
    }
}
