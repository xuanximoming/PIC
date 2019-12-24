using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SIS_Function
{
    /// <summary>
    /// Win32API
    /// </summary>
    public class Win32API
    {
        [DllImport("gdi32")]
        public static extern int SetBkMode(IntPtr hdc, int nBkMode);
        public const int TRANSPARENT = 1;

        [DllImport("gdi32")]
        public static extern IntPtr CreateFont(int H, int W, int E, int O, int FW, int I, int u, int S, int C, int OP, int CP, int Q, int PAF, string F);

        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32")]
        public static extern IntPtr StretchDIBits(IntPtr hdc, int W, int E, int O, int FW, int I, int u, int S, int C, IntPtr lpBits,bitmapinfo lpBitsInfo, uint iUsage, int dwRop);
        public const uint DIB_RGB_COLORS = 0;
        public const int SRCCOPY = 0x00CC0020;
        public struct bitmapinfo
        {
            [MarshalAs(UnmanagedType.Struct, SizeConst = 40)]
            public BITMAPINFOHEADER bmiHeader;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public Int32[] bmiColors;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biSize;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biWidth;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biHeight;
            [MarshalAs(UnmanagedType.I2)]
            public short biPlanes;
            [MarshalAs(UnmanagedType.I2)]
            public short biBitCount;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biCompression;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biSizeImage;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biXPelsPerMeter;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biYPelsPerMeter;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biClrUsed;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 biClrImportant;
        }
    }
}
