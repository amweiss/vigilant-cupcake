using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.OS_Utils {
    public static class LocalFiles {
        public static string BaseDirectoryRoot {
            get {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        public static string BaseDirectory {
            get {
                return System.IO.Path.Combine(BaseDirectoryRoot, FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductName);
            }
        }


        //From http://stackoverflow.com/questions/50744/wait-until-file-is-unlocked-in-net
        /// <summary>
        /// Blocks until the file is not locked any more.
        /// </summary>
        /// <param name="fullPath"></param>
        public static bool WaitForFile(string fullPath) {
            int numTries = 0;
            while (true) {
                ++numTries;
                try {
                    // Attempt to open the file exclusively.
                    using (FileStream fs = new FileStream(fullPath,
                        FileMode.Open, FileAccess.ReadWrite,
                        FileShare.None, 100)) {
                        fs.ReadByte();

                        // If we got this far the file is ready
                        break;
                    }
                } catch (Exception) {
                    if (numTries > 10) {
                        return false;
                    }

                    // Wait for the lock to be released
                    System.Threading.Thread.Sleep(500);
                }
            }
            return true;
        }
    }
}
