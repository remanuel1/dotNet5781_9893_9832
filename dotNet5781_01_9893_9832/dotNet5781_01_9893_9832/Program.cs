using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_9893_9832
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateNow = DateTime.Now;
            Console.WriteLine(dateNow);
            string ch;
            ListOfBus listBus = new ListOfBus();
            Console.WriteLine("Choose one of the following: ");
            Console.WriteLine("a: to ADD a new bus");
            Console.WriteLine("b: to choose bus for driving");
            Console.WriteLine("c: to do fuel or treat");
            Console.WriteLine("d: to show all bus km from the last treat");
            Console.WriteLine("e: to EXIT");
            do
            {
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "a":
                        listBus.insert();
                        break;
                    case "b":
                        listBus.busForDriving();
                        break;
                    case "c":
                        listBus.fuelOrTreat();
                        break;
                    case "d":
                        listBus.printAllKmfromTreat();
                        break;
                    case "e":
                        Console.WriteLine("see you..:)");
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

            } while (ch != "e");

        }
    }
}
