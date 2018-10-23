using MEMAPI;
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
    public partial class HardwareBreakpointDialog : Form
    {
        public List<HardwareBreakpoint> breakpoints{ get; set; }

        public HardwareBreakpointDialog()
        {
            InitializeComponent();
            breakpoints = new List<HardwareBreakpoint>();
        }

        public void updateList()
        {
            refresh();
        }

        private void refresh()
        {
            listViewBreakpoints.Items.Clear();
            for (int i = 0; i < breakpoints.Count; i++)
                listViewBreakpoints.Items.Add(new ListViewItem(breakpoints[i].toArray()));
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            addToolStripMenuItem.Enabled = listViewBreakpoints.Items.Count < 4;
            removeToolStripMenuItem.Enabled = listViewBreakpoints.SelectedItems.Count > 0;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (breakpoints.Count >= 4)
            {
                MessageBox.Show("You can only have a maximum of 4 hardware breakpoints set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddHardwareBreakpointDialog dialog = new AddHardwareBreakpointDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.breakpoint.Index = breakpoints.Count;
                breakpoints.Add(dialog.breakpoint);
                refresh();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewBreakpoints.SelectedItems.Count == 0)
                return;

            breakpoints.RemoveAt(Convert.ToInt32(listViewBreakpoints.SelectedItems[0].SubItems[0].Text));

            refresh();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
