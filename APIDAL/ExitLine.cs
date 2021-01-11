using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class ExitLine
    {
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
