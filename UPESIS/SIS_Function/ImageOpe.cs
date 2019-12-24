using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SIS_Function
{
    public class ImageOpe
    {
        public static byte[] ImageToByte(Image photo)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagedata = ms.GetBuffer();
            return imagedata;
        }

        public static Bitmap ByteToImage(byte[] imagedata)
        {
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imagedata))
                {
                    Bitmap img = new Bitmap(ms);
                    return img;
                }
            }
            catch
            {
                return null;
            }
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(HandleRef hDesDC, int x, int y, int w, int h,
            HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);

        //public static Bitmap FromGraphics(Graphics g, int w, int h)
        //{
        //    const int SRCCOPY = 0xcc0020;
        //    Bitmap b = new Bitmap(w, h);
        //    Graphics gd = Graphics.FromImage(b);
            
        //    BitBlt(new HandleRef(null, gd.GetHdc()), 0, 0, w, h,
        //     new HandleRef(null, g.GetHdc()), 0, 0, SRCCOPY);
        //    gd.ReleaseHdc(); g.ReleaseHdc();
        //    return b;
        //}
        /// <summary>
        /// 由图片控件截取图片
        /// </summary>
        /// <param name="control"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Bitmap FromGraphics(Control control, int w, int h)
        {
            Rectangle rect = new Rectangle(0, 0, w, h);
            Bitmap bitmap = new Bitmap(w,h);
            control.DrawToBitmap(bitmap, rect);
            return bitmap;
        }
        /// <summary>
        /// Resize图片
        /// </summary>
        /// <param name="bmp">原始Bitmap</param>
        /// <param name="newW">新的宽度</param>
        /// <param name="newH">新的高度</param>
        /// <param name="Mode">保留着，暂时未用</param>
        /// <returns>处理以后的图片</returns>
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b); 
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }

         /// <summary>
        /// 剪裁 -- 用GDI+
        /// </summary>
        /// <param name="b">原始Bitmap</param>
        /// <param name="StartX">开始坐标X</param>
        /// <param name="StartY">开始坐标Y</param>
        /// <param name="iWidth">宽度</param>
        /// <param name="iHeight">高度</param>
        /// <returns>剪裁后的Bitmap</returns>
        public static Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (StartX >= w || StartY >= h)
            {
                return null;
            }

            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

    }
}
