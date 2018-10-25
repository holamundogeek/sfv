using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
  public class SFVBoliviaHelper
  {
    int[,] multiply = new int[,] { { 0,1,2,3,4,5,6,7,8,9 },
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
    int[,] permuta = new int[8, 10] { { 0,1,2,3,4,5,6,7,8,9 },
                                      { 1,5,7,6,2,8,3,0,9,4 },
                                      { 5,8,0,3,7,9,6,1,4,2 },
                                      { 8,9,1,6,0,4,3,5,2,7 },
                                      { 9,4,5,3,1,2,6,8,7,0 },
                                      { 4,2,8,6,5,7,3,9,0,1 },
                                      { 2,7,9,3,8,0,6,4,1,5 },
                                      { 7,0,4,6,9,1,3,2,5,8 }
                                    };
    int[] inv = new int[] { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

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

    public void GetRC4Ciphertext()
    {
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
