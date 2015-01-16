using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.OS_Utils {
    static class HostsFileUtil {

        public static string CurrentHostsFile {
            get {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"System32\drivers\etc\hosts");
            }
        }
    }
}
