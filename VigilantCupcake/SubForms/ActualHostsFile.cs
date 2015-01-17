using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigilantCupcake.SubForms {
    public partial class ActualHostsFile : Form {
        public ActualHostsFile() {
            InitializeComponent();
        }

        private void ActualHostsFile_Load(object sender, EventArgs e) {
            actualHostsFileView.LoadFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText);
        }

        private void actualHostsFileView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
    }
}
