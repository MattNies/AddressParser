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
            string l1 = "212B S Lake Dr W Suite 302";
            string l2 = "Happy but Sad, SC 29072-1111";
            string l3 = "Lot 3024";

            Address testAddress = new Address(l1, l2, l3);

            string[] parsedl2 = ParseAddress.ParseAddressLine2(l2);

            foreach (string s in parsedl2)
            {
                Console.WriteLine(s);
            }
        }
    }
}
