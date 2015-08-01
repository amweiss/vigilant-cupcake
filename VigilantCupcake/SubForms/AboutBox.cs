using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VigilantCupcake.SubForms {

    partial class AboutBox : Form {

        public AboutBox() {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyTitle;
            this.labelVersion.Text = AssemblyVersion;
            this.lastUpdatedBox.Text = LastUpdatedDate.ToString();
            this.linkLabel1.Text = Properties.Settings.Default.WebsiteUrl;
        }

        public string LatestVersionText {
            set { latestBox.Text = value; }
        }

        #region Assembly Attribute Accessors

        public static string AssemblyTitle {
            get {
                return "Vigilant Cupcake";
            }
        }

        public static string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static DateTime LastUpdatedDate {
            get {
                return new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            }
        }

        #endregion Assembly Attribute Accessors

        void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Settings.Default.WebsiteUrl);
        }
    }
}