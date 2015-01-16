using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace Fragment
{
    public class HostfileFragment
    {
        private string _fileName;
        public HostfileFragment(string fileName)
        {
            this._fileName = fileName;
        }
        public string FileName
        {
            get
            {
                return this._fileName;
            }
        }

        public string[] read()
        {
            List<string> fragmentInput = new List<string>();
            StreamReader reader = new StreamReader(this._fileName);
            while (reader.Peek() != -1) //Check for the end of the file
            {
                fragmentInput.Add(reader.ReadLine());
            }
            return fragmentInput.ToArray();
        }

        public void write(string[] fragmentOutput, string remoteLocation = "")
        {
            StreamWriter writer = new StreamWriter(this.fileName);
            if (remoteLocation != "")
            {
                writer.Write("#Remote: " + remoteLocation);
            }
            for (int i = 0; i < fragmentOutput.Length(); i++)
            {
                writer.Write(fragmentOutput[i]);
            }
        }

        public Bool updateFromRemote(string localfileName)
        {
            Regex isRemote = new Regex(@"^#Remote:\s*");
            string[] fragmentData = this.read();
            for(int i = 0; i < fragmentData.Length(); i++)
            {
                if(isRemote.IsMatch(fragmentData[i].Trim()))
                {
                    remoteLocation = fragmentData[i];
                    break; //We found the comment specifying the remote location. No need to continue searching
                }
                if (!Regex.IsMatch(fragmentData[i].Trim(), @"^#"))
                {
                    return false; //Remote location will be in a comment block at the top of the file. If we leave the comment block, then this file is not remote... Stop looking
                }
            }
            string remoteLocation = isRemote.Replace(remoteLocation,""); //Strip off the defining tag #Remote:
            WebClient client = new WebClient();
            client.DownloadFile(remoteLocation, this._fileName);
            this.Write(this.Read(), remoteLocation);

            return true;
        }
    }
}