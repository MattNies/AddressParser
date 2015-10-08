using AddressParser.Objects;
using AddressParser.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressParser
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new Address("212B S Lake Dr West", "Lexington, SC 29072", "Suite 302").GetAddress());
            //string[] parsedl1 = ParseAddress.ParseAddressLine1(l1);

            //foreach (string s in parsedl1)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("\n*********************************\n");

            //string[] parsedl2 = ParseAddress.ParseAddressLine2(l2);

            //foreach (string s in parsedl2)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("\n*********************************\n");

            //string[] parsedl3 = ParseAddress.ParseAddressLine3(l3);
            //foreach (string s in parsedl3)
            //{
            //    Console.WriteLine(s);
            //}
        }
    }
}
