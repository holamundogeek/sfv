using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaHelperTest
    {
        SFVBoliviaHelper helper = new SFVBoliviaHelper();

        [TestMethod]
        public void GetRC4CiphertextTest()
        {
            String actualMessageCiffer = helper.GetRC4Ciphertext("d3Ir6", "sesamo");
            String expectedMessageCiffer = "EB-06-AE-F8-92";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

        [TestMethod]
        public void GetRC4CiphertextLongPasswordTest()
        {
            String actualMessageCiffer = helper.GetRC4Ciphertext("IUKYo", "XBCPY-GKGX4-PGK44-8B632-X9P33");
            String expectedMessageCiffer = "83-62-FC-B0-F0";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

        [TestMethod]
        public void GetRC4CiphertextComplexPasswordTest()
        {
            String actualMessageCiffer = helper.GetRC4Ciphertext("piWCp", "Aa1-bb2-Cc3-Dd4");
            String expectedMessageCiffer = "37-71-2E-14-A0";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }
    }
}
