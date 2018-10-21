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
    public partial class PS4Dialog : Form
    {
        public PS4 ps4 { get; set; }

        public PS4Dialog()
        {
            InitializeComponent();
            ps4 = new PS4();
        }

        public void updateFields()
        {
            textBoxIpAddress.Text = ps4.IP;
            textBoxName.Text = ps4.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIpAddress.Text == "" || textBoxName.Text == "")
            {
                MessageBox.Show("Name or IP Address is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ps4.IP = textBoxIpAddress.Text;
            ps4.Name = textBoxName.Text;

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
