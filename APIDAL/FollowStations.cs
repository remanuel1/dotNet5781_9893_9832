using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class FollowStations
    {
        /// <summary>
        /// follow station - 
        /// for pair of stations (in line bus), there are distance and driving time
        /// 
        /// </summary>
        public int numberStation1 { get; set; }
        public int numberStation2 { get; set; }
        public double distance { get; set; }
        public bool deleted { get; set; }
        public TimeSpan drivinngTime { get; set; }
    }
}
