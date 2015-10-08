using AddressParser.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParserTest
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void StreetTypeValidation()
        {
            string st = "way";

            ValidateAddress.ValidateStreetTypes(st);

            Assert.IsTrue( ValidateAddress.ValidateStreetTypes(st), "Not properly validating street type");
        }

    }
}
