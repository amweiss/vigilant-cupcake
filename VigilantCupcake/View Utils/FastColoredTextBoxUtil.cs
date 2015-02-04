using FastColoredTextBoxNS;
using System.Drawing;

namespace VigilantCupcake.View_Utils {

    public static class FastColoredTextBoxUtil {
        private static TextStyle commentStyle = new TextStyle(Brushes.DimGray, null, FontStyle.Regular);

        public static void hostsView_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(commentStyle);
            e.ChangedRange.SetStyle(commentStyle, "#.*");
        }
    }
}