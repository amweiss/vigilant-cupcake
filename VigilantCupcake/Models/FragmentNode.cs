using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {
    class FragmentNode : Node {

        public Fragment Fragment { get; set; }

        public FragmentNode(string text):
            base(text) {
        }

        override public bool IsLeaf {
            get { return (Fragment != null); }
        }
    }
}
