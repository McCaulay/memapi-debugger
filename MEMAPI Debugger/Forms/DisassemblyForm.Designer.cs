namespace MEMAPI_Debugger.Forms
{
    partial class DisassemblyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisassemblyForm));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOpcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOperands = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyOpcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyOperandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.goToAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToInstructionPointerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListBreakpoint = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderOpcode,
            this.columnHeaderOperands});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(629, 539);
            this.listView.StateImageList = this.imageListBreakpoint;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView_ItemCheck);
            // 
            // columnHeaderAddress
            // 
            this.columnHeaderAddress.Text = "Address";
            this.columnHeaderAddress.Width = 150;
            // 
            // columnHeaderOpcode
            // 
            this.columnHeaderOpcode.Text = "Opcode";
            this.columnHeaderOpcode.Width = 100;
            // 
            // columnHeaderOperands
            // 
            this.columnHeaderOperands.Text = "Operands";
            this.columnHeaderOperands.Width = 250;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyAddressToolStripMenuItem,
            this.copyOpcodeToolStripMenuItem,
            this.copyOperandsToolStripMenuItem,
            this.toolStripSeparator1,
            this.goToAddressToolStripMenuItem,
            this.goToInstructionPointerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(198, 164);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyAddressToolStripMenuItem
            // 
            this.copyAddressToolStripMenuItem.Name = "copyAddressToolStripMenuItem";
            this.copyAddressToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyAddressToolStripMenuItem.Text = "Copy address";
            this.copyAddressToolStripMenuItem.Click += new System.EventHandler(this.copyAddressToolStripMenuItem_Click);
            // 
            // copyOpcodeToolStripMenuItem
            // 
            this.copyOpcodeToolStripMenuItem.Name = "copyOpcodeToolStripMenuItem";
            this.copyOpcodeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyOpcodeToolStripMenuItem.Text = "Copy opcode";
            this.copyOpcodeToolStripMenuItem.Click += new System.EventHandler(this.copyOpcodeToolStripMenuItem_Click);
            // 
            // copyOperandsToolStripMenuItem
            // 
            this.copyOperandsToolStripMenuItem.Name = "copyOperandsToolStripMenuItem";
            this.copyOperandsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyOperandsToolStripMenuItem.Text = "Copy operands";
            this.copyOperandsToolStripMenuItem.Click += new System.EventHandler(this.copyOperandsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // goToAddressToolStripMenuItem
            // 
            this.goToAddressToolStripMenuItem.Name = "goToAddressToolStripMenuItem";
            this.goToAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToAddressToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.goToAddressToolStripMenuItem.Text = "Go to address";
            this.goToAddressToolStripMenuItem.Click += new System.EventHandler(this.goToAddressToolStripMenuItem_Click);
            // 
            // goToInstructionPointerToolStripMenuItem
            // 
            this.goToInstructionPointerToolStripMenuItem.Name = "goToInstructionPointerToolStripMenuItem";
            this.goToInstructionPointerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.goToInstructionPointerToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.goToInstructionPointerToolStripMenuItem.Text = "Go to RIP";
            this.goToInstructionPointerToolStripMenuItem.Click += new System.EventHandler(this.goToInstructionPointerToolStripMenuItem_Click);
            // 
            // imageListBreakpoint
            // 
            this.imageListBreakpoint.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBreakpoint.ImageStream")));
            this.imageListBreakpoint.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBreakpoint.Images.SetKeyName(0, "transparent.png");
            this.imageListBreakpoint.Images.SetKeyName(1, "pointer.png");
            // 
            // DisassemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 539);
            this.Controls.Add(this.listView);
            this.Name = "DisassemblyForm";
            this.Text = "Disassembly";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageListBreakpoint;
        private System.Windows.Forms.ColumnHeader columnHeaderAddress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem goToAddressToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderOpcode;
        private System.Windows.Forms.ColumnHeader columnHeaderOperands;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyOpcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyOperandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem goToInstructionPointerToolStripMenuItem;
    }
}