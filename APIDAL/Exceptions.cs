using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadIdException : Exception
    {
        public int ID;
        public BadIdException(int id) : base() => ID = id;
        public BadIdException(int id, string message) :
            base(message) => ID = id;
        public BadIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad identify number: {ID}";

    }

    public class BadTwoIdException : Exception
    {
        public int ID1;
        public int ID2;
        public BadTwoIdException(int _ID1, int _ID2) : base() { ID1 = _ID1; ID2 = _ID2; }
        public BadTwoIdException(int _ID1, int _ID2, string message) :
            base(message)
        { ID1 = _ID1; ID2 = _ID2; }
        public BadTwoIdException(int _ID1, int _ID2, string message, Exception innerException) :
            base(message, innerException)
        { ID1 = _ID1; ID2 = _ID2; }

        public override string ToString() => base.ToString() + $", bad identify number1: {ID1} and identify number2: {ID2}";
    }
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }

}
