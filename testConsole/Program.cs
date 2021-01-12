using System;
using BLAPI;

namespace testConsole
{
    class Program
    {
        static IBL mybl;
        static void Main(string[] args)
        {
            mybl = BLFactory.GetBL();
            TimeSpan time = TimeSpan.Parse("08:00:00");
            mybl.GetLineTimingsForStation(38844, time);

        }
    }
}
