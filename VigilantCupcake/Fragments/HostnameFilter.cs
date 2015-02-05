using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fragments {

    public class HostnameFilter {
        private HostfileRecord _hnRecord = new HostfileRecord();

        public IEnumerable<string> Apply(IEnumerable<string> lines, string filter) {
            List<string> appliedFilter = new List<string>();
            if (lines == null) return appliedFilter;

            foreach (string line in lines) {
                string writeBackLine = line;
                if (Regex.IsMatch(line, filter) && !Regex.IsMatch(line, @"^#")) {
                    List<string> matchedFilter = new List<string>();
                    List<string> keepAsIs = new List<string>();
                    Tuple<string, string[]> splitRecord = HostfileRecord.SplitHostfileRecord(writeBackLine);
                    foreach (string host in splitRecord.Item2) {
                        if (Regex.IsMatch(host, filter)) {
                            matchedFilter.Add(host);
                        } else {
                            keepAsIs.Add(host);
                        }
                    }
                    foreach (string record in _hnRecord.CombineHostfileRecord(splitRecord.Item1, matchedFilter)) {
                        appliedFilter.Add('#' + record);
                    }
                    appliedFilter.AddRange(_hnRecord.CombineHostfileRecord(splitRecord.Item1, keepAsIs));
                } else {
                    appliedFilter.Add(writeBackLine);
                }
            }
            return appliedFilter;
        }
    }
}