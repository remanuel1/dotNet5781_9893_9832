using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusInDriving
    {
        public int identifyBus { get; set; }
        public string numberLicense { get; set; }
        public int Line { get; set; }
        public DateTime Start { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
