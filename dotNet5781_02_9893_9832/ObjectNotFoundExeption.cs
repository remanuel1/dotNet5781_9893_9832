using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace dotNet5781_02_9893_9832
{
    [Serializable]
    class ObjectNotFoundExeption : Exception
    {
        public ObjectNotFoundExeption() : base() { }
        public ObjectNotFoundExeption(string message) : base(message) { }
        public ObjectNotFoundExeption(string message, Exception inner) : base(message, inner) { }
        protected ObjectNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        override public string ToString()
        {
            return "The object not exist\n";
        }
    }
}
