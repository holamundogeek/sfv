using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class SFVBoliviaHelper
    {
        public void GetVerhoeffCheckDigit()
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
            return  MessageCipher(message, KeyCipher(key, state));
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
            foreach (int i in Enumerable.Range(0, 256)) {
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

        public void GetBase64()
        {
        }

        public void GetQRCode()
        {
        }

        public void GetText()
        {
        }
    }
}
