using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.View_Utils {
    public static class FastColoredTextBoxUtil {

        private static TextStyle commentStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);

        public static void hostsView_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(commentStyle);
            e.ChangedRange.SetStyle(commentStyle, "#.*");
        }

    }
}
