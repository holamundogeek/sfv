using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    internal class User
    {

        protected long NIT { get; set; }
        
        protected string Name { get; set; }

        internal User()
        {
            this.Name = "";
            this.NIT = 0;
        }

        internal User(string name, long nIT)
        {
            this.NIT = nIT;
            this.Name = name;
        }
    }
}
