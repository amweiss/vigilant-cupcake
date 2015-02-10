using Aga.Controls.Tree;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VigilantCupcake.Models {

    public class FragmentNode {
        private System.Windows.Forms.CheckState _checkState = System.Windows.Forms.CheckState.Unchecked;
        private bool _firstUpdate = true;
        private Fragment _fragment = null;
        private string _text;
        private int _updatingNodes = 0;

        #region NodeCollection

        public class FragmentNodeCollection : Collection<FragmentNode> {
            private FragmentNode _owner;

            public FragmentNodeCollection(FragmentNode owner) {
                _owner = owner;
            }

            protected override void ClearItems() {
                while (this.Count != 0)
                    this.RemoveAt(this.Count - 1);
            }

            protected override void InsertItem(int index, FragmentNode item) {
                if (item == null)
                    throw new ArgumentNullException("item");

                if (item.Parent != _owner) {
                    if (item.Parent != null)
                        item.Parent.Nodes.Remove(item);
                    item._parent = _owner;
                    base.InsertItem(index, item);

                    FilterableTreeModel model = _owner.FindModel();
                    if (model != null)
                        model.OnNodeInserted(_owner, index, item);
                }
            }

            protected override void RemoveItem(int index) {
                FragmentNode item = this[index];
                item._parent = null;
                base.RemoveItem(index);

                FilterableTreeModel model = _owner.FindModel();
                if (model != null)
                    model.OnNodeRemoved(_owner, index, item);
            }

            protected override void SetItem(int index, FragmentNode item) {
                if (item == null)
                    throw new ArgumentNullException("item");

                RemoveAt(index);
                InsertItem(index, item);
            }
        }

        #endregion NodeCollection

        #region Properties

        private FilterableTreeModel _model;
        private FragmentNodeCollection _nodes;

        private FragmentNode _parent;

        public int Index {
            get {
                if (_parent != null)
                    return _parent.Nodes.IndexOf(this);
                else
                    return -1;
            }
        }

        public bool IsChecked {
            get {
                return CheckState != CheckState.Unchecked;
            }
            set {
                if (value)
                    CheckState = CheckState.Checked;
                else
                    CheckState = CheckState.Unchecked;
            }
        }

        public FragmentNode NextNode {
            get {
                int index = Index;
                if (index >= 0 && index < _parent.Nodes.Count - 1)
                    return _parent.Nodes[index + 1];
                else
                    return null;
            }
        }

        public Collection<FragmentNode> Nodes {
            get { return _nodes; }
        }

        public FragmentNode Parent {
            get { return _parent; }
            set {
                if (value != _parent) {
                    if (_parent != null)
                        _parent.Nodes.Remove(this);

                    if (value != null)
                        value.Nodes.Add(this);
                }
            }
        }

        public FragmentNode PreviousNode {
            get {
                int index = Index;
                if (index > 0)
                    return _parent.Nodes[index - 1];
                else
                    return null;
            }
        }

        internal FilterableTreeModel Model {
            get { return _model; }
            set { _model = value; }
        }

        #endregion Properties

        public FragmentNode()
            : this(string.Empty) {
        }

        public FragmentNode(string text) {
            _text = text;
            _nodes = new FragmentNodeCollection(this);
        }

        public CheckState CheckState {
            get { return _checkState; }
            set {
                UpdateCheckState(value, true);
            }
        }

        public string FilePath {
            get {
                return Path.Combine(OperatingSystemUtilities.LocalFiles.BaseDirectoryRoot, FullPath);
            }
        }

        public Fragment Fragment {
            get { return _fragment; }
            set {
                if (_fragment != value) {
                    _fragment = value;
                    if (_fragment != null) {
                        UpdateCheckState(_fragment.Enabled ? System.Windows.Forms.CheckState.Checked : System.Windows.Forms.CheckState.Unchecked);
                    }
                }
            }
        }

        public string FullPath {
            get {
                if (Parent == null || Parent.Parent == null) {
                    return Text;
                } else {
                    return Parent.FullPath + '\\' + Text;
                }
            }
        }

        public bool IsLeaf {
            get { return (Fragment != null); }
        }

        public string Text {
            get { return _text; }
            set {
                if (_text != value) {
                    _text = value;
                    if (Fragment != null) Fragment.Name = value;
                    NotifyModel();
                }
            }
        }

        public void Delete() {
            if (Nodes != null && Nodes.Count > 0)
                Nodes.Where(n => n is FragmentNode).ToList().ForEach(f => ((FragmentNode)f).Delete());

            if (Fragment != null) {
                Fragment.Delete();
            } else if (Directory.Exists(FilePath)) {
                Directory.Delete(FilePath, true);
            }
        }

        protected void NotifyModel() {
            FilterableTreeModel model = FindModel();
            if (model != null && Parent != null) {
                TreePath path = model.GetPath(Parent);
                if (path != null) {
                    TreeModelEventArgs args = new TreeModelEventArgs(path, new int[] { Index }, new object[] { this });
                    model.OnNodesChanged(args);
                }
            }
        }

        private FilterableTreeModel FindModel() {
            FragmentNode node = this;
            while (node != null) {
                if (node.Model != null)
                    return node.Model;
                node = node.Parent;
            }
            return null;
        }

        private void UpdateCheckState(System.Windows.Forms.CheckState newValue, bool fromProperty = false) {
            if (fromProperty && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }

            if (Fragment != null && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }

            if (_updatingNodes == 0 && (_checkState != newValue || _firstUpdate)) {
                _firstUpdate = false;
                _checkState = newValue;
                if (Fragment != null) {
                    Fragment.Enabled = (_checkState == System.Windows.Forms.CheckState.Checked || _checkState == System.Windows.Forms.CheckState.Indeterminate);
                }

                _updatingNodes++;
                if (Parent != null && Parent is FragmentNode) {
                    UpdateParent(_checkState);
                }

                if (Nodes.Count > 0 && _checkState != System.Windows.Forms.CheckState.Indeterminate) {
                    Nodes.ToList().ForEach(n => ((FragmentNode)n).UpdateCheckState(_checkState));
                }
                _updatingNodes--;
                NotifyModel();
            }
        }

        private void UpdateParent(System.Windows.Forms.CheckState checkstate) {
            if (Parent.Nodes.All(n => n.CheckState == checkstate))
                ((FragmentNode)Parent).UpdateCheckState(newValue: checkstate);
            else
                ((FragmentNode)Parent).UpdateCheckState(newValue: System.Windows.Forms.CheckState.Indeterminate);
        }
    }
}