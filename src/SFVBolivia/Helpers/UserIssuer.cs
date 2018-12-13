using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    internal class UserIssuer : User
    {
        internal string Address { get; set; }

        internal UserIssuer(string name, long NIT, string address)
        {
            this.Name = name;
            this.NIT = NIT;
            this.Address = address;
        }
    }
}
