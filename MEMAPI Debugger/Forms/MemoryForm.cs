using MEMAPI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MEMAPI_Debugger.Dialogs;
using System.IO;
using System.Runtime.InteropServices;

namespace MEMAPI_Debugger.Forms
{
    public partial class MemoryForm : Form
    {
        private ulong addressPointer;
        private ulong? lastFollowPointer;
        private int itemsPerRow;
        private byte[] previousMemory;
        private byte[] memory;
        private ulong downloadSize;
        private ulong downloadChunk;

        public MemoryForm()
        {
            InitializeComponent();
            dataGridView.DefaultCellStyle.Font = new Font(FontFamily.GenericMonospace, 8);

            downloadSize = 0xC00;
            downloadChunk = 0x400;
            lastFollowPointer = null;

            memory = new byte[downloadSize];
            previousMemory = new byte[downloadSize];

            // Events
            API.AttachedEvent += onAttached;
            API.DetachedEvent += onDetached;
            API.DisconnectEvent += onDisconnected;

            addressPointer = 0x400000;

            toolStripComboBoxColumns.SelectedIndex = 0;
        }

        private void onAttached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onAttached), sender, e);
                return;
            }

            toggleItems(true);
            refresh();
        }

        private void onDetached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDetached), sender, e);
                return;
            }

            toggleItems(false);
            refresh();
        }

        private void onDisconnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDisconnected), sender, e);
                return;
            }

            toggleItems(false);
            refresh();
        }

        private void toggleItems(bool enabled)
        {
            pasteToolStripMenuItem.Enabled = enabled;
            enterNewValueToolStripMenuItem.Enabled = enabled;
            fillMemoryWithAValueToolStripMenuItem.Enabled = enabled;
            loadMemoryToolStripMenuItem.Enabled = enabled;
            saveMemoryToolStripMenuItem.Enabled = enabled;
            followPointerToolStripMenuItem.Enabled = enabled;
            toolStripButtonTimer.Enabled = enabled;
            toolStripButtonRefresh.Enabled = enabled;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            refresh(null, true, false);
        }

        private void refresh(ulong? address = null, bool download = true, bool adjustScroll = true)
        {
            int bytesPerRow = getBytesPerRow();

            if (address == null)
                address = addressPointer;

            if (download)
            {
                if (!API.isAttached())
                    memory = new byte[downloadSize];
                else
                {
                    API.ErrorCode error = API.ErrorCode.NO_ERROR;
                    for (ulong offset = 0; offset < downloadSize; offset += downloadChunk)
                    {
                        byte[] buffer = API.read<byte>((addressPointer - (downloadSize / 3)) + offset, (int)downloadChunk, out error);
                        if (error != API.ErrorCode.NO_ERROR)
                            buffer = new byte[downloadChunk];
                        Array.Copy(buffer, 0, memory, (int)offset, (int)downloadChunk);
                    }
                }
            }

            int downloadAddressIndex = -1;
            int previousTopRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;

            // Clear Table
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Add Columns
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Width = 120 });
            for (int i = 0; i < bytesPerRow; i++)
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {
                    Width = 24,
                    DefaultCellStyle = new DataGridViewCellStyle() {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Width = 10 + (bytesPerRow * 7) });

            // Add Rows
            int row = 0;
            for (ulong offset = 0; (offset + (ulong)bytesPerRow) < (ulong)memory.Length; offset += (ulong)bytesPerRow)
            {
                ulong curAddress = (addressPointer - (ulong)(downloadSize / 3)) + offset;
                object[] items = new object[bytesPerRow + 2];
                items[0] = ((curAddress).ToString("x").ToUpper()).PadLeft(16, '0');

                if ((offset + (ulong)bytesPerRow) < (ulong)memory.Length)
                {
                    ulong nextAddress = (addressPointer - (ulong)(downloadSize / 3)) + (offset + (ulong)bytesPerRow);
                    if (curAddress <= addressPointer && nextAddress >= addressPointer)
                        downloadAddressIndex = row;
                }

                for (int i = 0; i < bytesPerRow; i++)
                {
                    if ((int)offset + i >= memory.Length)
                    {
                        items[i + 1] = " ";
                        continue;
                    }

                    items[i + 1] = BitConverter.ToString(new byte[] { memory[offset + (ulong)i] }).PadLeft(2, '0');
                }

                int len = bytesPerRow;
                if ((int)offset + len >= memory.Length)
                    len = memory.Length - (int)offset;
                items[bytesPerRow + 1] = getGridString(API.splitByteArray(memory, (int)offset, len));

                dataGridView.Rows.Add(items);

                // Apply colour if changed
                for (int i = 0; i < bytesPerRow; i++)
                {
                    byte currentByte = memory[offset + (ulong)i];
                    byte previousByte = previousMemory[offset + (ulong)i];
                    bool hasMemoryChanged = (currentByte != previousByte);
                    dataGridView.Rows[row].Cells[i + 1].Style.ForeColor = hasMemoryChanged ? Color.Red : Color.Black;
                }
                row++;
            }

            if (adjustScroll)
            {
                if (downloadAddressIndex != -1)
                    dataGridView.FirstDisplayedScrollingRowIndex = downloadAddressIndex;
            }
            else
                dataGridView.FirstDisplayedScrollingRowIndex = previousTopRowIndex;

            previousMemory = memory;
        }

        private string getGridString(byte[] data)
        {
            string builder = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x20 && data[i] <= 0x7E)
                    builder += Encoding.ASCII.GetString(new byte[] { data[i] });
                else
                    builder += '.';
            }
            return builder;
        }

        private int getBytesPerRow()
        {
            return itemsPerRow != -1 ? itemsPerRow : (int)Math.Floor((double)(dataGridView.Width - 120 - 10) / (double)(7 + 24 + 1));
        }

        private void toolStripComboBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            e.Handled = true;

            try
            {
                addressPointer = Convert.ToUInt64(toolStripComboBoxAddress.Text, 16);
                toolStripComboBoxAddress.Items.Insert(0, toolStripComboBoxAddress.Text);
                refresh();
            }
            catch
            {
                MessageBox.Show("Address is in an invalid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBoxAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxAddress.SelectedIndex == -1)
                return;

            string address = toolStripComboBoxAddress.Items[toolStripComboBoxAddress.SelectedIndex].ToString();

            addressPointer = Convert.ToUInt64(address, 16);
            refresh();
        }

        private void toolStripComboBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxColumns.SelectedIndex == -1)
                return;

            string item = toolStripComboBoxColumns.Items[toolStripComboBoxColumns.SelectedIndex].ToString();

            autoToolStripMenuItem.Checked = toolStripComboBoxColumns.SelectedIndex == 0;
            byteToolStripMenuItem.Checked = toolStripComboBoxColumns.SelectedIndex == 1;
            bytesToolStripMenuItemTwo.Checked = toolStripComboBoxColumns.SelectedIndex == 2;
            bytesToolStripMenuItemFour.Checked = toolStripComboBoxColumns.SelectedIndex == 3;
            bytesToolStripMenuItemEight.Checked = toolStripComboBoxColumns.SelectedIndex == 4;
            bytesToolStripMenuItemSixteen.Checked = toolStripComboBoxColumns.SelectedIndex == 5;
            bytesToolStripMenuItemThirtyTwo.Checked = toolStripComboBoxColumns.SelectedIndex == 6;

            if (item == "Auto")
                itemsPerRow = -1;
            else
                itemsPerRow = Convert.ToInt32(item);
            refresh();
        }

        private void MemoryForm_ResizeEnd(object sender, EventArgs e)
        {
            refresh(null, false);
        }

        private void MemoryForm_Resize(object sender, EventArgs e)
        {
            refresh(null, false);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;

            ulong? cellAddress = getSelectedCellAddress();
            ulong? cellPtr = getSelectedCellPointer();
            if (cellPtr != null)
                followPointerToolStripMenuItem.Text = "Follow pointer (0x" + ((ulong)cellPtr).ToString("x").ToUpper() + ")";
            else
                followPointerToolStripMenuItem.Text = "Follow pointer";

            if (API.isAttached())
            {
                followPointerToolStripMenuItem.Enabled = cellPtr != null;
                undoFollowPointerToolStripMenuItem.Enabled = lastFollowPointer != null;

                enterNewValueToolStripMenuItem.Enabled = cellAddress != null;
                pasteToolStripMenuItem.Enabled = cellAddress != null;
            }
            else
            {
                followPointerToolStripMenuItem.Enabled = false;
                undoFollowPointerToolStripMenuItem.Enabled = false;

                enterNewValueToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Helper.stringToByteArray(Clipboard.GetText());
                ulong cellAddress = (ulong)getSelectedCellAddress();
                API.write(cellAddress, data);
                refresh(null, true, false);
            }
            catch
            {
                MessageBox.Show("The copied text was not in a valid byte array format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 0;
        private void byteToolStripMenuItem_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 1;
        private void bytesToolStripMenuItemTwo_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 2;
        private void bytesToolStripMenuItemFour_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 3;
        private void bytesToolStripMenuItemEight_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 4;
        private void bytesToolStripMenuItemSixteen_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 5;
        private void bytesToolStripMenuItemThirtyTwo_Click(object sender, EventArgs e) => toolStripComboBoxColumns.SelectedIndex = 6;
        
        private void enterNewValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ulong? cellAddress = getSelectedCellAddress();
            if (cellAddress == null)
                return;

            MixedValueDialog dialog = new MixedValueDialog("Write to memory");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dynamic newVariable = Convert.ChangeType(dialog.Variable, dialog.VariableType);
                API.write((ulong)cellAddress, newVariable);
                refresh(null, true, false);
            }
        }

        private void fillMemoryWithAValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ulong? cellAddress = getSelectedCellAddress();
            if (cellAddress == null)
                return;

            MemoryRangeDialog dialog = new MemoryRangeDialog();
            dialog.Range.Start = (ulong)cellAddress;
            dialog.updateFields();

            MixedValueDialog mvDialog = new MixedValueDialog("Value to insert");

            if (dialog.ShowDialog() == DialogResult.OK && mvDialog.ShowDialog() == DialogResult.OK)
            {
                dynamic newVariable = Convert.ChangeType(mvDialog.Variable, mvDialog.VariableType);
                ulong newVariableSize = (ulong)Marshal.SizeOf(newVariable);

                for (ulong address = dialog.Range.Start; address < dialog.Range.End; address += newVariableSize)
                    API.write(address, newVariable);

                refresh(null, true, false);
            }
        }

        private void followPointerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ulong? address = getSelectedCellPointer();
            if (address == null)
                return;

            lastFollowPointer = addressPointer;
            addressPointer = (ulong)address;
            toolStripComboBoxAddress.Items.Insert(0, "0x" + addressPointer.ToString("x").ToUpper());
            refresh();
        }

        private ulong? getSelectedCellAddress()
        {
            DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;
            if (cells.Count != 1)
                return null;

            DataGridViewCell cell = cells[0];

            if (cell.ColumnIndex == dataGridView.ColumnCount - 1)
                return null;

            // Selected Address
            if (cell.ColumnIndex == 0)
                return Convert.ToUInt64(cell.Value.ToString(), 16);

            // Select value, so get address of value
            ulong offset = (ulong)((cell.ColumnIndex - 1) + (cell.RowIndex * getBytesPerRow()));
            return (addressPointer - (downloadChunk)) + offset;
        }

        private ulong? getSelectedCellPointer()
        {
            DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;
            if (cells.Count != 1)
                return null;

            DataGridViewCell cell = cells[0];

            if (cell.ColumnIndex == 0 || cell.ColumnIndex == dataGridView.ColumnCount - 1)
                return null;

            int offset = (cell.ColumnIndex - 1) + (cell.RowIndex * getBytesPerRow());
            if (offset + 7 >= memory.Length)
                return null;

            return API.convertFromBytes<ulong>(API.splitByteArray(memory, offset, 8));
        }

        private void undoFollowPointerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastFollowPointer == null)
                return;

            addressPointer = (ulong)lastFollowPointer;
            lastFollowPointer = null;
            refresh();
        }

        private void lockToAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockToAddressToolStripMenuItem.Checked = !lockToAddressToolStripMenuItem.Checked;
            toolStripButtonLock.Checked = lockToAddressToolStripMenuItem.Checked;
            toolStripButtonLock.Image = lockToAddressToolStripMenuItem.Checked ? Properties.Resources._lock : Properties.Resources.unlock;
        }

        private void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (lockToAddressToolStripMenuItem.Checked)
                e.NewValue = e.OldValue;
        }

        private void loadMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Binary File|*.bin|All Files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ulong cellAddress = (ulong)getSelectedCellAddress();
                API.write(cellAddress, File.ReadAllBytes(dialog.FileName));
                refresh(null, true, false);
            }
        }

        private void saveMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringDialog stDialog = new StringDialog("Enter the number of bytes you want to save...");
            if (stDialog.ShowDialog() == DialogResult.OK)
            {
                int byteLength = 0;
                try
                {
                    byteLength = Convert.ToInt32(stDialog.Message, 16);
                }
                catch
                {
                    MessageBox.Show("The entered value was not a valid hex number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Binary File|*.bin|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ulong cellAddress = (ulong)getSelectedCellAddress();
                    API.ErrorCode error;
                    File.WriteAllBytes(dialog.FileName, API.read<byte>(cellAddress, byteLength, out error));
                }
            }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && dataGridView.SelectedCells.Count <= 1)
            {
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView.Focus();
            }
        }

        private void toolStripButtonTimer_Click(object sender, EventArgs e)
        {
            toolStripButtonTimer.Checked = !toolStripButtonTimer.Checked;
            toolStripButtonTimer.Image = toolStripButtonTimer.Checked ? Properties.Resources.timer_on : Properties.Resources.timer_off;
            timerAutoRefresh.Enabled = toolStripButtonTimer.Checked;
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            refresh(null, true, false);
        }

        private void toolStripButtonLock_Click(object sender, EventArgs e)
        {
            toolStripButtonLock.Checked = !toolStripButtonLock.Checked;
            toolStripButtonLock.Image = toolStripButtonLock.Checked ? Properties.Resources._lock : Properties.Resources.unlock;
            lockToAddressToolStripMenuItem.Checked = toolStripButtonLock.Checked;
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
    }
}
