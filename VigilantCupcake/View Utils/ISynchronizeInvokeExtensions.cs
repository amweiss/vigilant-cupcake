﻿using System.ComponentModel;
using System.Windows.Forms;

namespace VigilantCupcake.View_Utils {
    static class ISynchronizeInvokeExtensions {
        public static void BeginInvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action) {
            if (obj.InvokeRequired) {
                var args = new object[0];
                obj.Invoke(action, args);
            } else {
                action();
            }
        }
    }
}
