﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("SFVBoliviaTest")]
namespace SFVBolivia.Helpers
{
    internal static class SFVBoliviaExtensions
    {
        private static SFVBoliviaHelper helper = new SFVBoliviaHelper();

        /// <summary>
        /// Gets control code according to parameters.
        /// </summary>
        /// <param name="authorizationNumber">Authorization number.</param>
        /// <param name="invoiceNumber">Invoice number.</param>
        /// <param name="nitOrCi">NIT or CI.</param>
        /// <param name="transactionDate">Transaction date.</param>
        /// <param name="transactionAmount">Transaction amount.</param>
        /// <param name="dosingKey">Dosing Key.</param>
        /// <returns></returns>
        internal static string GetCodeControl(long authorizationNumber, long invoiceNumber, long nitOrCi, long transactionDate, double transactionAmount, string dosingKey)
        {
            //Step 1
            string nitOrCiFormatted;
            string verhoeffDigits = GetVerhoeffDigits(ref invoiceNumber, ref nitOrCi, ref transactionDate, ref transactionAmount, out nitOrCiFormatted);
            Console.WriteLine("Step1: ", verhoeffDigits);
            verhoeffDigits = verhoeffDigits.PadLeft(5, '0');

            //Step 2 and 3
            string partialAllegedRC4 = GetPartialAllegedRC4(verhoeffDigits, authorizationNumber, invoiceNumber, nitOrCiFormatted, transactionDate, transactionAmount, dosingKey);
            Console.WriteLine("Step2 and 3: ", partialAllegedRC4);

            //Step 4
            int[] sumOfAsciiValues = CalculatePartialSum(partialAllegedRC4);
            Console.WriteLine("Step4: ", sumOfAsciiValues);

            //Step 5 and 6
            int[] asciiValues = { sumOfAsciiValues[1], sumOfAsciiValues[2], sumOfAsciiValues[3], sumOfAsciiValues[4], sumOfAsciiValues[5] };
            string controlCode = GetFinalAllegedRC4(verhoeffDigits, asciiValues, dosingKey);
            Console.WriteLine("Step5 and 6: ", controlCode);

            return controlCode;
        }

        /// <summary>
        /// Adds verhoeff digit to an expecific number.
        /// </summary>
        /// <param name="number">To concat verhoeff digits.</param>
        /// <param name="digitsNumber">Number to add.</param>
        /// <param name="verhoeffDigits">Concat generated for number.</param>
        /// <returns>Number concat with verhoeff digits.</returns>
        internal static long AddVerhoeffDigit(this long number, int digitsNumber, out string verhoeffDigits)
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
        ///  Retrieves last 5 verhoeff digits.
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="nitOrCi">Client identification.</param>
        /// <param name="transactionDate">Date YYYYmmdd.</param>
        /// <param name="transactionAmount">Bill total.</param>
        /// <returns>Last 5 verhoeff digits.</returns>
        internal static string GetVerhoeffDigits(ref long invoiceNumber, ref long nitOrCi, ref long transactionDate, ref double transactionAmount, out string nitOrCiFormatted)
        {
            bool isNitOrCiZero = nitOrCi == 0;
            //Retrieve verhoeff digit per each bill data and concat it.
            string verhoeffDigits;
            invoiceNumber = invoiceNumber.AddVerhoeffDigit(2, out verhoeffDigits);
            nitOrCi = nitOrCi.AddVerhoeffDigit(2, out verhoeffDigits);
            transactionDate = transactionDate.AddVerhoeffDigit(2, out verhoeffDigits);
            transactionAmount = Convert.ToInt64(Math.Round(transactionAmount, MidpointRounding.AwayFromZero)).AddVerhoeffDigit(2, out verhoeffDigits);

            // Add bill data
            long total = invoiceNumber + nitOrCi + transactionDate + (long)transactionAmount;
            total.AddVerhoeffDigit(5, out verhoeffDigits);

            nitOrCiFormatted = nitOrCi.ToString();
            if (isNitOrCiZero)
            {
                nitOrCiFormatted = nitOrCiFormatted.PadLeft(3, '0');
            }

            // Return last five verhoeff digits
            return verhoeffDigits;
        }

