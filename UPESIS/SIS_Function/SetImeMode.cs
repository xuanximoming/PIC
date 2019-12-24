using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SIS_Function
{
    /// <summary>
    /// 输入法控制
    /// </summary>
    public  class SetImeMode
    {
        //声明一些API函数   
        [System.Runtime.InteropServices.DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [System.Runtime.InteropServices.DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [System.Runtime.InteropServices.DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [System.Runtime.InteropServices.DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref    int lpdw, ref    int lpdw2);
        [System.Runtime.InteropServices.DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        public static void SetHalfShape(Control c, bool isOpen)
        {
            IntPtr hIme = ImmGetContext(c.Handle);
            if (isOpen)
            {
                if (!ImmGetOpenStatus(hIme))     //如果输入法处于非打开状态   
                {
                    int iMode = 0, iSentence = 0;
                    bool bSuccess = ImmGetConversionStatus(hIme, ref   iMode, ref   iSentence);     //检索输入法信息   
                    if (bSuccess)
                    {
                        ImmSetOpenStatus(hIme, true);
                        if ((iMode & IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                            ImmSimulateHotKey(c.Handle, IME_CHOTKEY_SHAPE_TOGGLE); //转换成半角
                    }
                }
            }
            else
            {
                if (ImmGetOpenStatus(hIme))     //如果输入法处于打开状态   
                {
                    int iMode = 0, iSentence = 0;
                    bool bSuccess = ImmGetConversionStatus(hIme, ref   iMode, ref   iSentence);     //检索输入法信息   
                    if (bSuccess)
                    {
                        ImmSetOpenStatus(hIme, false);
                    }
                }
            }
        }
    }
}
