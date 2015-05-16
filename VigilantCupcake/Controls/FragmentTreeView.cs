using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VigilantCupcake.ExtensionMethods;
using VigilantCupcake.Models;
using VigilantCupcake.OperatingSystemUtilities;
using VigilantCupcake.ViewExtensions;

namespace VigilantCupcake.Controls {

    public partial class FragmentTreeView : TreeViewAdv {
        private FragmentBrowserModel _model = new FragmentBrowserModel(LocalFiles.BaseDirectory);

        public FragmentTreeView() {
            base.Model = _model;
            InitializeComponent();
            Root.Children.ToList().ForEach(x => x.Expand());

            Model.NodesChanged += _treeModel_NodesChanged;
        }

        public new FragmentBrowserModel Model { get { return _model; } }

        public void buildImportedPaths(string remoteUrl, string name) {
            var split = name.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            if (split.Length > 1) {
                var foundChild = SelectedNode.Children.FirstOrDefault(x => ((FragmentNode)x.Tag).Text == split[0]);
                if (foundChild != null) {
                    SelectedNode = foundChild;
                } else {
                    createNewNode(false, split[0], split[0]);
                }
                buildImportedPaths(remoteUrl, string.Join(Path.DirectorySeparatorChar.ToString(), split.Skip(1)));
            } else {
                createNewNode(true, name, remoteUrl, false);
            }
        }

        public void createNewDirectory() {
            createNewNode(false);
        }

        public void createNewFragment() {
            createNewNode(true);
        }

        public void fragmentListContextMenuRename_Click(object sender, EventArgs e) {
            nodeTextBox1.BeginEdit();
        }

        public void importRemoteFragmentsToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dialog = new OpenFileDialog()) {
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK) {
                    try {
                        using (Stream myStream = dialog.OpenFile()) {
                            if (myStream != null) {
                                var lines = new List<string>();
                                using (var sr = new StreamReader(myStream)) {
                                    string line;
                                    while ((line = sr.ReadLine()) != null) {
                                        lines.Add(line);
                                    }
                                }

                                var prefix = lines.GetLongestCommonPrefix();
                                var currentSelection = SelectedNode;

                                foreach (var item in lines) {
                                    SelectedNode = currentSelection;
                                    var name = item;
                                    name = name.Replace(prefix, string.Empty);
                                    buildImportedPaths(item, name);
                                }

                                SelectedNode = currentSelection;
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Error: Could not read from fragment list source. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void _treeModel_NodesChanged(object sender, TreeModelEventArgs e) {
            var node = (FragmentNode)e.Children[0];
            node.Text = node.Text.AsFileName();
        }

        private void createNewNode(bool isFragment, string text = null, string remote = null, bool selectNode = true) {
            var selectedNode = (SelectedNode != null) ? (FragmentNode)SelectedNode.Tag : (FragmentNode)Root.Children[0].Tag;
            var directoryNode = selectedNode.IsLeaf ? selectedNode.Parent : selectedNode;
            var treeNode = new FragmentNode();

            if (isFragment) {
                var rootPath = Path.Combine(OperatingSystemUtilities.LocalFiles.BaseDirectoryRoot, directoryNode.FullPath);
                var fragment = new Fragment() {
                    RootPath = rootPath,
                    FileContents = string.Empty
                };
                if (!string.IsNullOrWhiteSpace(remote)) fragment.RemoteLocation = remote;
                treeNode.Fragment = fragment;
            }

            var validText = !string.IsNullOrWhiteSpace(text);
            var name = (validText) ? text : (isFragment) ? "New Fragment" : "New Folder";
            name = name.AsFileName();
            treeNode.Text = name;
            var fileNumber = 1;
            while (directoryNode.Nodes.Any(x => x.Text.Equals(treeNode.Text))) {
                var newName = string.Format("{0} {1}", name, fileNumber);
                treeNode.Text = newName;
                fileNumber++;
            }

            treeNode.Parent = directoryNode;
            if (selectNode || !validText) SelectedNode = FindNodeByTag(treeNode);
            if (!validText) {
                nodeTextBox1.BeginEdit();
            }
        }

        private void downloadFragmentToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SelectedNode != null) {
                var selectedNode = (FragmentNode)SelectedNode.Tag;
                if (selectedNode != null && selectedNode.Fragment != null) {
                    selectedNode.Fragment.DownloadFile();
                }
            }
        }

        private void fragmentListContextMenu_Opening(object sender, CancelEventArgs e) {
            if (SelectedNode != null) {
                var selectedNode = (FragmentNode)SelectedNode.Tag;
                if (selectedNode == null) return;

                downloadFragmentToolStripMenuItem.Visible = (selectedNode.Fragment != null) && !string.IsNullOrWhiteSpace(selectedNode.Fragment.RemoteLocation);
                importRemoteFragmentsToolStripMenuItem.Visible = (!selectedNode.IsLeaf && selectedNode.Nodes.Count == 0);

                toolStripSeparator5.Visible = downloadFragmentToolStripMenuItem.Visible || importRemoteFragmentsToolStripMenuItem.Visible;
            }
        }

        private void fragmentListContextMenuDelete_Click(object sender, EventArgs e) {
            if (Prompts.confirmAndDelete(SelectedNode.Tag as FragmentNode) == DialogResult.Yes) {
                if (SelectedNode != null)
                    (SelectedNode.Tag as FragmentNode).Parent = null;
            }
        }

        private void menuNewFolder_Click(object sender, EventArgs e) {
            createNewDirectory();
        }

        private void menuNewFragment_Click(object sender, EventArgs e) {
            createNewFragment();
        }
    }
}