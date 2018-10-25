﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaHelperTest
    {
        SFVBoliviaHelper helper = new SFVBoliviaHelper();

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseOneValueTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("0");
            int expectedVerhoeffDigit = 4;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseTwoTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("12083");
            int expectedVerhoeffDigit = 7;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseThreeTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("1810");
            int expectedVerhoeffDigit = 8;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseFourTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("04");
            int expectedVerhoeffDigit = 7;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseFiveTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("1503");
            int expectedVerhoeffDigit = 1;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseSixTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("15031");
            int expectedVerhoeffDigit = 2;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseSevenTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("420925371702");
            int expectedVerhoeffDigit = 7;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseEightTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("4209253717027");
            int expectedVerhoeffDigit = 1;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseNineTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("42092537170271");
            int expectedVerhoeffDigit = 6;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseTenTest()
        {
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("420925371702716");
            int expectedVerhoeffDigit = 2;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }

        [TestMethod]
        public void GetVerhoeffCheckDigitCaseElevenTest()
        {
            SFVBoliviaHelper helper = new SFVBoliviaHelper();
            int verhoeffDigitGenerated = helper.GetVerhoeffCheckDigit("4209253717027162");
            int expectedVerhoeffDigit = 1;
            Assert.AreEqual(expectedVerhoeffDigit, verhoeffDigitGenerated);
        }
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
