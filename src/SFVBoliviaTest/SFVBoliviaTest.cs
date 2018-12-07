using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

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
            Dictionary<string, long> verhoeffDigits = SFVBoliviaExtensions.AddVerhoeffDigits(invoiceNumber, nitOrCi, transactionDate, transactionAmount);

            // Then
            Assert.AreEqual(expectedLenght, verhoeffDigits["verhoeffDigits"].ToString().Length);
        }

        [TestMethod]
        public void VerhoeffDigitsAreEquals()
        {
            // Given
            long invoiceNumber = 1503;
            long nitOrCi = 4189179011;
            long transactionDate = 20070702;
            double transactionAmount = 2500;
            string expectedNumber = "71621";

            // When
            Dictionary<string, long> verhoeffDigits = SFVBoliviaExtensions.AddVerhoeffDigits(invoiceNumber, nitOrCi, transactionDate, transactionAmount);

            // Then
            Assert.AreEqual(expectedNumber, verhoeffDigits["verhoeffDigits"].ToString());
        }
    }
}
