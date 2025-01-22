using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП
{
    public class Registry
    {
        public Guid Id { get; private set; }
        protected Registry()
        {
            Id = Guid.NewGuid();
        }
    }
}
