using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger
{
    public static class Resource
    {
        public static string monospace = "DejaVuSansMono";

        public static byte[] getResource(string name)
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MEMAPI_Debugger.Resources." + name);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, (int)fileStream.Length);
            fileStream.Close();
            return data;
        }

        public static Font getCustomFont(string resource, int fontSize = 12)
        {
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();

            // Get font
            byte[] data = Resource.getResource(resource + ".ttf");

            // Allocate a pointer and copy data
            System.IntPtr ptr = Marshal.AllocCoTaskMem((int)data.Length);
            Marshal.Copy(data, 0, ptr, (int)data.Length);

            // Add font
            privateFontCollection.AddMemoryFont(ptr, (int)data.Length);

            // Cleanup allocated memory
            Marshal.FreeCoTaskMem(ptr);

            return new Font(privateFontCollection.Families[0].Name, fontSize, FontStyle.Regular, GraphicsUnit.Pixel); ;
        }
    }
}
