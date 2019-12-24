using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SIS_Function
{
    /// <summary>
    /// 系统托盘控制
    /// </summary>
    public static class SysTray
    {
        //取得系统托盘窗口的句柄
        private static int GetSysTrayWnd()
        {
            OSName osn = OS.GetVersion();
            int k = Windows.FindWindow("Shell_TrayWnd", null);
            k = Windows.FindWindowEx(k, 0, "TrayNotifyWnd", null);

            if (osn == OSName.Win2000 || osn == OSName.WinXP || osn == OSName.Win2003)
            {                
                if (osn == OSName.Win2000)
                {
                    k = Windows.FindWindowEx(k, 0, "ToolbarWindow32", null);
                    return k;
                }
                else
                {
                    k = Windows.FindWindowEx(k, 0, "SysPager", null);
                    k = Windows.FindWindowEx(k, 0, "ToolbarWindow32", null);
                    return k;
                }
            }
            else
            {
                return k;
            }
        }

        //刷新托盘区域：已中止进程的图标将会被系统删除。
        public static void Refresh()
        {
            int hwnd = GetSysTrayWnd();
            HRect nr = new HRect();

            Windows.GetClientRect((IntPtr)hwnd, out nr);

            for (int x = 0; x < nr.right; x = x + 2)
            {
                for (int y = 0; y < nr.bottom; y = y + 2)
                {
                    Message.SendMessage(hwnd, MsgId.WM_MOUSEMOVE, 0, Message.MakeLParam(x, y));
                }
            }
        }
    }
    public enum OSName
    {
        UNKNOWN,
        Win95,
        Win98,
        WinME,
        WinNT3,
        WinNT4,
        Win2000,
        WinXP,
        Win2003,
    }

    public struct OSVERSIONINFO
    {
        public uint dwOSVersionInfoSize;
        public uint dwMajorVersion;
        public uint dwMinorVersion;
        public uint dwBuildNumber;
        public uint dwPlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szCSDVersion;
        public Int16 wServicePackMajor;
        public Int16 wServicePackMinor;
        public Int16 wSuiteMask;
        public Byte wProductType;
        public Byte wReserved;
    }

    public static class OS
    {
        public const int VER_PLATFORM_WIN32_NT = 2;

        [DllImport("Kernel32.dll")]
        public static extern bool GetVersionEx(ref OSVERSIONINFO osvi);

        public static OSName GetVersion()
        {
            OSVERSIONINFO osvi = new OSVERSIONINFO();
            osvi.dwOSVersionInfoSize = (uint)Marshal.SizeOf(osvi);
            OSName ret;
            if (GetVersionEx(ref osvi))
            {
                if (osvi.dwPlatformId == VER_PLATFORM_WIN32_NT)
                {
                    #region Win32平台
                    switch (osvi.dwMajorVersion)
                    {
                        case 3:
                            ret = OSName.WinNT3;
                            break;
                        case 4:
                            ret = OSName.WinNT4;
                            break;
                        case 5:
                            switch (osvi.dwMinorVersion)
                            {
                                case 0:
                                    ret = OSName.Win2000;
                                    break;
                                case 1:
                                    ret = OSName.WinXP;
                                    break;
                                case 2:
                                    ret = OSName.Win2003;
                                    break;
                                default:
                                    ret = OSName.UNKNOWN;
                                    break;
                            }
                            break;
                        default:
                            ret = OSName.UNKNOWN;
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region Win16平台
                    if (osvi.dwMajorVersion == 4)
                    {
                        //Win9X系列
                        switch (osvi.dwMinorVersion)
                        {
                            case 0:
                                ret = OSName.Win95;
                                break;
                            case 10:
                                ret = OSName.Win98;
                                break;
                            case 90:
                                ret = OSName.WinME;
                                break;
                            default:
                                ret = OSName.UNKNOWN;
                                break;
                        }
                    }
                    else
                    {
                        ret = OSName.UNKNOWN;
                    }
                    #endregion
                }
            }
            else
            {
                ret = OSName.UNKNOWN;
            }
            return ret;
        }
    }
    public static class Windows
    {
        /// <summary>
        /// The FindWindow function retrieves a handle to the top-level 
        /// window whose class name and window name match the specified strings.
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="strClassName">the class name for the window to search for</param>
        /// <param name="strWindowName">the name of the window to search for</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int FindWindow(string strClassName, string strWindowName);

        /// <summary>
        /// The FindWindowEx function retrieves a handle to a window whose class name
        /// and window name match the specified strings.
        /// The function searches child windows, beginning with the one following the specified child window.
        /// This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="hwndParent">a handle to the parent window </param>
        /// <param name="hwndChildAfter">a handle to the child window to start search after</param>
        /// <param name="strClassName">the class name for the window to search for</param>
        /// <param name="strWindowName">the name of the window to search for</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

        /// <summary>
        /// The FindWindowEx API
        /// </summary>
        /// <param name="parentHandle">a handle to the parent window </param>
        /// <param name="childAfter">a handle to the child window to start search after</param>
        /// <param name="className">the class name for the window to search for</param>
        /// <param name="windowTitle">the name of the window to search for</param>
        /// <returns></returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(HandleRef hwnd, out HRect rect);

        [DllImport("User32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out HRect lpRect);

        [DllImport("User32.dll")]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
    }
    /// <summary>
    /// Contains message information from a thread's message queue.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Msg
    {
        public IntPtr hWnd;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public Point p;
    }

    /// <summary>
    /// Message For Copy DataOnly. Used For Interactive of Processes
    /// </summary>
    public struct CopyDataStruct
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }


    public static class Message
    {
        public static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }

        /// <summary>
        /// The SendMessage function sends the specified message to a
        /// window or windows. It calls the window procedure for the specified
        /// window and does not return until the window procedure
        /// has processed the message.
        /// </summary>
        /// <param name="hWnd">handle to destination window</param>
        /// <param name="Msg">message</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="hWnd">handle to destination window</param>
        /// <param name="Msg">message</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, int lParam);


        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, uint lParam);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="Msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);


        /// <summary>
        /// The PeekMessage function dispatches incoming sent messages, 
        /// checks the thread message queue for a posted message, 
        /// and retrieves the message (if any exist).
        /// </summary>
        [System.Security.SuppressUnmanagedCodeSecurity] // We won't use this maliciously
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Msg msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HRect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    public static class MsgId
    {
        public const int WM_CLOSE = 16;

        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;

        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;

        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;

        public const int WM_MOUSELAST = 0x0209;
        public const int WM_MOUSEWHEEL = 0x020A;


        public const int WM_COPYDATA = 0x004A;

        public const int WM_COMMAND = 0x111;

        public const int BN_CLICKED = 245;
    }
}
