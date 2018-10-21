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
    public partial class MixedValueDialog : Form
    {
        public object Variable { get; set; }
        public Type VariableType { get; set; }

        public MixedValueDialog(string title)
        {
            InitializeComponent();
            Text = title;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
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
                        Variable = Helper.stringToByteArray(textBoxValue.Text.Replace(" ", ""));
                        VariableType = typeof(byte[]);
                        break;
                    case 1:
                        Variable = Convert.ToInt32(textBoxValue.Text);
                        VariableType = typeof(int);
                        break;
                    case 2:
                        Variable = Convert.ToInt16(textBoxValue.Text);
                        VariableType = typeof(short);
                        break;
                    case 3:
                        Variable = Convert.ToInt64(textBoxValue.Text);
                        VariableType = typeof(long);
                        break;
                    case 4:
                        Variable = Convert.ToSingle(textBoxValue.Text);
                        VariableType = typeof(float);
                        break;
                    case 5:
                        Variable = Convert.ToDouble(textBoxValue.Text);
                        VariableType = typeof(double);
                        break;
                    case 6:
                        Variable = textBoxValue.Text;
                        VariableType = typeof(string);
                        break;
                    case 7:
                        Variable = Convert.ToUInt32(textBoxValue.Text);
                        VariableType = typeof(uint);
                        break;
                    case 8:
                        Variable = Convert.ToUInt16(textBoxValue.Text);
                        VariableType = typeof(ushort);
                        break;
                    case 9:
                        Variable = Convert.ToUInt64(textBoxValue.Text);
                        VariableType = typeof(ulong);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Value is in an invalid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
