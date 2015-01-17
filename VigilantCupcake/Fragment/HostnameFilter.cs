using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fragments
{
    public class HostnameFilter
    {
        private string _filter, _fileName;
        public HostnameFilter(string filter, string fileName)
        {
            _filter = filter;
            _fileName = fileName;
        }

        public String Filter
        {
            get
            {
                return this._filter;
            }
            set
            {
                this._filter = value;
            }
        }

        public void Apply(string filter)
        {
            HostfileFragment file = new HostfileFragment(this._fileName);
            string[] fileData = file.Read();
            List<string> appliedFilter = new List<string>();
            appliedFilter.Add("#Filter: " + filter);
            foreach (string line in fileData)
            {
                string writeBackLine = line;
                if(Regex.IsMatch(line, filter) && !Regex.IsMatch(line, @"^#"))
                {
                    writeBackLine = "#" + writeBackLine;
                }
                appliedFilter.Add(writeBackLine);
            }
            file.Write(appliedFilter.ToArray());
        }
        public void Apply()
        {
            HostfileFragment file = new HostfileFragment(this._fileName);
            string[] fileData = file.Read();
            List<string> appliedFilter = new List<string>();
            appliedFilter.Add("#Filter: " + _filter);
            foreach (string line in fileData)
            {
                string writeBackLine = line;
                if (Regex.IsMatch(line, _filter) && !Regex.IsMatch(line, @"^#"))
                {
                    writeBackLine = "#" + writeBackLine;
                }
                appliedFilter.Add(writeBackLine);
            }
            file.Write(appliedFilter.ToArray());
        }

        public void Remove(string filter)
        {
            HostfileFragment file = new HostfileFragment(this._fileName);
            string[] fileData = file.Read();
            List<string> removeFilter = new List<string>();
            string[] otherFilters = this.getOtherFilters(fileData);
            foreach (string line in fileData)
            {
                string writeBackLine = line;
                if (Regex.IsMatch(writeBackLine, filter))
                {
                    writeBackLine = Regex.Replace(writeBackLine, @"^#", "");
                }
                removeFilter.Add(writeBackLine);
            }
            //reapply leftover filters
            foreach( string line in otherFilters)
            {
                if (!Regex.IsMatch(line, @"^Filter: " + filter + "$"))
                {
                    this.Apply(Regex.Replace(line, @"^Filter: ", "").Trim());
                }
            }
        }

        public string[] getOtherFilters(string[] fileData)
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
