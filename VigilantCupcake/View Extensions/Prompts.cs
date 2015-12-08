using System.Windows.Forms;
using VigilantCupcake.Models;

namespace VigilantCupcake.ViewExtensions {

    static class Prompts {

        public static DialogResult confirmAndDelete(FragmentNode node) {
            DialogResult result = MessageBox.Show($"Delete {node.Text}?", "Delete Fragment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                node.Delete();
                node.Parent = null;
            }

            return result;
        }
    }
}