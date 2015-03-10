using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    public class HostfileRecordCombiner {
        private HostfileRecord _hnRecord = new HostfileRecord();
        private Dictionary<string, List<string>> _hostToIPMapping = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> _ipToHostMapping = new Dictionary<string, List<string>>();

        public IEnumerable<string> GenerateOutput(IEnumerable<string> mergedFile) {
            generateMappingsFromMerged(mergedFile.ToArray());

            var results = new List<string>();
            foreach (KeyValuePair<string, List<string>> pair in _ipToHostMapping) {
                var records = new HostfileRecord() { Ip = pair.Key, Hosts = pair.Value };
                results.AddRange(records.ToStringEnumerable());
            }
            return results;
        }

        private void generateMappingsFromMerged(string[] merged) {
            foreach (string entry in merged) {
                string trimmedEntry = entry.Trim();

                //skip this one if it is not an entry.. has to start with a digit
                if (!Regex.IsMatch(trimmedEntry, @"^\d+")) {
                    continue;
                }

                trimmedEntry = Regex.Replace(trimmedEntry, @"#.*", string.Empty);

                var splittedRecord = new HostfileRecord(trimmedEntry);
                foreach (string host in splittedRecord.Hosts) {
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
                    if (this._ipToHostMapping.ContainsKey(splittedRecord.Ip)) {
                        if (!_ipToHostMapping[splittedRecord.Ip].Contains(host)) {
                            _ipToHostMapping[splittedRecord.Ip].Add(host);
                        }
                    } else {
                        List<string> hostToAdd = new List<string>();
                        hostToAdd.Add(host);
                        _ipToHostMapping.Add(splittedRecord.Ip, hostToAdd);
                    }
                    //}

                    if (this._hostToIPMapping.ContainsKey(host)) {
                        if (!_hostToIPMapping[host].Contains(splittedRecord.Ip)) {
                            _hostToIPMapping[host].Add(splittedRecord.Ip);
                        }
                    } else {
                        List<string> ipToAdd = new List<string>();
                        ipToAdd.Add(splittedRecord.Ip);
                        _hostToIPMapping.Add(host, ipToAdd);
                    }
                }
            }
        }
    }
}