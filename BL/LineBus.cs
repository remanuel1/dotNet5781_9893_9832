﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineBus
    {
        public int identifyBus { get; set; }
        public int numberLine { get; set; }
        public Area area { get; set; }
        public Bus bus { get; set; }
        public IEnumerable<FollowStations> listStaion { get; set; }
        public bool deleted { get; set; }


    }
}
