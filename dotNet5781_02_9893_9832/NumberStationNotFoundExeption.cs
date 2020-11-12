using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace dotNet5781_02_9893_9832
{
    [Serializable]
    class NumberStationNotFoundExeption : Exception
    {
        public NumberStationNotFoundExeption() : base() { }
        public NumberStationNotFoundExeption(string message) : base(message) { }
        public NumberStationNotFoundExeption(string message, Exception inner) : base(message, inner) { }
        protected NumberStationNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        override public string ToString()
        {
            return "The number of station not exist\n";
        }
    }
}
