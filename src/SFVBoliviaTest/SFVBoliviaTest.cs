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
            string nitOrCiFormatted;
            string verhoeffDigits = SFVBoliviaExtensions.GetVerhoeffDigits(ref invoiceNumber, ref nitOrCi, ref transactionDate, ref transactionAmount, out nitOrCiFormatted);

            // Then
            Assert.AreEqual(expectedLenght, verhoeffDigits.Length);
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
            string nitOrCiFormatted;
            string verhoeffDigits = SFVBoliviaExtensions.GetVerhoeffDigits(ref invoiceNumber, ref nitOrCi, ref transactionDate, ref transactionAmount, out nitOrCiFormatted);

            // Then
            Assert.AreEqual(expectedNumber, verhoeffDigits);
        }
    }
}
