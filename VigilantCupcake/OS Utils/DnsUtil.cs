using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.OS_Utils {
    public static class DnsUtil {
        public static bool FlushDns() {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "ipconfig";
            startInfo.Arguments = "/flushdns";
            process.StartInfo = startInfo;
            return process.Start();
        }
    }
}
