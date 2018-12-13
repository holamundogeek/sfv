using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFVBolivia.Helpers
{
    public class User
    {

        protected long NitOrCi { get; set; }
        
        protected string Name { get; set; }

        internal User()
        {
            this.Name = "";
            this.NitOrCi = 0;
        }

        internal User(string name, long nIT)
        {
            this.NitOrCi = nIT;
            this.Name = name;
        }
    }
}
