using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace capture_tool.ScreenCapture.Win32Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public int Width
        {
            get { return Right - Left; }
        }

        public int Height
        {
            get { return Bottom - Top; }
        }
    }
}
