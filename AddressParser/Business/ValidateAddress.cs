using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressParser.Business
{
    public class ValidateAddress
    {
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
            Regex reg = new Regex(ParseAddress.ZipCodeRegexUS);

            if (reg.IsMatch(zipCode))
                return true;
            else
                return false;
        }


    }
}
