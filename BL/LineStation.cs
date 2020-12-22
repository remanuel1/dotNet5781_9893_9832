using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation
    {
        public int identifyBus { get; set; } 
        public int numberStation { get; set; }
        public int numberStationInLine { get; set; }
        public bool deleted { get; set; }
    }
}
