using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.OS_Utils {
    //From: http://stackoverflow.com/questions/10138040/how-to-detect-properly-windows-linux-mac-operating-systems
    public static class PlatformCheck {
        public enum Platform {
            Windows,
            Linux,
            Mac
        }

        public static Platform RunningPlatform() {
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }
    }
}
