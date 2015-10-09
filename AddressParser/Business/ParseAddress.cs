using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressParser.Business
{
    public class ParseAddress
    {
        #region fields

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
            List<string> streetNum = new List<string>();
            List<string> parsedAddress = new List<string>();

            address = address.Replace(',', ' ');
            address = address.Replace('.', ' ');

            foreach (string s in Regex.Split(address, Constants.Seperator))
            {
                parsedAddress.Add(s);
            }

            // the street number might not have to be broken into two different strings
            // the try/catch will catch they null exceptions if there is only one value after regex split
            foreach (string s in Regex.Split(parsedAddress[0], Constants.StreetNumberRegex))
            {
                streetNum.Add(s);
            }

            try
            {
                returnAddress[1] = streetNum[1];
            }
            catch
            {
                returnAddress[1] = String.Empty;
            }
            returnAddress[0] = streetNum[0];
            parsedAddress.RemoveAt(0);

            // used to get the prefix directional
            if (Constants.PrefixDirectionals.Contains(parsedAddress[0].ToUpper()))
            {
                if(parsedAddress[0].Length > 2)
                {
                    returnAddress[2] = ConvertPrefix(parsedAddress[0].ToUpper());
                }
                else
                {
                    returnAddress[2] = parsedAddress[0];
                }

                parsedAddress.RemoveAt(0);
            }
            else
            {
                returnAddress[2] = String.Empty;
            }

            // used to get the suffix directional
            if (Constants.SuffixDirectionals.Contains(parsedAddress[parsedAddress.Count - 1].ToUpper()))
            {
                if (parsedAddress[parsedAddress.Count - 1].Length > 2)
                {
                    returnAddress[5] = ConvertPrefix(parsedAddress[parsedAddress.Count - 1].ToUpper());
                }
                else
                {
                    returnAddress[5] = parsedAddress[parsedAddress.Count - 1];
                }
                
                parsedAddress.RemoveAt(parsedAddress.Count - 1);
            }
            else
            {
                returnAddress[5] = String.Empty;
            }

            // used to extract the street type
            if (Constants.StreetTypes.Contains(parsedAddress[parsedAddress.Count - 1].ToUpper()))
            {
                returnAddress[4] = parsedAddress[parsedAddress.Count - 1];
                parsedAddress.RemoveAt(parsedAddress.Count - 1);
            }
            else
            {
                returnAddress[4] = String.Empty;
            }

            returnAddress[3] = String.Join(" ", parsedAddress);


            return returnAddress;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string[] ParseAddressLine2(string address)
        {
            address = address.Replace(',', ' ');
            List<string> parsedAddress = new List<string>();
            string[] returnAddress = new string[3];

            foreach (string s in Regex.Split(address, Constants.Seperator))
            {
                parsedAddress.Add(s);
            }

            foreach (string s in parsedAddress)
            {
                if (Regex.IsMatch(s, Constants.ZipCodeRegexUS))
                {
                    returnAddress[2] = s;
                }
            }
            parsedAddress.Remove(returnAddress[2]);

            foreach (string s in parsedAddress)
            {
                if (Enum.IsDefined(typeof(State), s.ToUpper()))
                {
                    returnAddress[1] = s;
                }
            }
            parsedAddress.Remove(returnAddress[1]);

            returnAddress[0] = string.Join(" ", parsedAddress).Trim();

            return returnAddress;
        }

        /// <summary>
        /// Parses any lot/suite/apt information breaking it into the unit type and the units number.
        /// </summary>
        /// <param name="address3"></param>
        /// <returns></returns>
        public static string[] ParseAddressLine3(string address3)    
        {
            string[] returnAddress = new string[2];
            List<string> parsedAddress = new List<string>();

            // splits the address based on whitespace between words
            foreach (string s in Regex.Split(address3, Constants.Seperator))
            {
                parsedAddress.Add(s);
            }

            returnAddress[1] = parsedAddress[parsedAddress.Count - 1];
            parsedAddress.Remove(parsedAddress[parsedAddress.Count - 1]);
            returnAddress[0] = string.Join(" ", parsedAddress);

            return returnAddress;
        }

        /// <summary>
        /// Converts a prefix directional to its abbreviation
        /// </summary>
        /// <param name="prefix">prefix to be converted</param>
        /// <returns>converted prefix</returns>
        private static string ConvertPrefix(string prefix)
        {
            if (prefix.Equals("NORTH"))
                return "N";
            if (prefix.Equals("SOUTH"))
                return "S";
            if (prefix.Equals("WEST"))
                return "W";
            if (prefix.Equals("EAST"))
                return "E";
            if (prefix.Equals("NORTHWEST"))
                return "NW";

            return prefix;
        }

        /// <summary>
        /// Converts a suffix directional to its abbreviation
        /// </summary>
        /// <param name="suffix">suffix to be converted</param>
        /// <returns>converted suffix</returns>
        private static string ConvertSuffix(string suffix)
        {
            if (suffix.Equals("EAST"))
                return "E";
            if (suffix.Equals("WEST"))
                return "W";
            return suffix;
        }

        #endregion

    }

}