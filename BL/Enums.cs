using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
        public enum Area
        {
            north, center, south, general
        }

        public enum Status
        {
            ready, inDriving, refueling, inTreat, needTreat
        }

        public enum Type
        {
            manager, user
        }

}
