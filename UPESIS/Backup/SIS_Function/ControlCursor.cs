using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Function
{
    public class ControlCursor
    {
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "ClipCursor")]
        public extern static int ClipCursor(ref   RECT lpRect);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public extern static int GetWindowRect(int hwnd, ref   RECT lpRect);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        public extern static int SwapMouseButton(int bSwap);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ShowCursor")]
        public extern static bool ShowCursor(bool bShow);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        public extern static int SetDoubleClickTime(int wCount);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public extern static int GetDoubleClickTime();


        public struct RECT//声明参数的值
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

    }
}
