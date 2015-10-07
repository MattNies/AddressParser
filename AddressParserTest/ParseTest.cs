using System;
using AddressParser.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParserTest
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void Address_ParseAddressLine2_City()
        {
            string l2 = "Happy but Sad, SC 29072-1111";

            string[] parsedl2 = ParseAddress.ParseAddressLine2(l2);

            Assert.AreEqual("Happy but Sad", parsedl2[0], "City not parsing correct");
        }

        [TestMethod]
        public void Address_ParseAddressLine2_State()
        {
            string l2 = "Happy but Sad, SC 29072-1111";

            string[] parsedl2 = ParseAddress.ParseAddressLine2(l2);

            Assert.AreEqual("SC", parsedl2[1], "State not parsing correct");
        }

        [TestMethod]
        public void Address_ParseAddressLine2_ZipCode()
        {
            string l2 = "Happy but Sad, SC 29072-1111";

            string[] parsedl2 = ParseAddress.ParseAddressLine2(l2);

            Assert.AreEqual("29072-1111", parsedl2[2], "Zip code not parsing correct");
        }
        
    }
}
