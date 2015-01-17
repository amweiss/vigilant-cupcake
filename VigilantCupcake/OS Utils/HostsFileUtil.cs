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
                switch (OS_Utils.PlatformCheck.RunningPlatform()) {
                    case PlatformCheck.Platform.Windows: return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), Properties.Settings.Default.WindowsHostsFilePath);
                    default: return Properties.Settings.Default.LinuxHostsFilePath;
                }
                
            }
        }
    }
}
