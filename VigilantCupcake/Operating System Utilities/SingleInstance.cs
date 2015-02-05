using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace VigilantCupcake.OperatingSystemUtilities {

    static public class SingleInstance {

        public static readonly int WM_SHOWFIRSTINSTANCE =
            NativeMethods.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", _attribute);

        private static string _attribute = ((GuidAttribute)typeof(Program).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
        private static Mutex mutex;

        static public void ShowFirstInstance() {
            NativeMethods.PostMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                WM_SHOWFIRSTINSTANCE,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        static public bool Start() {
            bool onlyInstance = false;
            string mutexName = String.Format("Local\\{0}", _attribute);

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", _attribute);

            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }

        static public void Stop() {
            mutex.ReleaseMutex();
        }
    }
}