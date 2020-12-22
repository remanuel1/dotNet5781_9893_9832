using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class FollowStations
    {
        public LineStation Station1 { get; set; }
        public LineStation Station2 { get; set; }
        public float distance { get; set; }
        public DateTime drivinngTime { get; set; }
    }
}
