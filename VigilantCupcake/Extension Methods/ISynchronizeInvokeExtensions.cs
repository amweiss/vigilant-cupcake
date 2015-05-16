using System.ComponentModel;
using System.Windows.Forms;

namespace VigilantCupcake.ExtensionMethods {

    internal static class ISynchronizeInvokeExtensions {

        public static void BeginInvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action) {
            if (obj.InvokeRequired) {
                var args = new object[0];
                obj.BeginInvoke(action, args);
            } else {
                action();
            }
        }
    }
}