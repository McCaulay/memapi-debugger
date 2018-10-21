using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public class HardwareBreakpoint
    {
        public int Index { get; set; }
        public ulong Address { get; set; }
        public Length ByteLength { get; set; }
        public Flags Type { get; set; }

        public enum Length
        {
            ONE = 0,
            TWO = 1,
            FOUR= 3,
            EIGHT = 2,
        };

        public enum Flags
        {
            EXECUTE = 0,
            WRITE= 1,
            READ_WRITE = 3,
        };

        public HardwareBreakpoint()
        {

        }

        public HardwareBreakpoint(int index, ulong address, Length byteLength, Flags type)
        {
            Index = index;
            Address = address;
            ByteLength = byteLength;
            Type = type;
        }

        public string[] toArray()
        {
            return new string[] { Index.ToString(), Helper.ulongToString(Address, false), lengthToString(ByteLength), flagToString(Type) };
        }

        private string lengthToString(Length len)
        {
            switch (len)
            {
                case Length.ONE:
                    return "One Byte";
                case Length.TWO:
                    return "Two Bytes";
                case Length.FOUR:
                    return "Four Bytes";
                case Length.EIGHT:
                    return "Eight Bytes";
            }
            return "";
        }

        private string flagToString(Flags type)
        {
            switch (type)
            {
                case Flags.EXECUTE:
                    return "Execute";
                case Flags.READ_WRITE:
                    return "Read/Write";
                case Flags.WRITE:
                    return "Write";
            }
            return "";
        }
    }
}
