using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressParser.Business
{

    public enum State
    {
        AL, AK, AZ, AR, CF, CL, CT, DL, DC, FL,
        GA, HI, ID, IL, IN, IA, KA, KY, LA, ME,
        MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, 
        NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, 
        SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, 
        WY
    }

    public class ParseAddress
    {
        #region fields

        private static char[] Address2Separator = new char[] { ' ', ',' };
        public const string ZipCodeRegexUS = @"^\d{5}(?:[-\s]\d{4})?$";
        public const string StreetNumberRegex = @"(?<=\d)(?=\p{L})|(?<=\p{L})(?=\d)";

        #endregion

        #region methods

        /// <summary>
        /// Parses the address into 6 different sections: Street Number, Street Number Suffix, 
        /// Prefix Directional, Street Name, Street Type, Suffix Directional
        /// </summary>
        /// <param name="address">Address from line 1</param>
        /// <returns>parsed address information </returns>
        public static string[] ParseAddressLine1(string address)
        {
            string[] returnAddress = new string[6];

            return returnAddress;
        }

        public static string[] ParseAddressLine2(string address)
        {
            address = address.Replace(',', ' ');
            List<string> parsedAddress = new List<string>();
            string[] returnAddress = new string[3];

            foreach (string s in Regex.Split(address, @"\s{1,}"))
            {
                parsedAddress.Add(s);
            }

            //
            foreach (string s in parsedAddress)
            {
                if (Regex.IsMatch(s, ZipCodeRegexUS))
                {
                    returnAddress[2] = s;
                }
            }
            parsedAddress.Remove(returnAddress[2]);

            //
            foreach (string s in parsedAddress)
            {
                if (Enum.IsDefined(typeof(State), s))
                {
                    returnAddress[1] = s;
                }
            }
            parsedAddress.Remove(returnAddress[1]);

            //
            returnAddress[0] = string.Join(" ", parsedAddress);

            return returnAddress;
        }

        public static string[] ParseAddressLine3(string address3)    
        {

        }

        #endregion

    }

}