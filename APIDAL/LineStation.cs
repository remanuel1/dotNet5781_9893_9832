﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        /// <summary>
        /// line station - there are data for one line station (one station in line bus)
        /// </summary>
        public int identifyLine { get; set; } 
        public int numberStation { get; set; }
        public int numberStationInLine { get; set; }
        public bool deleted { get; set; }
    }
}
