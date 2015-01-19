using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Fragments {
    public class FragmentCombiner {
        private HostfileRecord _hnRecord = new HostfileRecord();
        private Dictionary<string, List<string>> _hostToIPMapping = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> _ipToHostMapping = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> _collisions = new Dictionary<string, List<string>>();

        public IEnumerable<string> generateOutput(IEnumerable<string> mergedFile) {
            generateMappingsFromMerged(mergedFile.ToArray());

            var results = new List<string>();
            foreach (KeyValuePair<string, List<string>> pair in _ipToHostMapping) {
                var records = _hnRecord.CombineHostfileRecord(pair.Key, pair.Value);
                results.AddRange(records);
            }
            return results;
        }

        private void generateMappingsFromMerged(string[] merged) {

            foreach (string entry in merged) {
                string trimmedEntry = entry.Trim();
                if (!Regex.IsMatch(trimmedEntry, @"^\d+")) //skip this one if it is not an entry.. has to start with a digit
                {
                    continue;
                }

                trimmedEntry = Regex.Replace(trimmedEntry, @"#.*", string.Empty);

                Tuple<string, string[]> splittedRecord = _hnRecord.SplitHostfileRecord(trimmedEntry);
                string ipAddress = splittedRecord.Item1;
                string[] hostnames = splittedRecord.Item2;
                foreach (string host in hostnames) {
                    //if (this.hostToIPMapping.ContainsKey(host) && !hostToIPMapping[host].Contains(ipAddress)) // There was a collision
                    //{
                    //    /* 
                    //     *  check to see if the key exists in the collision array
                    //     *  if it does, then append the ip address to the list already there
                    //     *  if it does not, then add it in with the 2 colliding IP Addresses
                    //     */
                    //    if (this.collisions.ContainsKey(host)) {
                    //        if (!this.collisions[host].Contains(ipAddress)) {
                    //            this.collisions[host].Add(ipAddress);
                    //        }
                    //    } else {
                    //        List<string> collisionList = new List<string>();
                    //        collisionList.Add(ipAddress);
                    //        collisionList.AddRange(hostToIPMapping[host]);
                    //        this.collisions.Add(host, collisionList);
                    //    }
                    //} else //There was no collision
                    //{
                    if (this._ipToHostMapping.ContainsKey(ipAddress)) {
                        if (!_ipToHostMapping[ipAddress].Contains(host)) {
                            _ipToHostMapping[ipAddress].Add(host);
                        }
                    } else {
                        List<string> hostToAdd = new List<string>();
                        hostToAdd.Add(host);
                        _ipToHostMapping.Add(ipAddress, hostToAdd);
                    }
                    //}

                    if (this._hostToIPMapping.ContainsKey(host)) {
                        if (!_hostToIPMapping[host].Contains(ipAddress)) {
                            _hostToIPMapping[host].Add(ipAddress);
                        }
                    } else {
                        List<string> ipToAdd = new List<string>();
                        ipToAdd.Add(ipAddress);
                        _hostToIPMapping.Add(host, ipToAdd);
                    }
                }
            }
        }
    }
}