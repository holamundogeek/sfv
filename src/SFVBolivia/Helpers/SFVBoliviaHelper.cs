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

        public void GetRC4Ciphertext()
        {
        }

        public string GetBase64(int number)
        {
            char[] charsetBase64 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E',
                                    'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                    'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                    'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                                    'y', 'z', '+', '/'};
            int quotient = number;
            StringBuilder encodedResult = new StringBuilder();
            do
            {
                encodedResult.Insert(0, charsetBase64[quotient % 64]);
                quotient = quotient / 64;
            }
            while (quotient > 0);
            return encodedResult.ToString();
        }

        public void GetQRCode()
        {
        }

        public void GetText()
        {
        }
    }
}
