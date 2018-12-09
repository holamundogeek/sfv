using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaHelperTest
    {
        private SFVBoliviaHelper helper = new SFVBoliviaHelper();

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

        [TestMethod]
        public void GetRC4CiphertextTest()
        {
            string actualMessageCiffer = helper.GetRC4Ciphertext("d3Ir6", "sesamo");
            string expectedMessageCiffer = "EB-06-AE-F8-92";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

        [TestMethod]
        public void GetRC4CiphertextLongPasswordTest()
        {
            string actualMessageCiffer = helper.GetRC4Ciphertext("IUKYo", "XBCPY-GKGX4-PGK44-8B632-X9P33");
            string expectedMessageCiffer = "83-62-FC-B0-F0";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

        [TestMethod]
        public void GetRC4CiphertextComplexPasswordTest()
        {
            string actualMessageCiffer = helper.GetRC4Ciphertext("piWCp", "Aa1-bb2-Cc3-Dd4");
            string expectedMessageCiffer = "37-71-2E-14-A0";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

       [TestMethod]
        public void GetFinalAllegedRC4Test()
        {
            int[] partialSumsArray = new int[] { 1548, 1537, 1540, 1565, 1530 };
            string dosingKey = "9rCB7Sv4X29d)5k7N%3ab89p-3(5[A";
            string verhoeffDigits = "71621";
            string actualMessageCiffer = SFVBoliviaExtensions.GetFinalAllegedRC4(verhoeffDigits, partialSumsArray, dosingKey);
            string expectedMessageCiffer = "6A-DC-53-05-14";
            Assert.AreEqual(expectedMessageCiffer, actualMessageCiffer);
        }

        [TestMethod]
        public void getQRCode()
        {
            // Given
            int billNumber = 10;
            long authorization = 132002430;
            DateTime date = DateTime.Now.Date;
            double amount = 30.00;
            double amountFiscalCredit = 27.00;
            string controlCode = "A6-22-1D-EF-11";
            long nITRecep = 3763395;
            UserIssuer userIssuer = new UserIssuer("Graciela Loayza", 352687016, "Av. Siles 2018");
            Bill bill = new Bill(billNumber, authorization, date, amount, amountFiscalCredit,
            controlCode, nITRecep, userIssuer);
           
            // When
            Bitmap qrCode = helper.GetQRCode(bill.ToString());

            // Then
            Assert.IsInstanceOfType(qrCode, typeof(Bitmap));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A qRString of null was inappropriately allowed.")]
        public void illegalArgumentException()
        {
            // When
            string emptyString = null;

            // Then
            Bitmap qrCode = helper.GetQRCode(emptyString);
        }
    }
}
