using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace VigilantCupcake.OperatingSystemUtilities {

    static public class SingleInstance {

        public static readonly int WM_SHOWFIRSTINSTANCE =
            NativeMethods.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", _attribute);

        static string _attribute = ((GuidAttribute)typeof(Program).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
        static Mutex mutex;

        static public void ShowFirstInstance() {
            NativeMethods.PostMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                WM_SHOWFIRSTINSTANCE,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        static public bool Start() {
            var onlyInstance = false;

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", _attribute);

            mutex = new Mutex(true, $"Local\\{_attribute}", out onlyInstance);
            return onlyInstance;
        }

        static public void Stop() {
            mutex.ReleaseMutex();
        }
    }
}