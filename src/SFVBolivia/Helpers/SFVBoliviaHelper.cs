using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;

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

        public void GetBase64()
        {
        }


        /// <summary>
        /// This method generate QRCodeImage as of String value send it as parameter.
        /// </summary>
        /// <param name="value">through this String QRCode will be created</param>
        /// <returns>if String value is not null/empty return Bitmap entity, otherwise throw ArgumentException</returns>
        public Bitmap GetQRCode(String value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("String value: " + value + " " + "should not be null or empty.");
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            
            return qrCodeImage;
        }

        public void GetText()
        {
        }
    }
}
