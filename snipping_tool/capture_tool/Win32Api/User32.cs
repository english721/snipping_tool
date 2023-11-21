using capture_tool.ScreenCapture.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace capture_tool.Win32Api
{
    class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Win32Rect rect);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Win32Rect rect);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Win32Point lpPoint);

        [DllImportAttribute("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Win32Point pt);
    }
}
