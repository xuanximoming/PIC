using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using ILL;

namespace SIS
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileOperator
    {
        public FileOperator()
        {

        }

        /// <summary>
        /// 文件保存
        /// </summary>
        /// <param name="bt"></param>
        /// <param name="FileName"></param>
        public void FileSave(byte[] bt, string FileName)
        {
            FileStream fsForWrite = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            fsForWrite.Write(bt, 0, bt.GetLength(0));
            fsForWrite.Close();
        }

        /// <summary>
        /// 文件二进制流
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public byte[] FileByte(string FileName)
        {
            FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Byte[] bt = new Byte[file.Length];//把图片转成 Byte型 二进制流   
            file.Read(bt, 0, bt.Length);//把二进制流读入缓冲区   
            file.Close();
            return bt;
        }

        /// <summary>
        /// 从文件获取图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Image GetImageFromFile(string file)
        {
            System.IO.FileStream fs = null;
            Image image = null;
            try
            {
                fs = new System.IO.FileStream(file, System.IO.FileMode.Open);
                if (fs.Length > 0)
                    image = Image.FromStream(fs);
                else
                {
                    fs.Close();
                    System.IO.File.Delete(file);
                }
            }
            catch { return image; }
            if (fs != null)
                fs.Close();
            return image;
        }

        /// <summary> 
        /// 保存JPG时用      
        /// </summary>     
        /// <param name="mimeType">文件类型</param>   
        /// <returns>得到指定mimeType的ImageCodecInfo</returns>    
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }
        
        /// <summary>        
        /// 保存为JPEG格式，支持压缩质量选项        
        /// </summary>
        /// <param name="bmp">原始位图</param>    
        /// <param name="FileName">新文件地址</param>   
        /// <param name="Qty">压缩质量，越大越好，文件也越大(0-100)</param>     
        /// <returns>成功标志</returns>     
        public static bool SaveAsJPEG(Image bmp, string FileName, int Qty)
        {
            try
            {
                EncoderParameter p;
                EncoderParameters ps;
                ps = new EncoderParameters(1);
                p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Qty);
                ps.Param[0] = p;
                bmp.Save(FileName, GetCodecInfo("image/jpeg"), ps);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 备份采集的图片
        /// </summary>
        public static void BackCatchImg(Image img)
        {
            //备份采集的图片
            try
            {
                if (frmMainForm.examInf.ExamAccessionNum != "" && frmMainForm.examInf.ReqDateTime != "")
                {
                    string ReqDateTime = frmMainForm.examInf.ReqDateTime;
                    string BackDir = string.Format(Application.StartupPath + "\\BCImages\\{0}\\{1}\\", frmMainForm.examInf.ReqDateTime, frmMainForm.examInf.ExamAccessionNum);
                    if (!Directory.Exists(BackDir))
                        Directory.CreateDirectory(BackDir);
                    string FileName = frmMainForm.examInf.ExamAccessionNum + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
                    FileOperator.SaveAsJPEG(img, BackDir + FileName, GetConfig.IMS_Quality);
                }
            }
            catch
            {
               // MessageBoxEx.Show(frmMainForm.examInf.ReqDateTime);
            }
           // MessageBoxEx.Show(frmMainForm.examInf.ReqDateTime);
        }

        /// <summary>
        /// 剪切图片
        /// </summary>
        /// <param name="SourceImg">Image</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns>剪切完的图片</returns>
        public static Image CutImg(Image SourceImg)
        {
            if (!ILL.GetConfig.IMS_IsUseRect)
                return SourceImg;
            //CutImg(Image SourceImg, int x, int y, int width, int height)
            //x=297;
            //y=103;
            //width=377;
            //height = 374;
            //int iLeft = x, iTop = y, iWidth = width, iHeight = height;
            int iLeft =int.Parse(ILL.GetConfig.IMS_Rect[0]);
            int iTop = int.Parse(ILL.GetConfig.IMS_Rect[1]);
            int iWidth = int.Parse(ILL.GetConfig.IMS_Rect[2]);
            int iHeight = int.Parse(ILL.GetConfig.IMS_Rect[3]);
            // 加载图片
            System.Drawing.Image image = SourceImg;
            Bitmap newImage = new Bitmap(iWidth, iHeight);
            // 目标区域
            Rectangle destRect = new Rectangle(0, 0, iWidth, iHeight);
            // 源图区域
            Rectangle srcRect = new Rectangle(iLeft, iTop, iWidth, iHeight);
            // 新建Graphics对象
            newImage = new Bitmap(iWidth, iHeight);
            Graphics g = Graphics.FromImage(newImage);
            // 绘图平滑程序
            g.SmoothingMode = SmoothingMode.None; ;
            // 图片输出质量
            g.CompositingQuality = CompositingQuality.Invalid;
            // 输出到newImage对象
            g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
            // 释放绘图对象
            g.Dispose();

            // 释放图像资源
            //image.Dispose();
            return newImage;
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="path">绝对路径</param>
        /// <returns></returns>
        public string GetFileName(string path)
        {
            return path.Substring(path.LastIndexOf("\\") + 1);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="destDirName"></param>
        /// <param name="DeldestDir"></param>
        public void CreateNewDir(string destDirName, bool DeldestDir)
        {
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);
            else if (DeldestDir)
            {
                try
                {
                    Directory.Delete(destDirName, true);
                }
                catch
                {
                    SIS_Function.ProcessOpe po = new SIS_Function.ProcessOpe();

                    //获得进程对象，以用来操作   
                    System.Diagnostics.Process myproc = new System.Diagnostics.Process();
                    List<int> pids = new List<int>();
                    //得到所有打开的进程    
                    try
                    {
                        //获得需要杀死的进程名   
                        foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName("WINWORD"))
                        {
                            pids.Add(thisproc.Id);
                        }
                    }
                    catch (Exception Exc)
                    {
                        throw new Exception("", Exc);
                    }
                    po.KillProcess(pids.ToArray(), destDirName);
                    System.Threading.Thread.Sleep(1000);
                    Directory.Delete(destDirName, true);
                }
                Directory.CreateDirectory(destDirName);
            }
        }

        /// <summary>
        /// 复制文件夹（暂不支持递归）
        /// </summary>
        /// <param name="sourceDirName">源文件路径</param>
        /// <param name="destDirName">目标文件路径</param>
        /// <param name="DeldestDir">复制前是否清除目标文件</param>
        /// <returns></returns>
        public bool FilesCopy(string sourceDirName, string destDirName, bool DeldestDir)
        {

            CreateNewDir(destDirName, DeldestDir);
            string[] files = Directory.GetFiles(sourceDirName);
            for (int i = 0; i < files.Length; i++)
            {
                string filename = destDirName + "\\" + GetFileName(files[i]);
                File.Copy(files[i], filename, true);
            }
            return true;
        }
        public List<ImgObj> ArrReportImg(List<ImgObj> array, string oldstr, string newstr)
        {
            List<ImgObj> arr = new List<ImgObj>();
            for (int i = 0; i < array.Count; i++)
            {
                ImgObj obj = ((ImgObj)array[i]).Copy();
                obj.ImagePath = obj.ImagePath.Replace(oldstr, newstr);
                arr.Add(obj);
            }
            return arr;
        }

        /// <summary>
        /// 上传时生成新的文件名
        /// </summary>
        /// <param name="Dir"></param>
        /// <param name="NameTitle"></param>
        /// <param name="FileType"></param>
        /// <returns></returns>
        public string GetNewFileName(string Dir,string NameTitle,string FileType)
        {
            int i=0;
            string newFileName = "";
            do
            {
                newFileName = NameTitle +System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileType;
                i++;
            } while (File.Exists(Dir + "\\" + newFileName));
            return newFileName;
        }

        /// <summary>
        /// 后台采集时生成新的文件名;
        /// </summary>
        /// <param name="Dir"></param>
        /// <param name="NameTitle"></param>
        /// <param name="FileType"></param>
        /// <returns></returns>
        public string GetNewBackFileName(string Dir, string NameTitle, string FileType)
        {
            string SearchPattern = NameTitle + "*.jpg";
            string[] fiels = Directory.GetFiles(Dir, SearchPattern, SearchOption.TopDirectoryOnly);
            int i = fiels.Length + 1;
            string newFileName = "";
            do
            {
                newFileName = NameTitle + "-" + i.ToString() + FileType;
                i++;

            } while (File.Exists(Dir + "\\" + newFileName));
            return newFileName;
        }

        public string[] GetFiles(string Dir, string SearchPattern)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            FileInfo[] files = di.GetFiles(SearchPattern);
            DataTable table = new DataTable();
            table.Columns.Add("fn", typeof(string));
            table.Columns.Add("cd", typeof(DateTime));
            for (int i = 0; i < files.Length; i++)
            {
                DataRow newrow = table.NewRow();
                newrow["fn"] = files[i].FullName;
                newrow["cd"] = files[i].CreationTime;
                table.Rows.Add(newrow);
            }
            table.DefaultView.Sort = "cd";
            string[] fns = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                fns[i] = table.DefaultView[i]["fn"].ToString();
            }
            return fns;
        }

        /// <summary>
        /// 记录系统日志
        /// </summary>
        /// <param name="logMsg"></param>
        public void WriteLog(string logMsg)
        {
            try
            {
                if (!Directory.Exists("log"))
                    Directory.CreateDirectory("log");
                StreamWriter sw = new StreamWriter("log\\" + DateTime.Now.ToString("yyyyMMdd") + ".log", true, Encoding.Default);
                sw.Write(logMsg);
                sw.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 根据文件创建时间删除指定时间外的文件
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="dTime"></param>
        public void DelBakImg(string Path, DateTime dTime)
        {
            DirectoryInfo dir = new DirectoryInfo(Path);
            DirectoryInfo[] subdirs = dir.GetDirectories();
            for (int i = 0; i < subdirs.Length; i++)
            {
                DateTime dt1 = subdirs[i].CreationTime;
                DateTime dt2 = dTime;

                if (DateTime.Compare(dt1, dt2) < 0)
                {
                    subdirs[i].Delete(true);
                }
            }

        }
    }
}
