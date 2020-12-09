using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;



namespace dotNet5781_03B_9893_9832
{
    public static class TotalBus
    {
        public static ObservableCollection<Bus> totalBus;

        static TotalBus()
        {
            totalBus = new ObservableCollection<Bus>();
            restart(ref totalBus);
            
        }

        static Random r = new Random(DateTime.Now.Millisecond);
        static void restart(ref ObservableCollection<Bus> listBus)
        {
            for (int i = 0; i < 10; i++)
            {
                int id1 = r.Next(1000000, 100000000);
                string id = id1.ToString();
                int year;
                if (id.Length==7)
                    year = r.Next(2000, 2017);
                else
                    year = r.Next(2018, 2021);
                int month = r.Next(1, 13);
                int day = r.Next(1, 29);
                //DateTime start = new DateTime(year, month, day);
                DateTime start = new DateTime(year, month, day);
                Bus temp = new Bus(id, start);
                listBus.Add(temp);
            }
            listBus[4].kmFromTreat = 19990;
            listBus[8].totalFuel = 10;
        }

        public static void addNewBus (Bus toAdd)
        {
            if(toAdd!=null)
            {
                totalBus.Add(toAdd);
            }
        }

        public static bool search(string ID)
        {
            for (int i=0; i<totalBus.Count(); i++)
            {
                if (totalBus[i].ID == ID)
                    return true;
            }
            return false;
        }

    }
}
