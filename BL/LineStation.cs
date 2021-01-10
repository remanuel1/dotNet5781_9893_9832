using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation
    {
        public int identifyLine { get; set; }
        public string nameStation { get; set; }
        public int numberStation { get; set; }
        public int numberStationInLine { get; set; }
        public TimeSpan timeFromPriorStation { set; get; }
        public bool deleted { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
