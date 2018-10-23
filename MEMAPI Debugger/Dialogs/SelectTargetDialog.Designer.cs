namespace MEMAPI_Debugger.Dialogs
{
    partial class SelectTargetDialog
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listViewPS4s = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonFindTargets = new System.Windows.Forms.Button();
            this.seperator = new System.Windows.Forms.Label();
            this.backgroundWorkerFindTargets = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 244);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(93, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // listViewPS4s
            // 
            this.listViewPS4s.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderIp,
            this.columnHeaderStatus});
            this.listViewPS4s.ContextMenuStrip = this.contextMenuStrip;
            this.listViewPS4s.FullRowSelect = true;
            this.listViewPS4s.Location = new System.Drawing.Point(12, 12);
            this.listViewPS4s.MultiSelect = false;
            this.listViewPS4s.Name = "listViewPS4s";
            this.listViewPS4s.Size = new System.Drawing.Size(320, 213);
            this.listViewPS4s.TabIndex = 0;
            this.listViewPS4s.UseCompatibleStateImageBehavior = false;
            this.listViewPS4s.View = System.Windows.Forms.View.Details;
            this.listViewPS4s.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewPS4s_ColumnWidthChanging);
            this.listViewPS4s.SelectedIndexChanged += new System.EventHandler(this.listViewPS4s_SelectedIndexChanged);
            this.listViewPS4s.DoubleClick += new System.EventHandler(this.listViewPS4s_DoubleClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 115;
            // 
            // columnHeaderIp
            // 
            this.columnHeaderIp.Text = "IP Address";
            this.columnHeaderIp.Width = 120;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 80;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 70);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(174, 244);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonFindTargets
            // 
            this.buttonFindTargets.Location = new System.Drawing.Point(257, 244);
            this.buttonFindTargets.Name = "buttonFindTargets";
            this.buttonFindTargets.Size = new System.Drawing.Size(75, 23);
            this.buttonFindTargets.TabIndex = 4;
            this.buttonFindTargets.Text = "Find Targets";
            this.buttonFindTargets.UseVisualStyleBackColor = true;
            this.buttonFindTargets.Click += new System.EventHandler(this.buttonFindTargets_Click);
            // 
            // seperator
            // 
            this.seperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperator.Location = new System.Drawing.Point(12, 234);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(320, 2);
            this.seperator.TabIndex = 6;
            // 
            // backgroundWorkerFindTargets
            // 
            this.backgroundWorkerFindTargets.WorkerReportsProgress = true;
            this.backgroundWorkerFindTargets.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFindTargets_DoWork);
            this.backgroundWorkerFindTargets.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerFindTargets_ProgressChanged);
            this.backgroundWorkerFindTargets.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFindTargets_RunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 249);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(344, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            this.statusStrip.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 256;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabel.Text = "0%";
            // 
            // SelectTargetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 271);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.seperator);
            this.Controls.Add(this.buttonFindTargets);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listViewPS4s);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTargetDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Target";
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listViewPS4s;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderIp;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonFindTargets;
        private System.Windows.Forms.Label seperator;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFindTargets;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}