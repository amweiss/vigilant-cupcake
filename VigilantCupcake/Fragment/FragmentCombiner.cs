using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Fragment
{
    public class FragmentCombiner
    {
        private HostfileFragment _left, _right;
        public FragmentCombiner(HostfileFragment left = null, HostfileFragment right = null)
        {
            _left = left;
            _right = right;
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
        
        public Dictionary<string,List<string>> getCollisions()
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
                foreach(string host in splittedRecord.Item2)
                {
                    host.Trim();
                    if(Regex.IsMatch(host, @"^#")) //it is a comment... cannot possibly collide
                    {
                        continue;
                    }
                    host = Regex.Replace(host,@"#.*",""); //remove the comment, not part of the host
                    //Check for collisions. if a host maps to more than 1 IP Address
                    if (hostIPMap.ContainsKey(host) && hostIPMap[host] != ipAddress) //Then we have a collision
                    {
                        /* 
                         *  check to see if the key exists in the collision array
                         *  if it does not, then add it in with the 2 colliding IP Addresses
                         *  if it does, then append the ip address to the list already there
                         */ 
                        if(collisions.ContainsKey(host))
                        {
                            if(collisions[host].Contains(ipAddress))
                            {
                                continue;
                            }
                            collisions[host].Add(ipAddress);
                        }
                        else
                        {
                            collisions.Add(host, new List<string>(ipAddress,hostIPMap[host]));
                        }
                    }
                }
                return collisions;
            }
        }
  
        public void Combine()
        {

        }
    }
}