using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;


namespace dotNet5781_03B_9893_9832
{

    public enum Status { ready, inDriving, refueling, inTreat };
    public class Bus : INotifyPropertyChanged
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
            set
            {
                m_sum = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("sumKM"));
                }
            }
        }
        private float ttF;
        public float totalFuel
        {
            get { return ttF; }
            set
            {
                ttF = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("totalFuel"));
                }
            }
        }
        private float kmfromt;
        public float kmFromTreat
        {
            get { return kmfromt; }
            set
            {
                kmfromt = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("kmFromTreat"));
                }
            }
        }
        private DateTime lastT;
        public DateTime lastTreat
        {
            get { return lastT; }
            set
            { 
                lastT = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("lastTreat"));
                }
            }
        }
        private Status st;
        public Status state
        {
            get { return st; }
            set
            {
                st = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("state"));
                }
            }
        }

        private string _timer;
        public string timer

        {
            get { return _timer; }
            set
            {
                _timer = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("timer"));
                }
            }
        }

        private int _work;
        public int work

        {
            get { return _work; }
            set
            {
                _work = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("work"));
                }
            }
        }
        int timeToEndWork;

        public event PropertyChangedEventHandler PropertyChanged;
        static Random r = new Random(DateTime.Now.Millisecond);
        //public Stopwatch stopWatch;
        public bool isTimerRun;

        public BackgroundWorker worker = new BackgroundWorker();
        

        public Bus(string id, DateTime date)
        {
            ID = id;
            startActivity = date;
            sumKM = 0;
            totalFuel = 1200;
            kmFromTreat = 0;
            lastTreat = date;
            state = 0;
            timer = "";
            //stopWatch = new Stopwatch();
            work = 0;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
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

        public bool checkDriving(float km)
        {
            DateTime dateNow = DateTime.Now;
            TimeSpan t = dateNow - lastTreat;
            if (state!=(Status)0 || kmFromTreat + km > 20000 || t.Days > 365 || totalFuel - km <= 0)
            {
                return false;
            }
            else
            {
                int num = r.Next(20, 51);
                //stopWatch.Restart();
                isTimerRun = true;
                worker.RunWorkerAsync((int)(num * km * 0.1));
                state = (Status)1;
                sumKM += km;
                kmFromTreat += km;
                totalFuel -= km;
                return true;
            }
        }
        public void fullFuel()
        {
            state = (Status)2;
            //stopWatch.Restart();
            isTimerRun = true;
            worker.RunWorkerAsync(12);
            totalFuel = 1200;
            //Console.WriteLine("the bus can driving 1200 KM");
        }
        public void doTreat()
        {
            state = (Status)3;
            //stopWatch.Restart();
            isTimerRun = true;
            worker.RunWorkerAsync(144);
            lastTreat = DateTime.Now;
            kmFromTreat = 0;

        }
        public void printKmFromTreat()
        {
            if (ID.Length == 7)
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

        public override string ToString()
        {
            string temp = ID;
            if (temp.Length == 7)
            {
                temp = temp.Insert(2, "-");
                temp = temp.Insert(6, "-");
            }
            else
            {
                temp = temp.Insert(3, "-");
                temp = temp.Insert(6, "-");
            }
            return temp;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int length = (int)e.Argument;
            timeToEndWork = length;
            //timer = "שניות " + timeToEndWork + " נשארו עוד";
            for(int i=1; i<= length; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(i * 100 / length);
            }
                
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            work = (int)e.ProgressPercentage;
            timer = "נשארו עוד " + timeToEndWork + " שניות";
            timeToEndWork--;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isTimerRun = false;
            state = (Status)0;
            work = 0;
            timer = "";
            timeToEndWork = 0;
        }









    }
}
