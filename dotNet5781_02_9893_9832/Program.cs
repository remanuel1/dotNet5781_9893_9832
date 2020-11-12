using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    class Program
    {
        static void restart(ref ListOfBusStation station, ref CollectionOfLineBus line)
        {
            station = new ListOfBusStation();
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i);
                station.addBusStation();
            }
                //station.Add(new BusStation());
            List<LineBus> lines = new List<LineBus>();
            lines.Add(new LineBus(station.total[0], station.total[1]));
            lines[0].addstation(station.total[2]);
            lines[0].addstation(station.total[3]);
            lines.Add(new LineBus(station.total[4], station.total[5]));
            lines[1].addstation(station.total[6]);
            lines[1].addstation(station.total[7]);
            lines.Add(new LineBus(station.total[8], station.total[9]));
            lines[2].addstation(station.total[10]);
            lines[2].addstation(station.total[11]);
            lines.Add(new LineBus(station.total[12], station.total[13]));
            lines[3].addstation(station.total[14]);
            lines[3].addstation(station.total[15]);
            lines.Add(new LineBus(station.total[16], station.total[17]));
            lines[4].addstation(station.total[18]);
            lines[4].addstation(station.total[19]);
            lines.Add(new LineBus(station.total[20], station.total[21]));
            lines[5].addstation(station.total[22]);
            lines[5].addstation(station.total[23]);
            lines.Add(new LineBus(station.total[24], station.total[25]));
            lines[6].addstation(station.total[26]);
            lines[6].addstation(station.total[27]);
            lines.Add(new LineBus(station.total[28], station.total[29]));
            lines[7].addstation(station.total[30]);
            lines[7].addstation(station.total[31]);
            lines.Add(new LineBus(station.total[32], station.total[33]));
            lines[8].addstation(station.total[34]);
            lines[8].addstation(station.total[35]);
            lines.Add(new LineBus(station.total[36], station.total[37]));
            lines[9].addstation(station.total[38]);
            lines[9].addstation(station.total[39]);
            lines[0].addstation(station.total[4]);
            lines[1].addstation(station.total[8]);
            lines[2].addstation(station.total[12]);
            lines[3].addstation(station.total[16]);
            lines[4].addstation(station.total[20]);
            lines[5].addstation(station.total[24]);
            lines[6].addstation(station.total[28]);
            lines[7].addstation(station.total[32]);
            lines[8].addstation(station.total[36]);
            lines[9].addstation(station.total[0]);
            line = new CollectionOfLineBus();
            for (int i = 0; i < 10; i++)
                line.addLineToCollection(lines[i]);
        }

        static void addNewLineBus(ref ListOfBusStation station, ref CollectionOfLineBus lines)
        {
            Console.WriteLine("enter station code for start and end of pass:");
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            //if(!station.search(start))
            //{
            //    Console.WriteLine("the start station not exist, do you want to add?");
            //    string data = Console.ReadLine();
            //    if (data == "yes")
            //        addNewStation(ref station);
            //}
            //if (!station.search(end))
            //{
            //    Console.WriteLine("the end station not exist, do you want to add?");
            //    string data = Console.ReadLine();
            //    if (data == "yes")
            //        addNewStation(ref station);
            //}
            if (station.search(start) && station.search(end))
                lines.addLineToCollection(new LineBus(station.GetStation(start), station.GetStation(end)));
            else
                throw new ObjectNotFoundExeption();
        }

        static void addNewStationInLineBus(ref ListOfBusStation station, ref CollectionOfLineBus lines)
        {
            Console.WriteLine("please enter the line bus");
            int numberBus = int.Parse(Console.ReadLine());
            if(lines.findIndex(numberBus) != -1)
            {
                Console.WriteLine("please enter number station key:");
                int numberStation = int.Parse(Console.ReadLine());
                if (station.search(numberStation))
                    lines[lines.findIndex(numberBus)].addstation(station.GetStation(numberStation));
            }

        }

        static void deleteLineBus(ref CollectionOfLineBus lines)
        {
            Console.WriteLine("please enter number line bus to delete:");
            int data = int.Parse(Console.ReadLine());
            int index = lines.findIndex(data);
            if(index!= -1)
                lines.deleteLineFromCollection(lines[index]);
        }

        static void deleteStationFromLineBus(ref CollectionOfLineBus lines)
        {
            Console.WriteLine("please enter number line bus and station to delete");
            int bus = int.Parse(Console.ReadLine());
            int station = int.Parse(Console.ReadLine());
            int indexBus = lines.findIndex(bus);
            if (indexBus != -1)
            {
                lines[indexBus].deleteStation(lines[indexBus].getStation(station));
            }
            else
                throw new ObjectNotFoundExeption();
        }

        static void searchLinesInStation(ref CollectionOfLineBus lines)
        {
            Console.WriteLine("please enter number of station");
            int station = int.Parse(Console.ReadLine());
            Console.WriteLine("the buses which pass in this station are:");
            foreach(LineBus bus in lines)
                if(bus.stationInLineBus(station))
                    Console.WriteLine(bus.numberBus + " ");
        }

        static void searchBestWay(ref CollectionOfLineBus lines)
        {
            CollectionOfLineBus options = new CollectionOfLineBus();
            Console.WriteLine("please enter start and end stations");
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            foreach (LineBus bus in lines)
            {
                int indexStart = bus.getIndexOfStation(start);
                int indexEnd = bus.getIndexOfStation(end);
                if(indexStart != -1 && indexEnd != -1 && indexEnd>indexStart)
                {
                    options.addLineToCollection(bus.subLineBus(bus.getStation(start), bus.getStation(end)));
                }
            }
            options.sortBusList();
            foreach (LineBus bus in options)
            {
                Console.WriteLine("Number line bus: " + bus.numberBus + " total time: " + bus.totalTimeDriving() + "\n");
            }

        }

        static void printAllLineBus(ref CollectionOfLineBus lines)
        {
            foreach (LineBus bus in lines)
                Console.WriteLine(bus.ToString());
        }

        static void printStationWithBus(ref ListOfBusStation stations, ref CollectionOfLineBus lines)
        {
            foreach(BusStation item in stations.total)
            {
                Console.WriteLine("number station " + item.BusStationKey);
                List<LineBus> buses = lines.listBusInStation(item.BusStationKey);
                Console.WriteLine(" the number line bus whitch pass in this station: ");
                foreach(LineBus line in buses)
                    Console.WriteLine("  "+line.numberBus);
                Console.WriteLine("***");
            }
        }


        static void Main(string[] args)
        {
            string ch;
            CollectionOfLineBus buses = new CollectionOfLineBus();
            ListOfBusStation stations = new ListOfBusStation();
            restart(ref stations, ref buses);
            Console.WriteLine("Choose one of the following: ");
            Console.WriteLine("a: to ADD a new line bus");
            Console.WriteLine("b: to ADD a new station for a line bus");
            Console.WriteLine("c: to DELETE line bus");
            Console.WriteLine("d: to DELETE station fron line bus");
            Console.WriteLine("e: to SEARCH lines whitch pass in spesific station");
            Console.WriteLine("f: to FIND the best way between two stations");
            Console.WriteLine("g: to PRINT all line buses");
            Console.WriteLine("h: to PRINT all station with the bus whitch pass there");
            Console.WriteLine("i: to EXIT");
            do
            {
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "a":
                        addNewLineBus(ref stations, ref buses);
                        break;
                    case "b":
                        addNewStationInLineBus(ref stations, ref buses);
                        break;
                    case "c":
                        deleteLineBus(ref buses);
                        break;
                    case "d":
                        deleteStationFromLineBus(ref buses);
                        break;
                    case "e":
                        searchLinesInStation(ref buses);
                        break;
                    case "f":
                        searchBestWay(ref buses);
                        break;
                    case "g":
                        printAllLineBus(ref buses);
                        break;
                    case "h":
                        printStationWithBus(ref stations, ref buses);
                        break;
                    case "i":
                        Console.WriteLine("see you..:)");
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

            } while (ch != "i");
        }
    }
}
