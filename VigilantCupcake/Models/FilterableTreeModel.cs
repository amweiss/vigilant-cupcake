using Aga.Controls.Tree;
using System;
using System.Collections.Generic;

namespace VigilantCupcake.Models {

    public class FilterableTreeModel : ITreeModel {
        string _filter = null;
        FragmentNode _root;

        public FilterableTreeModel() {
            _root = new FragmentNode();
            _root.Model = this;
        }

        public string Filter { get { return _filter; } set { _filter = value; OnStructureChanged(new TreePathEventArgs(GetPath(Root))); } }

        public FragmentNode Root {
            get { return _root; }
        }

        public FragmentNode FindNode(TreePath path) => (path == null || path.IsEmpty()) ? _root : FindNode(_root, path, 0);

        public TreePath GetPath(FragmentNode node) {
            if (node == _root)
                return TreePath.Empty;
            else {
                var stack = new Stack<object>();
                while (node != _root) {
                    stack.Push(node);
                    node = node.Parent;
                }
                return new TreePath(stack.ToArray());
            }
        }

        FragmentNode FindNode(FragmentNode root, TreePath path, int level) {
            foreach (FragmentNode node in root.Nodes)
                if (node == path.FullPath[level]) {
                    if (level == path.FullPath.Length - 1)
                        return node;
                    else
                        return FindNode(node, path, level + 1);
                }
            return null;
        }

        #region ITreeModel Members

        public event EventHandler<TreeModelEventArgs> NodesChanged;

        public event EventHandler<TreeModelEventArgs> NodesInserted;

        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public event EventHandler<TreePathEventArgs> StructureChanged;

        public System.Collections.IEnumerable GetChildren(TreePath treePath) {
            FragmentNode node = FindNode(treePath);
            if (node != null) {
                foreach (FragmentNode n in node.Nodes) {
                    if (n.Fragment == null || string.IsNullOrWhiteSpace(Filter) || n.Fragment.FileContents.Contains(Filter))
                        yield return n;
                }
            } else
                yield break;
        }

        public bool IsLeaf(TreePath treePath) {
            FragmentNode node = FindNode(treePath);
            if (node != null) {
                if (node.Fragment == null || string.IsNullOrWhiteSpace(Filter) || node.Fragment.FileContents.Contains(Filter))
                    return node.IsLeaf;
                else
                    return false;
            } else {
                throw new ArgumentException("Node not found.");
            }
        }

        public void OnStructureChanged(TreePathEventArgs args) {
            if (StructureChanged != null)
                StructureChanged(this, args);
        }

        internal void OnNodeInserted(FragmentNode parent, int index, FragmentNode node) {
            var args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
            NodesInserted?.Invoke(this, args);
        }

        internal void OnNodeRemoved(FragmentNode parent, int index, FragmentNode node) {
            var args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
            NodesRemoved?.Invoke(this, args);
        }

        internal void OnNodesChanged(TreeModelEventArgs args) {
            NodesChanged?.Invoke(this, args);
        }

        #endregion ITreeModel Members
    }
}