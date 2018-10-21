using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public class Process
    {
        public int Id { get; }
        public string Name { get; }

        public Process(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string[] toArray()
        {
            return new string[] { Id.ToString(), Name };
        }
    }
}
