using System;
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

            Assert.IsTrue(ValidateAddress.ValidateStreetType(st), "Not properly validating street type");
        }

    }
}
