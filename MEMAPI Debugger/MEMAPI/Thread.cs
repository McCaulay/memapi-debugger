using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public class Thread
    {
        public uint Id { get; }

        public Thread(uint id)
        {
            Id = id;
        }

        public string[] toArray()
        {
            return new string[] { Id.ToString() };
        }
    }
}
