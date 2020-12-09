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

    public enum Status { ready, inDriving, refueling, inTreat, needTreat };
    public class Bus : INotifyPropertyChanged
    {

        private string m_id;
        public string ID
        {
            get { return m_id; }
            private set
            {
                //m_id = value;
                if ((startActivity.Year < 2018 && value.Length == 7) || (startActivity.Year >= 2018 && value.Length == 8))
                    m_id = value;
                else
                    throw new Exception("מספר רישוי לא תקף");
            }
        }
        private DateTime start;
        public DateTime startActivity
        {
            get { return start; }
            set { start = value; }
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
                image = "";
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

        private bool _notEnable;
        public bool notEnable
        {
            get { return _notEnable; }
            set
            {
                _notEnable = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("notEnable"));
                }
            }
        }

        private string _image;
        public string image
        {
            get { return _image; }
            set
            {
                switch(state)
                {
                    case (Status)0:
                        _image = "ready.JPG";
                        break;
                    case (Status)1:
                        _image = "driving.JPG";
                        break;
                    case (Status)2:
                        _image = "fuel.jpg";
                        break;
                    case (Status)3:
                        _image = "treat.JPG";
                        break;
                    case (Status)4:
                        _image = "warn.JPG";
                        break;

                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("image"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        static Random r = new Random(DateTime.Now.Millisecond);
        bool isTimerRun = false;

        public BackgroundWorker worker = new BackgroundWorker();
        

        public Bus(string id, DateTime date)
        {
            startActivity = date;
            if (id.Length < 7)
                throw new Exception();
            ID = id;
            sumKM = 0;
            totalFuel = 1200;
            lastTreat = startActivity;
            kmFromTreat = 0;
            state = 0;
            timer = "";
            notEnable = true;
            work = 0;
            needTreat();
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
                state = (Status)4;
                return true;
            }
            return false;

        }

        public bool checkDriving(float km)
        {
            DateTime dateNow = DateTime.Now;
            TimeSpan t = dateNow - lastTreat;
            if (state!=(Status)0 || kmFromTreat + km > 20000 || needTreat() || totalFuel - km <= 0)
            {
                return false;
            }
            else
            {
                int num = r.Next(20, 51);
                state = (Status)1;
                isTimerRun = true;
                notEnable = false;
                worker.RunWorkerAsync((int)(num * km * 0.1));
                sumKM += km;
                kmFromTreat += km;
                totalFuel -= km;
                return true;
            }
        }
        public void fullFuel()
        {
            state = (Status)2;
            isTimerRun = true;
            notEnable = false;
            worker.RunWorkerAsync(12);

        }
        public void doTreat()
        {
            state = (Status)3;
            isTimerRun = true;
            notEnable = false;
            worker.RunWorkerAsync(144);

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
            Thread.Sleep(100);

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            work = (int)e.ProgressPercentage;
            timer = "נשארו עוד " + timeToEndWork + " שניות";
            timeToEndWork--;
            if (state == Status.refueling)
                if(timeToEndWork!=0)
                totalFuel = totalFuel + (1200 - totalFuel)/(timeToEndWork) ;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isTimerRun = false;
            notEnable = true;
            state = (Status)0;
            work = 0;
            timer = "";
            timeToEndWork = 0;
            if (state == Status.inTreat)
            {
                lastTreat = DateTime.Now;
                kmFromTreat = 0;
            }
        }









    }
}
