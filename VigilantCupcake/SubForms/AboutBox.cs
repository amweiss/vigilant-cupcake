using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VigilantCupcake.SubForms {

    partial class AboutBox : Form {

        public AboutBox() {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = AssemblyVersion;
            this.buildDate.Text = String.Format("Last Updated: {0}", LastUpdatedDate);
            this.linkLabel1.Text = Properties.Settings.Default.WebsiteUrl;
        }

        #region Assembly Attribute Accessors

        public string AssemblyProduct {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public DateTime LastUpdatedDate {
            get {
                return new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            }
        }

        #endregion Assembly Attribute Accessors

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Settings.Default.WebsiteUrl);
        }

        private void logoPictureBox_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(Properties.Settings.Default.WebsiteUrl);
        }
    }
}