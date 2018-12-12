using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class User
    {
        
        protected long NIT { get; set; }

        
        protected string Name { get; set; }

        public User()
        {
            this.Name = "";
            this.NIT = 0;
        }
        public User(string name, long nIT)
        {
            this.NIT = nIT;
            this.Name = name;
        }

    }
}
