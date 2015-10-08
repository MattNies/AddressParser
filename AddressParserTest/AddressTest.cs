using AddressParser.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParserTest
{
    [TestClass]
    public class AddressTest
    {

        [TestMethod]
        public void AddressGetTest()
        {
            var expected = new List<string>();
            expected.Add("212B S Lake Dr W, Suite 302, Lexington, SC 29072");
            //expected.Add("212B S Lake Dr W, Suite 302, Lexington, SC 29072");
            expected.Add("121 Northpoint Dr, Apt 210, Lexington, SC 29072");
            expected.Add("104 Bridle Ct, Lexington, SC 29072");
            expected.Add("143 Hunters Ridge Dr, Lexington, SC 29072");
            expected.Add("4590 Augusta Rd, Lexington, SC 29073");
            expected.Add("131 New Orangeburg Rd, Lexington, SC 29073");
            expected.Add("480 Oak St, West Columbia, SC 29172");
            expected.Add("2286 N Lake Dr, Columbia, SC 29212");
            expected.Add("2257 Lake Murray Blvd, Columbia, SC 29212");
            expected.Add("2255 Lake Murray Blvd, Columbia, SC 29212");
            expected.Add("251 Grandflora Ln, Columbia, SC 29212");
            expected.Add("112 Highgrove Cir, West Columbia, SC 29170");
            expected.Add("113 Highgrove Ct, West Columbia, SC 29170");
            expected.Add("121 Northpoint Dr, Lexington, SC 29072");
            expected.Add("2664 Augusta Hwy, Lexington, SC 29072");
            //expected.Add("752 Highway 378 W, Lexington, SC 29072");
            expected.Add("914 N Lake Dr, Lexington, SC 29072");
            expected.Add("210 Garden Brooke Dr, Irmo, SC 29063");
            expected.Add("410 Pine Knot Court, Lexington, SC 29073");
            expected.Add("414 Pine Knot Ct, Lexington, SC 29073");
            expected.Add("913 Indian River Dr, West Columbia, SC 29170");
            expected.Add("1651a S Lake Dr, Lexington, SC 29073");
            expected.Add("112A Southwood Dr, Lexington, SC 29073");
            //expected.Add("2176 S Lake Dr, Lexington, SC 29073");
            expected.Add("150 Tannery Way, Columbia, SC 29036");
            expected.Add("179 Heimatsweg Rd, Chapin, SC 29036");
            //expected.Add("179 Heimatsweg, Chapin, SC 29036");
            expected.Add("1212 S Lake Dr, Lot F, Lexington, SC 29073");


            var actual = new List<string>();
            actual.Add(new Address("212B S Lake Dr W", "Lexington, SC 29072", "Suite 302").GetAddress());
            //actual.Add(new Address("212B S Lake Dr West", "Lexington, SC 29072", "Suite 302").GetAddress());
            actual.Add(new Address("121 Northpoint Dr", "Lexington, SC 29072", "Apt 210").GetAddress());
            actual.Add(new Address("104 BRIDLE CT", "Lexington, SC 29072", String.Empty).GetAddress());
            actual.Add(new Address("143 Hunters Ridge Dr", "Lexington, SC 29072", String.Empty).GetAddress());
            actual.Add(new Address("4590 Augusta Rd", "Lexington, SC 29073", String.Empty).GetAddress());
            actual.Add(new Address("131 New Orangeburg Rd", "Lexington, SC 29073", "").GetAddress());
            actual.Add(new Address("480 OAK ST", " West Columbia, SC 29172", "").GetAddress());
            actual.Add(new Address("2286 N LAKE DR", "Columbia, SC 29212", "").GetAddress());
            actual.Add(new Address("2257 LAKE MURRAY BLVD", "Columbia, SC 29212", "").GetAddress());
            actual.Add(new Address("2255 LAKE MURRAY BLVD", "COLUMBIA, sc 29212", "").GetAddress());
            actual.Add(new Address("251 Grandflora Ln", "Columbia, SC 29212", "").GetAddress());
            actual.Add(new Address("112 Highgrove Cir", "West Columbia, SC 29170", "").GetAddress());
            actual.Add(new Address("113 Highgrove Ct", "West Columbia, SC 29170", "").GetAddress());
            actual.Add(new Address("121 NORTHPOINT DR", "Lexington, SC 29072", "").GetAddress());
            actual.Add(new Address("2664 Augusta HWY", "Lexington SC 29072", "").GetAddress());
            //actual.Add(new Address("752 HIGHWAY 378 W", "Lexington, SC 29072", "").GetAddress());
            actual.Add(new Address("914 N LAKE DR", "Lexington, SC 29072", "").GetAddress());
            actual.Add(new Address("210 GARDEN BROOKE DR", "Irmo, SC 29063", "").GetAddress());
            actual.Add(new Address("410 Pine Knot Court", "Lexington, SC 29073", "").GetAddress());
            actual.Add(new Address("414 Pine Knot Ct", "Lexington, SC 29073", "").GetAddress());
            actual.Add(new Address("913 Indian River Dr", "West Columbia, SC 29170", "").GetAddress());
            actual.Add(new Address("1651a S Lake Dr", "Lexington, SC 29073", "").GetAddress());
            actual.Add(new Address("112A Southwood Dr", "Lexington SC 29073", "").GetAddress());
            //actual.Add(new Address("2176 South Lake Dr", "Lexington, SC 29073", "").GetAddress());
            actual.Add(new Address("150 Tannery Way", "Columbia, SC 29036", "").GetAddress());
            actual.Add(new Address("179 Heimatsweg Rd", "Chapin, SC 29036", "").GetAddress());
            //actual.Add(new Address("179 Heimatsweg", "Chapin, SC 29036", "").GetAddress());
            actual.Add(new Address("1212 S Lake Dr", "Lexington, SC 29073", "Lot F").GetAddress());

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
