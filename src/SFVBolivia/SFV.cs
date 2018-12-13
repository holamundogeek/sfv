using System;
using System.Drawing;
using SFVBolivia.Helpers;

namespace SFVBolivia
{
    public static class SFV
    {
        /// <summary>
        /// Gets control code based on parameters.
        /// </summary>
        /// <param name="authorizationNumber">Authorization code.</param>
        /// <param name="invoiceNumber">Invoice number.</param>
        /// <param name="nitOrCi">Nit or CI</param>
        /// <param name="transactionDate">Transaction Date.</param>
        /// <param name="transactionAmount">Transaction Amount.</param>
        /// <param name="dosingKey">Dosing Key.</param>
        /// <returns>Control code generated as string.</returns>
        public static string GetCodeControl(long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            return SFVBoliviaExtensions.GetCodeControl(authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);
        }

        /// <summary>
        /// Generates QR code bitmap according to the text value parameter.
        /// </summary>
        /// <param name="value">Text to be encoded.</param>
        /// <returns>QR code bitmap generated.</returns>
        public static Bitmap GetQRCode(int billNumber, long authorization, DateTime transactionDate, double transactionAmount, double amountFiscalCredit, string controlCode, long nitOrCiRecep, UserIssuer userIssuer)
        {
            Bill bill = new Bill(billNumber, authorization, transactionDate, transactionAmount, amountFiscalCredit, controlCode, nitOrCiRecep, userIssuer);

            return SFVBoliviaHelper.GetQRCode(bill.ToString());
        }

        public static string GetText(int transactionAmount)
        {
            return SFVBoliviaHelper.ConvertToLiteral(transactionAmount);
        }
    }
}
