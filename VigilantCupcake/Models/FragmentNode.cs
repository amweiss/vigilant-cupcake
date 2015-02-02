using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantCupcake.Models {
    class FragmentNode : Node {

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

        public FragmentNode(string text):
            base(text) {
        }

        override public bool IsLeaf {
            get { return (Fragment != null); }
        }

        private CheckState _checkState;
        override public CheckState CheckState {
            get { return _checkState; }
            set {
                updateCheckState(value, true);
            }
        }

        private void updateCheckState(System.Windows.Forms.CheckState newValue, bool fromProperty = false) {
            if (fromProperty && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }
            
            if (Fragment != null && newValue == System.Windows.Forms.CheckState.Indeterminate) {
                newValue = System.Windows.Forms.CheckState.Unchecked;
            }

            if (_checkState != newValue) {
                _checkState = newValue;
                if (Fragment != null) {
                    Fragment.Enabled = (_checkState == System.Windows.Forms.CheckState.Checked || _checkState == System.Windows.Forms.CheckState.Indeterminate);
                }

                if (Parent != null && Parent is FragmentNode) {
                    if (_checkState == System.Windows.Forms.CheckState.Checked && !Parent.IsChecked && Parent.Nodes.Any(n => !n.IsChecked)) ((FragmentNode)Parent).updateCheckState(System.Windows.Forms.CheckState.Indeterminate);
                    if (_checkState == System.Windows.Forms.CheckState.Checked && Parent.Nodes.All(n => n.IsChecked)) ((FragmentNode)Parent).updateCheckState(System.Windows.Forms.CheckState.Checked);
                    if (_checkState == System.Windows.Forms.CheckState.Unchecked && Parent.IsChecked && Parent.Nodes.Any(n => n.IsChecked)) ((FragmentNode)Parent).updateCheckState(System.Windows.Forms.CheckState.Indeterminate);
                    if (_checkState == System.Windows.Forms.CheckState.Unchecked && Parent.Nodes.All(n => !n.IsChecked)) ((FragmentNode)Parent).updateCheckState(System.Windows.Forms.CheckState.Unchecked);
                }

                if (Nodes.Count > 0 && _checkState != System.Windows.Forms.CheckState.Indeterminate) {
                    Nodes.ToList().ForEach(n => ((FragmentNode)n).updateCheckState(_checkState));
                }

                NotifyModel();
            }
        }
    }
}
