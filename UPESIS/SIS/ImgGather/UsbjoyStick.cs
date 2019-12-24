using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SIS.ImgGather
{
    public class UsbjoyStick
    {
        /* 游戏操纵杆错误返回值 */
        public const int JOYERR_BASE = 160;
        public const int OYERR_NOERROR = (0);              /* 正常 */
        public const int JOYERR_ParmS = (JOYERR_BASE + 5);     /* 参数错误 */
        public const int JOYERR_NOCANDO = (JOYERR_BASE + 6);   /* 无法正常工作 */
        public const int JOYERR_UNPLUGGED = (JOYERR_BASE + 7);  /* 操纵杆未连接 */
        /* 用以表明当前操纵杆的状态 */
        public const int JOY_BUTTON1 = 0x0001;
        public const int JOY_BUTTON2 = 0x0002;
        public const int JOY_BUTTON3 = 0x0004;
        public const int JOY_BUTTON4 = 0x0008;
        public const int JOY_BUTTON1CHG = 0x0100;
        public const int JOY_BUTTON2CHG = 0x0200;
        public const int JOY_BUTTON3CHG = 0x0400;
        public const int JOY_BUTTON4CHG = 0x0800;
        /* 操纵杆标识号 */
        public const int JOYSTICKID1 = 0;
        public const int JOYSTICKID2 = 1;
        /* 用以传递操纵杆当前状态的一些消息 */
        public const int MM_JOY1MOVE = 0x3A0;
        public const int MM_JOY2MOVE = 0x3A1;
        public const int MM_JOY1ZMOVE = 0x3A2;
        public const int MM_JOY2ZMOVE = 0x3A3;
        public const int MM_JOY1BUTTONDOWN = 0x3B5;
        public const int MM_JOY2BUTTONDOWN = 0x3B6;
        public const int MM_JOY1BUTTONUP = 0x3B7;
        public const int MM_JOY2BUTTONUP = 0x3B8;


        ///　<summary>
        /// 向系统申请捕获某个游戏杆并定时将该设备的状态值通过消息发送到某个窗口 
        ///　</summary>
        ///　<param name="hWnd">窗口句柄</param>
        ///　<param name="uJoyID">指定游戏杆(0-15)，它可以是JOYSTICKID1或JOYSTICKID2</param>
        ///　<param name="uPeriod">每隔给定的轮询间隔就给应用程序发送有关游戏杆的信息。这个参数是以毫妙为单位的轮询频率。</param>
        ///　<param name="fChanged">是否允许程序当操纵杆移动一定的距离后才接受消息</param>
        ///　<returns></returns>
        [DllImport("winmm.dll")]
        public static extern int joySetCapture(IntPtr hWnd, int uJoyID, int uPeriod, bool fChanged);

    }
}
