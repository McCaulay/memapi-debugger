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
using static System.Windows.Forms.ListViewItem;

namespace MEMAPI_Debugger.Forms
{
    public partial class SearchForm : Form
    {
        private List<MemoryRange> regions;
        private Type lastSearchType;
        private int searchValueLength;

        public SearchForm()
        {
            InitializeComponent();
            listViewRanges.Font = new Font(FontFamily.GenericMonospace, 8);

            regions = new List<MemoryRange>();
            lastSearchType = null;
            searchValueLength = 0;

            // Events
            API.AttachedEvent += onAttached;
            API.DetachedEvent += onDetached;
            API.DisconnectEvent += onDisconnected;
        }

        private void onAttached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onAttached), sender, e);
                return;
            }

            toggleComponents(true);
            refreshRanges();
        }

        private void onDetached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDetached), sender, e);
                return;
            }

            toggleComponents(false);
            refreshRanges();
        }

        private void onDisconnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDisconnected), sender, e);
                return;
            }

            toggleComponents(false);
            refreshRanges();
        }

        private void toggleComponents(bool enabled)
        {
            buttonSearch.Enabled = enabled;
            textBoxFrom.Enabled = enabled;
            textBoxTo.Enabled = enabled;
            textBoxValue.Enabled = enabled;
            comboBoxType.Enabled = enabled;
        }

        private void refreshRanges()
        {
            if (!API.isAttached())
                regions = new List<MemoryRange>();
            else
            {
                API.ErrorCode error;
                regions = API.getRegions(out error);
            }

            listViewRanges.Items.Clear();
            foreach (MemoryRange range in regions)
            {
                listViewRanges.Items.Add(new ListViewItem(new string[] { Helper.ulongToString(range.Start), Helper.ulongToString(range.End) }));
            }
        }

        private void refreshResults(string value = "")
        {
            ulong[] results = API.getResults();
            listViewResults.Items.Clear();
            foreach (ulong result in results)
            {
                if (value == "")
                {
                    API.ErrorCode error;
                    switch (comboBoxType.SelectedIndex)
                    {
                        case 0:
                            value = BitConverter.ToString(API.read<byte>(result, searchValueLength, out error)).Replace("-", "");
                            break;
                        case 1:
                            value = API.read<int>(result, out error).ToString();
                            break;
                        case 2:
                            value = API.read<short>(result, out error).ToString();
                            break;
                        case 3:
                            value = Helper.longToString(API.read<long>(result, out error), false);
                            break;
                        case 4:
                            value = API.read<float>(result, out error).ToString();
                            break;
                        case 5:
                            value = API.read<double>(result, out error).ToString();
                            break;
                        case 6:
                            value = API.read<string>(result, out error);
                            break;
                        case 7:
                            value = API.read<uint>(result, out error).ToString();
                            break;
                        case 8:
                            value = API.read<ushort>(result, out error).ToString();
                            break;
                        case 9:
                            value = Helper.ulongToString(API.read<ulong>(result, out error), false);
                            break;
                    }
                }
                listViewResults.Items.Add(new ListViewItem(new string[] { Helper.ulongToString(result), value }));
            }
        }

        private void listViewRanges_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Disable column resizing
            e.Cancel = true;
            e.NewWidth = listViewRanges.Columns[e.ColumnIndex].Width;
        }

        private void contextMenuStripRegions_Opening(object sender, CancelEventArgs e)
        {
            copyToolStripMenuItem.Enabled = listViewRanges.SelectedItems.Count > 0;
            searchRegionToolStripMenuItem.Enabled = listViewRanges.SelectedItems.Count == 1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach (ListViewItem item in listViewRanges.SelectedItems)
            {
                foreach (ListViewSubItem subitem in item.SubItems)
                    toCopy += subitem.Text + "\t";
                toCopy = toCopy.TrimEnd(new char[] { '\t' });
                toCopy += "\r\n";
            }

            toCopy = toCopy.TrimEnd(new char[] { '\r', '\n' });
            if (toCopy != null && toCopy != "")
                Clipboard.SetText(toCopy);
        }

        private void searchRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewSubItemCollection items = listViewRanges.SelectedItems[0].SubItems;
            textBoxFrom.Text = "0x" + items[0].Text.TrimStart(new char[] { '0' });
            textBoxTo.Text = "0x" + items[1].Text.TrimStart(new char[] { '0' });
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            API.endSearch();

            ulong start = 0;
            ulong end = 0;
            dynamic variable = null;
            lastSearchType = null;

            try
            {
                start = Convert.ToUInt64(textBoxFrom.Text, 16);
                end = Convert.ToUInt64(textBoxTo.Text, 16);
            }
            catch
            {
                MessageBox.Show("Start and/or end address was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (end <= start)
            {
                MessageBox.Show("End address must be greater than the start address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a valid variable type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                switch (comboBoxType.SelectedIndex)
                {
                    case 0:
                        variable = Helper.stringToByteArray(textBoxValue.Text.Replace(" ", ""));
                        searchValueLength = variable.Length;
                        lastSearchType = typeof(byte[]);
                        break;
                    case 1:
                        variable = Convert.ToInt32(textBoxValue.Text);
                        lastSearchType = typeof(int);
                        break;
                    case 2:
                        variable = Convert.ToInt16(textBoxValue.Text);
                        lastSearchType = typeof(short);
                        break;
                    case 3:
                        variable = Convert.ToInt64(textBoxValue.Text);
                        lastSearchType = typeof(long);
                        break;
                    case 4:
                        variable = Convert.ToSingle(textBoxValue.Text);
                        lastSearchType = typeof(float);
                        break;
                    case 5:
                        variable = Convert.ToDouble(textBoxValue.Text);
                        lastSearchType = typeof(double);
                        break;
                    case 6:
                        variable = textBoxValue.Text;
                        lastSearchType = typeof(string);
                        break;
                    case 7:
                        variable = Convert.ToUInt32(textBoxValue.Text);
                        lastSearchType = typeof(uint);
                        break;
                    case 8:
                        variable = Convert.ToUInt16(textBoxValue.Text);
                        lastSearchType = typeof(ushort);
                        break;
                    case 9:
                        variable = Convert.ToUInt64(textBoxValue.Text);
                        lastSearchType = typeof(ulong);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Value is in an invalid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dynamic newVariable = Convert.ChangeType(variable, lastSearchType);
            API.search(start, end, newVariable);

            int numResults = API.getResultsCount();
            labelResultCount.Text = "Results: " + numResults.ToString();
            buttonRefreshResults.Enabled = numResults < 100;
            if (numResults < 100)
                refreshResults(textBoxValue.Text);
            buttonSearchResult.Enabled = true;
        }

        private void buttonSearchResult_Click(object sender, EventArgs e)
        {
            dynamic variable = null;
            Type variableType = null;

            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a valid variable type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                switch (comboBoxType.SelectedIndex)
                {
                    case 0:
                        variable = Helper.stringToByteArray(textBoxValue.Text.Replace(" ", ""));
                        variableType = typeof(byte[]);
                        break;
                    case 1:
                        variable = Convert.ToInt32(textBoxValue.Text);
                        variableType = typeof(int);
                        break;
                    case 2:
                        variable = Convert.ToInt16(textBoxValue.Text);
                        variableType = typeof(short);
                        break;
                    case 3:
                        variable = Convert.ToInt64(textBoxValue.Text);
                        variableType = typeof(long);
                        break;
                    case 4:
                        variable = Convert.ToSingle(textBoxValue.Text);
                        variableType = typeof(float);
                        break;
                    case 5:
                        variable = Convert.ToDouble(textBoxValue.Text);
                        variableType = typeof(double);
                        break;
                    case 6:
                        variable = textBoxValue.Text;
                        variableType = typeof(string);
                        break;
                    case 7:
                        variable = Convert.ToUInt32(textBoxValue.Text);
                        variableType = typeof(uint);
                        break;
                    case 8:
                        variable = Convert.ToUInt16(textBoxValue.Text);
                        variableType = typeof(ushort);
                        break;
                    case 9:
                        variable = Convert.ToUInt64(textBoxValue.Text);
                        variableType = typeof(ulong);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Value is in an invalid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dynamic newVariable = Convert.ChangeType(variable, variableType);
            API.rescan(newVariable);
            int numResults = API.getResultsCount();
            labelResultCount.Text = "Results: " + numResults.ToString();
            buttonRefreshResults.Enabled = numResults < 100;
            if (numResults < 100)
                refreshResults(textBoxValue.Text);
        }

        private void buttonRefreshResults_Click(object sender, EventArgs e)
        {
            int numResults = API.getResultsCount();
            labelResultCount.Text = "Results: " + numResults.ToString();
            if (numResults < 100)
                refreshResults();
        }

        private void contextMenuStripResults_Opening(object sender, CancelEventArgs e)
        {
            copyToolStripMenuItem1.Enabled = listViewResults.SelectedItems.Count > 0;
            copyAddressToolStripMenuItem.Enabled = listViewResults.SelectedItems.Count > 0;
            copyValueToolStripMenuItem.Enabled = listViewResults.SelectedItems.Count > 0;
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach (ListViewItem item in listViewResults.SelectedItems)
            {
                foreach (ListViewSubItem subitem in item.SubItems)
                    toCopy += subitem.Text + "\t";
                toCopy = toCopy.TrimEnd(new char[] { '\t' });
                toCopy += "\r\n";
            }

            toCopy = toCopy.TrimEnd(new char[] { '\r', '\n' });
            if (toCopy != null && toCopy != "")
                Clipboard.SetText(toCopy);
        }

        private void copyAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach (ListViewItem item in listViewResults.SelectedItems)
                toCopy += item.SubItems[0].Text + "\r\n";

            toCopy = toCopy.TrimEnd(new char[] { '\r', '\n' });
            if (toCopy != null && toCopy != "")
                Clipboard.SetText(toCopy);
        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach (ListViewItem item in listViewResults.SelectedItems)
                toCopy += item.SubItems[1].Text + "\r\n";

            toCopy = toCopy.TrimEnd(new char[] { '\r', '\n' });
            if (toCopy != null && toCopy != "")
                Clipboard.SetText(toCopy);
        }
    }
}
