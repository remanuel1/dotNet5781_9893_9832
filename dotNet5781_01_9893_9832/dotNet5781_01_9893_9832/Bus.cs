using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_9893_9832
{
    class Bus
    {
        public int ID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public DateTime startActivity
        {
            get { return startActivity; }
            private set { startActivity = value; }
        }
        public float sumKM
        {
            get { return sumKM; }
            private set { sumKM = value; }
        }
        public float totalFuel
        {
            get; set;
        }
        public float kmFromTreat
        {
            get; set;
        }
        public DateTime lastTreat
        {
            get; set;
        }

        public Bus(int id, DateTime date)
        {
            ID = id;
            startActivity = date;
            sumKM = 0;
            totalFuel = 1200;
            kmFromTreat = 0;
            lastTreat = date;
        }

        public bool needTreat()
        {
            DateTime dateNow = DateTime.Now;
            TimeSpan t = dateNow - lastTreat;
            if (kmFromTreat > 20000 || t.Days > 365)
            {
                kmFromTreat = 0;
                lastTreat = dateNow;
                return true;
            }
            return false;

        }

        public void checkDriving(float km)
        {
            DateTime dateNow = DateTime.Now;
            TimeSpan t = dateNow - lastTreat;
            if (kmFromTreat+km > 20000 || t.Days > 365 || totalFuel-km <=0)
            {
                Console.WriteLine("sorry, we can't do this driving..");
            }
            else
            {
                Console.WriteLine("the driving is O.K.");
                sumKM += km;
                kmFromTreat += km;
                totalFuel -= km;
            }
        }
        public void fullFuel()
        {
            totalFuel = 1200;
            Console.WriteLine("the bus can driving 1200 KM");
        }
        public void doTreat()
        {
            lastTreat = DateTime.Now;
            kmFromTreat = 0;
            
        }
        public void printKmFromTreat()
        {
            // number with 8 digis 999-99-999
            if (ID > 9999999)
                Console.WriteLine("ID BUNS: " + ID/100000 + "-" + (ID/1000)%100 + "-" + ID%1000);
            // number with 7 digis 99-999-99
            else
                Console.WriteLine("ID BUNS: " + ID / 100000 + "-" + (ID / 100) % 1000 + "-" + ID % 100);
            Console.WriteLine("the number KM from the last treat: " + kmFromTreat);
        }


    }

    
}
