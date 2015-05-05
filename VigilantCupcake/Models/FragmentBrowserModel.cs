using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {

    public class FragmentBrowserModel : FilterableTreeModel {

        public FragmentBrowserModel(string path) {
            Root.Nodes.Add(CreateDirectoryNode(new DirectoryInfo(path), Root));
        }

        public IEnumerable<FragmentNode> FragmentNodes {
            get {
                return GetAllNodesRecursively(Root).Select(x => x as FragmentNode);
            }
        }

        public IEnumerable<Fragment> Fragments {
            get {
                return FragmentNodes.Where(x => x != null && x.Fragment != null).Select(y => y.Fragment);
            }
        }

        public void SaveAll() {
            if (Fragments.Any(f => f.DownloadPending)) {
                new TaskFactory().StartNew(() => {
                    while (Fragments.Any(f => f.DownloadPending)) {
                        System.Threading.Thread.Sleep(1000);
                    }
                    DoSaveAll();
                });
            } else {
                DoSaveAll();
            }
        }

        private FragmentNode CreateDirectoryNode(DirectoryInfo directoryInfo, FragmentNode parent) {
            var directoryNode = new FragmentNode() { Text = directoryInfo.Name, Parent = parent};
            if (!directoryInfo.Exists) return directoryNode;
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory, directoryNode));
            foreach (var file in directoryInfo.GetFiles()) {
                var name = Path.GetFileNameWithoutExtension(file.Name);
                var treeNode = new FragmentNode() { Text = name, Parent = directoryNode };
                var fragment = new Fragment() {
                    Name = name,
                    FullPath = file.FullName,
                    Enabled = UserConfig.Instance.SelectedFiles != null && UserConfig.Instance.SelectedFiles.Contains(file.FullName)
                };
                fragment.ForceLoad();
                directoryNode.Nodes.Add(treeNode);
                treeNode.Fragment = fragment; //Assign fragment after adding to tree so hierarchy is in place
            }
            return directoryNode;
        }

        private void DoSaveAll() {
            Fragments.ToList().ForEach(f => f.Save()); //Doing it in parallel seems to deadlock UI on label update
        }

        private IEnumerable<FragmentNode> GetAllNodesRecursively(FragmentNode subnode) {
            yield return subnode;

            foreach (var node in subnode.Nodes) {
                foreach (var n in GetAllNodesRecursively(node)) {
                    yield return n;
                }
            }
        }
    }
}