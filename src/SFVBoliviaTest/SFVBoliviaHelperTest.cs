using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;

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
        public void GetLiteralNumberFromADigitTest()
        {
            string actualLiteral = helper.ConvertToLiteral(8);
            string expectedLiteral = "Ocho";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromAnTensTest()
        {
            string actualLiteral = helper.ConvertToLiteral(83);
            string expectedLiteral = "Ochenta y Tres";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromTest()
        {
            string actualLiteral = helper.ConvertToLiteral(953);
            string expectedLiteral = "Novecientos Cincuenta y Tres";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberTest()
        {
            string actualLiteral = helper.ConvertToLiteral(500);
            string expectedLiteral = "Quinientos";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromThousandUnitTest()
        {
            string actualLiteral = helper.ConvertToLiteral(10084);
            string expectedLiteral = "Diez Mil Ochenta y Cuatro";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromOtherThousandUnitTest()
        {
            string actualLiteral = helper.ConvertToLiteral(537020);
            string expectedLiteral = "Quinientos Treinta y Siete Mil Veinte";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromAlmostMillionUnitTest()
        {
            string actualLiteral = helper.ConvertToLiteral(999999);
            string expectedLiteral = "Novecientos Noventa y Nueve Mil Novecientos Noventa y Nueve";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }

        [TestMethod]
        public void GetLiteralNumberFromMillionUnitTest()
        {
            string actualLiteral = helper.ConvertToLiteral(845520767);
            string expectedLiteral = "Ochocientos Cuarenta y Cinco Millones Quinientos Veinte Mil Setecientos Sesenta y Siete";
            Assert.AreEqual(expectedLiteral, actualLiteral);
        }
    }
}