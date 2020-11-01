using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_9893_9832
{
    class Bus
    {
        private string m_id;
        public string ID
        {
            get { return m_id; }
            private set { m_id = value; }
        }
        private DateTime start;
        public DateTime startActivity
        {
            get { return start; }
            private set { start = value; }
        }
        private float m_sum;
        public float sumKM
        {
            get { return m_sum; }
            private set { m_sum = value; }
        }
        private float ttF;
        public float totalFuel
        {
            get; set;
        }
        private float kmfromt;
        public float kmFromTreat
        {
            get; set;
        }
        private DateTime lastT;
        public DateTime lastTreat
        {
            get; set;
        }

        public Bus(string id, DateTime date)
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
            if(ID.Length==7)
            {
                ID = ID.Insert(2, "-");
                ID = ID.Insert(6, "-");
            }
            else
            {
                ID = ID.Insert(3, "-");
                ID = ID.Insert(6, "-");
            }
            Console.WriteLine("ID BUNS: " + ID);
            Console.WriteLine("the number KM from the last treat: " + kmFromTreat);


        }


    }

    
}
