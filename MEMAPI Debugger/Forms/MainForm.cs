using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MEMAPI_Debugger.MEMAPI;
using MEMAPI_Debugger.Forms;
using MEMAPI_Debugger.Dialogs;

namespace MEMAPI_Debugger.Forms
{
    public partial class MainForm : Form
    {
        private List<Form> forms;
        private List<HardwareBreakpoint> hardwareBreakpoints;

        public MainForm()
        {
            InitializeComponent();

            hardwareBreakpoints = new List<HardwareBreakpoint>();

            // Events
            API.ConnectedEvent += onConnected;
            API.DisconnectEvent += onDisconnected;
            API.AttachedEvent += onAttached;
            API.DetachedEvent += onDetached;
            API.GoEvent += onGo;
            API.StoppedEvent += onStopped;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            toolStrip.ImageScalingSize = new Size(20, 20);
            forms = new List<Form>();

            // Start listening for debug information
            Server.start();

            // Listen for interrupts
            API.interruptThread.Start();

            if (Properties.Settings.Default.defaultPs4Ip != null && Properties.Settings.Default.defaultPs4Ip != "")
                targetSelected(Properties.Settings.Default.defaultPs4Ip);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Default Forms
            addNewForm(new DisassemblyForm(), 29.5, 70, 0, 0);
            addNewForm(new MemoryForm(), 35.5, 70, 29.5, 0);
            addNewForm(new RegistersForm(), 65, 30, 0, 70);
            addNewForm(new SearchForm(), 35, 100, 65, 0);
        }

        #region Implementation

        #region File
        private void newProject()
        {

        }

        private void loadProject()
        {

        }

        private void closeProject()
        {

        }

        private void saveProject(string filename = null)
        {

        }

        private void saveProjectAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                saveProject(dialog.FileName);
        }

        private void recentProject()
        {

        }
        #endregion

        #region Debug
        private void go() => API.go();
        private void pause() => API.stop();
        private void stop() => API.kill();
        private void step() => API.step();

