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

        public Bitmap GetQRCode(String value)
        {
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
