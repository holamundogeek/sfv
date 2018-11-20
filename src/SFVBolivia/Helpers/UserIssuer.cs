using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class UserIssuer : User
    {

        public string Address { get; set; }

        public UserIssuer(string name, long nIT,  string address)
        {
            this.Name = name;
            this.NIT = nIT;
            this.Address = address;
        }

       
    }
}
