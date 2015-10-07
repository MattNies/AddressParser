using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressParser.Business
{

    public enum State
    {
        AL, AK, AZ, AR, CF, CL, CT, DL, DC, FL, GA, HI, ID, IL, IN, IA, KA, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH,
        NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }

    public class ParseAddress
    {
        #region fields

        private static char[] Address2Separator = new char[] { ' ', ',' };
        private const string ZipCodeRegexUS = @"^\d{5}(?:[-\s]\d{4})?$";

        #endregion

        #region methods

        public static void ParseAddressLine1(string address)
        {

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

        public static bool ValidateStreetTypes(string streetType)
        {
            string[] streetTypes = new string[]
            {
                "ALLEY", "ALY",
                "AVENUE", "AVE",
                "BOULEVARD", "BLVD",
                "BEND", "BND",
                "CIRCLE", "CIR",
                "CRESCENT", "CRES",
                "CROSSING", "CRNG",
                "COURT", "CT",
                "DRIVE", "DR",
                "END", 
                "ESTATES", "ESTS",
                "EXPRESSWAY", "EXPR",
                "EXTENSION", "EXT",
                "HIGHWAY", "HWY",
                "LANE", "LN",
                "LOOP",
                "PASS",
                "PATH",
                "PARKWAY", "PKWY",
                "PLACE", "PL",
                "POINT", "PT",
                "POINTE", "PTE",
                "RAMP",
                "ROAD", "RD",
                "ROW",
                "ROUTE", "RTE",
                "RUN",
                "SQUARE", "SQ",
                "STREET", "ST",
                "TERRACE", "TER",
                "TRACE", "TRC",
                "TRAIL", "TRL",
                "WAY"
            };

            bool check = streetTypes.Contains(streetType.ToUpper());

            return check;
        }

        public static bool ValidateState(string state)
        {
            return true;
        }

        public static bool ValidateZipCode(string zipCode)
        {
            Regex reg = new Regex(ZipCodeRegexUS);

            if (reg.IsMatch(zipCode))
                return true;
            else
                return false;
        }



        #endregion

    }

}
