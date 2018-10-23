using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MEMAPI;

namespace MEMAPI_Debugger.Forms
{
    public partial class KernelForm : Form
    {
        List<Module> modules;
        List<Process> processes;

        public KernelForm()
        {
            InitializeComponent();

            modules = new List<Module>();
            processes = new List<Process>();

            // Events
            API.ConnectedEvent += onConnected;
            API.DisconnectEvent += onDisconnected;

            refresh();
        }

        private void onConnected(object sender, EventArgs e)
        {
            refresh();
        }

        private void onDisconnected(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            API.ErrorCode error;
            if (!API.isConnected())
            {
                modules = new List<Module>();
                processes = new List<Process>();
            }
            else
            {
                modules = API.getModules(out error);
                processes = API.getProcesses(out error);
            }

            // Clear existing nodes
            TreeNode processNode = getRootByTag("process");
            TreeNode moduleNode = getRootByTag("modules");

            processNode.Nodes.Clear();
            moduleNode.Nodes.Clear();

            // Add Process Nodes
            foreach (Process process in processes)
            {
                TreeNode sub = processNode.Nodes.Add(process.Id.ToString(), process.Id + " | " + process.Name, "process.png");
                sub.Nodes.Add(process.Id + "_loading", "Loading...", "loading.png");
            }
            processNode.Text = "Processes (" + processes.Count + ")";

            // Add Module Nodes
            ulong totalCodeSize = 0;
            ulong totalDataSize = 0;
            foreach (Module module in modules)
            {
                ulong memorySize = module.CodeSize + module.DataSize;
                TreeNode sub = moduleNode.Nodes.Add(module.Name, module.Id + " | " + module.Name + " | Memory Size: 0x" + Helper.ulongToString(memorySize, false) + " (" + Helper.sizeToSuffix(memorySize) + ")", "document.png");

                sub.Nodes.Add(module.Name + "_text", "Text Segment | Memory Size (.text) 0x" + Helper.ulongToString(module.CodeSize, false) + " (" + Helper.sizeToSuffix(module.CodeSize) + ")", "document.png");
                sub.Nodes.Add(module.Name + "_data", "Data Segment | Memory Size (.data) 0x" + Helper.ulongToString(module.DataSize, false) + " (" + Helper.sizeToSuffix(module.DataSize) + ")", "document.png");

                totalCodeSize += module.CodeSize;
                totalDataSize += module.DataSize;
            }
            ulong totalMemorySize = totalCodeSize + totalDataSize;
            moduleNode.Text = "Modules (" + modules.Count + ")";
            if (modules.Count > 0)
                moduleNode.Text += " | Memory Size " + Helper.sizeToSuffix(totalMemorySize) + " (.text = " + Helper.sizeToSuffix(totalCodeSize) + ", .data = " + Helper.sizeToSuffix(totalDataSize) + ")";
        }

        private TreeNode getRootByTag(string tag)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Tag.ToString() == tag)
                    return node;
            }
            return null;
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count < 1 || e.Node.FirstNode.Text != "Loading...")
                return;

            int processId = Convert.ToInt32(e.Node.Name.Replace("_loading", ""));

            API.ErrorCode error;
            List<Thread> threads = API.getProcessThreads(out error, processId);

            e.Node.Nodes.Clear();
            foreach (Thread thread in threads)
                e.Node.Nodes.Add(processId + "_" + thread.Id, "Thread: " + thread.Id, "blue_cog.png");
        }
    }
}
