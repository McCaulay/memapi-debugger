namespace MEMAPI_Debugger.Forms
{
    partial class MemoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItemTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItemFour = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItemEight = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItemSixteen = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItemThirtyTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.enterNewValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillMemoryWithAValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.goToAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followPointerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoFollowPointerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.loadMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxAddress = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelColumns = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxColumns = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonTimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLock = new System.Windows.Forms.ToolStripButton();
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(644, 567);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            this.dataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Scroll);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.columnsToolStripMenuItem,
            this.toolStripSeparator2,
            this.enterNewValueToolStripMenuItem,
            this.fillMemoryWithAValueToolStripMenuItem,
            this.toolStripSeparator4,
            this.goToAddressToolStripMenuItem,
            this.followPointerToolStripMenuItem,
            this.undoFollowPointerToolStripMenuItem,
            this.lockToAddressToolStripMenuItem,
            this.toolStripSeparator5,
            this.loadMemoryToolStripMenuItem,
            this.saveMemoryToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(248, 248);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.byteToolStripMenuItem,
            this.bytesToolStripMenuItemTwo,
            this.bytesToolStripMenuItemFour,
            this.bytesToolStripMenuItemEight,
            this.bytesToolStripMenuItemSixteen,
            this.bytesToolStripMenuItemThirtyTwo});
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.columnsToolStripMenuItem.Text = "Columns";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Checked = true;
            this.autoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // byteToolStripMenuItem
            // 
            this.byteToolStripMenuItem.Name = "byteToolStripMenuItem";
            this.byteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.byteToolStripMenuItem.Text = "1 Byte";
            this.byteToolStripMenuItem.Click += new System.EventHandler(this.byteToolStripMenuItem_Click);
            // 
            // bytesToolStripMenuItemTwo
            // 
            this.bytesToolStripMenuItemTwo.Name = "bytesToolStripMenuItemTwo";
            this.bytesToolStripMenuItemTwo.Size = new System.Drawing.Size(117, 22);
            this.bytesToolStripMenuItemTwo.Text = "2 Bytes";
            this.bytesToolStripMenuItemTwo.Click += new System.EventHandler(this.bytesToolStripMenuItemTwo_Click);
            // 
            // bytesToolStripMenuItemFour
            // 
            this.bytesToolStripMenuItemFour.Name = "bytesToolStripMenuItemFour";
            this.bytesToolStripMenuItemFour.Size = new System.Drawing.Size(117, 22);
            this.bytesToolStripMenuItemFour.Text = "4 Bytes";
            this.bytesToolStripMenuItemFour.Click += new System.EventHandler(this.bytesToolStripMenuItemFour_Click);
            // 
            // bytesToolStripMenuItemEight
            // 
            this.bytesToolStripMenuItemEight.Name = "bytesToolStripMenuItemEight";
            this.bytesToolStripMenuItemEight.Size = new System.Drawing.Size(117, 22);
            this.bytesToolStripMenuItemEight.Text = "8 Bytes";
            this.bytesToolStripMenuItemEight.Click += new System.EventHandler(this.bytesToolStripMenuItemEight_Click);
            // 
            // bytesToolStripMenuItemSixteen
            // 
            this.bytesToolStripMenuItemSixteen.Name = "bytesToolStripMenuItemSixteen";
            this.bytesToolStripMenuItemSixteen.Size = new System.Drawing.Size(117, 22);
            this.bytesToolStripMenuItemSixteen.Text = "16 Bytes";
            this.bytesToolStripMenuItemSixteen.Click += new System.EventHandler(this.bytesToolStripMenuItemSixteen_Click);
            // 
            // bytesToolStripMenuItemThirtyTwo
            // 
            this.bytesToolStripMenuItemThirtyTwo.Name = "bytesToolStripMenuItemThirtyTwo";
            this.bytesToolStripMenuItemThirtyTwo.Size = new System.Drawing.Size(117, 22);
            this.bytesToolStripMenuItemThirtyTwo.Text = "32 Bytes";
            this.bytesToolStripMenuItemThirtyTwo.Click += new System.EventHandler(this.bytesToolStripMenuItemThirtyTwo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
            // 
            // enterNewValueToolStripMenuItem
            // 
            this.enterNewValueToolStripMenuItem.Enabled = false;
            this.enterNewValueToolStripMenuItem.Name = "enterNewValueToolStripMenuItem";
            this.enterNewValueToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.enterNewValueToolStripMenuItem.Text = "Enter new value";
            this.enterNewValueToolStripMenuItem.Click += new System.EventHandler(this.enterNewValueToolStripMenuItem_Click);
            // 
            // fillMemoryWithAValueToolStripMenuItem
            // 
            this.fillMemoryWithAValueToolStripMenuItem.Enabled = false;
            this.fillMemoryWithAValueToolStripMenuItem.Name = "fillMemoryWithAValueToolStripMenuItem";
            this.fillMemoryWithAValueToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.fillMemoryWithAValueToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.fillMemoryWithAValueToolStripMenuItem.Text = "Fill memory with a value";
            this.fillMemoryWithAValueToolStripMenuItem.Click += new System.EventHandler(this.fillMemoryWithAValueToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(244, 6);
            // 
            // goToAddressToolStripMenuItem
            // 
            this.goToAddressToolStripMenuItem.Name = "goToAddressToolStripMenuItem";
            this.goToAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToAddressToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.goToAddressToolStripMenuItem.Text = "Go to address";
            this.goToAddressToolStripMenuItem.Click += new System.EventHandler(this.goToAddressToolStripMenuItem_Click);
            // 
            // followPointerToolStripMenuItem
            // 
            this.followPointerToolStripMenuItem.Enabled = false;
            this.followPointerToolStripMenuItem.Name = "followPointerToolStripMenuItem";
            this.followPointerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.followPointerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.followPointerToolStripMenuItem.Text = "Follow pointer";
            this.followPointerToolStripMenuItem.Click += new System.EventHandler(this.followPointerToolStripMenuItem_Click);
            // 
            // undoFollowPointerToolStripMenuItem
            // 
            this.undoFollowPointerToolStripMenuItem.Enabled = false;
            this.undoFollowPointerToolStripMenuItem.Name = "undoFollowPointerToolStripMenuItem";
            this.undoFollowPointerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.undoFollowPointerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.undoFollowPointerToolStripMenuItem.Text = "Undo Follow pointer";
            this.undoFollowPointerToolStripMenuItem.Click += new System.EventHandler(this.undoFollowPointerToolStripMenuItem_Click);
            // 
            // lockToAddressToolStripMenuItem
            // 
            this.lockToAddressToolStripMenuItem.Name = "lockToAddressToolStripMenuItem";
            this.lockToAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.lockToAddressToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.lockToAddressToolStripMenuItem.Text = "Lock to address";
            this.lockToAddressToolStripMenuItem.Click += new System.EventHandler(this.lockToAddressToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(244, 6);
            // 
            // loadMemoryToolStripMenuItem
            // 
            this.loadMemoryToolStripMenuItem.Enabled = false;
            this.loadMemoryToolStripMenuItem.Name = "loadMemoryToolStripMenuItem";
            this.loadMemoryToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.loadMemoryToolStripMenuItem.Text = "Load Memory";
            this.loadMemoryToolStripMenuItem.Click += new System.EventHandler(this.loadMemoryToolStripMenuItem_Click);
            // 
            // saveMemoryToolStripMenuItem
            // 
            this.saveMemoryToolStripMenuItem.Enabled = false;
            this.saveMemoryToolStripMenuItem.Name = "saveMemoryToolStripMenuItem";
            this.saveMemoryToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.saveMemoryToolStripMenuItem.Text = "Save Memory";
            this.saveMemoryToolStripMenuItem.Click += new System.EventHandler(this.saveMemoryToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel,
            this.toolStripComboBoxAddress,
            this.toolStripButtonRefresh,
            this.toolStripSeparator,
            this.toolStripLabelColumns,
            this.toolStripComboBoxColumns,
            this.toolStripSeparator6,
            this.toolStripButtonTimer,
            this.toolStripButtonLock});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(644, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Tool Strip";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel.Text = "Address";
            // 
            // toolStripComboBoxAddress
            // 
            this.toolStripComboBoxAddress.Name = "toolStripComboBoxAddress";
            this.toolStripComboBoxAddress.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxAddress.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxAddress_SelectedIndexChanged);
            this.toolStripComboBoxAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBoxAddress_KeyPress);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Enabled = false;
            this.toolStripButtonRefresh.Image = global::MEMAPI_Debugger.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.ToolTipText = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelColumns
            // 
            this.toolStripLabelColumns.Name = "toolStripLabelColumns";
            this.toolStripLabelColumns.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabelColumns.Text = "Columns";
            // 
            // toolStripComboBoxColumns
            // 
            this.toolStripComboBoxColumns.Items.AddRange(new object[] {
            "Auto",
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.toolStripComboBoxColumns.Name = "toolStripComboBoxColumns";
            this.toolStripComboBoxColumns.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxColumns.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxColumns_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonTimer
            // 
            this.toolStripButtonTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTimer.Enabled = false;
            this.toolStripButtonTimer.Image = global::MEMAPI_Debugger.Properties.Resources.timer_off;
            this.toolStripButtonTimer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTimer.Name = "toolStripButtonTimer";
            this.toolStripButtonTimer.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTimer.Text = "Auto Refresh";
            this.toolStripButtonTimer.Click += new System.EventHandler(this.toolStripButtonTimer_Click);
            // 
            // toolStripButtonLock
            // 
            this.toolStripButtonLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLock.Image = global::MEMAPI_Debugger.Properties.Resources._lock;
            this.toolStripButtonLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLock.Name = "toolStripButtonLock";
            this.toolStripButtonLock.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLock.Text = "Lock";
            this.toolStripButtonLock.ToolTipText = "Lock";
            this.toolStripButtonLock.Click += new System.EventHandler(this.toolStripButtonLock_Click);
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Interval = 500;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
            // 
            // MemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 592);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemoryForm";
            this.Text = "Memory";
            this.ResizeEnd += new System.EventHandler(this.MemoryForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MemoryForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripLabel toolStripLabelColumns;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxColumns;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxAddress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem enterNewValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillMemoryWithAValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem followPointerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoFollowPointerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem loadMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItemTwo;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItemFour;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItemEight;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItemSixteen;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItemThirtyTwo;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonTimer;
        private System.Windows.Forms.Timer timerAutoRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonLock;
    }
}