using System;
using System.Windows.Forms;
using VigilantCupcake.OS_Utils;

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