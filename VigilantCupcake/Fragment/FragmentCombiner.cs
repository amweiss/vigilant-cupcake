using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Fragment
{
    public class FragmentCombiner
    {
        private HostfileFragment _left, _right;
        private string _fileName;
        private Dictionary<string,List<string>> hostToIPMapping, ipToHostMapping, collisions;
        public FragmentCombiner(string fileName, HostfileFragment left = null, HostfileFragment right = null)
        {
            _left = left;
            _right = right;
            _fileName = fileName;
            if( left != null && right != null)
            {
                self.generateMappings();
            }
        }

        public HostileFragment Left
        {
            get
            {
                return this._left;
            }
            set
            {
                _left = value;
            }
        }
        public HostfileFragment Right
        {
            get
            {
                return this._right;
            }
            set
            {
                _right = value;
            }
        }
        public string FileName
        {
            get
            {
                return this._filename;
            }
            set
            {
                _filename = value;
            }
        }

        private Tuple<string, string[]> _SplitDNSRecord(string dnsRecord)
        {
            string trimmedDNSRecord = dnsRecord.Trim();
            List<string> hosts = new List<string>();
            string[] words = Regex.Split(trimmedDNSRecord, @"\s+");
            string ip = words[0];
            for( int i = 1; i < words.Length(); i++)
            {
                    hosts.Add(words[i]);
            }
            return new Tuple<string, string[]>(ip, hosts.ToArray());
        }
        
        public void generateMappings()
        {
            string[] left = this.getLeft().Read();
            string[] right = this.getRight().Read();
            string[] merged = new string[left.Length() + right.Length()];
            Array.Copy(left, 0, merged);
            Array.Copy(right, 0, merged, left.Length(), right.Length());

            Dictionary hostIPMap = new Dictionary<string, string>();
            Dictionary collisions = new Dictionary<string, List<string>);
            
            foreach(string entry in merged)
            {
                Tuple<string, string[]> splittedRecord = this._SplitDNSRecord(entry);
                string ipAddress = splittedRecord.Item1;
                string hostname = splittedRecord.Item2;
                
                if(this._hasCollision(ipAddress, hostname)) // There was a collision
                {
                    /* 
                     *  check to see if the key exists in the collision array
                     *  if it does, then append the ip address to the list already there
                     *  if it does not, then add it in with the 2 colliding IP Addresses
                     */
                    if (this.collisions.ContainsKey(host))
                    {
                        if (!this.collisions[host].Contains(ipAddress))
                        {
                            this.collisions[host].Add(ipAddress);
                        }
                    }
                        else
                    {
                        this.collisions.Add(host, new List<string>(ipAddress, hostToIPMapping[host]));
                    }
                }
                else //There was no collision
                {
                    if (!this.ipToHostMapping[ipAddress].Contains(host))
                    {
                        this.ipToHostMapping[ipAddress].Add(host);
                    }
                }
                if (!this.hostToIPMapping[host].Contains(ipAdress))
                {
                    this.hostToIPMapping[host].Add(ipAddress);
                }
            }
        }

        private bool _hasCollision(string ipaddress, string host)
        {
            if (this.hostToIPMapping.ContainsKey(host) && hostIPMap[host] != ipAddress) //Then we have a collision
            {
                return true;
            }
            return false;
        }

        public string[] CombineDNSRecord(string ipAddress, List<string> hostnames)
        {
            int maxLength = 1020; //We want to wrap into a second entry if the length of the line will be greater than 1020
            int entryLength = 0;
            List<string> combinedRecords = new List<string>();

            string entryString = ipAddress;
            int entryLength = ipAddress.Length();
            foreach(string host in hostnames)
            {
                if(entryLength + host.Length() + 1 <= maxLength)
                {
                    entryString = entryString + " " + host;
                    entryLength = entryLength + host.Length() + 1;
                }
                else
                {
                    combinedRecords.Add(entryString);
                    entryString = ipAddress;
                    entryLength = ipAddress.Length();
                }
            }
            //Take care of the remaining record if one still exists
            if (entryLength > ipAddress.Length())
            {
                combinedRecords.Add(entryString());
            }
            return combinedRecords.ToArray();
        }

        public void CombineFragmentsToFile()
        {
            //Take care of the ip mapping (list where there are no collisions)
            StreamWriter writer = new StreamWriter(this._fileName);
            foreach (KeyValuePair<string, List<string>> pair in this.ipToHostMapping)
            {
                string[] records = this.CombineDNSRecord(pair.Key(), pair.Value());
                foreach(string line in records)
                {
                    writer.WriteLine(line);
                }
            }
            foreach(KeyValuePair<string, List<string>> pair in this.collisions)
            {
                //TODO: Prompt user to resolve collision cases
            }
            writer.Close();
        }
    }
}