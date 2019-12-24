using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;

namespace SIS_Function.GatherCard
{
    public class OKGather:Comment
    {
        public event GetCallBackEventHandler GetCallBack;
        private System.Drawing.Bitmap bm = null;
        private OK ok;
        private IntPtr cardHandle;
        private IntPtr a;
        private ColorPalette palette;
        private long bits, size;
        private int width = 0, height = 0, stride = 0;
        private bool isOpened;

        /// <summary>
        /// 打开卡
        /// </summary>
        public bool OpenCard()
        {
            if (isOpened)
                return true;
            try
            {
                int i = 0;
                cardHandle = OK.okOpenBoard(ref i);
                bits = OK.okSetCaptureParam(cardHandle, 4, -1);
                size = OK.okSetCaptureParam(cardHandle, 6, -1);
                size = this.GETHIWORD(bits) / 8 * this.GETHIWORD(size) * this.GETLOWORD(size);
                OK.okGetTargetInfo(cardHandle, 1, 0, ref width, ref height, ref stride);
                OK.okSetConvertParam(cardHandle, "CONVERT_FIELDEXTEND", -1);
                OK.okSetCaptureParam(cardHandle, 15, 0);
                OK.okSetCaptureParam(cardHandle, 4, -1);
                OK.okSetCaptureParam(cardHandle, 6, -1);
                OK.okSetCaptureParam(cardHandle, 1, 0);
                OK.okSetSeqCallback(cardHandle, ok.begin, ok.seq, ok.end);
                OK.okCaptureByBuffer(cardHandle, 1, 0, 0);
                isOpened = true;
            }
            catch
            {
                MessageBox.Show(ok.lastError().ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public bool initCard()
        {
            ok = new OK();
            ok.begin = new OK.BeginProc(beginproc);
            ok.seq = new OK.SeqProgress(seqprogress);
            ok.end = new OK.EndProc(endproc);
            return true;
        }

        public bool beginproc(IntPtr hBoard)
        {
            try
            {
                a = System.Runtime.InteropServices.Marshal.AllocHGlobal(Convert.ToInt32(size));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return true;
        }

        public bool endproc(IntPtr hBoard)
        {
            return true;
        }

        public bool seqprogress(IntPtr hBoard, int No)
        {
            OK.okReadRect(hBoard, 1, No, a);
            switch (this.GETHIWORD(bits))
            {
                case 8:
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, a);
                    //创建灰阶
                    palette = bm.Palette;
                    for (int i = 0; i < palette.Entries.Length; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    bm.Palette = palette;
                    break;
                //case 32:
                //    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, a);
                //    break;
                case 24:
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, a);
                    break;
                case 16:
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format16bppRgb565, a);
                    break;
                default:
                    MessageBox.Show("没找到卡!");
                    ok.CloseBoard(cardHandle);
                    break;
            }
            GetCallBackEventHandler temp = GetCallBack;
            if (temp != null)
                temp(bm);
            return true;
        }

        /// <summary>
        /// 关闭卡
        /// </summary>
        public bool CloseCard()
        {
            if (!isOpened)
                return true;
            try
            {
                OK.okSetSeqCallback(cardHandle, null, null, null);
                isOpened = false;
                ok.CloseBoard(cardHandle);

            }
            catch
            {
                MessageBox.Show(ok.lastError().ToString());
                ok.CloseBoard(cardHandle);
                return false;
            }
            return true;
        }

        private long GETLOWORD(long lParam)
        {
            return (lParam & 0x0000ffff);
        }

        private long GETHIWORD(long lParam)
        {
            lParam = (lParam & 0xffff0000);
            return (lParam >> 16);
        }
    }
}
