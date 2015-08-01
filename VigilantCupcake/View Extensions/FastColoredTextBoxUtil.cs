using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace VigilantCupcake.ViewExtensions {

    public static class FastColoredTextBoxUtility {
        static readonly TextStyle _commentStyle = new TextStyle(Brushes.DimGray, null, FontStyle.Regular);
        static readonly TextStyle _conflictStyle = new TextStyle(Brushes.White, Brushes.Red, FontStyle.Regular);

        public static Dictionary<string, List<string>> Collisions { get; set; }

        public static void FastColoredTextBoxTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            if (e != null) setStyles(e.ChangedRange);
        }

        public static void RefreshStyles(this FastColoredTextBox fctb) {
            if (fctb != null) setStyles(fctb.Range);
        }

        static void setStyles(Range range) {
            if (range == null || string.IsNullOrEmpty(range.Text)) return;
            range.ClearStyle(_conflictStyle, _commentStyle);

            if (Collisions?.Keys?.Count > 0) {
                Collisions.Keys.ToList().ForEach(x => {
                    var pattern = Regex.Escape(x);
                    range.SetStyle(_conflictStyle, @"(?<=[\s])" + pattern);
                });
            }

            range.SetStyle(_commentStyle, @"#.*");
        }
    }
}