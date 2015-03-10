using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    public class HostfileRecord {

        public string Ip { get; set; }
        public IEnumerable<string> Hosts { get; set; }

        public HostfileRecord() { }

        public HostfileRecord(string dnsRecord) {
            if (string.IsNullOrEmpty(dnsRecord)) return;
            var trimmedDNSRecord = dnsRecord.Trim();
            var hosts = new List<string>();
            var words = Regex.Split(trimmedDNSRecord, @"\s+");
            var ip = words[0];
            for (int i = 1; i < words.Length; i++) {
                hosts.Add(words[i]);
            }
            Ip = ip;
            Hosts = hosts;
        }

        public IEnumerable<string> ToStringEnumerable() {
            int maxLength = 80; //We want to wrap into a second entry if the length of the line will be greater than 1020
            var ipFormat = Regex.IsMatch(Ip, @"\.") ? "{0,-16}" : "{0,-40}"; //IPv4 vs. IPv6
            var entryString = string.Format(ipFormat, Ip);
            //TODO: Cleanup
            var hostArray = Hosts.ToList();
            while (hostArray.Count != 0) {
                var host = hostArray.First();

                if (entryString.Length + host.Length + 1 <= maxLength) {
                    entryString = entryString + " " + host;
                    hostArray.Remove(host);
                } else {
                    yield return entryString;
                    entryString = string.Format(ipFormat, Ip);
                }
            }

            //Take care of the remaining record if one still exists
            if (entryString.Length > String.Format(ipFormat, Ip).Length) {
                yield return entryString;
            }
        }
    }
}