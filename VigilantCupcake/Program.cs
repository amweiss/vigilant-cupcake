using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.OS_Utils;

namespace VigilantCupcake {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
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
