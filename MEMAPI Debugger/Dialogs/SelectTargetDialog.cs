using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMAPI_Debugger.Dialogs
{
    public partial class SelectTargetDialog : Form
    {
        public string IP { get; set; }

        private List<PS4> ps4s;

        public SelectTargetDialog()
        {
            InitializeComponent();
            ps4s = new List<PS4>();
            loadPS4s();
            refresh();
        }

        private void loadPS4s()
        {
            ps4s.Clear();

            if (Properties.Settings.Default.ps4s == null || Properties.Settings.Default.ps4s == "")
                return;

            try
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.ps4s)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    ps4s = (List<PS4>)bf.Deserialize(ms);
                }
            }
            catch
            {
                Properties.Settings.Default.ps4s = "";
                Properties.Settings.Default.Save();
            }
        }

        private void savePS4s()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, ps4s);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.ps4s = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }

        private void findTargets()
        {
            if (!backgroundWorkerFindTargets.IsBusy)
            {
                Height = 335;
                buttonOk.Enabled = false;
                buttonCancel.Enabled = false;
                buttonRefresh.Enabled = false;
                buttonFindTargets.Enabled = false;
                statusStrip.Visible = true;
                toolStripStatusLabel.Text = "0%";
                toolStripProgressBar.Value = 0;
                contextMenuStrip.Enabled = false;
                backgroundWorkerFindTargets.RunWorkerAsync();
            }
        }

        private void addPS4(PS4 ps4)
        {
            // Ensure it's not already on our list
            for (int i = 0; i < ps4s.Count; i++)
            {
                if (ps4s[i].IP == ps4.IP)
                    return;
            }

            // Add it
            ps4s.Add(ps4);
        }

        private void removePS4(string ip)
        {
            if (Properties.Settings.Default.defaultPs4Ip == ip)
            {
                Properties.Settings.Default.defaultPs4Ip = "";
                Properties.Settings.Default.Save();
            }

            ps4s.RemoveAt(getPS4Index(ip));
        }

        private int getPS4Index(string ip)
        {
            for (int i = 0; i < ps4s.Count; i++)
            {
                if (ps4s[i].IP == ip)
                    return i;
            }
            return -1;
        }

        private bool checkTarget(string ip)
        {
            TcpClient client = new TcpClient();
            try
            {
                if (client.ConnectAsync(ip, 9020).Wait(10))
                {
                    client.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                client.Close();
                return false;
            }
        }

        private string getLocalIp()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            socket.Connect("8.8.8.8", 65530);
            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            string localIP = endPoint.Address.ToString();
            socket.Close();
            return localIP;
        }

        private void refresh()
        {
            listViewPS4s.Items.Clear();
            for (int i = 0; i < ps4s.Count; i++)
                listViewPS4s.Items.Add(new ListViewItem(ps4s[i].toArray()));
        }

        private void listViewPS4s_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Disable column resizing
            e.Cancel = true;
            e.NewWidth = listViewPS4s.Columns[e.ColumnIndex].Width;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonFindTargets_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You must have the Webkit Exploit running on your PS4.\nAfter the scan has finished, you will need to reload the Webkit Exploit before sending the payload.\n\nAre you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            findTargets();
        }

        private void listViewPS4s_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPS4s.SelectedItems.Count == 0)
                return;

            IP = listViewPS4s.SelectedItems[0].SubItems[1].Text;
        }

        private void listViewPS4s_DoubleClick(object sender, EventArgs e)
        {
            if (IP == null)
                return;

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IP == null)
            {
                MessageBox.Show("No PS4 has been selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void backgroundWorkerFindTargets_DoWork(object sender, DoWorkEventArgs e)
        {
            string ipAddres = getLocalIp();
            string localSubnet = ipAddres.Substring(0, ipAddres.LastIndexOf("."));
            
            for (int i = 0; i < 256; i++)
            {
                string checkIp = localSubnet + "." + i.ToString();
                if (checkTarget(checkIp))
                    addPS4(new PS4(checkIp, checkIp));
                BackgroundWorker bg = (BackgroundWorker)sender;
                bg.ReportProgress(i);
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => {
                    refresh();
                }));
                return;
            }
            refresh();
        }

        private void backgroundWorkerFindTargets_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => {
                    toolStripProgressBar.Value = e.ProgressPercentage;
                    toolStripStatusLabel.Text = Math.Floor(e.ProgressPercentage / 2.56f) + "%";
                }));
                return;
            }
            toolStripProgressBar.Value = e.ProgressPercentage;
            toolStripStatusLabel.Text = Math.Floor(e.ProgressPercentage / 2.56f) + "%";
        }

        private void backgroundWorkerFindTargets_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Height = 310;
            buttonOk.Enabled = true;
            buttonCancel.Enabled = true;
            buttonRefresh.Enabled = true;
            buttonFindTargets.Enabled = true;
            statusStrip.Visible = false;
            contextMenuStrip.Enabled = true;
            savePS4s();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PS4Dialog dialog = new PS4Dialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                addPS4(dialog.ps4);
                savePS4s();
                refresh();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPS4s.SelectedItems.Count == 0)
                return;

            PS4Dialog dialog = new PS4Dialog();

            int index = getPS4Index(listViewPS4s.SelectedItems[0].SubItems[1].Text);

            dialog.ps4 = ps4s[index];
            dialog.updateFields();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ps4s[index] = dialog.ps4;
                savePS4s();
                refresh();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPS4s.SelectedItems.Count == 0)
                return;

            removePS4(listViewPS4s.SelectedItems[0].SubItems[1].Text);
            savePS4s();
            refresh();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = listViewPS4s.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = listViewPS4s.SelectedItems.Count > 0;
        }
    }
}
