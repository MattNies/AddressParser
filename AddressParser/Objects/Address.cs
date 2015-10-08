/****************************************************************************************
 *   Creates an Address object based on GIS requirements for lexington county.
 ****************************************************************************************/

using AddressParser.Business;
using System;
using System.Globalization;
using System.Text;

namespace AddressParser.Objects
{
    public class Address
    {
        #region fields

        #endregion

        #region properties

        public string Address1 { get; private set; } // street address, apt/lot information
        public string Address2 { get; private set; } // city, state zip
        public string Address3 { get; private set; } // unit/lot information

        public string StreetNumber { get; private set; }
        public string StreetNumberSuffix { get; private set; }
        public string PrefixDirectional { get; private set; }
        public string StreetName { get; private set; }
        public string StreetType { get; private set; }
        public string SuffixDirectional { get; private set; }
        public string UnitType { get; private set; }
        public string Unit { get; private set; }

        public string City { get; private set; }
        public string DefaultCity { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public bool isValid { get; private set; }

        #endregion

        #region constructors

        public Address(string address1, string address2, string address3)
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            
            string[] parsedAddress = ParseAddress.ParseAddressLine1(address1);
            StreetNumber = parsedAddress[0];
            StreetNumberSuffix = parsedAddress[1];
            PrefixDirectional = parsedAddress[2];
            StreetName = parsedAddress[3];
            StreetType = parsedAddress[4];
            SuffixDirectional = parsedAddress[5];

            string[] parsedAddress2 = ParseAddress.ParseAddressLine2(address2);
            City = parsedAddress2[0];
            State = parsedAddress2[1];
            ZipCode = parsedAddress2[2];
            DefaultCity = GetDefaultCity();

            string[] parsedAddress3 = ParseAddress.ParseAddressLine3(address3);
            UnitType = parsedAddress3[0];
            Unit = parsedAddress3[1];

        }

        #endregion

        #region methods

        public string GetAddress()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(!String.IsNullOrEmpty(StreetNumber) ? ToTitleCase(StreetNumber) : String.Empty);
            sb.Append(!String.IsNullOrEmpty(StreetNumberSuffix) ? StreetNumberSuffix : String.Empty);
            sb.Append(" ");
            sb.Append(!String.IsNullOrEmpty(PrefixDirectional) ? PrefixDirectional.ToUpper() + " " : String.Empty);
            sb.Append(!String.IsNullOrEmpty(StreetName) ? ToTitleCase(StreetName) : String.Empty);
            sb.Append(" ");
            sb.Append(!String.IsNullOrEmpty(StreetType) ? ToTitleCase(StreetType) : String.Empty);
            sb.Append(!String.IsNullOrEmpty(SuffixDirectional) ? " " + SuffixDirectional.ToUpper() : String.Empty);
            sb.Append(", ");
            sb.Append(!String.IsNullOrEmpty(UnitType) ? ToTitleCase(UnitType) + " " : String.Empty);
            sb.Append(!String.IsNullOrEmpty(Unit) ? Unit + ", " : String.Empty);
            sb.Append(!String.IsNullOrEmpty(City) ? ToTitleCase(City) : String.Empty);
            sb.Append(", ");
            sb.Append(!String.IsNullOrEmpty(State) ? State.ToUpper() : String.Empty);
            sb.Append(" ");
            sb.Append(!String.IsNullOrEmpty(ZipCode) ? ZipCode : String.Empty);

            return sb.ToString();
        }

        /// <summary>
        /// Based on the zip code provided, the default city is returned.
        /// </summary>
        /// <returns></returns>
        /// if  this is ever expanded to a wider range of areas, look into USPS web tools to accomplish.
        private string GetDefaultCity()
        {
            if (this.ZipCode.Equals("29006"))
                return "Batesburg";
            if (this.ZipCode.Equals("29033"))
                return "Cayce";
            if (this.ZipCode.Equals("29036"))
                return "Chapin";
            if (this.ZipCode.Equals("29054"))
                return "Gaston";
            if (this.ZipCode.Equals("29063"))
                return "Irmo";
            if (this.ZipCode.Equals("29070"))
                return "Leesville";
            if (this.ZipCode.Equals("29072") || this.ZipCode.Equals("29073"))
                return "Lexington";
            if (this.ZipCode.Equals("29075"))
                return "Little Mountain";
            if (this.ZipCode.Equals("29112"))
                return "North";
            if (this.ZipCode.Equals("29123"))
                return "Pelion";
            if (this.ZipCode.Equals("29160"))
                return "Swansea";
            if (this.ZipCode.Equals("29169") || this.ZipCode.Equals("29170") || this.ZipCode.Equals("29172"))
                return "West Columbia";
            if (this.ZipCode.Equals("29210") || this.ZipCode.Equals("29212"))
                return "Columbia";

            return String.Empty;
        }

        private string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        #endregion
    }
}
