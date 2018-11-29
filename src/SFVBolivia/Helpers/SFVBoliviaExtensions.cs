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
            Dictionary<string, long> verhoeffDigits = AddVerhoeffDigits(invoiceNumber, nitOrCi, transactionDate, transactionAmount);
            Console.WriteLine("Step1: ", verhoeffDigits);

            //Step 2 and 3 (Review)
            string partialAllegedRC4 = GetPartialAllegedRC4(verhoeffDigits["verhoeffDigits"].ToString(), authorizationNumber, verhoeffDigits["newInvoiceNumber"],
                verhoeffDigits["newNitOrCi"], verhoeffDigits["newTransactionDate"], verhoeffDigits["newTransactionAmount"], dosingKey);
            Console.WriteLine("Step2 and 3: ", partialAllegedRC4);

            //Step 4
            int[] sumOfAsciiValues = CalculatePartialSum(partialAllegedRC4);
            Console.WriteLine("Step4: ", sumOfAsciiValues);

            //Step 5 and 6
            int[] asciiValues = { sumOfAsciiValues[1], sumOfAsciiValues[2], sumOfAsciiValues[3], sumOfAsciiValues[4], sumOfAsciiValues[5] };
            string controlCode = GetFinalAllegedRC4(verhoeffDigits["verhoeffDigits"].ToString(), asciiValues, dosingKey);
            Console.WriteLine("Step5 and 6: ", controlCode);

            return controlCode;
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
        public static Dictionary<string, long> AddVerhoeffDigits(long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount)
        {
            //Retrieve verhoeff digit per each bill data and concat it.
            string verhoeffDigits;
            Dictionary<string, long> modifiedParameters = new Dictionary<string, long>();
            //var newInvoiceNumber = invoiceNumber.AddVerhoeffDigit(2, out verhoeffDigits);
            modifiedParameters.Add("newInvoiceNumber", invoiceNumber.AddVerhoeffDigit(2, out verhoeffDigits));
            //var newNitOrCi = nitOrCi.AddVerhoeffDigit(2, out verhoeffDigits);
            modifiedParameters.Add("newNitOrCi", nitOrCi.AddVerhoeffDigit(2, out verhoeffDigits));
            //var newTransactionDate = transactionDate.AddVerhoeffDigit(2, out verhoeffDigits);
            modifiedParameters.Add("newTransactionDate", transactionDate.AddVerhoeffDigit(2, out verhoeffDigits));
            //var newTransactionAmount = Convert.ToInt64(Math.Round(transactionAmount)).AddVerhoeffDigit(2, out verhoeffDigits);
            modifiedParameters.Add("newTransactionAmount", Convert.ToInt64(Math.Round(transactionAmount)).AddVerhoeffDigit(2, out verhoeffDigits));

            // Add bill data
            long total = modifiedParameters ["newInvoiceNumber"] + modifiedParameters ["newNitOrCi"] + modifiedParameters ["newTransactionDate"] 
                + modifiedParameters ["newTransactionAmount"];

            total.AddVerhoeffDigit(5, out verhoeffDigits);
            modifiedParameters["verhoeffDigits"] = long.Parse(verhoeffDigits);

            // Return last five verhoeff digits
            return modifiedParameters;
        }

        //Step 2 and 3
        /// <summary>
        /// This method is to get partial allegedRC4 value.
        /// </summary>
        /// <param name="verhoeffDigits">the verhoeff digit generated previously</param>
        /// <param name="authorizationNumber">number of authorization with verhoeff digits.</param>
        /// <param name="invoiceNumber">number of invoice with verhoeff digits.</param>
        /// <param name="nitOrCi">number of NIT or CI with verhoeff digits.</param>
        /// <param name="transactionDate">the transaction date with verhoeff digits.</param>
        /// <param name="transactionAmount">the transaction amount with verhoeff digits.</param>
        /// <param name="dosingKey">the dosing key.</param>
        /// <returns>A partial alleged RC4 value</returns>
        public static string GetPartialAllegedRC4(string verhoeffDigits, long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            List<string> splitDosingKey = new List<string>();
            string auxDosingKey = dosingKey;
            verhoeffDigits.ToList().ForEach(n => {
                int verhoeffDigit = int.Parse(n.ToString());
                verhoeffDigit = verhoeffDigit == 9 ? 0 : verhoeffDigit + 1;
                splitDosingKey.Add(auxDosingKey.Substring(0, verhoeffDigit));
                auxDosingKey = auxDosingKey.Substring(verhoeffDigit);
            });
            string concat = $"{authorizationNumber}{splitDosingKey.ElementAt(0)}{invoiceNumber}{splitDosingKey.ElementAt(1)}" +
                            $"{nitOrCi}{splitDosingKey.ElementAt(2)}{transactionDate}{splitDosingKey.ElementAt(3)}" +
                            $"{transactionAmount}{splitDosingKey.ElementAt(4)}";
            string newDosingKey = $"{dosingKey}{verhoeffDigits}";
            return helper.GetRC4Ciphertext(concat, newDosingKey).Replace("-", string.Empty);
        }

        //Step 4
        public static int[] CalculatePartialSum(string hash)
        {
            int[] sumsArray = new int[6];
            byte[] asciiBytes = Encoding.ASCII.GetBytes(hash);
            Enumerable.Range(0, asciiBytes.Length).ToList().ForEach(n => {
                sumsArray[0] += asciiBytes[n];
                sumsArray[n + 1 - 5 * (n / 5)] += asciiBytes[n];
            });
            return sumsArray;
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