using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class UserIssuer : User
    {
        private String address;
        public String Address { get; set; }

        public UserIssuer() {
            Address = "";
        }

        public UserIssuer(string name, long nIT,  string address)
        {
            this.name = name;
            this.nit = nIT;
            this.address = address;
        }

       
    }
}
