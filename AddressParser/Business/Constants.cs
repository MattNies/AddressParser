using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Constants
    {
        public const string ZipCodeRegexUS = @"^\d{5}(?:[-\s]\d{4})?$";
        
        public const string StreetNumberRegex = @"(?<=\d)(?=\p{L})|(?<=\p{L})(?=\d)";

        public const string Seperator = @"\s{1,}";

        public static readonly string[] StreetTypes = new string[]
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

        public static readonly string[] SuffixDirectionals = new string[]
            {
               "E", "EAST",
               "W", "WEST"
            };

        public static readonly string[] PrefixDirectionals = new string[]
            {
                "N", "NORTH",
                "S", "SOUTH",
                "E", "EAST",
                "W", "WEST",
                "NW", "NORTHWEST"
            };
            

    }
}
