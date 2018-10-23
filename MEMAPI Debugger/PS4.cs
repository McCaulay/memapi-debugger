using MEMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger
{
    [Serializable()]
    public class PS4
    {
        public string IP { get; set; }
        public string Name { get; set; }

        public PS4()
        {

        }

        public PS4(string name, string ip)
        {
            Name = name;
            IP = ip;
        }

        private string getStatus()
        {
            if (API.IP == IP)
                return API.isConnected() ? "Connected" : "Selected";
            return "Disconnected";
        }

        public string[] toArray()
        {
            return new string[] { Name, IP, getStatus() };
        }
    }
}
