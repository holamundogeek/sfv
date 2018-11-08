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


            //Step   5
           

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
                numberStr = $"{number}{verhoeffDigit}";
            }

            return long.Parse(numberStr);
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
        public static string GetFinalAllegedRC4(string verhoeffDigits, int[] partialSumsArray, string dosinKey)
        {
            List<int> numbers = verhoeffDigits.Select(digit => int.Parse(digit.ToString())).ToList();
            int spIndex = 0;
            int totalTruncSum = 0;
            int totalSum = partialSumsArray.Sum();
            numbers.ForEach(number => {
                totalTruncSum += ((totalSum * partialSumsArray[spIndex]) / (number + 1));
                spIndex++;
            });
            return helper.GetRC4Ciphertext(helper.GetBase64(totalTruncSum), $"{dosinKey}{verhoeffDigits}");
        }

        public static void FormatCodeControl()
        {
        }
    }
}