using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineBus
    {
        /// <summary>
        /// line bus - there are data for one line bus
        /// </summary>
        public int identifyBus { get; set; }
        public int numberLine { get; set; }
        public Area area { get; set; }
        public int firstNumberStation { get; set; }
        public int lastNumberStation { get; set; }
        public bool deleted { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
