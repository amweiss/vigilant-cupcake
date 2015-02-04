using System.Diagnostics;

namespace VigilantCupcake.OS_Utils {

    public static class DnsUtil {

        public static bool FlushDns() {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            switch (OS_Utils.PlatformCheck.RunningPlatform()) {
                case OS_Utils.PlatformCheck.Platform.Linux: {
                        startInfo.FileName = Properties.Settings.Default.DnsFlushCommandLinux;
                        startInfo.Arguments = Properties.Settings.Default.DnsFlushArgumentsLinux;
                        break;
                    }
                case OS_Utils.PlatformCheck.Platform.Mac: {
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