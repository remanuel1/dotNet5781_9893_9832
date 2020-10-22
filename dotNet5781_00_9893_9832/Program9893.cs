using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_9893_9832
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome9893();
            Welcome9832();
            Console.ReadKey();



        }

        static partial void Welcome9832();

        private static void Welcome9893()
        {
            Console.WriteLine("Enter your name: ");
            string your_name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", your_name);
        }
    }
}
