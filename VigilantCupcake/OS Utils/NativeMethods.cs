﻿using System;
using System.Runtime.InteropServices;

namespace VigilantCupcake.OS_Utils {

    //From: http://www.codeproject.com/Articles/32908/C-Single-Instance-App-With-the-Ability-To-Restore
    static internal class NativeMethods {

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args) {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImportAttribute("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window) {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }
    }
}