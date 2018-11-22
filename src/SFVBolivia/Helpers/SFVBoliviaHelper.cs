﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFVBolivia.Helpers
{
    public class SFVBoliviaHelper
    {
        private int[,] multiply = { { 0,1,2,3,4,5,6,7,8,9 },
                                    { 1,2,3,4,0,6,7,8,9,5 },
                                    { 2,3,4,0,1,7,8,9,5,6 },
                                    { 3,4,0,1,2,8,9,5,6,7 },
                                    { 4,0,1,2,3,9,5,6,7,8 },
                                    { 5,9,8,7,6,0,4,3,2,1 },
                                    { 6,5,9,8,7,1,0,4,3,2 },
                                    { 7,6,5,9,8,2,1,0,4,3 },
                                    { 8,7,6,5,9,3,2,1,0,4 },
                                    { 9,8,7,6,5,4,3,2,1,0 }
                                  };

        private int[,] permuta = { { 0,1,2,3,4,5,6,7,8,9 },
                                   { 1,5,7,6,2,8,3,0,9,4 },
                                   { 5,8,0,3,7,9,6,1,4,2 },
                                   { 8,9,1,6,0,4,3,5,2,7 },
                                   { 9,4,5,3,1,2,6,8,7,0 },
                                   { 4,2,8,6,5,7,3,9,0,1 },
                                   { 2,7,9,3,8,0,6,4,1,5 },
                                   { 7,0,4,6,9,1,3,2,5,8 }
                                 };

        private char[] charsetBase64 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E',
                                        'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                        'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                                        'y', 'z', '+', '/'};

        private int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

        public void GetQRCode()
        {
        }

        public void GetText()
        {
        }

        /// <summary>
        /// Gets the RC4 cipher text.
        /// </summary>
        /// <param name="message"> Message to cipher.</param>
        /// <param name="key"> Key to cipher.</param>
        /// <returns>A Cipher text.</returns>
        public string GetRC4Ciphertext(string message, string key)
        {
            int[] state = Enumerable.Range(0, 256).ToArray();
            return MessageCipher(message, KeyCipher(key, state));
        }

        /// <summary>
        /// Get a Verhoeff digit by number.
        /// </summary>
        /// <param name="number"> Number to generate.</param>
        /// <returns>A Verhoeef digit.</returns>
        public int GetVerhoeffCheckDigit(string number)
        {
            int lastindex = number.Length - 1;
            int check = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int digitSrting = number[lastindex--] - 48;
                check = multiply[check, permuta[((i + 1) % 8), digitSrting]];
            }

            return inv[check];
        }

        /// <summary>
        /// Gets Base64 encoded representation.
        /// </summary>
        /// <param name="number">Number to be encoded.</param>
        /// <returns>Base64 encoded string.</returns>
        public string GetBase64(int number)
        {
            int quotient = number;
            StringBuilder encodedResult = new StringBuilder();
            do
            {
                encodedResult.Insert(0, this.charsetBase64[quotient % 64]);
                quotient = quotient / 64;
            }
            while (quotient > 0);

            return encodedResult.ToString();
        }

        /// <summary>
        /// Gets the Array state with the key cipher.
        /// </summary>
        /// <param name="key"> Key text to cipher.</param>
        /// <param name="state"> Array state.</param>
        /// <returns>A Array state with the key cipher</returns>
        private int[] KeyCipher(string key, int[] state)
        {
            int index1 = 0, index2 = 0;
            foreach (int i in Enumerable.Range(0, 256))
            {
                index2 = (key[index1] + state[i] + index2) % 256;
                state = Swap(state, index2, i);
                index1 = (index1 + 1) % key.Length;
            }

            return state;
        }

        /// <summary>
        /// Gets the text with the message cipher.
        /// </summary>
        /// <param name="message">Message text to cipher.</param>
        /// <param name="state">Array state with the key cipher</param>
        /// <returns>A text message cipher</returns>
        private string MessageCipher(string message, int[] state)
        {
            int index1 = 0, index2 = 0;
            StringBuilder messageCipher = new StringBuilder();
            foreach (int i in Enumerable.Range(0, message.Length))
            {
                index1 = (index1 + 1) % 256;
                index2 = (state[index1] + index2) % 256;
                state = Swap(state, index1, index2);
                string nMen = (message[i] ^ state[(state[index1] + state[index2]) % 256]).ToString("X");
                messageCipher.Append("-").Append(nMen.Length == 1 ? string.Concat("0", nMen) : nMen);
            }
            return messageCipher.ToString().Substring(1, messageCipher.Length - 1);
        }

        /// <summary>
        /// Swaps the values of two positions of the state array.
        /// </summary>
        /// <param name="state">State array.</param>
        /// <param name="index1">The first position to swap.</param>
        /// <param name="index2">The second position to swap.</param>
        /// <returns>The array state with the swap values</returns>
        private int[] Swap(int[] state, int index1, int index2)
        {
            int temp = state[index2];
            state[index2] = state[index1];
            state[index1] = temp;

            return state;
        }

        /// <summary>
        /// Convert a number to literal.
        /// </summary>
        /// <param name="number">is the number to converts.</param>
        /// <returns>literal of a number.</returns>
        public string ConvertToLiteral(int number) {
            StringBuilder result = new StringBuilder();
            Dictionary<int, string> seedNumbers = GetSeedNumbers();

            int partialNumber, exponent;
            while (number > 0) {
                exponent = CountDigits(number) - 1;
                
                if(seedNumbers.ContainsKey(number)) {
                    result.Append(seedNumbers[number]);
                } else {
                    partialNumber = number / ((int) System.Math.Pow(10, exponent)) * ((int) System.Math.Pow(10, exponent));
                    
                    if (IsMillionUnit(partialNumber)) {
                        string millionUnit = ConvertToLiteral(number/1000000);
                        string millionUnitLiteral = (millionUnit.Equals("Uno"))? " Millon " : " Millones ";
                        result.Append(millionUnit).Append(millionUnitLiteral);
                        number = number % 1000000;
                    } else if (IsThousandUnit(partialNumber)) {
                        result.Append(ConvertToLiteral(number/1000)).Append(" Mil ");
                        number = number % 1000;
                    } else if (IsTens(number)) {
                        result.Append(seedNumbers[partialNumber]).Append(" y ");
                    } else {
                        result.Append(seedNumbers[(partialNumber)]).Append(" ");
                    }
                }

                number = number % ((int) System.Math.Pow(10, exponent));
            }

            return result.ToString();
        }

        /// <summary>
        /// Count the number digits.
        /// </summary>
        /// <param name="number">is the number to counts.</param>
        /// <returns>the quantity of digits.</returns>
        private int CountDigits(int number) {
            int count = 0;
            while(number != 0){
                number /= 10;
                count ++;
            }

            return count;
        }

        /// <summary>
        /// Verify if a number is a tens.
        /// </summary>
        /// <param name="number">is the number to verify.</param>
        /// <returns>true if the number is a tens, otherwise false.</returns>
        private bool IsTens(int number)
        {
            return (number / 10 < 10) && (number / 10) != 0;
        }

        /// <summary>
        /// Verify if a number is a thousand unit.
        /// </summary>
        /// <param name="number">is the number to verify.</param>
        /// <returns>true if the number is a thousand unit, otherwise false.</returns>
        private bool IsThousandUnit(int number)
        {
            return (number / 1000) != 0;
        }

        /// <summary>
        /// Verify if a number is a million unit.
        /// </summary>
        /// <param name="number">is the number to verify.</param>
        /// <returns>true if the number is a million unit, otherwise false.</returns>
        private bool IsMillionUnit(int number)
        {
            return (number / 1000000) != 0;
        }

        /// <summary>
        /// Fill a dictionary with specific values.
        /// </summary>
        /// <returns>the dictionary filled.</returns>
        private Dictionary<int, string> GetSeedNumbers() {
            Dictionary<int, string> numbers = new Dictionary<int, string>();
            numbers.Add(0, "Cero");
            numbers.Add(1, "Uno");
            numbers.Add(2, "Dos");
            numbers.Add(3, "Tres");
            numbers.Add(4, "Cuatro");
            numbers.Add(5, "Cinco");
            numbers.Add(6, "Seis");
            numbers.Add(7, "Siete");
            numbers.Add(8, "Ocho");
            numbers.Add(9, "Nueve");
            numbers.Add(10, "Diez");

            numbers.Add(11, "Once");
            numbers.Add(12, "Doce");
            numbers.Add(13, "Trece");
            numbers.Add(14, "Catorce");
            numbers.Add(15, "Quince");
            numbers.Add(16, "Dieciseis");
            numbers.Add(17, "Diecisiete");
            numbers.Add(18, "Dieciocho");
            numbers.Add(19, "Diecinueve");

            numbers.Add(20, "Veinte");
            numbers.Add(30, "Treinta");
            numbers.Add(40, "Cuarenta");
            numbers.Add(50, "Cincuenta");
            numbers.Add(60, "Sesenta");
            numbers.Add(70, "Setenta");
            numbers.Add(80, "Ochenta");
            numbers.Add(90, "Noventa");

            numbers.Add(100, "Cien");
            numbers.Add(200, "Doscientos");
            numbers.Add(300, "Trescientos");
            numbers.Add(400, "Cuatrocientos");
            numbers.Add(500, "Quinientos");
            numbers.Add(600, "Seiscientos");
            numbers.Add(700, "Setecientos");
            numbers.Add(800, "Ochocientos");
            numbers.Add(900, "Novecientos");
           
            return numbers;
        }
    }
}