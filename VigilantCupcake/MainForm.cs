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
using VigilantCupcake.TreeViewUtils;

namespace VigilantCupcake {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            hostsFileView.LoadFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText); //TODO: frag
        }

        private void exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            hostsFileView.SaveFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText); //TODO: frag
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OS_Utils.DnsUtil.FlushDns();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            FileTreeUtils.ListDirectory(localFragmentTree, OS_Utils.LocalFiles.BaseDirectory);
            localFragmentTree.Nodes[0].Expand();
        }

        private void localFragmentTree_AfterCheck(object sender, TreeViewEventArgs e) {
            FileTreeUtils.CheckAllChildNodes(e.Node, e.Node.Checked);
            var allchecked = FileTreeUtils.GetAllCheckedFullPaths(e.Node.TreeView.Nodes);
            var paths = allchecked.Select(x => Path.Combine(OS_Utils.LocalFiles.BaseDirectoryRoot, x));

            //TODO: frag
            var files = from path in paths
                       select File.ReadAllText(path);

            hostsFileView.Text = (files.Count() > 0) ? files.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
        }

        private void localFragmentTree_AfterSelect(object sender, TreeViewEventArgs e) {
            if (e.Node.Nodes.Count != 0 || e.Node.IsSelected == false) return;
            var fullpath = Path.Combine(OS_Utils.LocalFiles.BaseDirectoryRoot, e.Node.FullPath);
            currentFragmentView.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
        }
    }
}
