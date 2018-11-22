using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    class Reader
    {
        /// <summary>
        /// Method that allows read a specific file
        /// </summary>
        /// <param name="path">It's related to file path</param>
        /// <returns>An array with information, otherwise null</returns>
        public string[] ReadFile(String path)
        {
            string[] lines = null;

            try
            {
                lines = File.ReadAllLines(@path, Encoding.UTF8);
            }
            catch (IOException)
            {
                Console.WriteLine("The File could not be readed.");
            }

            return lines;
        }
    }
}
