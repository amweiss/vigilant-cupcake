using System;
using System.Windows.Forms;
using VigilantCupcake.OperatingSystemUtilities;

namespace VigilantCupcake {

    internal static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            if (!SingleInstance.Start()) {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.UpgradeRequired) {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            try {
                MainForm mainForm = new MainForm();
                Application.Run(mainForm);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }

            SingleInstance.Stop();
        }
    }
}