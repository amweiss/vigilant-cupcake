using System;
using System.IO;
using static VigilantCupcake.OperatingSystemUtilities.PlatformCheck;

namespace VigilantCupcake.OperatingSystemUtilities {

    static class HostsFileUtil {

        public static string CurrentHostsFile {
            get {
                switch (RunningPlatform()) {
                    case Platform.Windows: return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), Properties.Settings.Default.WindowsHostsFilePath);
                    default: return Properties.Settings.Default.LinuxHostsFilePath;
                }
            }
        }
    }
}