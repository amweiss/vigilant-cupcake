using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    public static class HostnameFilter {

        public static IEnumerable<string> Apply(IEnumerable<string> lines, string filter) {
            var appliedFilter = new List<string>();
            if (lines == null) return appliedFilter;

            //TODO: Cleanup
            foreach (string line in lines) {
                string writeBackLine = line;
                if (Regex.IsMatch(line, filter) && !Regex.IsMatch(line, @"^#")) {
                    var matchedFilter = new List<string>();
                    var keepAsIs = new List<string>();
                    var splitRecord = new HostfileRecord(writeBackLine);
                    foreach (string host in splitRecord.Hosts) {
                        if (Regex.IsMatch(host, filter)) {
                            matchedFilter.Add(host);
                        } else {
                            keepAsIs.Add(host);
                        }
                    }
                    foreach (string record in (new HostfileRecord() { Ip = splitRecord.Ip, Hosts = matchedFilter }.ToStringEnumerable())) {
                        appliedFilter.Add('#' + record);
                    }
                    appliedFilter.AddRange(new HostfileRecord() { Ip = splitRecord.Ip, Hosts = keepAsIs }.ToStringEnumerable());
                } else {
                    appliedFilter.Add(writeBackLine);
                }
            }
            return appliedFilter;
        }
    }
}