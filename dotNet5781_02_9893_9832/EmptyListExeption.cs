using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace dotNet5781_02_9893_9832
{
    [Serializable]
    class EmptyListExeption : Exception
    {
        public EmptyListExeption() : base() { }
        public EmptyListExeption(string message) : base(message) { }
        public EmptyListExeption(string message, Exception inner) : base(message, inner) { }
        protected EmptyListExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        override public string ToString()
        {
            return "There are not line that pass in this station\n";
        }
    }
}
