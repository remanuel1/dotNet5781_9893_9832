using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9893_9832
{
    class LineBus
    {
        class StationLineBus
        {
            public int stationBusKey
            {
                get; private set;
            }
            public double distanceBetweenLastStation
            {
                get; private set;
            }
            public DateTime timeRideFromLastStation
            {
                get; private set;
            }
        }

    }
}
