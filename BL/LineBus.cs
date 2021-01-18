using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineBus
    {
        /// <summary>
        /// line bus - there are data for one line bus and all stations through which this line passes
        /// </summary>
        public int identifyBus { get; set; }
        public int numberLine { get; set; }
        public Area area { get; set; }
        public IEnumerable<LineStation> listStaion { get; set; }
        public bool deleted { get; set; }
        public override string ToString()
        {
            return ""+numberLine;
        }


    }
}
