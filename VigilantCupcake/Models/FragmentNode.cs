using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantCupcake.Models {
    class FragmentNode : Node {

        private bool _firstUpdate = true;

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

        public FragmentNode(string text):
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
            if (Fragment != null) {
                Fragment.delete();
            } else {
                var fileHandleFree = OS_Utils.LocalFiles.WaitForFile(FullPath);
                if (fileHandleFree)
                    Directory.Delete(FullPath, true);
            }
        }

        private void updateCheckState(System.Windows.Forms.CheckState newValue, bool fromProperty = false) {
            if (fromProperty && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }
            
            if (Fragment != null && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }

            if (_checkState != newValue || _firstUpdate) {
                _firstUpdate = false;
                _checkState = newValue;
                if (Fragment != null) {
                    Fragment.Enabled = (_checkState == System.Windows.Forms.CheckState.Checked || _checkState == System.Windows.Forms.CheckState.Indeterminate);
                }

                if (Parent != null && Parent is FragmentNode) {
                    updateParent(_checkState);
                }

                if (Nodes.Count > 0 && _checkState != System.Windows.Forms.CheckState.Indeterminate) {
                    Nodes.ToList().ForEach(n => ((FragmentNode)n).updateCheckState(_checkState));
                }
                NotifyModel();
            }
        }

        private void updateParent(System.Windows.Forms.CheckState checkstate) {
            if (Parent.Nodes.All(n => n.CheckState == checkstate))
                ((FragmentNode)Parent).updateCheckState(checkstate);
            else
                ((FragmentNode)Parent).updateCheckState(System.Windows.Forms.CheckState.Indeterminate);
        }
    }
}
