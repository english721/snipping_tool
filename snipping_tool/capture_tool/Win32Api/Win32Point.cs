using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace capture_tool.ScreenCapture.Win32Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct  Win32Point
    {
        public int X;
        public int Y;

        public Win32Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
