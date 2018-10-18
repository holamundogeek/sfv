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

        public String GetRC4Ciphertext(String message, String key)
        {
            int[] state = Enumerable.Range(0, 256).ToArray();
            return  MessageCipher(message, KeyCipher(key, state));
        }

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

        private String MessageCipher(string message, int[] state)
        {
            int index1 = 0, index2 = 0;
            String messageCipher = "";
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
