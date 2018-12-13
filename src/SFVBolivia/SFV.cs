using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Helpers.SFVBoliviaExtensions.GetCodeControl(authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);
        }

        /// <summary>
        /// Generates QR code bitmap according to the text value parameter.
        /// </summary>
        /// <param name="value">Text to be encoded.</param>
        /// <returns>QR code bitmap generated.</returns>
        public static Bitmap GetQRCode(string value)
        {
            return Helpers.SFVBoliviaHelper.GetQRCode(value);
        }

        public static void GetText()
        {
        }
    }
}
