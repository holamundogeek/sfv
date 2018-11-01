using System.Linq;
using System.Text;
using System.Drawing;
using QRCoder;

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
        /// This method generate QRCodeImage as of String value send it as parameter.
        /// </summary>
        /// <param name="value">through this String QRCode will be created</param>
        /// <returns>if String value is not null/empty return Bitmap entity, otherwise throw ArgumentException</returns>
        public Bitmap GetQRCode(string value)
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
            string messageCipher = "";
            foreach (int i in Enumerable.Range(0, message.Length))
            {
                index1 = (index1 + 1) % 256;
                index2 = (state[index1] + index2) % 256;
                state = Swap(state, index1, index2);
                string nMen = (message[i] ^ state[(state[index1] + state[index2]) % 256]).ToString("X");
                messageCipher = messageCipher + "-" + (nMen.Length == 1 ? "0" + nMen : nMen);
            }

            return messageCipher.Substring(1, messageCipher.Length - 1);
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
    }
}