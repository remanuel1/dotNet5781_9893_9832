using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using DLAPI;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        //static IBL mybl;
        static IDL mydl;
        static void Main(string[] args)
        {
            //mybl = BLFactory.GetBL();
            mydl = DLFactory.GetDal();
            mydl.getAllLineBus();
        }
    }
}
