using AddressParser.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressParser.Objects
{
    class Address
    {
        #region fields

        #endregion

        #region properties

        public string Address1 { get; private set; } // street address, apt/lot information
        public string Address2 { get; private set; } // city, state zip

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

        #endregion

        #region constructors

        public Address(string address1, string address2)
        {
            Address1 = address1;
            Address2 = address2;
        }

        #endregion

        #region methods

        private void SetAdress1(string address)
        {
            //string[] parsedAddress;
        }

        private void ParseAdress2(string address)
        {
            string[] parsedAddress = ParseAddress.ParseAddressLine2(address);
            City = parsedAddress[0];
            State = parsedAddress[1];
            ZipCode = parsedAddress[2];
        }

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


        #endregion
    }
}
