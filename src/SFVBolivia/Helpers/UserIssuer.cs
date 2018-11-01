using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class UserIssuer : User
    {
        private string address;
        public string Address { get; set; }

        public UserIssuer() {
            address = "";
        }

        public UserIssuer(string name, long nIT,  string address)
        {
            this.name = name;
            this.nit = nIT;
            this.address = address;
        }

       
    }
}
