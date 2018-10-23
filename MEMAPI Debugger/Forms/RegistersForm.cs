using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MEMAPI_Debugger.Dialogs;
using MEMAPI;

namespace MEMAPI_Debugger.Forms
{
    public partial class RegistersForm : Form
    {
        Registers registers;

        public RegistersForm()
        {
            InitializeComponent();

            registers = new Registers();

            // Events
            API.GoEvent += onGo;
            API.StoppedEvent += onStopped;
            API.SteppedEvent += onStepped;

            refresh();
        }

        private void onGo(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onGo), sender, e);
                return;
            }

            registers = new Registers();
            refresh(false);
        }

        private void onStopped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onStopped), sender, e);
                return;
            }

            refresh();
        }

        private void onStepped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onStepped), sender, e);
                return;
            }

            refresh();
        }

        private void refresh(bool download = true)
        {
            if (download)
            {
                API.ErrorCode error;
                if (!API.isConnected())
                    registers = new Registers();
                else
                    registers = API.getRegisters(out error);
            }

            string register = "register";
            string rip = "rip";
            string segment = "segment";
            string other = "other";

            listView.Items.Clear();

            addItem(register, "RAX: " + Helper.ulongToString(registers.rax));
            addItem(register, "RBX: " + Helper.ulongToString(registers.rbx));
            addItem(register, "RCX: " + Helper.ulongToString(registers.rcx));
            addItem(register, "RDX: " + Helper.ulongToString(registers.rdx));
            addItem(register, "RSI: " + Helper.ulongToString(registers.rsi));
            addItem(register, "RDI: " + Helper.ulongToString(registers.rdi));
            addItem(register, "RBP: " + Helper.ulongToString(registers.rbp));
            addItem(register, "RSP: " + Helper.ulongToString(registers.rsp));
            addItem(register, "R08: " + Helper.ulongToString(registers.r8));
            addItem(register, "R09: " + Helper.ulongToString(registers.r9));
            addItem(register, "R10: " + Helper.ulongToString(registers.r10));
            addItem(register, "R11: " + Helper.ulongToString(registers.r11));
            addItem(register, "R12: " + Helper.ulongToString(registers.r12));
            addItem(register, "R13: " + Helper.ulongToString(registers.r13));
            addItem(register, "R14: " + Helper.ulongToString(registers.r14));
            addItem(register, "R15: " + Helper.ulongToString(registers.r15));

            addItem(rip, "RIP: " + Helper.ulongToString(registers.rip));

            addItem(segment, "CS: " + Helper.ulongToString(registers.cs));
            addItem(segment, "DS: " + Helper.ushortToString(registers.ds));
            addItem(segment, "SS: " + Helper.ulongToString(registers.ss));
            addItem(segment, "ES: " + Helper.ushortToString(registers.es));
            addItem(segment, "FS: " + Helper.ushortToString(registers.fs));
            addItem(segment, "GS: " + Helper.ushortToString(registers.gs));

            addItem(other, "Flags: " + Helper.ulongToString(registers.rflags));
            addItem(other, "Trap: " + Helper.uintToString(registers.trapno));
            addItem(other, "Error: " + Helper.uintToString(registers.err));
        }

        private void addItem(string group, string value)
        {
            ListViewItem item = new ListViewItem(value);
            item.Group = getGroup(group);
            listView.Items.Add(item);
        }

        private ListViewGroup getGroup(string tag)
        {
            foreach (ListViewGroup group in listView.Groups)
            {
                if (group.Tag.ToString() == tag)
                    return group;
            }
            return null;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            copyToolStripMenuItem.Enabled = listView.SelectedItems.Count > 0;
            pasteToolStripMenuItem.Enabled = listView.SelectedItems.Count > 0;
            enterNewValueToolStripMenuItem.Enabled = listView.SelectedItems.Count == 1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach (ListViewItem item in listView.SelectedItems)
                toCopy += (item.Text.Split(new char[] { ' ' })[1]) + "\n";

            toCopy = toCopy.TrimEnd(new char[] { '\n' });
            if (toCopy != null && toCopy != "")
                Clipboard.SetText(toCopy);
        }

        private Registers setRegister(Registers regs, string register, string value)
        {
            switch (register)
            {
                case "RAX":
                    regs.rax = Convert.ToUInt64(value, 16);
                    break;
                case "RBX":
                    regs.rbx = Convert.ToUInt64(value, 16);
                    break;
                case "RCX":
                    regs.rcx = Convert.ToUInt64(value, 16);
                    break;
                case "RDX":
                    regs.rdx = Convert.ToUInt64(value, 16);
                    break;
                case "RSI":
                    regs.rsi = Convert.ToUInt64(value, 16);
                    break;
                case "RDI":
                    regs.rdi = Convert.ToUInt64(value, 16);
                    break;
                case "RBP":
                    regs.rbp = Convert.ToUInt64(value, 16);
                    break;
                case "RSP":
                    regs.rsp = Convert.ToUInt64(value, 16);
                    break;
                case "R08":
                    regs.r8 = Convert.ToUInt64(value, 16);
                    break;
                case "R09":
                    regs.r9 = Convert.ToUInt64(value, 16);
                    break;
                case "R10":
                    regs.r10 = Convert.ToUInt64(value, 16);
                    break;
                case "R11":
                    regs.r11 = Convert.ToUInt64(value, 16);
                    break;
                case "R12":
                    regs.r12 = Convert.ToUInt64(value, 16);
                    break;
                case "R13":
                    regs.r13 = Convert.ToUInt64(value, 16);
                    break;
                case "R14":
                    regs.r14 = Convert.ToUInt64(value, 16);
                    break;
                case "R15":
                    regs.r15 = Convert.ToUInt64(value, 16);
                    break;
                case "RIP":
                    regs.rip = Convert.ToUInt64(value, 16);
                    break;
                case "CS":
                    regs.cs = Convert.ToUInt64(value, 16);
                    break;
                case "DS":
                    regs.ds = Convert.ToUInt16(value, 16);
                    break;
                case "SS":
                    regs.ss = Convert.ToUInt64(value, 16);
                    break;
                case "ES":
                    regs.ds = Convert.ToUInt16(value, 16);
                    break;
                case "FS":
                    regs.ds = Convert.ToUInt16(value, 16);
                    break;
                case "GS":
                    regs.ds = Convert.ToUInt16(value, 16);
                    break;
                case "Flags":
                    regs.rflags = Convert.ToUInt64(value, 16);
                    break;
                case "Trap":
                    regs.trapno = Convert.ToUInt32(value, 16);
                    break;
                case "Error":
                    regs.err = Convert.ToUInt32(value, 16);
                    break;
            }
            return regs;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] values = Clipboard.GetText().Split(new char[] { '\r', '\n' });
            if (values.Length != listView.SelectedItems.Count)
            {
                MessageBox.Show("Number of values in clipboard (" + values.Length + ") does not match the number of paste registers (" + listView.SelectedItems.Count + ").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            API.ErrorCode error;
            Registers regs = API.getRegisters(out error);

            if (error != API.ErrorCode.NO_ERROR)
                return;

            int i = 0;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                try
                {
                    string[] itemSplit = item.Text.Split(new char[] { ':' });
                    string register = itemSplit[0];
                    regs = setRegister(regs, register, values[i]);
                }
                catch { }
                i++;
            }

            API.setRegisters(regs);
            refresh();
        }

        private void enterNewValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView.SelectedItems[0];

            API.ErrorCode error;
            Registers regs = API.getRegisters(out error);

            if (error != API.ErrorCode.NO_ERROR)
                return;

            StringDialog dialog = new StringDialog("Enter new register value");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] itemSplit = item.Text.Split(new char[] { ':' });
                    string register = itemSplit[0];
                    regs = setRegister(regs, register, dialog.Message);
                    API.setRegisters(regs);
                    refresh();
                }
                catch { }
            }
        }
    }
}
