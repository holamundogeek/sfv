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
            string verhoeffDigits;
            var newInvoiceNumber = invoiceNumber.AddVerhoeffDigit(2, out verhoeffDigits);
            var newNitOrCi = nitOrCi.AddVerhoeffDigit(2, out verhoeffDigits);
            var newTransactionDate = transactionDate.AddVerhoeffDigit(2, out verhoeffDigits);
            var newTransactionAmount = Convert.ToInt64(Math.Round(transactionAmount)).AddVerhoeffDigit(2, out verhoeffDigits);

            long total = newInvoiceNumber + newNitOrCi + newTransactionDate + newTransactionAmount;
            total.AddVerhoeffDigit(5, out verhoeffDigits);

            //Step 2 and 3
            string partialAllegedRC4 = GetPartialAllegedRC4(verhoeffDigits, authorizationNumber, invoiceNumber, nitOrCi, transactionDate, transactionAmount, dosingKey);

            //Step 4

            return "";
        }

        //Step1
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

        //Step 2 and 3
        public static string GetPartialAllegedRC4(string verhoeffDigits, long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            List<string> splitDosingKey = new List<string>();
            string auxDosingKey = dosingKey;
            verhoeffDigits.ToList().ForEach(n => {
                int verhoeffDigit = Int32.Parse(n.ToString());
                verhoeffDigit = verhoeffDigit == 9 ? 0 : verhoeffDigit + 1;
                splitDosingKey.Add(auxDosingKey.Substring(0, verhoeffDigit));
                auxDosingKey = auxDosingKey.Substring(verhoeffDigit);
            });
            string concat = $"{authorizationNumber}{splitDosingKey.ElementAt(0)}{invoiceNumber}{splitDosingKey.ElementAt(1)}" +
                            $"{nitOrCi}{splitDosingKey.ElementAt(2)}{transactionDate}{splitDosingKey.ElementAt(3)}" +
                            $"{transactionAmount}{splitDosingKey.ElementAt(4)}";
            string newDosingKey = $"{dosingKey}{verhoeffDigits}";
            return helper.GetRC4Ciphertext(concat, newDosingKey);
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