using System;
using BLAPI;

namespace testConsole
{
    class Program
    {
        static IBL mybl;
        static void Main(string[] args)
        {
            mybl = BLFactory.GetBL();
            BO.BusStation busStation = mybl.getBusStation(38839);
            Console.WriteLine(mybl.getLineInBusStations(busStation));
           
            //BO.BusStation station = mybl.getBusStation(38831);
            //BO.BusStation station1 = mybl.getBusStation(38832);
            //mybl.insertFollowStations(station1, station);
            //try
            //{
            //    foreach (BO.LineStation item in bus.listStaion)
            //        Console.WriteLine(item);
            //    Console.WriteLine("\n***after addition***\n");
            //    mybl.addStationToLine(bus, station, 4);
            //    foreach (BO.LineStation item in bus.listStaion)
            //        Console.WriteLine(item.ToString());
            //}
            //catch (BO.BadIDExceptions ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
