using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    [Serializable]
    public class BadIDExceptions : Exception
    {
        public int ID;
        public BadIDExceptions(string message) : base(message) { ; }
        public BadIDExceptions(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad identify number: {ID}";

    }

    public class BadIDAndDateExceptions : Exception
    {
        public int ID;
        public DateTime DATE;
        public BadIDAndDateExceptions(int id, DateTime date, string message) :
            base(message) { ID = id; DATE = date; }

        public override string ToString() => base.ToString() + $", bad identify number: {ID} with date: {DATE}";

    }

    public class BadDateExceptions : Exception
    {
        public DateTime DATE;
        public BadDateExceptions(DateTime date, string message) :
            base(message)
        {DATE = date; }

        public override string ToString() => base.ToString() + $", bad date: {DATE}";

    }

    public class BadLineExceptions : Exception
    {
        public BadLineExceptions(string message) :
            base(message) { ; }
        
        public override string ToString() => base.ToString() + $", bad line bus";
    }

    public class BadLocalExceptions : Exception
    {
        public BadLocalExceptions(string message) :
            base(message)
        {; }
        public override string ToString() => base.ToString() + $", bad local for bus station";
    }


}
