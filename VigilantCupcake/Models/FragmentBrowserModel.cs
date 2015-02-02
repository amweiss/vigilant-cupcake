using Aga.Controls.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {
    class FragmentBrowserModel : TreeModel {
        public int PendingDownloads { get; protected set; }

        public IEnumerable<FragmentNode> FragmentNodes {
            get {
                return getAllNodesRecursively(Root).Select(x => x as FragmentNode);
            }
        }

        public IEnumerable<Fragment> Fragments {
            get {
                return FragmentNodes.Where(x => x != null && x.Fragment != null).Select(y => y.Fragment);
            }
        }

        public FragmentBrowserModel(string path) {
            PendingDownloads = 0;
            Nodes.Add(createDirectoryNode(new DirectoryInfo(OS_Utils.LocalFiles.BaseDirectory)));
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

        private IEnumerable<Node> getAllNodesRecursively(Node subnode) {
            yield return subnode;

            foreach (var node in subnode.Nodes) {
                foreach (var n in getAllNodesRecursively((Node)node)) {
                    yield return n;
                }
            }
        }

        private Node createDirectoryNode(DirectoryInfo directoryInfo) {
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
                directoryNode.Nodes.Add(treeNode);
                treeNode.Fragment = fragment; //Assign fragment after adding to tree so hierarchy is in place
                fragment.ContentsDownloaded += fragment_ContentsDownloaded;
                fragment.DownloadStarting += fragment_DownloadStarting;
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
            getAllNodesRecursively(Root).Where(y => y as FragmentNode != null && ((FragmentNode)y).Fragment != null).ToList().ForEach(x => ((FragmentNode)x).Fragment.save());
        }
    }
}
