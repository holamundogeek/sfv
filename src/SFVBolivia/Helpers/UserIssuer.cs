using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class UserIssuer : User
    {
        internal string Address { get; set; }

        internal UserIssuer(string name, long nitOrCiOrCiIssuer, string address)
        {
            this.Name = name;
            this.NitOrCi = nitOrCiOrCiIssuer;
            this.Address = address;
        }
    }
}
