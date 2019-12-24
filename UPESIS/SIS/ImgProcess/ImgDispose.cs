using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using BaseControls.ImageBox.Imaging;

namespace SIS.ImgProcess
{
    class ImgDispose
    {
        /// <summary>
        /// ͼ����������
        /// </summary>
        /// <param name="b">ԭʼͼ</param>
        /// <param name="degree">����[-255, 255]</param>
        /// <returns></returns>
        public static Bitmap KiLighten(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -255) degree = -255;
            if (degree > 255) degree = 255;

            try
            {

                int width = b.Width;
                int height = b.Height;

                int pix = 0;

                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // ����ָ��λ�����ص�����
                            for (int i = 0; i < 3; i++)
                            {

                                pix = p[i] + degree;

                                if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                                if (degree > 0) p[i] = (byte)Math.Min(255, pix);

                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }

                b.UnlockBits(data);

                return b;
            }
            catch
            {
                return null;
            }

        } // end of Lighten

        /// <summary>
        /// ͼ��Աȶȵ���
        /// </summary>
        /// <param name="b">ԭʼͼ</param>
        /// <param name="degree">�Աȶ�[-100, 100]</param>
        /// <returns></returns>
        public static Bitmap KiContrast(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;

            try
            {

                double pixel = 0;
                double contrast = (100.0 + degree) / 100.0;
                contrast *= contrast;
                int width = b.Width;
                int height = b.Height;
                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // ����ָ��λ�����صĶԱȶ�
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[i] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                b.UnlockBits(data);
                return b;
            }
            catch
            {
                return null;
            }
        } // end of Contrast


