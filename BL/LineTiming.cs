using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    public class LineTiming
    {
        /// <summary>
        /// line timing - contain:
        /// trip start - time of line start the trip, taken from StartAt of ExitLine
        /// line id - Line ID from Line
        /// line number - Line Number as understood by the people
        /// last station name - so the passengers will know better which direction it is
        /// expected time till arrive - Expected time of arrival 
        /// </summary>

        public TimeSpan TripStart { get; set; }

        public int LineId { get; set; }

        public int LineNumber { get; set; }

        public string LastStation { get; set; }

        public TimeSpan ExpectedTimeTillArrive { get; set; }

    }
}
