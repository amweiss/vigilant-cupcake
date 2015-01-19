using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fragments {
    public class HostfileRecord {
        public IEnumerable<string> CombineHostfileRecord(string ipAddress, List<string> hostnames) {
            int maxLength = 80; //We want to wrap into a second entry if the length of the line will be greater than 1020
            var ipFormat = Regex.IsMatch(ipAddress, @"\.") ? "{0,-16}" : "{0,-40}"; //IPv4 vs. IPv6
            var entryString = string.Format(ipFormat, ipAddress);
            var entryLength = entryString.Length;
            foreach (string host in hostnames) {
                if (entryLength + host.Length + 1 <= maxLength) {
                    entryString = entryString + " " + host;
                    entryLength = entryLength + host.Length + 1;
                } else {
                    yield return entryString;
                    entryString = string.Format(ipFormat, ipAddress);
                    entryLength = entryString.Length;
                }
            }
            //Take care of the remaining record if one still exists
            if (entryLength > String.Format(ipFormat, ipAddress).Length) {
                yield return entryString;
            }
        }

        public Tuple<string, string[]> SplitHostfileRecord(string dnsRecord) {
            var trimmedDNSRecord = dnsRecord.Trim();
            var hosts = new List<string>();
            var words = Regex.Split(trimmedDNSRecord, @"\s+");
            var ip = words[0];
            for (int i = 1; i < words.Length; i++) {
                hosts.Add(words[i]);
            }
            return new Tuple<string, string[]>(ip, hosts.ToArray());
        }
    }
}