using System.Diagnostics;

namespace VigilantCupcake.OperatingSystemUtilities {

    public static class DnsUtility {

        public static bool FlushDns() {
            using (var process = new Process()) {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                switch (OperatingSystemUtilities.PlatformCheck.RunningPlatform()) {
                    case OperatingSystemUtilities.PlatformCheck.Platform.Linux: {
                            startInfo.FileName = Properties.Settings.Default.DnsFlushCommandLinux;
                            startInfo.Arguments = Properties.Settings.Default.DnsFlushArgumentsLinux;
                            break;
                        }
                    case OperatingSystemUtilities.PlatformCheck.Platform.Mac: {
                            startInfo.FileName = Properties.Settings.Default.DnsFlushCommandMac;
                            startInfo.Arguments = Properties.Settings.Default.DnsFlushArgumentsMac;
                            break;
                        }
                    default: {
                            startInfo.FileName = Properties.Settings.Default.DnsFlushCommand;
                            startInfo.Arguments = Properties.Settings.Default.DnsFlushArguments;
                            break;
                        }
                }

                process.StartInfo = startInfo;
                return process.Start();
            }
        }
    }
}