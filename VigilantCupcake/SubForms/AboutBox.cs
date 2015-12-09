using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VigilantCupcake.SubForms {

    partial class AboutBox : Form {

        public AboutBox() {
            InitializeComponent();
            Text = $"About {AssemblyTitle}";
            labelProductName.Text = AssemblyTitle;
            labelVersion.Text = AssemblyVersion;
            lastUpdatedBox.Text = LastUpdatedDate.ToString();
            linkLabel1.Text = Properties.Settings.Default.WebsiteUrl;
        }

        public string LatestVersionText {
            set { latestBox.Text = value; }
        }

        public static string AssemblyTitle { get; } = "Vigilant Cupcake";

        public static string AssemblyVersion {
            get {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Revision}";
            }
        }

        public static DateTime LastUpdatedDate {
            get {
                return new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            }
        }

        void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Settings.Default.WebsiteUrl);
        }
    }
}