using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Fragments
{
    public class FragmentCombiner
    {
        private HostfileFragment _left, _right;
        private string _fileName;
        private HostfileRecord _hnRecord;
        private Dictionary<string,List<string>> hostToIPMapping, ipToHostMapping, collisions;
        public FragmentCombiner(string fileName, HostfileFragment left = null, HostfileFragment right = null)
        {
            _left = left;
            _right = right;
            _fileName = fileName;
            _hnRecord = new HostfileRecord();
            hostToIPMapping = new Dictionary<string,List<string>>();
            ipToHostMapping = new Dictionary<string, List<string>>();
            collisions = new Dictionary<string, List<string>>();
            if( left != null && right != null)
            {
                generateMappings();
            }
        }

        public HostfileFragment Left
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
                return this._fileName;
            }
            set
            {
                _fileName = value;
            }
        }
        
        public void generateMappings()
        {
            string[] left = this._left.Read();
            string[] right = this._right.Read();
            string[] merged = new string[left.Length + right.Length];
            Array.Copy(left, merged, left.Length);
            Array.Copy(right, 0, merged, left.Length, right.Length);

            Dictionary<string, string> hostIPMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> collisions = new Dictionary<string, List<string>>();

            foreach (string entry in merged)
            {
                string trimmedEntry = entry.Trim();
                if(!Regex.IsMatch(trimmedEntry, @"^\d+")) //skip this one if it is not an entry.. has to start with a digit
                {
                    continue;
                }
                Tuple<string, string[]> splittedRecord = this._hnRecord.SplitHostfileRecord(trimmedEntry);
                string ipAddress = splittedRecord.Item1;
                string[] hostnames = splittedRecord.Item2;
                foreach (string host in hostnames)
                {
                    if (this._hasCollision(ipAddress, host)) // There was a collision
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
                            List<string> collisionList = new List<string>();
                            collisionList.Add(ipAddress);
                            collisionList.AddRange(hostToIPMapping[host]);
                            this.collisions.Add(host, collisionList);
                        }
                    }
                    else //There was no collision
                    {
                        if(this.ipToHostMapping.ContainsKey(ipAddress))
                        {
                            if (!this.ipToHostMapping[ipAddress].Contains(host))
                            {
                                this.ipToHostMapping[ipAddress].Add(host);
                            }
                        }
                        else
                        {
                            List<string> hostToAdd = new List<string>();
                            hostToAdd.Add(host);
                            ipToHostMapping.Add(ipAddress, hostToAdd);
                        }
                    }
                    if (this.hostToIPMapping.ContainsKey(host))
                    {
                        if (!this.hostToIPMapping[host].Contains(ipAddress))
                        {
                            this.hostToIPMapping[host].Add(ipAddress);
                        }
                    }
                    else
                    {
                        List<string> ipToAdd = new List<string>();
                        ipToAdd.Add(ipAddress);
                        hostToIPMapping.Add(host, ipToAdd);
                    }
                }
            }
        }

        private bool _hasCollision(string ipAddress, string host)
        {
            if (this.hostToIPMapping.ContainsKey(host) && !hostToIPMapping[host].Contains(ipAddress)) //Then we have a collision
            {
                return true;
            }
            return false;
        }

        public void CombineFragmentsToFile()
        {
            //Take care of the ip mapping (list where there are no collisions)
            StreamWriter writer = new StreamWriter(this._fileName);
            foreach (KeyValuePair<string, List<string>> pair in this.ipToHostMapping)
            {
                string[] records = this._hnRecord.CombineHostfileRecord(pair.Key, pair.Value);
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