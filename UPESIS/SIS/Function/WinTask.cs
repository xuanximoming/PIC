using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;

namespace SIS
{
    /// <summary>
    /// Windows任务类
    /// </summary>
    public class WinTask
    {

        [DllImport("user32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd,
            out uint dwProcessId);

        public const uint PROCESS_VM_OPERATION = 0x0008;
        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess,
            bool bInheritHandle, uint dwProcessId);
        public const uint MEM_COMMIT = 0x1000;
        public const uint MEM_RELEASE = 0x8000;

        public const uint MEM_RESERVE = 0x2000;
        public const uint PAGE_READWRITE = 4;

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
           IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

        public const int WM_USER = 0x0400;
        public const int TB_BUTTONCOUNT = WM_USER + 24;
        public const int TB_GETBUTTONTEXTW = WM_USER + 75;

        /// <summary>
        /// 获取WINDOWS任务栏窗体集合
        /// </summary>
        /// <returns></returns>
        public ArrayList ArTask()
        {
            IntPtr vHandle = FindWindow("Shell_TrayWnd", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "ReBarWindow32", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "MSTaskSwWClass", null);
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "ToolbarWindow32", null);
            int vCount = SendMessage(vHandle, TB_BUTTONCOUNT, 0, 0);
            uint vProcessId;
            GetWindowThreadProcessId(vHandle, out vProcessId);
            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ |
                PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 0x1000,
                MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            char[] vBuffer = new char[256];
            uint vNumberOfBytesRead = 0;
            ArrayList array = new ArrayList();
            try
            {
                for (int i = 0; i < vCount; i++)
                {
                    SendMessage(vHandle, TB_GETBUTTONTEXTW, i, vPointer.ToInt32());
                    ReadProcessMemory(vProcess, vPointer,
                        Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0),
                        vBuffer.Length * sizeof(char), ref vNumberOfBytesRead);
                    int l = 0;
                    for (int j = 0; j < vBuffer.Length; j++)
                    {
                        if (vBuffer[j] == (char)0)
                        {
                            l = j;
                            break;
                        }
                    }
                    //Console.WriteLine(new string(vBuffer, 0, l));

                    array.Add(new string(vBuffer, 0, l));
                }
            }
            finally
            {
                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
            return array;
        }
        /// <summary>
        /// 是否存在任务栏中
        /// </summary>
        /// <param name="procname"></param>
        /// <returns></returns>
        public bool ProcIsIntask(string procname)
        {
            if (ArTask().Contains(procname))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 根据进程名杀进程
        /// </summary>
        /// <param name="ProcName"></param>
        /// <returns></returns>
        public bool KillProc(string ProcName)
        {
            try
            {
                Process[] prc = Process.GetProcesses();
                foreach (Process pr in prc) //遍历整个进程
                {
                    if (ProcName == pr.ProcessName)  //如果进程存在
                    {
                        pr.Kill();
                        break;
                        // ProgressCount = 0; //计数器清空
                    }
                }
                return true;
            }
            catch
            { return false; }
        }
    }
}