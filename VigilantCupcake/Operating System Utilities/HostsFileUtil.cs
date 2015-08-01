using System;
using System.IO;

namespace VigilantCupcake.OperatingSystemUtilities {

    static class HostsFileUtil {

        public static string CurrentHostsFile {
            get {
                switch (OperatingSystemUtilities.PlatformCheck.RunningPlatform()) {
                    case PlatformCheck.Platform.Windows: return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), Properties.Settings.Default.WindowsHostsFilePath);
                    default: return Properties.Settings.Default.LinuxHostsFilePath;
                }
            }
        }
    }
}