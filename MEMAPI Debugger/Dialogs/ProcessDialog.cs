using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MEMAPI;

namespace MEMAPI_Debugger.Dialogs
{
    public partial class ProcessDialog : Form
    {
        public Process process { get; set; }

        private List<Process> processes;

        public ProcessDialog()
        {
            InitializeComponent();
            process = null;
            refresh();
        }

        private void refresh()
        {
            API.ErrorCode error;
            processes = API.getProcesses(out error);

            listViewProcesses.Items.Clear();
            for (int i = processes.Count - 1; i >= 0; i--)
                listViewProcesses.Items.Add(new ListViewItem(processes[i].toArray()));
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (process == null)
            {
                MessageBox.Show("No Process has been selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void listViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count == 0)
                return;

            ListViewItem item = listViewProcesses.SelectedItems[0];
            process = new Process(Convert.ToInt32(item.SubItems[0].Text), item.SubItems[1].Text);
        }

        private void listViewProcesses_DoubleClick(object sender, EventArgs e)
        {
            if (process == null)
                return;

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listViewProcesses_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Disable column resizing
            e.Cancel = true;
            e.NewWidth = listViewProcesses.Columns[e.ColumnIndex].Width;
        }
    }
}
