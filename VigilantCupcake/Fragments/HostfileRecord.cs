using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fragments
{
    public class HostfileRecord
    {
        public HostfileRecord()
        {
        }

        public string[] CombineHostfileRecord(string ipAddress, List<string> hostnames)
        {
            int maxLength = 80; //We want to wrap into a second entry if the length of the line will be greater than 1020
            int entryLength = 0;
            List<string> combinedRecords = new List<string>();
            string entryString;
            string ipFormat;
            if (Regex.IsMatch(ipAddress, @"\.")) //IPv4
            {
                ipFormat = "{0,-16}";
            }
            else //IPv6
            {
                ipFormat = "{0,-40}";
            }
            entryString = String.Format(ipFormat, ipAddress);
            entryLength = entryString.Length;
            foreach (string host in hostnames)
            {
                if (entryLength + host.Length + 1 <= maxLength)
                {
                    entryString = entryString + " " + host;
                    entryLength = entryLength + host.Length + 1;
                }
                else
                {
                    combinedRecords.Add(entryString);
                    entryString = String.Format(ipFormat, ipAddress);
                    entryLength = entryString.Length;
                }
            }
            //Take care of the remaining record if one still exists
            if (entryLength > String.Format(ipFormat, ipAddress).Length)
            {
                combinedRecords.Add(entryString);
            }
            return combinedRecords.ToArray();
        }

        public Tuple<string, string[]> SplitHostfileRecord(string dnsRecord)
        {
            string trimmedDNSRecord = dnsRecord.Trim();
            List<string> hosts = new List<string>();
            string[] words = Regex.Split(trimmedDNSRecord, @"\s+");
            string ip = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                hosts.Add(words[i]);
            }
            return new Tuple<string, string[]>(ip, hosts.ToArray());
        }
    }
}