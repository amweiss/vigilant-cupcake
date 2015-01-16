using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantCupcake {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            hostsFileView.LoadFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText);
        }

        private void save_Click(object sender, EventArgs e) {
            hostsFileView.SaveFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText);
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OS_Utils.DnsUtil.FlushDns();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ListDirectory(localFragmentTree, OS_Utils.LocalFiles.BaseDirectory);
            localFragmentTree.Nodes[0].Expand();
        }

        private void ListDirectory(TreeView treeView, string path) {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo) {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }

        private string GetFullPathOfFileNode(TreeNode treeNode, string current) {
            if (treeNode.Parent != null) {
                return Path.Combine(GetFullPathOfFileNode(treeNode.Parent, current), treeNode.Text);
            }

            return current;
        }

        private void localFragmentTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Node.Nodes.Count != 0) return;
            var filename = GetFullPathOfFileNode(e.Node, OS_Utils.LocalFiles.BaseDirectory);
            currentFragmentView.LoadFile(filename, RichTextBoxStreamType.PlainText);
        }
    }
}
