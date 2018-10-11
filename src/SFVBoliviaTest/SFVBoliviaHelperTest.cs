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
        public void GetBase64EncodedStringOfZeroValueTest()
        {
            string generatedResult = helper.GetBase64(0);
            string expectedResult = "0";
            Assert.AreEqual(expectedResult, generatedResult);
        }

        [TestMethod]
        public void GetBase64EncodedStringOfNineDigitsNumberOneTest()
        {
            string generatedResult = helper.GetBase64(934598591);
            string expectedResult = "tjDU/";
            Assert.AreEqual(expectedResult, generatedResult);
        }

        [TestMethod]
        public void GetBase64EncodedStringOfNineDigitsNumberTwoTest()
        {
            string generatedResult = helper.GetBase64(434376710);
            string expectedResult = "Pv106";
            Assert.AreEqual(expectedResult, generatedResult);
        }

        [TestMethod]
        public void GetBase64EncodedStringOfNineDigitsNumberThreeTest()
        {
            string generatedResult = helper.GetBase64(204986118);
            string expectedResult = "CDzS6";
            Assert.AreEqual(expectedResult, generatedResult);
        }
    }
}
