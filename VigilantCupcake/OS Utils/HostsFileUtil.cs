using System;
using System.IO;

namespace VigilantCupcake.OS_Utils {

    internal static class HostsFileUtil {

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