using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    //TODO: Cleanup
    public class HostfileRecordCombiner {
        private HostfileRecord _hnRecord = new HostfileRecord();

        public Dictionary<string, List<string>> Collisions { get; private set; }

        public string Filter { get; set; }

        public Dictionary<string, List<string>> HostToIpMapping { get; private set; }

        public Dictionary<string, List<string>> IpToHostMapping { get; private set; }

        public IEnumerable<string> GenerateOutput(IEnumerable<string> mergedFile) {
            HostToIpMapping = new Dictionary<string, List<string>>();
            IpToHostMapping = new Dictionary<string, List<string>>();
            Collisions = new Dictionary<string, List<string>>();

            GenerateMappingsFromMerged(filterHosts(mergedFile).ToArray());

            var results = new List<string>();
            foreach (KeyValuePair<string, List<string>> pair in IpToHostMapping) {
                var records = new HostfileRecord() { Ip = pair.Key, Hosts = pair.Value };
                results.AddRange(records.ToStringEnumerable());
            }
            return results;
        }

        private IEnumerable<string> filterHosts(IEnumerable<string> lines) {
            if (lines == null || string.IsNullOrWhiteSpace(Filter)) return lines;

            return lines.Where(x => !Regex.IsMatch(x, Filter));
        }

        private void GenerateMappingsFromMerged(string[] merged) {
            foreach (string entry in merged) {
                string trimmedEntry = entry.Trim();

                //skip this one if it is not an entry.. has to start with a digit
                if (!Regex.IsMatch(trimmedEntry, @"^\d+")) {
                    continue;
                }

                trimmedEntry = Regex.Replace(trimmedEntry, @"#.*", string.Empty);

                var splittedRecord = new HostfileRecord(trimmedEntry);
                foreach (string host in splittedRecord.Hosts) {
                    // There was a collision
                    if (HostToIpMapping.ContainsKey(host) && !HostToIpMapping[host].Contains(splittedRecord.Ip)) {
                        /*
                         *  check to see if the key exists in the collision array
                         *  if it does, then append the ip address to the list already there
                         *  if it does not, then add it in with the 2 colliding IP Addresses
                         */
                        if (Collisions.ContainsKey(host)) {
                            if (!Collisions[host].Contains(splittedRecord.Ip)) {
                                Collisions[host].Add(splittedRecord.Ip);
                            }
                        } else {
                            var collisionList = new List<string>();
                            collisionList.Add(splittedRecord.Ip);
                            collisionList.AddRange(HostToIpMapping[host]);
                            Collisions.Add(host, collisionList);
                        }
                    }

                    if (IpToHostMapping.ContainsKey(splittedRecord.Ip)) {
                        if (!IpToHostMapping[splittedRecord.Ip].Contains(host)) {
                            IpToHostMapping[splittedRecord.Ip].Add(host);
                        }
                    } else {
                        var hostToAdd = new List<string>();
                        hostToAdd.Add(host);
                        IpToHostMapping.Add(splittedRecord.Ip, hostToAdd);
                    }

                    if (this.HostToIpMapping.ContainsKey(host)) {
                        if (!HostToIpMapping[host].Contains(splittedRecord.Ip)) {
                            HostToIpMapping[host].Add(splittedRecord.Ip);
                        }
                    } else {
                        var ipToAdd = new List<string>();
                        ipToAdd.Add(splittedRecord.Ip);
                        HostToIpMapping.Add(host, ipToAdd);
                    }
                }
            }
        }
    }
}