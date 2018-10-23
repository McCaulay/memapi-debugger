namespace MEMAPI_Debugger.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.listViewRanges = new System.Windows.Forms.ListView();
            this.columnHeaderStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripRegions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonRefreshResults = new System.Windows.Forms.Button();
            this.labelResultCount = new System.Windows.Forms.Label();
            this.buttonSearchResult = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.contextMenuStripRegions.SuspendLayout();
            this.contextMenuStripResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewRanges
            // 
            this.listViewRanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStart,
            this.columnHeaderEnd});
            this.listViewRanges.ContextMenuStrip = this.contextMenuStripRegions;
            this.listViewRanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRanges.FullRowSelect = true;
            this.listViewRanges.Location = new System.Drawing.Point(0, 0);
            this.listViewRanges.Name = "listViewRanges";
            this.listViewRanges.Size = new System.Drawing.Size(259, 620);
            this.listViewRanges.TabIndex = 0;
            this.listViewRanges.UseCompatibleStateImageBehavior = false;
            this.listViewRanges.View = System.Windows.Forms.View.Details;
            this.listViewRanges.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewRanges_ColumnWidthChanging);
            // 
            // columnHeaderStart
            // 
            this.columnHeaderStart.Text = "Start";
            this.columnHeaderStart.Width = 125;
            // 
            // columnHeaderEnd
            // 
            this.columnHeaderEnd.Text = "End";
            this.columnHeaderEnd.Width = 125;
            // 
            // contextMenuStripRegions
            // 
            this.contextMenuStripRegions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.searchRegionToolStripMenuItem});
            this.contextMenuStripRegions.Name = "contextMenuStripRegions";
            this.contextMenuStripRegions.Size = new System.Drawing.Size(150, 48);
            this.contextMenuStripRegions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripRegions_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // searchRegionToolStripMenuItem
            // 
            this.searchRegionToolStripMenuItem.Name = "searchRegionToolStripMenuItem";
            this.searchRegionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.searchRegionToolStripMenuItem.Text = "Search Region";
            this.searchRegionToolStripMenuItem.Click += new System.EventHandler(this.searchRegionToolStripMenuItem_Click);
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderValue});
            this.listViewResults.ContextMenuStrip = this.contextMenuStripResults;
            this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResults.Location = new System.Drawing.Point(0, 0);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(357, 480);
            this.listViewResults.TabIndex = 2;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAddress
            // 
            this.columnHeaderAddress.Text = "Address";
            this.columnHeaderAddress.Width = 125;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 205;
            // 
            // contextMenuStripResults
            // 
            this.contextMenuStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.copyAddressToolStripMenuItem,
            this.copyValueToolStripMenuItem});
            this.contextMenuStripResults.Name = "contextMenuStripResults";
            this.contextMenuStripResults.Size = new System.Drawing.Size(148, 70);
            this.contextMenuStripResults.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripResults_Opening);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // copyAddressToolStripMenuItem
            // 
            this.copyAddressToolStripMenuItem.Name = "copyAddressToolStripMenuItem";
            this.copyAddressToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.copyAddressToolStripMenuItem.Text = "Copy Address";
            this.copyAddressToolStripMenuItem.Click += new System.EventHandler(this.copyAddressToolStripMenuItem_Click);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.copyValueToolStripMenuItem.Text = "Copy Value";
            this.copyValueToolStripMenuItem.Click += new System.EventHandler(this.copyValueToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewRanges);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(620, 620);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewResults);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonRefreshResults);
            this.splitContainer2.Panel2.Controls.Add(this.labelResultCount);
            this.splitContainer2.Panel2.Controls.Add(this.buttonSearchResult);
            this.splitContainer2.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxTo);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxFrom);
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxType);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxValue);
            this.splitContainer2.Size = new System.Drawing.Size(357, 620);
            this.splitContainer2.SplitterDistance = 480;
            this.splitContainer2.TabIndex = 3;
            // 
            // buttonRefreshResults
            // 
            this.buttonRefreshResults.Enabled = false;
            this.buttonRefreshResults.Location = new System.Drawing.Point(7, 106);
            this.buttonRefreshResults.Name = "buttonRefreshResults";
            this.buttonRefreshResults.Size = new System.Drawing.Size(336, 23);
            this.buttonRefreshResults.TabIndex = 6;
            this.buttonRefreshResults.Text = "Refresh Results";
            this.buttonRefreshResults.UseVisualStyleBackColor = true;
            this.buttonRefreshResults.Click += new System.EventHandler(this.buttonRefreshResults_Click);
            // 
            // labelResultCount
            // 
            this.labelResultCount.AutoSize = true;
            this.labelResultCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.labelResultCount.Location = new System.Drawing.Point(4, 5);
            this.labelResultCount.Name = "labelResultCount";
            this.labelResultCount.Size = new System.Drawing.Size(71, 17);
            this.labelResultCount.TabIndex = 8;
            this.labelResultCount.Text = "Results: 0";
            // 
            // buttonSearchResult
            // 
            this.buttonSearchResult.Enabled = false;
            this.buttonSearchResult.Location = new System.Drawing.Point(178, 77);
            this.buttonSearchResult.Name = "buttonSearchResult";
            this.buttonSearchResult.Size = new System.Drawing.Size(165, 23);
            this.buttonSearchResult.TabIndex = 5;
            this.buttonSearchResult.Text = "Search Result";
            this.buttonSearchResult.UseVisualStyleBackColor = true;
            this.buttonSearchResult.Click += new System.EventHandler(this.buttonSearchResult_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(7, 77);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(165, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxTo
            // 
            this.textBoxTo.Enabled = false;
            this.textBoxTo.Location = new System.Drawing.Point(178, 25);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(165, 20);
            this.textBoxTo.TabIndex = 1;
            this.textBoxTo.Text = "0x0000000000000000";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Enabled = false;
            this.textBoxFrom.Location = new System.Drawing.Point(7, 25);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(165, 20);
            this.textBoxFrom.TabIndex = 0;
            this.textBoxFrom.Text = "0x0000000000000000";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Enabled = false;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Bytes",
            "Integer",
            "Short",
            "Long",
            "Float",
            "Double",
            "String",
            "Unsigned Integer",
            "Unsigned Short",
            "Unsigned Long"});
            this.comboBoxType.Location = new System.Drawing.Point(178, 50);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(165, 21);
            this.comboBoxType.TabIndex = 3;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Enabled = false;
            this.textBoxValue.Location = new System.Drawing.Point(7, 51);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(165, 20);
            this.textBoxValue.TabIndex = 2;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 620);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.Text = "Search";
            this.contextMenuStripRegions.ResumeLayout(false);
            this.contextMenuStripResults.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRanges;
        private System.Windows.Forms.ColumnHeader columnHeaderStart;
        private System.Windows.Forms.ColumnHeader columnHeaderEnd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegions;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnHeaderAddress;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button buttonSearchResult;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelResultCount;
        private System.Windows.Forms.ToolStripMenuItem searchRegionToolStripMenuItem;
        private System.Windows.Forms.Button buttonRefreshResults;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripResults;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyValueToolStripMenuItem;
    }
}