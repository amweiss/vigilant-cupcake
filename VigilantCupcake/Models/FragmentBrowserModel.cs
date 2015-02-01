using Aga.Controls.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {
    class FragmentBrowserModel : ITreeModel {
        public int PendingDownloads { get; protected set; }

        public IEnumerable<FragmentNode> Nodes {
            get {
                return getAllNodesRecursively(Root);
            }
        }

        public IEnumerable<Fragment> Fragments {
            get {
                return Nodes.Where(x => x.Fragment != null).Select(y => y.Fragment);
            }
        }

        private string RootPath { get; set; }

        private FragmentNode Root { get; set; }

        public FragmentBrowserModel(string path) {
            PendingDownloads = 0;
            RootPath = path;
        }

        public void saveAll() {
            if (PendingDownloads > 0) {
                var backgroundSave = new TaskFactory().StartNew(() => {
                    while (PendingDownloads > 0) {
                        System.Threading.Thread.Sleep(1000);
                    }
                    doSaveAll();
                });
            } else {
                doSaveAll();
            }
        }

        public void remove(FragmentNode node) {
            if (node != null) {
                node.Parent = null;
            }
        }

        public bool IsLeaf(TreePath treePath) {
            return treePath.LastNode != null && ((FragmentNode)treePath.LastNode).IsLeaf;
        }

        public IEnumerable GetChildren(TreePath treePath) {
            if (treePath.IsEmpty()) {
                if (Root == null) {
                    Root = createDirectoryNode(new DirectoryInfo(RootPath));
                }
                yield return Root;
            } else {
                var parent = treePath.LastNode as FragmentNode;
                if (parent != null) {
                    foreach (var node in getAllNodesRecursively(parent).Where(x => x != parent))
                        yield return node;
                } else {
                    yield break;
                }
            }
        }

        private IEnumerable<FragmentNode> getAllNodesRecursively(FragmentNode subnode) {
            yield return subnode;

            foreach (var node in subnode.Nodes) {
                foreach (var n in getAllNodesRecursively((FragmentNode)node)) {
                    yield return n;
                }
            }
        }

        private FragmentNode createDirectoryNode(DirectoryInfo directoryInfo) {
            var directoryNode = new FragmentNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(createDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles()) {
                var name = Path.GetFileNameWithoutExtension(file.Name);
                var treeNode = new FragmentNode(name);
                var fragment = new Fragment() {
                    Name = name,
                    FullPath = file.FullName,
                    Enabled = Properties.Settings.Default.SelectedFiles != null && Properties.Settings.Default.SelectedFiles.Contains(file.FullName)
                };
                treeNode.Fragment = fragment;
                fragment.ContentsDownloaded += fragment_ContentsDownloaded;
                fragment.DownloadStarting += fragment_DownloadStarting;
                directoryNode.Nodes.Add(treeNode);
            }
            return directoryNode;
        }

        private void fragment_DownloadStarting(object sender, EventArgs e) {
            PendingDownloads++;
        }

        private void fragment_ContentsDownloaded(object sender, EventArgs e) {
            PendingDownloads--;
        }

        private void doSaveAll() {
            getAllNodesRecursively(Root).AsParallel().Where(y => y.Fragment != null).ForAll(x => x.Fragment.save());
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;
    }
}
