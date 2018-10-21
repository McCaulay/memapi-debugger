using MEMAPI_Debugger.MEMAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMAPI_Debugger.Dialogs
{
    public partial class AddHardwareBreakpointDialog : Form
    {
        public HardwareBreakpoint breakpoint { get; set; }

        public AddHardwareBreakpointDialog()
        {
            InitializeComponent();
            breakpoint = new HardwareBreakpoint();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ulong address = 0;
            try
            {
                address = Convert.ToUInt64(textBoxAddress.Text, 16);
            }
            catch
            {
                showError("Address is in an invalid format.");
                return;
            }

            if (comboBoxLength.SelectedIndex == -1)
            {
                showError("Invalid length selected.");
                return;
            }

            breakpoint.Address = address;

            if (radioButtonExecute.Checked)
                breakpoint.Type = HardwareBreakpoint.Flags.EXECUTE;
            else if (radioButtonReadWrite.Checked)
                breakpoint.Type = HardwareBreakpoint.Flags.READ_WRITE;
            else if (radioButtonWrite.Checked)
                breakpoint.Type = HardwareBreakpoint.Flags.WRITE;

            switch (comboBoxLength.SelectedIndex)
            {
                case 0:
                    breakpoint.ByteLength = HardwareBreakpoint.Length.ONE;
                    break;
                case 1:
                    breakpoint.ByteLength = HardwareBreakpoint.Length.TWO;
                    break;
                case 2:
                    breakpoint.ByteLength = HardwareBreakpoint.Length.FOUR;
                    break;
                case 3:
                    breakpoint.ByteLength = HardwareBreakpoint.Length.EIGHT;
                    break;
            }

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void showError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
