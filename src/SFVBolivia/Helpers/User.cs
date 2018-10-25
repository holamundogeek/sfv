using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class User
    {
        protected long nit;
        public long NIT { get; set; }

        protected string name;
        public string Name { get; set; }

        public User()
        {
            this.name = "";
            this.nit = 0;
        }
        public User(string name, long nIT)
        {
            this.nit = nIT;
            this.name = name;
        }

    }
}
