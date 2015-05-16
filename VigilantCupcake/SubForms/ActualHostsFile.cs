﻿using System;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.ViewExtensions;

namespace VigilantCupcake.SubForms {

    public partial class ActualHostsFile : Form {

        public ActualHostsFile() {
            InitializeComponent();
            actualHostsFileView.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(FastColoredTextBoxUtility.FastColoredTextBoxTextChanged);
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