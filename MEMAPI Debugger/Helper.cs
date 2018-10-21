using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger
{
    public static class Helper
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string ulongToString(ulong input, bool padding = true)
        {
            string output = input.ToString("x").ToUpper();
            if (padding)
                output = output.PadLeft(16, '0');
            return output;
        }

        public static string uintToString(uint input, bool padding = true)
        {
            string output = input.ToString("x").ToUpper();
            if (padding)
                output = output.PadLeft(8, '0');
            return output;
        }

        public static string ushortToString(ushort input, bool padding = true)
        {
            string output = input.ToString("x").ToUpper();
            if (padding)
                output = output.PadLeft(4, '0');
            return output;
        }

        public static string sizeToSuffix(ulong value, int decimalPlaces = 1)
        {
            int i = 0;
            decimal dValue = value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]).Replace(".0", "");
        }

        public static byte[] stringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "").Replace("\t", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