        private void getHardwareBreakpoints()
        {
            HardwareBreakpointDialog dialog = new HardwareBreakpointDialog();
            dialog.breakpoints = hardwareBreakpoints;
            dialog.updateList();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Reset all existing hardware breakpoints
                API.resetHardwareBreakpoints(new int[] { 0, 1, 2, 3 });

                // Set dialog hardware breakpoints
                hardwareBreakpoints = dialog.breakpoints;
                API.setHardwareBreakpoints(hardwareBreakpoints);
            }
        }

        private void attachProcess()
        {
            ProcessDialog dialog = new ProcessDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                API.attach(dialog.process);
        }
        #endregion

        #region Tools
        private void selectTarget()
        {
            SelectTargetDialog dialog = new SelectTargetDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                targetSelected(dialog.IP);
        }

        private void sendPayload()
        {
            // Send Payload
            if (!API.payload(Resource.getResource("memapi-server.bin")))
                MessageBox.Show("Failed to send payload!\nPossible Reasons:\n- PS4 is not turned on.\n- Webkit Exploit isn't running.\n- Webkit Exploit needs restarting.", "Failed to send", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void connect()
        {
            if (!API.connect())
                MessageBox.Show("Connection failed!\nPossible Reasons:\n- PS4 is not turned on.\n- MEMAPI Payload has not been executed.\n- MEMAPI Payload has crashed.", "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void disconnect()
        {
            if (API.isConnected())
                API.disconnect();
        }

        private void notify()
        {
            StringDialog dialog = new StringDialog("Notification Message");
            if (dialog.ShowDialog() == DialogResult.OK)
                API.notify(dialog.Message);
        }
        #endregion

        #region Window
        private void addNewForm(Form form, double width = -1, double height = -1, double x = -1, double y = -1)
        {
            form.MdiParent = this;
            form.StartPosition = FormStartPosition.Manual;
            form.Show();

            PropertyInfo pi = typeof(Form).GetProperty("MdiClient", BindingFlags.Instance | BindingFlags.NonPublic);
            MdiClient cli = (MdiClient)pi.GetValue(this, null);

            if (width != -1)
                form.Width = (int)Math.Round((cli.Width / 100) * width);
            if (height != -1)
                form.Height = (int)Math.Round((cli.Height / 100) * height);
            if (x != -1)
                form.Left = (int)Math.Round((cli.Width / 100) * x);
            if (y != -1)
                form.Top = (int)Math.Round((cli.Height / 100) * y);

            form.Size = new Size(form.Width, form.Height);
            form.Location = new Point(form.Left, form.Top);

            forms.Add(form);
        }

        private void changeActiveForm(Form form)
        {
            // Get the active view
            Form active = this.ActiveMdiChild;

            // If there is no active view, show an error message
            if (active == null)
            {
                MessageBox.Show("There is no active view selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find active view index
            int index = forms.FindIndex(f => f.GetHashCode() == active.GetHashCode());
            if (index == -1)
            {
                MessageBox.Show("Failed to find the active view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show new form and set the same properties as active form
            form.MdiParent = this;
            form.Show();
            form.Size = active.Size;
            form.Location = active.Location;

            // Close active form
            active.Close();

            // Replace Form
            forms[index] = form;
        }
        #endregion

        #endregion

        #region Tool Strip Menu

        #region File
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e) => newProject();
        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e) => loadProject();
        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e) => closeProject();
        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e) => saveProject();
        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e) => saveProjectAs();
        private void recentProjectsToolStripMenuItem_Click(object sender, EventArgs e) => recentProject();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        #endregion

        #region Debug
        private void goToolStripMenuItem_Click(object sender, EventArgs e) => go();
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => pause();
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) => stop();
        private void stepToolStripMenuItem_Click(object sender, EventArgs e) => step();
        private void attachProcessToolStripMenuItem_Click(object sender, EventArgs e) => attachProcess();
        private void hardwareBreakpointsToolStripMenuItem_Click(object sender, EventArgs e) => getHardwareBreakpoints();
        #endregion

        #region Tools
        private void selectTargetToolStripMenuItem_Click(object sender, EventArgs e) => selectTarget();
        private void sendPayloadToolStripMenuItem_Click(object sender, EventArgs e) => sendPayload();
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) => connect();
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) => disconnect();
        private void notifyToolStripMenuItem_Click(object sender, EventArgs e) => notify();
        #endregion

        #region Window
        private void breakpointsToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new BreakpointsForm());
        private void disassemblyToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new DisassemblyForm());
        private void kernelToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new KernelForm());
        private void memoryToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new MemoryForm());
        private void registersToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new RegistersForm());
        private void searchToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new SearchForm());
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e) => addNewForm(new ConsoleForm());

        private void changeBreakpointsToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new BreakpointsForm());
        private void changeDisassemblyToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new DisassemblyForm());
        private void changeKernelToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new KernelForm());
        private void changeMemoryToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new MemoryForm());
        private void changeRegistersToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new RegistersForm());
        private void changeSearchToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new SearchForm());
        private void changeConsoleToolStripMenuItem_Click(object sender, EventArgs e) => changeActiveForm(new ConsoleForm());
        #endregion

        #endregion

        #region Tool Strip Button Add Form

        #region File
        private void toolStripButtonNewProject_Click(object sender, EventArgs e) => newProject();
        private void toolStripButtonLoadProject_Click(object sender, EventArgs e) => loadProject();
        private void toolStripButtonSave_Click(object sender, EventArgs e) => saveProject();
        #endregion

        #region Debug
        private void toolStripButtonPlay_Click(object sender, EventArgs e) => go();
        private void toolStripButtonPause_Click(object sender, EventArgs e) => pause();
        private void toolStripButtonStop_Click(object sender, EventArgs e) => stop();
        private void toolStripButtonStep_Click(object sender, EventArgs e) => step();
        #endregion

        #region Tools
        private void toolStripButtonSelectTarget_Click(object sender, EventArgs e) => selectTarget();
        private void toolStripButtonSendPayload_Click(object sender, EventArgs e) => sendPayload();
        private void toolStripButtonConnect_Click(object sender, EventArgs e) => connect();
        private void toolStripButtonDisconnect_Click(object sender, EventArgs e) => disconnect();
        private void toolStripButtonNotify_Click(object sender, EventArgs e) => notify();
        private void toolStripButtonAttachProcess_Click(object sender, EventArgs e) => attachProcess();
        #endregion

        #region Window
        private void toolStripButtonBreakpoints_Click(object sender, EventArgs e) => addNewForm(new BreakpointsForm());
        private void toolStripButtonDisassembly_Click(object sender, EventArgs e) => addNewForm(new DisassemblyForm());
        private void toolStripButtonKernel_Click(object sender, EventArgs e) => addNewForm(new KernelForm());
        private void toolStripButtonMemory_Click(object sender, EventArgs e) => addNewForm(new MemoryForm());
        private void toolStripButtonRegisters_Click(object sender, EventArgs e) => addNewForm(new RegistersForm());
        private void toolStripButtonSearch_Click(object sender, EventArgs e) => addNewForm(new SearchForm());
        private void toolStripButtonConsole_Click(object sender, EventArgs e) => addNewForm(new ConsoleForm());
        #endregion

        #endregion

        #region API Events
        private void onConnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onConnected), sender, e);
                return;
            }

            toolStripStatusLabelStatus.Image = Properties.Resources.connected;
            connectToolStripMenuItem.Enabled = false;
            toolStripButtonConnect.Enabled = false;
            disconnectToolStripMenuItem.Enabled = true;
            toolStripButtonDisconnect.Enabled = true;
            notifyToolStripMenuItem.Enabled = true;
            toolStripButtonNotify.Enabled = true;
            attachProcessToolStripMenuItem.Enabled = true;
            toolStripButtonAttachProcess.Enabled = true;

            toolStripStatusLabelFirmware.Text = "Firmware: " + API.getFirmware();
            toolStripStatusLabelFirmware.Visible = true;
            toolStripStatusSeperator3.Visible = true;
        }
        private void onDisconnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDisconnected), sender, e);
                return;
            }

            toolStripStatusLabelStatus.Image = Properties.Resources.disconnected;
            connectToolStripMenuItem.Enabled = true;
            toolStripButtonConnect.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            toolStripButtonDisconnect.Enabled = false;
            notifyToolStripMenuItem.Enabled = false;
            toolStripButtonNotify.Enabled = false;
            attachProcessToolStripMenuItem.Enabled = false;
            toolStripButtonAttachProcess.Enabled = false;

            toolStripStatusLabelFirmware.Visible = false;
            toolStripStatusSeperator2.Visible = false;
            toolStripStatusLabelProcess.Visible = false;
            toolStripStatusSeperator3.Visible = false;

            goToolStripMenuItem.Enabled = false;
            toolStripButtonPlay.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            toolStripButtonPause.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            toolStripButtonStop.Enabled = false;
            stepToolStripMenuItem.Enabled = false;
            toolStripButtonStep.Enabled = false;
            hardwareBreakpointsToolStripMenuItem.Enabled = false;
        }
        private void onAttached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onAttached), sender, e);
                return;
            }

            toolStripStatusSeperator2.Visible = true;
            toolStripStatusLabelProcess.Visible = true;
            toolStripStatusLabelProcess.Text = " Process: " + API.ActiveProcess.Name + " ";

            stopToolStripMenuItem.Enabled = true;
            toolStripButtonStop.Enabled = true;
            pauseToolStripMenuItem.Enabled = true;
            toolStripButtonPause.Enabled = true;
            goToolStripMenuItem.Enabled = false;
            toolStripButtonPlay.Enabled = false;
            hardwareBreakpointsToolStripMenuItem.Enabled = true;
        }
        private void onDetached(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onDetached), sender, e);
                return;
            }

            stopToolStripMenuItem.Enabled = false;
            toolStripButtonStop.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            toolStripButtonPause.Enabled = false;
            goToolStripMenuItem.Enabled = false;
            toolStripButtonPlay.Enabled = false;
            hardwareBreakpointsToolStripMenuItem.Enabled = false;
        }
        private void onGo(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onGo), sender, e);
                return;
            }

            goToolStripMenuItem.Enabled = false;
            toolStripButtonPlay.Enabled = false;

            pauseToolStripMenuItem.Enabled = true;
            toolStripButtonPause.Enabled = true;

            stepToolStripMenuItem.Enabled = false;
            toolStripButtonStep.Enabled = false;
        }
        private void onStopped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(onStopped), sender, e);
                return;
            }

            goToolStripMenuItem.Enabled = true;
            toolStripButtonPlay.Enabled = true;

            pauseToolStripMenuItem.Enabled = false;
            toolStripButtonPause.Enabled = false;

            stepToolStripMenuItem.Enabled = true;
            toolStripButtonStep.Enabled = true;
        }
        #endregion

        private void targetSelected(string ip)
        {
            // Disconnect from existing PS4
            disconnect();

            API.IP = ip;

            sendPayloadToolStripMenuItem.Enabled = true;
            toolStripButtonSendPayload.Enabled = true;
            connectToolStripMenuItem.Enabled = true;
            toolStripButtonConnect.Enabled = true;

            toolStripStatusSeperator1.Visible = true;
            toolStripStatusLabelIpAddress.Visible = true;
            toolStripStatusLabelIpAddress.Text = " IP Address: " + ip + " ";

            Properties.Settings.Default.defaultPs4Ip = ip;
            Properties.Settings.Default.Save();
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (API.isConnected())
                API.disconnect();
        }
    }
}
