using System.Collections.Generic;
using System.Linq;

namespace VigilantCupcake.ExtensionMethods {

    static class IEnumerableStringExtensions {

        public static string GetLongestCommonPrefix(this IEnumerable<string> lines) {
            var matching =
                from len in Enumerable.Range(0, lines.Min(s => s.Length)).Reverse()
                let possibleMatch = lines.First().Substring(0, len)
                where lines.All(f => f.StartsWith(possibleMatch, System.StringComparison.Ordinal))
                select possibleMatch;
            return matching.FirstOrDefault();
        }
    }
}