        /// <summary>
        /// Create and initialize grayscale image
        /// </summary>
        /// 
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// 
        /// <returns>Returns the created grayscale image</returns>
        /// 
        /// <remarks>The methods create new grayscale image and initializes its palette.
        /// Grayscale image is represented as
        /// <see cref="System.Drawing.Imaging.PixelFormat">Format8bppIndexed</see>
        /// image with palette initialized to 256 gradients of gray color</remarks>
        /// 
        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            // create new image
            Bitmap image = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            // set palette to grayscale
            SetGrayscalePalette(image);
            // return new image
            return image;
        }

        /// <summary>
        /// Set pallete of the image to grayscale
        /// </summary>
        /// 
        /// <param name="image">Image to initialize</param>
        /// 
        /// <remarks>The method initializes palette of
        /// <see cref="System.Drawing.Imaging.PixelFormat">Format8bppIndexed</see>
        /// image with 256 gradients of gray color.</remarks>
        /// 
        public static void SetGrayscalePalette(Bitmap image)
        {
            // check pixel format
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException();

            // get palette
            ColorPalette cp = image.Palette;
            // init palette
            for (int i = 0; i < 256; i++)
            {
                cp.Entries[i] = Color.FromArgb(i, i, i);
            }
            // set palette back
            image.Palette = cp;
        }

        public static Bitmap RGB2Gray(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);

            // ��Bitmap������ϵͳ�ڴ���, ���BitmapData
            BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //����Bitmap
            Bitmap dstBitmap = CreateGrayscaleImage(wide, height);//��������ں����ж���
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            // λͼ�е�һ���������ݵĵ�ַ����Ҳ���Կ�����λͼ�еĵ�һ��ɨ����
            System.IntPtr srcPtr = srcBmData.Scan0;
            System.IntPtr dstPtr = dstBmData.Scan0;

            // ��Bitmap�������Ϣ��ŵ�byte������
            int src_bytes = srcBmData.Stride * height;
            byte[] srcValues = new byte[src_bytes];
            int dst_bytes = dstBmData.Stride * height;
            byte[] dstValues = new byte[dst_bytes];

            //����GRB��Ϣ��byte����
            System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);

            // ����Y=0.299*R+0.114*G+0.587B,YΪ����
            for (int i = 0; i < height; i++)
                for (int j = 0; j < wide; j++)
                {
                    //ֻ����ÿ����ͼ����������,����δ�ÿռ�
                    //ע��λͼ�ṹ��RGB��BGR��˳��洢
                    int k = 3 * j;

                    byte temp = (byte)(srcValues[i * srcBmData.Stride + k + 2] * .299

                         + srcValues[i * srcBmData.Stride + k + 1] * .587 + srcValues[i * srcBmData.Stride + k] * .114);

                    dstValues[i * dstBmData.Stride + j] = temp;
                }

            //�����Ĺ���byte[]������ԭλͼ
            System.Runtime.InteropServices.Marshal.Copy(dstValues, 0, dstPtr, dst_bytes);

            // ����λͼ
            srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;
        }

        public unsafe static Bitmap PseudoColor1(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);
            Bitmap grayImage;
            BitmapData grayData;
            BitmapData srcBmData;
            bool isLock = false;
            if (srcBitmap.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                // do the processing
                grayImage = RGB2Gray(srcBitmap);
                // lock the image
                grayData = grayImage.LockBits(
                    new Rectangle(0, 0, wide, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                // substitute the source
                srcBmData = grayData;
            }
            else
            {
                srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                isLock = true;
            }
            // ��Bitmap������ϵͳ�ڴ���, ���BitmapData
            //BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            //srcBmData.PixelFormat = PixelFormat.Format24bppRgb;
            //����Bitmap
            Bitmap dstBitmap = new Bitmap(wide, height, PixelFormat.Format24bppRgb);
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int widthData = srcBmData.Width;
            int heightData = srcBmData.Height;

            int srcOffset = srcBmData.Stride - widthData;
            int dstOffset = dstBmData.Stride - widthData * 3;

            // do the job
            byte* src = (byte*)srcBmData.Scan0.ToPointer();
            byte* dst = (byte*)dstBmData.Scan0.ToPointer();

            // for each line
            for (int y = 0; y < height; y++)
            {
                // for each pixel
                for (int x = 0; x < widthData; x++, src++, dst += 3)
                {
                    dst[RGB.R] = dst[RGB.G] = dst[RGB.B] = *src;
                }
                src += srcOffset;
                dst += dstOffset;
            }


            // λͼ�е�һ���������ݵĵ�ַ����Ҳ���Կ�����λͼ�еĵ�һ��ɨ����
            //System.IntPtr srcPtr = srcBmData.Scan0;
            System.IntPtr dstPtr = dstBmData.Scan0;

            // ��Bitmap�������Ϣ��ŵ�byte������
            //int src_bytes = srcBmData.Stride * height;
            //byte[] srcValues = new byte[src_bytes];
            int dst_bytes = dstBmData.Stride * height;
            byte[] dstValues = new byte[dst_bytes];

            //����GRB��Ϣ��byte����
            //System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);
            //dstValues = srcValues;
            // ����Y=0.299*R+0.114*G+0.587B,YΪ����
            for (int i = 0; i < height - 2; i++)
                for (int j = 0; j < wide - 2; j++)
                {

                    int k = 3 * j;
                    int k1 = i * dstBmData.Stride + k;
                    int k2 = i * dstBmData.Stride + k + 1;
                    int k3 = i * dstBmData.Stride + k + 2;
                    byte gray = (byte)(dstValues[k3] * 0.299 + dstValues[k2] * 0.587 + dstValues[k1] * 0.114);
                    if (0 <= gray && gray < 63)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(254 - 4 * gray);
                        dstValues[k1] = 155;
                    }
                    if (64 <= gray && gray < 127)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(4 * gray - 254);
                        dstValues[k1] = (byte)(510 - 4 * gray);
                    }
                    if (128 <= gray && gray < 191)
                    {
                        dstValues[k3] = (byte)(4 * gray - 510);
                        dstValues[k2] = 255;
                        dstValues[k1] = 0;
                    }
                    if (192 <= gray && gray <= 255)
                    {
                        dstValues[k3] = 255;
                        dstValues[k2] = (byte)(1022 - 4 * gray);
                        dstValues[k1] = 0;
                    }
                    //byte temp = (byte)(srcValues[i * srcBmData.Stride + k + 2] * .299

                    //     + srcValues[i * srcBmData.Stride + k + 1] * .587 + srcValues[i * srcBmData.Stride + k] * .114);

                    //dstValues[i * dstBmData.Stride + j] = temp;
                }

            //�����Ĺ���byte[]������ԭλͼ
            System.Runtime.InteropServices.Marshal.Copy(dstValues, 0, dstPtr, dst_bytes);

            // ����λͼ
            if (isLock)
                srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;
        }


        public unsafe static Bitmap PseudoColor2(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);
            Bitmap grayImage;
            BitmapData grayData;
            BitmapData srcBmData;
            bool isLock = false;
            if (srcBitmap.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                // do the processing
                grayImage = RGB2Gray(srcBitmap);
                // lock the image
                grayData = grayImage.LockBits(
                    new Rectangle(0, 0, wide, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                // substitute the source
                srcBmData = grayData;
            }
            else
            {
                srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                isLock = true;
            }
            // ��Bitmap������ϵͳ�ڴ���, ���BitmapData
            //BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            //srcBmData.PixelFormat = PixelFormat.Format24bppRgb;
            //����Bitmap
            Bitmap dstBitmap = new Bitmap(wide, height, PixelFormat.Format24bppRgb);
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int widthData = srcBmData.Width;
            int heightData = srcBmData.Height;

            int srcOffset = srcBmData.Stride - widthData;
            int dstOffset = dstBmData.Stride - widthData * 3;

            // do the job
            byte* src = (byte*)srcBmData.Scan0.ToPointer();
            byte* dst = (byte*)dstBmData.Scan0.ToPointer();

            // for each line
            for (int y = 0; y < height; y++)
            {
                // for each pixel
                for (int x = 0; x < widthData; x++, src++, dst += 3)
                {
                    dst[RGB.R] = dst[RGB.G] = dst[RGB.B] = *src;
                }
                src += srcOffset;
                dst += dstOffset;
            }


            // λͼ�е�һ���������ݵĵ�ַ����Ҳ���Կ�����λͼ�еĵ�һ��ɨ����
            //System.IntPtr srcPtr = srcBmData.Scan0;
            System.IntPtr dstPtr = dstBmData.Scan0;

            // ��Bitmap�������Ϣ��ŵ�byte������
            //int src_bytes = srcBmData.Stride * height;
            //byte[] srcValues = new byte[src_bytes];
            int dst_bytes = dstBmData.Stride * height;
            byte[] dstValues = new byte[dst_bytes];

            //����GRB��Ϣ��byte����
            //System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);
            //dstValues = srcValues;
            // ����Y=0.299*R+0.114*G+0.587B,YΪ����
            for (int i = 0; i < height - 2; i++)
                for (int j = 0; j < wide - 2; j++)
                {

                    int k = 3 * j;
                    int k1 = i * dstBmData.Stride + k;
                    int k2 = i * dstBmData.Stride + k + 1;
                    int k3 = i * dstBmData.Stride + k + 2;
                    byte gray = (byte)(dstValues[k3] * 0.587 + dstValues[k2] * 0.114 + dstValues[k1] * 0.299);
                    if (0 <= gray && gray < 63)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(254 - 4 * gray);
                        dstValues[k1] = 155;
                    }
                    if (64 <= gray && gray < 127)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(4 * gray - 254);
                        dstValues[k1] = (byte)(510 - 4 * gray);
                    }
                    if (128 <= gray && gray < 191)
                    {
                        dstValues[k3] = (byte)(4 * gray - 510);
                        dstValues[k2] = 255;
                        dstValues[k1] = 0;
                    }
                    if (192 <= gray && gray <= 255)
                    {
                        dstValues[k3] = 255;
                        dstValues[k2] = (byte)(1022 - 4 * gray);
                        dstValues[k1] = 0;
                    }
                    //byte temp = (byte)(srcValues[i * srcBmData.Stride + k + 2] * .299

                    //     + srcValues[i * srcBmData.Stride + k + 1] * .587 + srcValues[i * srcBmData.Stride + k] * .114);

                    //dstValues[i * dstBmData.Stride + j] = temp;
                }

            //�����Ĺ���byte[]������ԭλͼ
            System.Runtime.InteropServices.Marshal.Copy(dstValues, 0, dstPtr, dst_bytes);

            // ����λͼ
            if (isLock)
                srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;
        }

        public unsafe static Bitmap PseudoColor3(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);
            Bitmap grayImage;
            BitmapData grayData;
            BitmapData srcBmData;
            bool isLock = false;
            if (srcBitmap.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                // do the processing
                grayImage = RGB2Gray(srcBitmap);
                // lock the image
                grayData = grayImage.LockBits(
                    new Rectangle(0, 0, wide, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                // substitute the source
                srcBmData = grayData;
            }
            else
            {
                srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                isLock = true;
            }
            // ��Bitmap������ϵͳ�ڴ���, ���BitmapData
            //BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            //srcBmData.PixelFormat = PixelFormat.Format24bppRgb;
            //����Bitmap
            Bitmap dstBitmap = new Bitmap(wide, height, PixelFormat.Format24bppRgb);
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int widthData = srcBmData.Width;
            int heightData = srcBmData.Height;

            int srcOffset = srcBmData.Stride - widthData;
            int dstOffset = dstBmData.Stride - widthData * 3;

            // do the job
            byte* src = (byte*)srcBmData.Scan0.ToPointer();
            byte* dst = (byte*)dstBmData.Scan0.ToPointer();

            // for each line
            for (int y = 0; y < height; y++)
            {
                // for each pixel
                for (int x = 0; x < widthData; x++, src++, dst += 3)
                {
                    dst[RGB.R] = dst[RGB.G] = dst[RGB.B] = *src;
                }
                src += srcOffset;
                dst += dstOffset;
            }


            // λͼ�е�һ���������ݵĵ�ַ����Ҳ���Կ�����λͼ�еĵ�һ��ɨ����
            //System.IntPtr srcPtr = srcBmData.Scan0;
            System.IntPtr dstPtr = dstBmData.Scan0;

            // ��Bitmap�������Ϣ��ŵ�byte������
            //int src_bytes = srcBmData.Stride * height;
            //byte[] srcValues = new byte[src_bytes];
            int dst_bytes = dstBmData.Stride * height;
            byte[] dstValues = new byte[dst_bytes];

            //����GRB��Ϣ��byte����
            //System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);
            //dstValues = srcValues;
            // ����Y=0.299*R+0.114*G+0.587B,YΪ����
            for (int i = 0; i < height - 2; i++)
                for (int j = 0; j < wide - 2; j++)
                {

                    int k = 3 * j;
                    int k1 = i * dstBmData.Stride + k;
                    int k2 = i * dstBmData.Stride + k + 1;
                    int k3 = i * dstBmData.Stride + k + 2;
                    byte gray = (byte)(dstValues[k3] * 0.114 + dstValues[k2] * 0.299 + dstValues[k1] * 0.587);
                    if (0 <= gray && gray < 63)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(254 - 4 * gray);
                        dstValues[k1] = 155;
                    }
                    if (64 <= gray && gray < 127)
                    {
                        dstValues[k3] = 0;
                        dstValues[k2] = (byte)(4 * gray - 254);
                        dstValues[k1] = (byte)(510 - 4 * gray);
                    }
                    if (128 <= gray && gray < 191)
                    {
                        dstValues[k3] = (byte)(4 * gray - 510);
                        dstValues[k2] = 255;
                        dstValues[k1] = 0;
                    }
                    if (192 <= gray && gray <= 255)
                    {
                        dstValues[k3] = 255;
                        dstValues[k2] = (byte)(1022 - 4 * gray);
                        dstValues[k1] = 0;
                    }
                    //byte temp = (byte)(srcValues[i * srcBmData.Stride + k + 2] * .299

                    //     + srcValues[i * srcBmData.Stride + k + 1] * .587 + srcValues[i * srcBmData.Stride + k] * .114);

                    //dstValues[i * dstBmData.Stride + j] = temp;
                }

            //�����Ĺ���byte[]������ԭλͼ
            System.Runtime.InteropServices.Marshal.Copy(dstValues, 0, dstPtr, dst_bytes);

            // ����λͼ
            if (isLock)
                srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;
        }

    }
}