        /// <summary>
        /// Gets partial allegedRC4 value.
        /// </summary>
        /// <param name="verhoeffDigits">the verhoeff digit generated previously.</param>
        /// <param name="authorizationNumber">number of authorization with verhoeff digits.</param>
        /// <param name="invoiceNumber">number of invoice with verhoeff digits.</param>
        /// <param name="nitOrCi">number of NIT or CI with verhoeff digits.</param>
        /// <param name="transactionDate">the transaction date with verhoeff digits.</param>
        /// <param name="transactionAmount">the transaction amount with verhoeff digits.</param>
        /// <param name="dosingKey">the dosing key.</param>
        /// <returns>A partial alleged RC4 value.</returns>
        internal static string GetPartialAllegedRC4(string verhoeffDigits, long authorizationNumber, long invoiceNumber, string nitOrCiFormatted, long transactionDate, double transactionAmount, string dosingKey)
        {
            List<string> splitDosingKey = new List<string>();
            string auxDosingKey = dosingKey;
            verhoeffDigits.ToList().ForEach(n =>
            {
                int verhoeffDigit = int.Parse(n.ToString());
                verhoeffDigit++;
                splitDosingKey.Add(auxDosingKey.Substring(0, verhoeffDigit));
                auxDosingKey = auxDosingKey.Substring(verhoeffDigit);
            });

            string concat = $"{authorizationNumber}{splitDosingKey.ElementAt(0)}{invoiceNumber}{splitDosingKey.ElementAt(1)}" +
                            $"{nitOrCiFormatted}{splitDosingKey.ElementAt(2)}{transactionDate}{splitDosingKey.ElementAt(3)}" +
                            $"{transactionAmount}{splitDosingKey.ElementAt(4)}";
            string newDosingKey = $"{dosingKey}{verhoeffDigits}";
            return helper.GetRC4Ciphertext(concat, newDosingKey).Replace("-", string.Empty);
        }

        /// <summary>
        /// Calculates partial sums of ASCII values.
        /// </summary>
        /// <param name="hash">Base64 encoded hash.</param>
        /// <returns>Array of integers that contains the partial sums.</returns>
        internal static int[] CalculatePartialSum(string hash)
        {
            int[] sumsArray = new int[6];
            byte[] asciiBytes = Encoding.ASCII.GetBytes(hash);
            Enumerable.Range(0, asciiBytes.Length).ToList().ForEach(n =>
            {
                sumsArray[0] += asciiBytes[n];
                sumsArray[n + 1 - 5 * (n / 5)] += asciiBytes[n];
            });
            return sumsArray;
        }

        /// <summary>
        /// Gets the final Alleged RC4 encoded string according to parameters.
        /// </summary>
        /// <param name="verhoeffDigits">Verhoeff digits.</param>
        /// <param name="partialSumsArray">Partials sums.</param>
        /// <param name="dosinKey">Dosing key.</param>
        /// <returns>Alleged RC4 encoded string.</returns>
        internal static string GetFinalAllegedRC4(string verhoeffDigits, int[] partialSumsArray, string dosinKey)
        {
            List<int> numbers = verhoeffDigits.Select(digit => int.Parse(digit.ToString())).ToList();
            int spIndex = 0;
            int totalTruncSum = 0;
            int totalSum = partialSumsArray.Sum();
            numbers.ForEach(number =>
            {
                totalTruncSum += ((totalSum * partialSumsArray[spIndex]) / (number + 1));
                spIndex++;
            });
            return helper.GetRC4Ciphertext(helper.GetBase64(totalTruncSum), $"{dosinKey}{verhoeffDigits}");
        }
    }
}
