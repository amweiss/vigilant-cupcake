using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace Fragments
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

        public string[] Read()
        {
            List<string> fragmentInput = new List<string>();
            StreamReader reader = new StreamReader(this._fileName);
            while (reader.Peek() != -1) //Check for the end of the file
            {
                fragmentInput.Add(reader.ReadLine());
            }
            reader.Close();
            return fragmentInput.ToArray();
        }

        public void Write(string[] fragmentOutput, string remoteLocation = "")
        {
            StreamWriter writer = new StreamWriter(this._fileName);
            if (remoteLocation != "")
            {
                writer.WriteLine("#Remote: " + remoteLocation);
            }
            for (int i = 0; i < fragmentOutput.Length; i++)
            {
                writer.WriteLine(fragmentOutput[i]);
            }
            writer.Close();
        }

        public bool updateFromRemote(string localfileName)
        {
            Regex isRemote = new Regex(@"^#Remote:\s*");
            string[] fragmentData = this.Read();
            string remoteLocation = "";
            foreach(string line in fragmentData)
            {
                if(isRemote.IsMatch(line.Trim()))
                {
                    remoteLocation = line;
                    break; //We found the comment specifying the remote location. No need to continue searching
                }
                if (!Regex.IsMatch(line.Trim(), @"^#"))
                {
                    return false; //Remote location will be in a comment block at the top of the file. If we leave the comment block, then this file is not remote... Stop looking
                }
            }
            remoteLocation = isRemote.Replace(remoteLocation,""); //Strip off the defining tag #Remote:
            WebClient client = new WebClient();
            client.DownloadFile(remoteLocation, this._fileName);
            this.Write(this.Read(), remoteLocation);

            return true;
        }
    }
}