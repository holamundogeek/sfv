using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class User
    {
        protected long nIT;
        protected string name;

        public User()
        {
            this.name = "";
            this.nIT = 0;
        }
        public User(string name, long nIT)
        {
            this.nIT = nIT;
            this.name = name;
        }

        public int MyProperty { get; set; }

    }
}
