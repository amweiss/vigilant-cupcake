using System.Diagnostics;
using static VigilantCupcake.OperatingSystemUtilities.PlatformCheck;

namespace VigilantCupcake.OperatingSystemUtilities {

    public static class DnsUtility {

        public static bool FlushDns() {
            using (var process = new Process()) {
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                switch (RunningPlatform()) {
                    case Platform.Linux:
                        {
                            startInfo.FileName = Properties.Settings.Default.DnsFlushCommandLinux;
                            startInfo.Arguments = Properties.Settings.Default.DnsFlushArgumentsLinux;
                            break;
                        }
                    case Platform.Mac:
                        {
                            startInfo.FileName = Properties.Settings.Default.DnsFlushCommandMac;
                            startInfo.Arguments = Properties.Settings.Default.DnsFlushArgumentsMac;
                            break;
                        }
                    default:
                        {
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