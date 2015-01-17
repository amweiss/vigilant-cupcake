using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fragments
{

    public class HostnameFilter
    {
        private string _fileName;
        private HostfileRecord _hnRecord;
        public HostnameFilter(string fileName)
        {
            _fileName = fileName;
            _hnRecord = new HostfileRecord();
        }

        public void Apply(string filter)
        {
            HostfileFragment file = new HostfileFragment(this._fileName);
            string[] fileData = file.Read();
            List<string> appliedFilter = new List<string>();
            if (!new List<string>(fileData).Contains("#Filter: " + filter))
            {
                appliedFilter.Add("#Filter: " + filter);
            }
            foreach (string line in fileData)
            {
                string writeBackLine = line;
                if (Regex.IsMatch(line, filter) && !Regex.IsMatch(line, @"^#"))
                {
                    List<string> matchedFilter = new List<string>();
                    List<string> keepAsIs = new List<string>();
                    Tuple<string, string[]> splitRecord = _hnRecord.SplitHostfileRecord(writeBackLine);
                    foreach (string host in splitRecord.Item2)
                    {
                        if (Regex.IsMatch(host, filter))
                        {
                            matchedFilter.Add(host);
                        }
                        else
                        {
                            keepAsIs.Add(host);
                        }
                    }
                    foreach (string record in _hnRecord.CombineHostfileRecord(splitRecord.Item1, matchedFilter))
                    {
                        appliedFilter.Add('#' + record);
                    }
                    appliedFilter.AddRange(_hnRecord.CombineHostfileRecord(splitRecord.Item1, keepAsIs));
                }
                else
                {
                    appliedFilter.Add(writeBackLine);
                }
            }
            file.Write(appliedFilter.ToArray());
        }


        public void Remove(string filter)
        {
            HostfileFragment file = new HostfileFragment(this._fileName);
            string[] fileData = file.Read();
            List<string> removeFilter = new List<string>();
            string[] otherFilters = this.getAllFilters(fileData);
            foreach (string line in fileData)
            {
                if(Regex.IsMatch(line, @"^#Filter:") && Regex.IsMatch(line, filter))
                {
                    continue; //We want to make sure we do not keep the metadata for this filter at the top of the file
                }
                string writeBackLine = line;
                if (Regex.IsMatch(writeBackLine, filter))
                {
                    writeBackLine = Regex.Replace(writeBackLine, @"^#", "");
                }
                removeFilter.Add(writeBackLine);
            }
            file.Write(removeFilter.ToArray());
            //reapply leftover filters
            foreach( string line in otherFilters)
            {
                if (line != filter)
                {
                    this.Apply(line);
                }
            }
        }

        public string[] getAllFilters(string[] fileData)
        {
            List<string> otherFilters = new List<string>();
            Regex isFilter = new Regex(@"^#Filter:\s*");
            foreach(string line in fileData )
            {
                if (!Regex.IsMatch(line.Trim(), @"^#"))
                {
                    break; //Remote location will be in a comment block at the top of the file. If we leave the comment block, then this file is not remote... Stop looking
                }
                if (isFilter.IsMatch(line))
                {
                    otherFilters.Add(isFilter.Replace(line, "").Trim());
                }
            }
            return otherFilters.ToArray();
        }
    }
}
