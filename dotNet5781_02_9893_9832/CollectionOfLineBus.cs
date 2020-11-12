using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    class CollectionOfLineBus : IEnumerable<LineBus>
    {
        public List<LineBus> AllLineBus
        {
            get; set;
        }

        public IEnumerator<LineBus> GetEnumerator()
        {
            return AllLineBus.GetEnumerator();
        }

        //the func

        public CollectionOfLineBus()
        {
            AllLineBus = new List<LineBus>();
        }
        public void addLineToCollection(LineBus addBus)
        {
            bool exist = false;
            foreach (LineBus bus in CollectionOfLineBus)
                if (addBus.numberBus == bus.numberBus)
                    exist = true;
            if (!exist)
                AllLineBus.Add(addBus);
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
            foreach (LineBus bus in CollectionOfLineBus)
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
            foreach (LineBus bus in CollectionOfLineBus)
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
