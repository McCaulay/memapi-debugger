using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMAPI_Debugger.Forms
{
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent();

            // Custom Font
            consoleOutput.Font = Resource.getCustomFont(Resource.monospace);

            MEMAPI.Server.ServerQueueUpdated += c_ServerQueueUpdated;
        }

        

        private void c_ServerQueueUpdated(object sender, EventArgs e)
        {
            if (consoleOutput.InvokeRequired)
            {
                Invoke(new MethodInvoker(() => {
                    consoleOutput.Lines = MEMAPI.Server.lines.ToArray();
                    consoleOutput.SelectionStart = consoleOutput.Text.Length;
                    consoleOutput.ScrollToCaret();
                }));
                return;
            }
            consoleOutput.Lines = MEMAPI.Server.lines.ToArray();
            consoleOutput.SelectionStart = consoleOutput.Text.Length;
            consoleOutput.ScrollToCaret();
        }
    }
}
