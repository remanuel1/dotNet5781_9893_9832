using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BO
{
    public class Bus
    {
            public string numberLicense { get; set; }
            public DateTime startActivity { get; set; }
            public float sumKM { get; set; }
            public int totalFuel { get; set; }
            public Status Status { get; set; }
            public float sumKMFromLastTreat { get; set; }
            public DateTime lastTreat { get; set; }
            public bool deleted { get; set; }

    }
}
