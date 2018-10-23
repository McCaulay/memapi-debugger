namespace MEMAPI_Debugger.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.attachProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachEbootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.hardwareBreakpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendPayloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disassemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBreakpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDisassemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeKernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSelectTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendPayload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAttachEboot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAttachProcess = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDetach = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNotify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBreakpoints = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDisassembly = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonKernel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMemory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRegisters = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConsole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPatreon = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSeperator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIpAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSeperator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSeperator3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFirmware = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveProjectToolStripMenuItemList,
            this.toolStripSeparator1,
            this.recentProjectsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripMenuItem.Image")));
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Visible = false;
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadProjectToolStripMenuItem.Image")));
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            this.loadProjectToolStripMenuItem.Visible = false;
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeProjectToolStripMenuItem.Image")));
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeProjectToolStripMenuItem.Text = "Close Project";
            this.closeProjectToolStripMenuItem.Visible = false;
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // saveProjectToolStripMenuItemList
            // 
            this.saveProjectToolStripMenuItemList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem});
            this.saveProjectToolStripMenuItemList.Enabled = false;
            this.saveProjectToolStripMenuItemList.Name = "saveProjectToolStripMenuItemList";
            this.saveProjectToolStripMenuItemList.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItemList.Text = "Save...";
            this.saveProjectToolStripMenuItemList.Visible = false;
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectToolStripMenuItem.Image")));
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectAsToolStripMenuItem.Image")));
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // recentProjectsToolStripMenuItem
            // 
            this.recentProjectsToolStripMenuItem.Enabled = false;
            this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
            this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recentProjectsToolStripMenuItem.Text = " Recent Projects";
            this.recentProjectsToolStripMenuItem.Visible = false;
            this.recentProjectsToolStripMenuItem.Click += new System.EventHandler(this.recentProjectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator4,
            this.stepToolStripMenuItem,
            this.toolStripSeparator5,
            this.attachProcessToolStripMenuItem,
            this.attachEbootToolStripMenuItem,
            this.detachToolStripMenuItem,
            this.toolStripSeparator8,
            this.hardwareBreakpointsToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // goToolStripMenuItem
            // 
            this.goToolStripMenuItem.Enabled = false;
            this.goToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("goToolStripMenuItem.Image")));
            this.goToolStripMenuItem.Name = "goToolStripMenuItem";
            this.goToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.goToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.goToolStripMenuItem.Text = "Go";
            this.goToolStripMenuItem.Click += new System.EventHandler(this.goToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Enabled = false;
            this.pauseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pauseToolStripMenuItem.Image")));
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5)));
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Enabled = false;
            this.stepToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stepToolStripMenuItem.Image")));
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(196, 6);
            // 
            // attachProcessToolStripMenuItem
            // 
            this.attachProcessToolStripMenuItem.Enabled = false;
            this.attachProcessToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.attach;
            this.attachProcessToolStripMenuItem.Name = "attachProcessToolStripMenuItem";
            this.attachProcessToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.attachProcessToolStripMenuItem.Text = "Attach process...";
            this.attachProcessToolStripMenuItem.Click += new System.EventHandler(this.attachProcessToolStripMenuItem_Click);
            // 
            // attachEbootToolStripMenuItem
            // 
            this.attachEbootToolStripMenuItem.Enabled = false;
            this.attachEbootToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.attach_eboot;
            this.attachEbootToolStripMenuItem.Name = "attachEbootToolStripMenuItem";
            this.attachEbootToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.attachEbootToolStripMenuItem.Text = "Attach EBOOT";
            this.attachEbootToolStripMenuItem.Click += new System.EventHandler(this.attachEbootToolStripMenuItem_Click);
            // 
            // detachToolStripMenuItem
            // 
            this.detachToolStripMenuItem.Enabled = false;
            this.detachToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.detach;
            this.detachToolStripMenuItem.Name = "detachToolStripMenuItem";
            this.detachToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.detachToolStripMenuItem.Text = "Detach Process";
            this.detachToolStripMenuItem.Click += new System.EventHandler(this.detachToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(196, 6);
            // 
            // hardwareBreakpointsToolStripMenuItem
            // 
            this.hardwareBreakpointsToolStripMenuItem.Enabled = false;
            this.hardwareBreakpointsToolStripMenuItem.Name = "hardwareBreakpointsToolStripMenuItem";
            this.hardwareBreakpointsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.hardwareBreakpointsToolStripMenuItem.Text = "Hardware Breakpoints...";
            this.hardwareBreakpointsToolStripMenuItem.Click += new System.EventHandler(this.hardwareBreakpointsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectTargetToolStripMenuItem,
            this.sendPayloadToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.notifyToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // selectTargetToolStripMenuItem
            // 
            this.selectTargetToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.ps4;
            this.selectTargetToolStripMenuItem.Name = "selectTargetToolStripMenuItem";
            this.selectTargetToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectTargetToolStripMenuItem.Text = "Select Target...";
            this.selectTargetToolStripMenuItem.Click += new System.EventHandler(this.selectTargetToolStripMenuItem_Click);
            // 
            // sendPayloadToolStripMenuItem
            // 
            this.sendPayloadToolStripMenuItem.Enabled = false;
            this.sendPayloadToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.send;
            this.sendPayloadToolStripMenuItem.Name = "sendPayloadToolStripMenuItem";
            this.sendPayloadToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sendPayloadToolStripMenuItem.Text = "Send Payload";
            this.sendPayloadToolStripMenuItem.Click += new System.EventHandler(this.sendPayloadToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Enabled = false;
            this.connectToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.connect;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.disconnect;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // notifyToolStripMenuItem
            // 
            this.notifyToolStripMenuItem.Enabled = false;
            this.notifyToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.notify;
            this.notifyToolStripMenuItem.Name = "notifyToolStripMenuItem";
            this.notifyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.notifyToolStripMenuItem.Text = "Notify";
            this.notifyToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newViewToolStripMenuItem,
            this.changeViewToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // newViewToolStripMenuItem
            // 
            this.newViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.breakpointsToolStripMenuItem,
            this.disassemblyToolStripMenuItem,
            this.kernelToolStripMenuItem,
            this.memoryToolStripMenuItem,
            this.registersToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.consoleToolStripMenuItem});
            this.newViewToolStripMenuItem.Name = "newViewToolStripMenuItem";
            this.newViewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newViewToolStripMenuItem.Text = "New View";
            // 
            // breakpointsToolStripMenuItem
            // 
            this.breakpointsToolStripMenuItem.Enabled = false;
            this.breakpointsToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_breakpoints;
            this.breakpointsToolStripMenuItem.Name = "breakpointsToolStripMenuItem";
            this.breakpointsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.breakpointsToolStripMenuItem.Text = "Breakpoints";
            this.breakpointsToolStripMenuItem.Click += new System.EventHandler(this.breakpointsToolStripMenuItem_Click);
            // 
            // disassemblyToolStripMenuItem
            // 
            this.disassemblyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disassemblyToolStripMenuItem.Image")));
            this.disassemblyToolStripMenuItem.Name = "disassemblyToolStripMenuItem";
            this.disassemblyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.disassemblyToolStripMenuItem.Text = "Disassembly";
            this.disassemblyToolStripMenuItem.Click += new System.EventHandler(this.disassemblyToolStripMenuItem_Click);
            // 
            // kernelToolStripMenuItem
            // 
            this.kernelToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_kernels;
            this.kernelToolStripMenuItem.Name = "kernelToolStripMenuItem";
            this.kernelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.kernelToolStripMenuItem.Text = "Kernel";
            this.kernelToolStripMenuItem.Click += new System.EventHandler(this.kernelToolStripMenuItem_Click);
            // 
            // memoryToolStripMenuItem
            // 
            this.memoryToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_memory;
            this.memoryToolStripMenuItem.Name = "memoryToolStripMenuItem";
            this.memoryToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.memoryToolStripMenuItem.Text = "Memory";
            this.memoryToolStripMenuItem.Click += new System.EventHandler(this.memoryToolStripMenuItem_Click);
            // 
            // registersToolStripMenuItem
            // 
            this.registersToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_registers;
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.registersToolStripMenuItem.Text = "Registers";
            this.registersToolStripMenuItem.Click += new System.EventHandler(this.registersToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_search;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consoleToolStripMenuItem.Image")));
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // changeViewToolStripMenuItem
            // 
            this.changeViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBreakpointsToolStripMenuItem,
            this.changeDisassemblyToolStripMenuItem,
            this.changeKernelToolStripMenuItem,
            this.changeMemoryToolStripMenuItem,
            this.changeRegistersToolStripMenuItem,
            this.changeSearchToolStripMenuItem,
            this.changeConsoleToolStripMenuItem});
            this.changeViewToolStripMenuItem.Name = "changeViewToolStripMenuItem";
            this.changeViewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.changeViewToolStripMenuItem.Text = "Change View";
            // 
            // changeBreakpointsToolStripMenuItem
            // 
            this.changeBreakpointsToolStripMenuItem.Enabled = false;
            this.changeBreakpointsToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_breakpoints;
            this.changeBreakpointsToolStripMenuItem.Name = "changeBreakpointsToolStripMenuItem";
            this.changeBreakpointsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeBreakpointsToolStripMenuItem.Text = "Breakpoints";
            this.changeBreakpointsToolStripMenuItem.Click += new System.EventHandler(this.changeBreakpointsToolStripMenuItem_Click);
            // 
            // changeDisassemblyToolStripMenuItem
            // 
            this.changeDisassemblyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeDisassemblyToolStripMenuItem.Image")));
            this.changeDisassemblyToolStripMenuItem.Name = "changeDisassemblyToolStripMenuItem";
            this.changeDisassemblyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeDisassemblyToolStripMenuItem.Text = "Disassembly";
            this.changeDisassemblyToolStripMenuItem.Click += new System.EventHandler(this.changeDisassemblyToolStripMenuItem_Click);
            // 
            // changeKernelToolStripMenuItem
            // 
            this.changeKernelToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_kernels;
            this.changeKernelToolStripMenuItem.Name = "changeKernelToolStripMenuItem";
            this.changeKernelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeKernelToolStripMenuItem.Text = "Kernel";
            this.changeKernelToolStripMenuItem.Click += new System.EventHandler(this.changeKernelToolStripMenuItem_Click);
            // 
            // changeMemoryToolStripMenuItem
            // 
            this.changeMemoryToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_memory;
            this.changeMemoryToolStripMenuItem.Name = "changeMemoryToolStripMenuItem";
            this.changeMemoryToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeMemoryToolStripMenuItem.Text = "Memory";
            this.changeMemoryToolStripMenuItem.Click += new System.EventHandler(this.changeMemoryToolStripMenuItem_Click);
            // 
            // changeRegistersToolStripMenuItem
            // 
            this.changeRegistersToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_registers;
            this.changeRegistersToolStripMenuItem.Name = "changeRegistersToolStripMenuItem";
            this.changeRegistersToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeRegistersToolStripMenuItem.Text = "Registers";
            this.changeRegistersToolStripMenuItem.Click += new System.EventHandler(this.changeRegistersToolStripMenuItem_Click);
            // 
            // changeSearchToolStripMenuItem
            // 
            this.changeSearchToolStripMenuItem.Image = global::MEMAPI_Debugger.Properties.Resources.window_search;
            this.changeSearchToolStripMenuItem.Name = "changeSearchToolStripMenuItem";
            this.changeSearchToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeSearchToolStripMenuItem.Text = "Search";
            this.changeSearchToolStripMenuItem.Click += new System.EventHandler(this.changeSearchToolStripMenuItem_Click);
            // 
            // changeConsoleToolStripMenuItem
            // 
            this.changeConsoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeConsoleToolStripMenuItem.Image")));
            this.changeConsoleToolStripMenuItem.Name = "changeConsoleToolStripMenuItem";
            this.changeConsoleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeConsoleToolStripMenuItem.Text = "Console";
            this.changeConsoleToolStripMenuItem.Click += new System.EventHandler(this.changeConsoleToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewProject,
            this.toolStripButtonLoadProject,
            this.toolStripButtonSave,
            this.toolStripSeparator7,
            this.toolStripButtonPlay,
            this.toolStripButtonPause,
            this.toolStripButtonStop,
            this.toolStripButtonStep,
            this.toolStripSeparator6,
            this.toolStripButtonSelectTarget,
            this.toolStripButtonSendPayload,
            this.toolStripButtonConnect,
            this.toolStripButtonDisconnect,
            this.toolStripButtonAttachEboot,
            this.toolStripButtonAttachProcess,
            this.toolStripButtonDetach,
            this.toolStripButtonNotify,
            this.toolStripSeparator9,
            this.toolStripButtonBreakpoints,
            this.toolStripButtonDisassembly,
            this.toolStripButtonKernel,
            this.toolStripButtonMemory,
            this.toolStripButtonRegisters,
            this.toolStripButtonSearch,
            this.toolStripButtonConsole,
            this.toolStripSeparator10,
            this.toolStripButtonPatreon});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonNewProject
            // 
            this.toolStripButtonNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewProject.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewProject.Image")));
            this.toolStripButtonNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewProject.Name = "toolStripButtonNewProject";
            this.toolStripButtonNewProject.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewProject.Text = "New Project";
            this.toolStripButtonNewProject.ToolTipText = "New Project";
            this.toolStripButtonNewProject.Visible = false;
            this.toolStripButtonNewProject.Click += new System.EventHandler(this.toolStripButtonNewProject_Click);
            // 
            // toolStripButtonLoadProject
            // 
            this.toolStripButtonLoadProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadProject.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadProject.Image")));
            this.toolStripButtonLoadProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadProject.Name = "toolStripButtonLoadProject";
            this.toolStripButtonLoadProject.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLoadProject.Text = "Load Project";
            this.toolStripButtonLoadProject.Visible = false;
            this.toolStripButtonLoadProject.Click += new System.EventHandler(this.toolStripButtonLoadProject_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save";
            this.toolStripButtonSave.Visible = false;
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator7.Visible = false;
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlay.Enabled = false;
            this.toolStripButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlay.Image")));
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPlay.Text = "Play";
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // toolStripButtonPause
            // 
            this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPause.Enabled = false;
            this.toolStripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
            this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPause.Name = "toolStripButtonPause";
            this.toolStripButtonPause.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPause.Text = "Pause";
            this.toolStripButtonPause.ToolTipText = "Pause";
            this.toolStripButtonPause.Click += new System.EventHandler(this.toolStripButtonPause_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripButtonStep
            // 
            this.toolStripButtonStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStep.Enabled = false;
            this.toolStripButtonStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStep.Image")));
            this.toolStripButtonStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStep.Name = "toolStripButtonStep";
            this.toolStripButtonStep.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStep.Text = "Step";
            this.toolStripButtonStep.ToolTipText = "Step";
            this.toolStripButtonStep.Click += new System.EventHandler(this.toolStripButtonStep_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSelectTarget
            // 
            this.toolStripButtonSelectTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelectTarget.Image = global::MEMAPI_Debugger.Properties.Resources.ps4;
            this.toolStripButtonSelectTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectTarget.Name = "toolStripButtonSelectTarget";
            this.toolStripButtonSelectTarget.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSelectTarget.Text = "Select Target...";
            this.toolStripButtonSelectTarget.Click += new System.EventHandler(this.toolStripButtonSelectTarget_Click);
            // 
            // toolStripButtonSendPayload
            // 
            this.toolStripButtonSendPayload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSendPayload.Enabled = false;
            this.toolStripButtonSendPayload.Image = global::MEMAPI_Debugger.Properties.Resources.send;
            this.toolStripButtonSendPayload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendPayload.Name = "toolStripButtonSendPayload";
            this.toolStripButtonSendPayload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSendPayload.Text = "Send Payload";
            this.toolStripButtonSendPayload.Click += new System.EventHandler(this.toolStripButtonSendPayload_Click);
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConnect.Enabled = false;
            this.toolStripButtonConnect.Image = global::MEMAPI_Debugger.Properties.Resources.connect;
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConnect.Text = "Connect";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            // 
            // toolStripButtonDisconnect
            // 
            this.toolStripButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDisconnect.Enabled = false;
            this.toolStripButtonDisconnect.Image = global::MEMAPI_Debugger.Properties.Resources.disconnect;
            this.toolStripButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDisconnect.Name = "toolStripButtonDisconnect";
            this.toolStripButtonDisconnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDisconnect.Text = "Disconnect";
            this.toolStripButtonDisconnect.Click += new System.EventHandler(this.toolStripButtonDisconnect_Click);
            // 
            // toolStripButtonAttachEboot
            // 
            this.toolStripButtonAttachEboot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAttachEboot.Enabled = false;
            this.toolStripButtonAttachEboot.Image = global::MEMAPI_Debugger.Properties.Resources.attach_eboot;
            this.toolStripButtonAttachEboot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAttachEboot.Name = "toolStripButtonAttachEboot";
            this.toolStripButtonAttachEboot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAttachEboot.Text = "Attach EBOOT";
            this.toolStripButtonAttachEboot.Click += new System.EventHandler(this.toolStripButtonAttachEboot_Click);
            // 
            // toolStripButtonAttachProcess
            // 
            this.toolStripButtonAttachProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAttachProcess.Enabled = false;
            this.toolStripButtonAttachProcess.Image = global::MEMAPI_Debugger.Properties.Resources.attach;
            this.toolStripButtonAttachProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAttachProcess.Name = "toolStripButtonAttachProcess";
            this.toolStripButtonAttachProcess.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAttachProcess.Text = "Attach Process";
            this.toolStripButtonAttachProcess.Click += new System.EventHandler(this.toolStripButtonAttachProcess_Click);
            // 
            // toolStripButtonDetach
            // 
            this.toolStripButtonDetach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDetach.Enabled = false;
            this.toolStripButtonDetach.Image = global::MEMAPI_Debugger.Properties.Resources.detach;
            this.toolStripButtonDetach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDetach.Name = "toolStripButtonDetach";
            this.toolStripButtonDetach.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDetach.Text = "Detach Process";
            this.toolStripButtonDetach.Click += new System.EventHandler(this.toolStripButtonDetach_Click);
            // 
            // toolStripButtonNotify
            // 
            this.toolStripButtonNotify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNotify.Enabled = false;
            this.toolStripButtonNotify.Image = global::MEMAPI_Debugger.Properties.Resources.notify;
            this.toolStripButtonNotify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNotify.Name = "toolStripButtonNotify";
            this.toolStripButtonNotify.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNotify.Text = "Notify";
            this.toolStripButtonNotify.Click += new System.EventHandler(this.toolStripButtonNotify_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBreakpoints
            // 
            this.toolStripButtonBreakpoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBreakpoints.Enabled = false;
            this.toolStripButtonBreakpoints.Image = global::MEMAPI_Debugger.Properties.Resources.window_breakpoints;
            this.toolStripButtonBreakpoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBreakpoints.Name = "toolStripButtonBreakpoints";
            this.toolStripButtonBreakpoints.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBreakpoints.Text = "Breakpoints";
            this.toolStripButtonBreakpoints.Click += new System.EventHandler(this.toolStripButtonBreakpoints_Click);
            // 
            // toolStripButtonDisassembly
            // 
            this.toolStripButtonDisassembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDisassembly.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDisassembly.Image")));
            this.toolStripButtonDisassembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDisassembly.Name = "toolStripButtonDisassembly";
            this.toolStripButtonDisassembly.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDisassembly.Text = "Disassembly";
            this.toolStripButtonDisassembly.Click += new System.EventHandler(this.toolStripButtonDisassembly_Click);
            // 
            // toolStripButtonKernel
            // 
            this.toolStripButtonKernel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonKernel.Image = global::MEMAPI_Debugger.Properties.Resources.window_kernels;
            this.toolStripButtonKernel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonKernel.Name = "toolStripButtonKernel";
            this.toolStripButtonKernel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonKernel.Text = "Kernel";
            this.toolStripButtonKernel.Click += new System.EventHandler(this.toolStripButtonKernel_Click);
            // 
            // toolStripButtonMemory
            // 
            this.toolStripButtonMemory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMemory.Image = global::MEMAPI_Debugger.Properties.Resources.window_memory;
            this.toolStripButtonMemory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMemory.Name = "toolStripButtonMemory";
            this.toolStripButtonMemory.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMemory.Text = "Memory";
            this.toolStripButtonMemory.Click += new System.EventHandler(this.toolStripButtonMemory_Click);
            // 
            // toolStripButtonRegisters
            // 
            this.toolStripButtonRegisters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRegisters.Image = global::MEMAPI_Debugger.Properties.Resources.window_registers;
            this.toolStripButtonRegisters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRegisters.Name = "toolStripButtonRegisters";
            this.toolStripButtonRegisters.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRegisters.Text = "Register";
            this.toolStripButtonRegisters.Click += new System.EventHandler(this.toolStripButtonRegisters_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::MEMAPI_Debugger.Properties.Resources.window_search;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonConsole
            // 
            this.toolStripButtonConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConsole.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConsole.Image")));
            this.toolStripButtonConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConsole.Name = "toolStripButtonConsole";
            this.toolStripButtonConsole.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConsole.Text = "Console";
            this.toolStripButtonConsole.Click += new System.EventHandler(this.toolStripButtonConsole_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonPatreon
            // 
            this.toolStripButtonPatreon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPatreon.Image = global::MEMAPI_Debugger.Properties.Resources.patreon_icon;
            this.toolStripButtonPatreon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPatreon.Name = "toolStripButtonPatreon";
            this.toolStripButtonPatreon.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPatreon.Text = "Donate with Patreon";
            this.toolStripButtonPatreon.ToolTipText = "Donate with Patreon";
            this.toolStripButtonPatreon.Click += new System.EventHandler(this.toolStripButtonPatreon_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripStatusSeperator1,
            this.toolStripStatusLabelIpAddress,
            this.toolStripStatusSeperator2,
            this.toolStripStatusLabelProcess,
            this.toolStripStatusSeperator3,
            this.toolStripStatusLabelFirmware});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Image = global::MEMAPI_Debugger.Properties.Resources.disconnected;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelStatus.Text = " ";
            // 
            // toolStripStatusSeperator1
            // 
            this.toolStripStatusSeperator1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSeperator1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusSeperator1.Name = "toolStripStatusSeperator1";
            this.toolStripStatusSeperator1.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusSeperator1.Visible = false;
            // 
            // toolStripStatusLabelIpAddress
            // 
            this.toolStripStatusLabelIpAddress.Name = "toolStripStatusLabelIpAddress";
            this.toolStripStatusLabelIpAddress.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabelIpAddress.Text = " IP Address: ";
            this.toolStripStatusLabelIpAddress.Visible = false;
            // 
            // toolStripStatusSeperator2
            // 
            this.toolStripStatusSeperator2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSeperator2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusSeperator2.Name = "toolStripStatusSeperator2";
            this.toolStripStatusSeperator2.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusSeperator2.Visible = false;
            // 
            // toolStripStatusLabelProcess
            // 
            this.toolStripStatusLabelProcess.Name = "toolStripStatusLabelProcess";
            this.toolStripStatusLabelProcess.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabelProcess.Text = " Process:";
            this.toolStripStatusLabelProcess.Visible = false;
            // 
            // toolStripStatusSeperator3
            // 
            this.toolStripStatusSeperator3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusSeperator3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusSeperator3.Name = "toolStripStatusSeperator3";
            this.toolStripStatusSeperator3.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusSeperator3.Visible = false;
            // 
            // toolStripStatusLabelFirmware
            // 
            this.toolStripStatusLabelFirmware.Name = "toolStripStatusLabelFirmware";
            this.toolStripStatusLabelFirmware.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabelFirmware.Text = "Firmware: ";
            this.toolStripStatusLabelFirmware.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "<Untitled> - PS4 - MEMAPI Debugger for PS4 v1.00";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItemList;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareBreakpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewProject;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadProject;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem newViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disassemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBreakpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDisassemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeKernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeRegistersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonConsole;
        private System.Windows.Forms.ToolStripButton toolStripButtonDisassembly;
        private System.Windows.Forms.ToolStripButton toolStripButtonBreakpoints;
        private System.Windows.Forms.ToolStripButton toolStripButtonMemory;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegisters;
        private System.Windows.Forms.ToolStripButton toolStripButtonKernel;
        private System.Windows.Forms.ToolStripMenuItem attachProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendPayloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectTarget;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendPayload;
        private System.Windows.Forms.ToolStripButton toolStripButtonNotify;
        private System.Windows.Forms.ToolStripButton toolStripButtonAttachProcess;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDisconnect;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProcess;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSeperator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIpAddress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSeperator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSeperator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFirmware;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonAttachEboot;
        private System.Windows.Forms.ToolStripMenuItem attachEbootToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDetach;
        private System.Windows.Forms.ToolStripMenuItem detachToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonPatreon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    }
}

