using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;
using System;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaTest
    {
        [TestMethod]
        public void Get5verhoeffDigits()
        {
            // Given
            long invoiceNumber = 1503;
            long nitOrCi = 4189179011;
            long transactionDate = 20070702;
            double transactionAmount = 2500;
            int expectedLenght = 5;

            // When
            string verhoeffDigit = SFVBoliviaExtensions.AddBillData(invoiceNumber, nitOrCi, transactionDate, transactionAmount);

            // Then
            Assert.AreEqual(expectedLenght, verhoeffDigit.Length);
        }
    }
}