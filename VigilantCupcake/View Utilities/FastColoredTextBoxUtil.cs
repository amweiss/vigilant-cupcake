using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace VigilantCupcake.ViewUtilities {

    public static class FastColoredTextBoxUtility {
        private static TextStyle _commentStyle = new TextStyle(Brushes.DimGray, null, FontStyle.Regular);
        private static TextStyle _conflictStyle = new TextStyle(Brushes.White, Brushes.Red, FontStyle.Regular);

        public static Dictionary<string, List<string>> Collisions { get; set; }

        public static void FastColoredTextBoxTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            if (e == null || e.ChangedRange == null || string.IsNullOrEmpty(e.ChangedRange.Text)) return;

            setStyles(e.ChangedRange);
        }

        private static void setStyles(FastColoredTextBoxNS.Range range) {
            range.ClearStyle(_conflictStyle, _commentStyle);

            if (Collisions != null
                && Collisions.Keys != null
                && Collisions.Keys.Count > 0) {
                Collisions.Keys.ToList().ForEach(x => {
                    var pattern = Regex.Escape(x);
                    range.SetStyle(_conflictStyle, pattern);
                });
            }

            range.SetStyle(_commentStyle, "#.*");
        }

        public static void RefreshStyles(this FastColoredTextBox fctb) {
            setStyles(fctb.Range);
        }
    }
}