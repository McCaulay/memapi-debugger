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
    public partial class StringDialog : Form
    {
        public String Message { get; set; }

        public StringDialog(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public void updateField()
        {
            textBoxString.Text = Message;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxString.Text == "")
            {
                MessageBox.Show("Message must not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Message = textBoxString.Text;

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
