using System.Linq;
using System.Text.RegularExpressions;

namespace AddressParser.Business
{
    public class ValidateAddress
    {
        public static bool ValidateStreetTypes(string streetType)
        {

            bool check = Constants.StreetTypes.Contains(streetType.ToUpper());

            return check;
        }

        public static bool ValidateState(string state)
        {
            return true;
        }

        public static bool ValidateZipCode(string zipCode)
        {
            Regex reg = new Regex(Constants.ZipCodeRegexUS);

            if (reg.IsMatch(zipCode))
                return true;
            else
                return false;
        }


    }
}
