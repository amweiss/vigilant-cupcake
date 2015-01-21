using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.Models;

namespace VigilantCupcake.SubForms {
    public partial class ActualHostsFile : Form {

        public ActualHostsFile() {
            InitializeComponent();
            actualHostsFileView.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged);
        }

        private void ActualHostsFile_Load(object sender, EventArgs e) {
            var hostsFile = new Fragment() { IsHostsFile = true };
            actualHostsFileView.Text = hostsFile.FileContents;
        }

        private void actualHostsFileView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
    }
}
