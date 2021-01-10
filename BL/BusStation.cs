using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusStation
    {
        public int numberStation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string nameStation { get; set; }
        public string address { get; set; }
        public IEnumerable<LineStation> lineInStation { get; set; }
        public bool deleted { get; set; }

        public override string ToString()
        {
            return nameStation;
        }
    }
}
