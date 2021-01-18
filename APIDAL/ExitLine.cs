using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class ExitLine
    {
        /// <summary>
        /// Exit Line - exsits for data to schedule information of line bus
        /// contain:
        /// - identifyBus for specific line
        /// - time to start this exit line
        /// - time to end this exit line
        /// - frequency how often this line exit
        /// </summary>
        public int identifyBus { get; set; }
        public TimeSpan startTime { get; set; }
        public int frequency { get; set; }
        public TimeSpan endTime { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }
}
