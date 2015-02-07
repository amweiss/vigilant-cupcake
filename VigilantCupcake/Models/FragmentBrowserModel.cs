using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {

    public class FragmentBrowserModel : FilterableTreeModel {

        public FragmentBrowserModel(string path) {
            PendingDownloads = 0;
            Root.Nodes.Add(createDirectoryNode(new DirectoryInfo(path)));
        }

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

        public int PendingDownloads { get; protected set; }

        public void saveAll() {
            if (PendingDownloads > 0) {
                new TaskFactory().StartNew(() => {
                    while (PendingDownloads > 0) {
                        System.Threading.Thread.Sleep(1000);
                    }
                    doSaveAll();
                });
            } else {
                doSaveAll();
            }
        }

        private FragmentNode createDirectoryNode(DirectoryInfo directoryInfo) {
            var directoryNode = new FragmentNode() { Text = directoryInfo.Name };
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(createDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles()) {
                var name = Path.GetFileNameWithoutExtension(file.Name);
                var treeNode = new FragmentNode() { Text = name };
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

        private void doSaveAll() {
            var fragments = from node in getAllNodesRecursively(Root)
                            where node != null && node.Fragment != null
                            select node.Fragment;
            fragments.ToList().ForEach(f => f.save()); //Doing it in parallel seems to deadlock UI on label update
        }

        private void fragment_ContentsDownloaded(object sender, EventArgs e) {
            PendingDownloads--;
        }

        private void fragment_DownloadStarting(object sender, EventArgs e) {
            PendingDownloads++;
        }

        private IEnumerable<FragmentNode> getAllNodesRecursively(FragmentNode subnode) {
            yield return subnode;

            foreach (var node in subnode.Nodes) {
                foreach (var n in getAllNodesRecursively(node)) {
                    yield return n;
                }
            }
        }
    }
}