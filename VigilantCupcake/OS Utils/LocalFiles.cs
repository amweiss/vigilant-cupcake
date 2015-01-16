using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.OS_Utils {
    public static class LocalFiles {
        public static string BaseDirectory { get { return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductName); } }
    }
}
