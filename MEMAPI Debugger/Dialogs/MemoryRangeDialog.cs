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
    public partial class MemoryRangeDialog : Form
    {
        public MemoryRange Range { get; set; }

        public MemoryRangeDialog()
        {
            InitializeComponent();
            Range = new MemoryRange();
        }

        public void updateFields()
        {
            textBoxFrom.Text = "0x" + Helper.ulongToString(Range.Start, false);
            textBoxTo.Text = "0x" + Helper.ulongToString(Range.End, false);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MemoryRange tempRange = new MemoryRange();
            try
            {
                ulong start = Convert.ToUInt64(textBoxFrom.Text, 16);
                ulong end = Convert.ToUInt64(textBoxTo.Text, 16);

                if (start >= end)
                {
                    MessageBox.Show("End address must be after the start address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tempRange = new MemoryRange(start, end);
            }
            catch
            {
                MessageBox.Show("Memory range is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Range = tempRange;

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
