using System;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.OperatingSystemUtilities;

namespace VigilantCupcake {

    static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            UserConfig.Instance.Reload();

            if (!SingleInstance.Start()) {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                var mainForm = new MainForm();
                Application.Run(mainForm);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }

            SingleInstance.Stop();
        }
    }
}