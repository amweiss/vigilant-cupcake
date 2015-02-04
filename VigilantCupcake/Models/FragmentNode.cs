using Aga.Controls.Tree;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VigilantCupcake.Models {

    internal class FragmentNode : Node {
        private bool _firstUpdate = true;
        private int _updatingNodes = 0;

        private Fragment _fragment = null;

        public Fragment Fragment {
            get { return _fragment; }
            set {
                if (_fragment != value) {
                    _fragment = value;
                    if (_fragment != null) {
                        updateCheckState(_fragment.Enabled ? System.Windows.Forms.CheckState.Checked : System.Windows.Forms.CheckState.Unchecked);
                    }
                }
            }
        }

        public string FullPath {
            get {
                if (Parent is FragmentNode) {
                    var pnode = (FragmentNode)Parent;
                    return pnode.FullPath + '\\' + Text;
                } else {
                    return Text;
                }
            }
        }

        private string FilePath {
            get {
                return Path.Combine(OS_Utils.LocalFiles.BaseDirectoryRoot, FullPath);
            }
        }

        public FragmentNode(string text) :
            base(text) {
            Text = text;
        }

        override public bool IsLeaf {
            get { return (Fragment != null); }
        }

        private System.Windows.Forms.CheckState _checkState = System.Windows.Forms.CheckState.Unchecked;

        override public CheckState CheckState {
            get { return _checkState; }
            set {
                updateCheckState(value, true);
            }
        }

        private string _text;

        override public string Text {
            get { return _text; }
            set {
                if (_text != value) {
                    _text = value;
                    if (Fragment != null) Fragment.Name = value;
                    NotifyModel();
                }
            }
        }

        public void delete() {
            if (Nodes != null && Nodes.Count > 0)
                Nodes.Where(n => n is FragmentNode).ToList().ForEach(f => ((FragmentNode)f).delete());

            if (Fragment != null) {
                Fragment.delete();
            } else if (Directory.Exists(FilePath)) {
                Directory.Delete(FilePath, true);
            }
        }

        private void updateCheckState(System.Windows.Forms.CheckState newValue, bool fromProperty = false) {
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
                    updateParent(_checkState);
                }

                if (Nodes.Count > 0 && _checkState != System.Windows.Forms.CheckState.Indeterminate) {
                    Nodes.ToList().ForEach(n => ((FragmentNode)n).updateCheckState(_checkState));
                }
                _updatingNodes--;
                NotifyModel();
            }
        }

        private void updateParent(System.Windows.Forms.CheckState checkstate) {
            if (Parent.Nodes.All(n => n.CheckState == checkstate))
                ((FragmentNode)Parent).updateCheckState(newValue: checkstate);
            else
                ((FragmentNode)Parent).updateCheckState(newValue: System.Windows.Forms.CheckState.Indeterminate);
        }
    }
}