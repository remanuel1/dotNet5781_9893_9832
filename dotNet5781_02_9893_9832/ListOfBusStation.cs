using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    class ListOfBusStation
    {
        public List<BusStation> total
        {
            get; set;
        }

        public ListOfBusStation()
        {
            total = new List<BusStation>();
        }

        public void addBusStation()
        {
            string data = " ";
            Console.WriteLine("did you want to enter station address? [yes/no]");
            data = Console.ReadLine();
            if (data == "yes")
            {
                Console.WriteLine("enter station address");
                data = Console.ReadLine();
            }
            BusStation station = new BusStation(data);
            total.Add(station);
        }

        public void remove(BusStation stationToDelete)
        {
            foreach (BusStation item in total)
                if (item.BusStationKey == stationToDelete.BusStationKey)
                    total.Remove(item);
        }
    }
}
