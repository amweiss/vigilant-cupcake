using FastColoredTextBoxNS;
using System.Drawing;

namespace VigilantCupcake.ViewUtilities {

    public static class FastColoredTextBoxUtility {
        private static TextStyle commentStyle = new TextStyle(Brushes.DimGray, null, FontStyle.Regular);

        public static void FastColoredTextBoxTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            if (e == null || e.ChangedRange == null || string.IsNullOrEmpty(e.ChangedRange.Text)) return;
            e.ChangedRange.ClearStyle(commentStyle);
            e.ChangedRange.SetStyle(commentStyle, "#.*");
        }
    }
}