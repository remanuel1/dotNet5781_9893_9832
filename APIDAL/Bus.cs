using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Bus
    {
        /// <summary>
        /// bus - there are data for one bus
        /// </summary>
        public string numberLicense { get; set; }
        public DateTime startActivity { get; set; }
        public float sumKM { get; set; }
        public int totalFuel { get; set; }
        public Status Status { get; set; }
        public float sumKMFromLastTreat { get; set; }
        public DateTime lastTreat { get; set; }
        public bool deleted { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
