using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantCupcake.TreeViewUtils {
    public static class FileTreeUtils {

        public static void ListDirectory(TreeView treeView, string path) {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        public static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo) {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }

        //public static string GetFullPathOfFileNode(TreeNode treeNode, string current) {
        //    if (treeNode.Parent != null) {
        //        return Path.Combine(GetFullPathOfFileNode(treeNode.Parent, current), treeNode.Text);
        //    }
        //    return current;
        //}

        public static void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked) {
            foreach (TreeNode node in treeNode.Nodes) {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0) {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        public static IEnumerable<string> GetAllCheckedFullPaths(TreeNodeCollection treeNode) {
            var retVal = new List<String>();

            if (treeNode != null) {
                foreach (TreeNode node in treeNode) {
                    if (node.Checked) {
                        retVal.Add(node.FullPath);
                    }

                    retVal.AddRange(GetAllCheckedFullPaths(node.Nodes));
                }
            }

            return retVal;
        }
    }
}
