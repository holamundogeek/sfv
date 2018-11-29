using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaExtensionsTest
    {

        [TestMethod]
        public void TestAddVerhoeffDigit()
        {
            long number = 1503;
            string verhoeffDigits;
            long value = number.AddVerhoeffDigit(2, out verhoeffDigits);
            long expected = 150312;
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void TestAddVerhoeffDigitBigValue()
        {
            long number = 4189179011;
            string verhoeffDigits;
            long value = number.AddVerhoeffDigit(2, out verhoeffDigits);
            long expected = 418917901158;
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void TestGetPartialAllegedRC4()
        {
            string verhoeffDigits = "71621";
            long authorizationNumber = 29040011007;
            long invoiceNumber = 150312;
            long nitOrCi = 418917901158;
            long transactionDate = 2007070201;
            double transactionAmount = 250031;
            string dosingKey = "9rCB7Sv4X29d)5k7N%3ab89p-3(5[A";
            string allegedRC4 = SFVBoliviaExtensions.GetPartialAllegedRC4(verhoeffDigits, authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);
            string expected = "69DD0A42536C9900C4AE6484726C122ABDBF95D80A4BA403FB7834B3EC2A88595E2149A3D965923BA4547B42B9528AAE7B8CFB9996BA2B58516913057C9D791B6B748A";
            Assert.AreEqual(expected, allegedRC4);
        }

        [TestMethod]
        public void TestPartialSumsSimple()
        {
            string hash = "AAAAA";
            int[] partialSums = SFVBoliviaExtensions.CalculatePartialSum(hash);
            int[] expectedPartialSums = { 325, 65, 65, 65, 65, 65};
            CollectionAssert.AreEqual(expectedPartialSums, partialSums);
        }

        [TestMethod]
        public void TestPartialSumsSimpleWithTwoLetters()
        {
            string hash = "AAAAABBBBB";
            int[] partialSums = SFVBoliviaExtensions.CalculatePartialSum(hash);
            int[] expectedPartialSums = { 655, 131, 131, 131, 131, 131 };
            CollectionAssert.AreEqual(expectedPartialSums, partialSums);
        }

        [TestMethod]
        public void TestPartialSumsComplex()
        {
            string hash = "69DD0A42536C9900C4AE6484726C122ABDBF95D80A4BA403FB7834B3EC2A88595E2149A3D965923BA4547B42B9528AAE7B8CFB9996BA2B58516913057C9D791B6B748A";
            int[] partialSums = SFVBoliviaExtensions.CalculatePartialSum(hash);
            int[] expectedPartialSums = { 7720, 1548, 1537, 1540, 1565, 1530 };
            CollectionAssert.AreEqual(expectedPartialSums, partialSums);
        }

        [TestMethod]
        public void TestGetControlCode()
        {
            long authorizationNumber = 79040011859;
            long invoiceNumber = 152;
            long nitOrCi = 1026469026;
            long transactionDate = 20070728;
            double transactionAmount = 135;
            string dosingKey = "A3Fs4s$)2cvD(eY667A5C4A2rsdf53kw9654E2B23s24df35F5";

            string actualResult = SFVBoliviaExtensions.GetCodeControl(authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);
            string expectedResult = "FB-A6-E4-78";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
