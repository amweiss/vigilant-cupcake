using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {
    class Fragment {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string FullPath {
            get {
                return Path.Combine(OS_Utils.LocalFiles.BaseDirectory, Name);
            }
        }
    }

}
