using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MEMAPI_Debugger.MEMAPI;
using MEMAPI_Debugger.Dialogs;
using SharpDisasm;

namespace MEMAPI_Debugger.Forms
{
    public partial class DisassemblyForm : Form
    {
        private ulong addressPointer;
        private ulong? instructionPointer;
        private int instructionIndex;
        private byte[] memory;

        public DisassemblyForm()
        {
            InitializeComponent();
            listView.Font = Resource.getCustomFont(Resource.monospace);

            instructionPointer = null;

            // Events
            API.AttachedEvent += onAttached;
            API.GoEvent += onGo;
            API.SteppedEvent += onStepped;
            API.StoppedEvent += onStopped;

            addressPointer = 0x0;
            instructionIndex = -1;

            goToAddressToolStripMenuItem.Enabled = false;

            // Initialise Disassembler
            Disassembler.Translator.IncludeAddress = true;
            Disassembler.Translator.IncludeBinary = false;
        }

        private void onAttached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onAttached), sender, e);
                return;
            }
            // Check if it's paused, if so, then get RIP, otherwise leave blank...
        }

        private void onGo(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onGo), sender, e);
                return;
            }

            listView.Items.Clear();
            instructionPointer = null;
            goToAddressToolStripMenuItem.Enabled = false;
        }

        private void onStopped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onStopped), sender, e);
                return;
            }
            refreshAtInstructionPointer();
        }

        private void onStepped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onStepped), sender, e);
                return;
            }
            refreshAtInstructionPointer();
        }

        private void refreshAtInstructionPointer()
        {
            // Get RIP and insert into address param
            API.ErrorCode error;
            Registers regs = API.getRegisters(out error);
            instructionPointer = regs.rip;
            refresh(instructionPointer);
        }

        private void refresh(ulong? address = null)
        {
            if (address == null)
                address = addressPointer;

            goToAddressToolStripMenuItem.Enabled = false;
            listView.Items.Clear();
            if (!API.isConnected())
                return;

            API.ErrorCode error;
            memory = API.read<byte>((ulong)address - 0x100, 0x200, out error);
            if (error != API.ErrorCode.NO_ERROR)
                memory = new byte[0x200];

            Disassembler disasm = new Disassembler(memory, ArchitectureMode.x86_64, (ulong)(address - 0x100), true);

            instructionIndex = -1;
            IEnumerable<Instruction> instructions = disasm.Disassemble();
            for (int i = 0; i < instructions.Count(); i++)
            {
                Instruction instruction = instructions.ElementAt(i);

                string line = instruction.ToString();
                List<string> lines = new List<string>(line.Split(new char[] { ' ' }));

                string addr = lines[0];
                string opcode = lines[1];
                lines.RemoveRange(0, 2);
                string operands = string.Join(" ", lines);

                ListViewItem item = new ListViewItem(new string[] { addr, opcode, operands });

                ulong addrConverted = Convert.ToUInt64(addr, 16);
                bool isAtRip = instructionPointer == addrConverted;
                bool hasBreakpoint = false;

                if (addrConverted <= address)
                {
                    if (instructions.Count() == i + 1)
                        instructionIndex = i;
                    else
                    {
                        string nextInstruction = instructions.ElementAt(i + 1).ToString();
                        ulong nextInstructionAddress = Convert.ToUInt64(nextInstruction.Split(new char[] { ' ' })[0], 16);
                        if (nextInstructionAddress > address)
                            instructionIndex = i;
                    }
                }

                if (isAtRip && hasBreakpoint)
                    item.StateImageIndex = 3;
                else if (isAtRip)
                    item.StateImageIndex = 2;
                else if (hasBreakpoint)
                    item.StateImageIndex = 1;
                else
                    item.StateImageIndex = 0;

                listView.Items.Add(item);
            }

            if (instructionIndex != -1)
                listView.TopItem = listView.Items[instructionIndex];
            goToAddressToolStripMenuItem.Enabled = true;
        }

        private void goToAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringDialog dialog = new StringDialog("Go to address");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                addressPointer = Convert.ToUInt64(dialog.Message, 16);
                refresh();
            }
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
                e.Item.StateImageIndex = instructionIndex == e.Item.Index ? 3 : 1;
            else
                e.Item.StateImageIndex = instructionIndex == e.Item.Index ? 2 : 0;
        }
    }
}
