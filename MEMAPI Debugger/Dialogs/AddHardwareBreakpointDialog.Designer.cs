namespace MEMAPI_Debugger.Dialogs
{
    partial class AddHardwareBreakpointDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonExecute = new System.Windows.Forms.RadioButton();
            this.radioButtonReadWrite = new System.Windows.Forms.RadioButton();
            this.radioButtonWrite = new System.Windows.Forms.RadioButton();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.comboBoxLength = new System.Windows.Forms.ComboBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonExecute
            // 
            this.radioButtonExecute.AutoSize = true;
            this.radioButtonExecute.Location = new System.Drawing.Point(66, 65);
            this.radioButtonExecute.Name = "radioButtonExecute";
            this.radioButtonExecute.Size = new System.Drawing.Size(64, 17);
            this.radioButtonExecute.TabIndex = 2;
            this.radioButtonExecute.TabStop = true;
            this.radioButtonExecute.Text = "Execute";
            this.radioButtonExecute.UseVisualStyleBackColor = true;
            // 
            // radioButtonReadWrite
            // 
            this.radioButtonReadWrite.AutoSize = true;
            this.radioButtonReadWrite.Checked = true;
            this.radioButtonReadWrite.Location = new System.Drawing.Point(139, 65);
            this.radioButtonReadWrite.Name = "radioButtonReadWrite";
            this.radioButtonReadWrite.Size = new System.Drawing.Size(87, 17);
            this.radioButtonReadWrite.TabIndex = 3;
            this.radioButtonReadWrite.TabStop = true;
            this.radioButtonReadWrite.Text = "Read / Write";
            this.radioButtonReadWrite.UseVisualStyleBackColor = true;
            // 
            // radioButtonWrite
            // 
            this.radioButtonWrite.AutoSize = true;
            this.radioButtonWrite.Location = new System.Drawing.Point(237, 65);
            this.radioButtonWrite.Name = "radioButtonWrite";
            this.radioButtonWrite.Size = new System.Drawing.Size(50, 17);
            this.radioButtonWrite.TabIndex = 4;
            this.radioButtonWrite.TabStop = true;
            this.radioButtonWrite.Text = "Write";
            this.radioButtonWrite.UseVisualStyleBackColor = true;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(66, 12);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(223, 20);
            this.textBoxAddress.TabIndex = 0;
            // 
            // comboBoxLength
            // 
            this.comboBoxLength.FormattingEnabled = true;
            this.comboBoxLength.Items.AddRange(new object[] {
            "1 Byte",
            "2 Bytes",
            "4 Bytes",
            "8 Bytes"});
            this.comboBoxLength.Location = new System.Drawing.Point(66, 38);
            this.comboBoxLength.Name = "comboBoxLength";
            this.comboBoxLength.Size = new System.Drawing.Size(221, 21);
            this.comboBoxLength.TabIndex = 1;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(12, 15);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 5;
            this.labelAddress.Text = "Address:";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(17, 41);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(43, 13);
            this.labelLength.TabIndex = 6;
            this.labelLength.Text = "Length:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(214, 88);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(66, 88);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddHardwareBreakpointDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 119);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.comboBoxLength);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.radioButtonWrite);
            this.Controls.Add(this.radioButtonReadWrite);
            this.Controls.Add(this.radioButtonExecute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddHardwareBreakpointDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Hardware Breakpoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonExecute;
        private System.Windows.Forms.RadioButton radioButtonReadWrite;
        private System.Windows.Forms.RadioButton radioButtonWrite;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.ComboBox comboBoxLength;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
    }
}