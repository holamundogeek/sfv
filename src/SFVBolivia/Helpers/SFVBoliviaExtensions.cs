using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public static class SFVBoliviaExtensions
    {
        private static SFVBoliviaHelper helper = new SFVBoliviaHelper();

        //TODO Complete this implementation
        public static string GetCodeControl(long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            //Step 1      
            string verhoeffDigits = AddVerhoeffDigits(invoiceNumber, nitOrCi, transactionDate, transactionAmount);
        
            //Step 2 and 3
            string partialAllegedRC4 = GetPartialAllegedRC4(verhoeffDigits, authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);

            //Step 4

            return "";
        }

        /// <summary>
        /// This method number of verhoeff digit to an expecific number.
        /// </summary>
        /// <param name="number">to concat verhoeff digits</param>
        /// <param name="digitsNumber">number to add</param>
        /// <param name="verhoeffDigits">concat generated for number</param>
        /// <returns>number concat with verhoeff digits</returns>
        public static long AddVerhoeffDigit(this long number, int digitsNumber, out string verhoeffDigits)
        {
            verhoeffDigits = "";
            string numberStr = number.ToString();
            for (int i = 0; i < digitsNumber; i++)
            {
                var verhoeffDigit = helper.GetVerhoeffCheckDigit(numberStr);
                verhoeffDigits = $"{verhoeffDigits}{verhoeffDigit}";
                numberStr = $"{numberStr}{verhoeffDigit}";
            }

            return long.Parse(numberStr);
        }

        /// <summary>
        ///  THis method implements logic to retrieve last 5 verhoeff digits.
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="nitOrCi">client identification</param>
        /// <param name="transactionDate"> date YYYYmmdd</param>
        /// <param name="transactionAmount">bill total</param>
        /// <returns>last 5 verhoeff digits</returns>
        public static string AddVerhoeffDigits(long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount)
        {
            //Retrieve verhoeff digit per each bill data and concat it.
            string verhoeffDigits;
            var newInvoiceNumber = invoiceNumber.AddVerhoeffDigit(2, out verhoeffDigits);
            var newNitOrCi = nitOrCi.AddVerhoeffDigit(2, out verhoeffDigits);
            var newTransactionDate = transactionDate.AddVerhoeffDigit(2, out verhoeffDigits);
            var newTransactionAmount = Convert.ToInt64(Math.Round(transactionAmount)).AddVerhoeffDigit(2, out verhoeffDigits);

            // Add bill data
            long total = newInvoiceNumber + newNitOrCi + newTransactionDate + newTransactionAmount;
            total.AddVerhoeffDigit(5, out verhoeffDigits);

            // Return last five verhoeff digits
            return verhoeffDigits;
        }

        //Step 2 and 3
        public static string GetPartialAllegedRC4(string verhoeffDigits, long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            return "";
        }

        //Step 4
        public static void CalculatePartialSum()
        {
        }

        //Step 5 and 6
        public static void GetFinalAllegedRC4()
        {
        }

        public static void FormatCodeControl()
        {
        }
    }
}