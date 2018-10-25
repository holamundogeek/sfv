using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFVBolivia.Helpers;
using System.Drawing;

namespace SFVBoliviaTest
{
    [TestClass]
    public class SFVBoliviaHelperTest
    {
        SFVBoliviaHelper helper = new SFVBoliviaHelper();

        [TestMethod]
        public void TestMethod1()
        {
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
    }

    
}
