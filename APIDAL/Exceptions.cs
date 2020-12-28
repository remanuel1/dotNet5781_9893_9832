using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BusExceptions : Exception
    {
        public string NUM;
        public BusExceptions(string numBus) : base() => NUM = numBus;
        public BusExceptions(string numBus, string message) :
                base(message) => NUM = numBus;
        public BusExceptions(string numBus, string message, Exception innerException) :
                base(message, innerException) => NUM = numBus;
        public override string ToString() => base.ToString() + $", bad number License : {NUM}";
        
    }

    public class BusStationExceptions : Exception
    {
        public int NUM;
        public BusStationExceptions(int numStation) : base() => NUM = numStation;
        public BusStationExceptions(int numStation, string message) :
                base(message) => NUM = numStation;
        public BusStationExceptions(int numStation, string message, Exception innerException) :
                base(message, innerException) => NUM = numStation;
        public override string ToString() => base.ToString() + $", bad number station : {NUM}";

    }

    public class FollowStationsExceptions : Exception
    {
        public int NUM;
        public FollowStationsExceptions(int numStation1, int numStation2) : base() => NUM = numStation1;
        public FollowStationsExceptions(int numStation1, int numStation2, string message) :
                base(message) => NUM = numStation1;
        public FollowStationsExceptions(int numStation1, int numStation2, string message, Exception innerException) :
                base(message, innerException) => NUM = numStation1;
        public override string ToString() => base.ToString() + $", ERROR in numbers stations : {NUM}";

    }

    public class LineBusExceptions : Exception
    {
        public int LINEBUS;
        public LineBusExceptions(int lineBus) : base() => LINEBUS = lineBus;
        public LineBusExceptions(int lineBus, string message) :
                base(message) => LINEBUS = lineBus;
        public LineBusExceptions(int lineBus, string message, Exception innerException) :
                base(message, innerException) => LINEBUS = lineBus;
        public override string ToString() => base.ToString() + $", bad number station : {LINEBUS}";
    }

    public class LineStationExceptions : Exception
    {
        public int LINESTATION;
        public LineStationExceptions(int lineStation) : base() => LINESTATION = lineStation;
        public LineStationExceptions(int lineStation, string message) :
                base(message) => LINESTATION = lineStation;
        public LineStationExceptions(int lineStation, string message, Exception innerException) :
                base(message, innerException) => LINESTATION = lineStation;
        public override string ToString() => base.ToString() + $", bad number station : {LINESTATION}";
    }
}
