using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_9893_9832
{
    class ListOfBus
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        public List<Bus> total
        {
            get; set;

        }

        public ListOfBus()
        {
            total = new List<Bus>();
        }
        public void insert()
        {
            Console.WriteLine("Please enter ID of bus:");
            string id = Console.ReadLine();
            Console.WriteLine("Please enter date of start activity:");
            string data = Console.ReadLine();
            DateTime date = DateTime.Parse(data);
            Bus b = new Bus(id, date);
            total.Add(b);
        }
        public bool findBusBool(string id)
        {
            foreach (Bus item in total)
                if (item.ID == id)
                    return true;
            return false;
        }

        public Bus findBusBus(string id)
        {
            foreach (Bus item in total)
                if (item.ID == id)
                    return item;
            return null;
        }
        public void busForDriving()
        {
            Console.WriteLine("Please enter ID of bus:");
            string id = Console.ReadLine();
            if (!findBusBool(id))
                Console.WriteLine("the bus is not found..");
            else
            {
                //int km = r.Next();
                int km = 200;
                Bus b = findBusBus(id);
                b.checkDriving(km);
            }
        }

        public void fuelOrTreat()
        {
            string data;
            Console.WriteLine("Please enter ID of bus:");
            string id = Console.ReadLine();
            if (!findBusBool(id))
                Console.WriteLine("the bus is not found..");
            else
            {
                Bus b = findBusBus(id);
                Console.WriteLine("did you want to full the fuel? (yes/no)");
                data = Console.ReadLine();
                if (data == "yes")
                {
                    b.fullFuel();
                }
                Console.WriteLine("did you want to do treat for the bus? (yes/no)");
                data = Console.ReadLine();
                if (data == "yes")
                    b.doTreat();
            }
        }

        public void printAllKmfromTreat()
        {
            foreach (Bus item in total)
                item.printKmFromTreat();
        }

    }
}
