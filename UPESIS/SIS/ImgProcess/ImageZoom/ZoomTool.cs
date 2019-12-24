using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SIS.ImgProcess.ImageZoom
{
    class ZoomTool
    {
        public ZoomTool()
        {


        }
        /// <SUMMARY>
        /// ͼƬ����
        /// </SUMMARY>
        /// <PARAM name="sourceFile">ͼƬԴ·��</PARAM>
        /// <PARAM name="destFile">���ź�ͼƬ���·��</PARAM>
        /// <PARAM name="destHeight">���ź�ͼƬ�߶�</PARAM>
        /// <PARAM name="destWidth">���ź�ͼƬ���</PARAM>
        /// <RETURNS></RETURNS>
        public static Bitmap GetThumbnail(Image imgSource, int destHeight, int destWidth)
        {
            //System.Drawing.Image imgSource = System.Drawing.Image.FromFile(sourceFile);
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // ����������
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;

            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }

            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.WhiteSmoke);

            // ���û������������
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            // ���´���Ϊ����ͼƬʱ������ѹ������
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;

            try
            {
                //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x];//����JPEG����
                        break;
                    }
                }

                if (jpegICI != null)
                {

                    if (!Directory.Exists(@"D:\Temp\"))
                    {

                        Directory.CreateDirectory(@"D:\Temp\");
                    }

                    outBmp.Save(@"D:\Temp\aa.bmp", jpegICI, encoderParams);
                    return (Bitmap)Bitmap.FromFile(@"D:\Temp\aa.bmp");
                }
                else
                {
                    outBmp.Save(@"D:\Temp\", thisFormat);
                    return (Bitmap)Bitmap.FromFile(@"D:\Temp\aa.bmp");
                }


            }
            catch(Exception ex)
            {
                string kk = ex.Message;
                MessageBoxEx.Show(ex.Message);
               // return false;
                return (Bitmap)imgSource;
            }
            finally
            {
                imgSource.Dispose();
                outBmp.Dispose();
                //Directory.Delete(@"D:\Temp\aa.bmp");
            }
        }


    }
   
}
