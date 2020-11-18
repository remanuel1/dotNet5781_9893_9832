using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    //Collection of all lines
    class CollectionOfLineBus : IEnumerable<LineBus>
    {
        public List<LineBus> AllLineBus //List of all lines
        {
            get; set;
        }
        //An exercise that will allow the collection to be counted
        public IEnumerator<LineBus> GetEnumerator()
        {
            return AllLineBus.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)AllLineBus).GetEnumerator();
        }

        //the func

        public CollectionOfLineBus() //constructor
        {
            AllLineBus = new List<LineBus>();
        }
        public void addLineToCollection(LineBus addBus) //Add a line 
        {
            bool exist = false; //Checks if the line is already on the list
            foreach (LineBus bus in AllLineBus)
                if (addBus.numberBus == bus.numberBus)
                    exist = true;
            if (!exist)
                AllLineBus.Add(addBus); //
        }

        public void deleteLineFromCollection(LineBus addBus)
        {
            bool did = false;
            if (AllLineBus.Count!=0)
                did = AllLineBus.Remove(addBus);
            if (!did)
                throw new ObjectNotFoundExeption();
        }

        public List<LineBus> listBusInStation(int code)
        {
            List<LineBus> busInStation = new List<LineBus>();
            foreach (LineBus bus in AllLineBus)
                if (bus.stationInLineBus(code))
                    busInStation.Add(bus);
            if (busInStation.Count == 0)
                throw new EmptyListExeption();
            return busInStation;
        }

        public void sortBusList()
        {
            AllLineBus.Sort();
        }

        public int findIndex(int numberLine)
        {
            foreach (LineBus bus in AllLineBus)
                if (bus.numberBus == numberLine)
                    return AllLineBus.IndexOf(bus);
            return -1;

        }

        public LineBus this[int index]
        {
            get { return AllLineBus[index]; }
            set { AllLineBus[index] = value; }
        }




    }
}
