using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;


namespace Consol
{
    public class Class1
    {
        static IDL mydl;
        static void main(string[] args)
        {
            mydl = DLFactory.GetDal();
            DO.Bus bus;
            Console.WriteLine(mydl.getBus("1234567"));
        }


    }
}
