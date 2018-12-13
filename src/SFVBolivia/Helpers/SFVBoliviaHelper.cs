using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using QRCoder;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SFVBoliviaTest")]
namespace SFVBolivia.Helpers
{
    internal class SFVBoliviaHelper
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
        private Dictionary<int, string> seedNumbers = new Dictionary<int, string>
        {
            {0, "Cero"},
            {1, "Uno"},
            {2, "Dos"},
            {3, "Tres"},
            {4, "Cuatro"},
            {5, "Cinco"},
            {6, "Seis"},
            {7, "Siete"},
            {8, "Ocho"},
            {9, "Nueve"},
            {10, "Diez"},
            {11, "Once"},
            {12, "Doce"},
            {13, "Trece"},
            {14, "Catorce"},
            {15, "Quince"},
            {16, "Dieciseis"},
            {17, "Diecisiete"},
            {18, "Dieciocho"},
            {19, "Diecinueve"},
            {20, "Veinte"},
            {21, "Veintiuno"},
            {22, "Veintidos"},
            {23, "Veintitres"},
            {24, "Veinticuatro"},
            {25, "Veinticinco"},
            {26, "Veintiseis"},
            {27, "Veintisiete"},
            {28, "Veintiocho"},
            {29, "Veintinueve"},
            {30, "Treinta"},
            {40, "Cuarenta"},
            {50, "Cincuenta"},
            {60, "Sesenta"},
            {70, "Setenta"},
            {80, "Ochenta"},
            {90, "Noventa"},
            {100, "Cien"},
            {200, "Doscientos"},
            {300, "Trescientos"},
            {400, "Cuatrocientos"},
            {500, "Quinientos"},
            {600, "Seiscientos"},
            {700, "Setecientos"},
            {800, "Ochocientos"},
            {900, "Novecientos"}
        };

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
        internal string GetRC4Ciphertext(string message, string key)
        {
            int[] state = Enumerable.Range(0, 256).ToArray();
            return MessageCipher(message, KeyCipher(key, state));
        }


        /// <summary>
        /// This method generate QRCodeImage as of String value send it as parameter.
        /// </summary>
        /// <param name="value">through this String QRCode will be created</param>
        /// <returns>if String value is not null/empty return Bitmap entity, otherwise throw ArgumentException</returns>
        internal static Bitmap GetQRCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException("String value: " + value + " " + "should not be null or empty.");
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }

        /// <summary>
        /// Get a Verhoeff digit by number.
        /// </summary>
        /// <param name="number"> Number to generate.</param>
        /// <returns>A Verhoeef digit.</returns>
        internal int GetVerhoeffCheckDigit(string number)
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
        internal string GetBase64(int number)
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

            int partialNumber, exponent;
            while (number > 0) {
                exponent = number.ToString().Length - 1;

                if (seedNumbers.ContainsKey(number)) {
                    result.Append(seedNumbers[number]);
                } else {
                    partialNumber = number / ((int) System.Math.Pow(10, exponent)) * ((int) System.Math.Pow(10, exponent));
                    result.Append(BuildingThePartialNumber(ref number, partialNumber));
                }

                number = number % ((int)System.Math.Pow(10, exponent));
            }

            return result.ToString();
        }

        private string BuildingThePartialNumber(ref int number, int partialNumber)
        {
            StringBuilder result = new StringBuilder();

            if (IsMillionUnit(partialNumber))
            {
                string millionUnit = ConvertToLiteral(number / 1000000);
                string millionUnitLiteral = (millionUnit.Equals("Uno")) ? " Millon " : " Millones ";
                result.Append(millionUnit).Append(millionUnitLiteral);
                number = number % 1000000;
            }
            else if (IsThousandUnit(partialNumber))
            {
                result.Append(ConvertToLiteral(number / 1000)).Append(" Mil ");
                number = number % 1000;
            }
            else if (IsTens(number))
            {
                result.Append(seedNumbers[partialNumber]).Append(" y ");
            }
            else
            {
                result.Append(seedNumbers[(partialNumber)]).Append(" ");
            }

            return result.ToString();
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
    }
}
