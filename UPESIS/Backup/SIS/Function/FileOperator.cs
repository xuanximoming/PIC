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
    /// �ļ�������
    /// </summary>
    public class FileOperator
    {
        public FileOperator()
        {

        }

        /// <summary>
        /// �ļ�����
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
        /// �ļ���������
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public byte[] FileByte(string FileName)
        {
            FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Byte[] bt = new Byte[file.Length];//��ͼƬת�� Byte�� ��������   
            file.Read(bt, 0, bt.Length);//�Ѷ����������뻺����   
            file.Close();
            return bt;
        }

        /// <summary>
        /// ���ļ���ȡͼƬ
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
        /// ����JPGʱ��      
        /// </summary>     
        /// <param name="mimeType">�ļ�����</param>   
        /// <returns>�õ�ָ��mimeType��ImageCodecInfo</returns>    
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
        /// ����ΪJPEG��ʽ��֧��ѹ������ѡ��        
        /// </summary>
        /// <param name="bmp">ԭʼλͼ</param>    
        /// <param name="FileName">���ļ���ַ</param>   
        /// <param name="Qty">ѹ��������Խ��Խ�ã��ļ�ҲԽ��(0-100)</param>     
        /// <returns>�ɹ���־</returns>     
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
        /// ���ݲɼ���ͼƬ
        /// </summary>
        public static void BackCatchImg(Image img)
        {
            //���ݲɼ���ͼƬ
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
        /// ����ͼƬ
        /// </summary>
        /// <param name="SourceImg">Image</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">��</param>
        /// <param name="height">��</param>
        /// <returns>�������ͼƬ</returns>
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
            // ����ͼƬ
            System.Drawing.Image image = SourceImg;
            Bitmap newImage = new Bitmap(iWidth, iHeight);
            // Ŀ������
            Rectangle destRect = new Rectangle(0, 0, iWidth, iHeight);
            // Դͼ����
            Rectangle srcRect = new Rectangle(iLeft, iTop, iWidth, iHeight);
            // �½�Graphics����
            newImage = new Bitmap(iWidth, iHeight);
            Graphics g = Graphics.FromImage(newImage);
            // ��ͼƽ������
            g.SmoothingMode = SmoothingMode.None; ;
            // ͼƬ�������
            g.CompositingQuality = CompositingQuality.Invalid;
            // �����newImage����
            g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
            // �ͷŻ�ͼ����
            g.Dispose();

            // �ͷ�ͼ����Դ
            //image.Dispose();
            return newImage;
        }

        /// <summary>
        /// ��ȡ�ļ���
        /// </summary>
        /// <param name="path">����·��</param>
        /// <returns></returns>
        public string GetFileName(string path)
        {
            return path.Substring(path.LastIndexOf("\\") + 1);
        }

        /// <summary>
        /// ����Ŀ¼
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

                    //��ý��̶�������������   
                    System.Diagnostics.Process myproc = new System.Diagnostics.Process();
                    List<int> pids = new List<int>();
                    //�õ����д򿪵Ľ���    
                    try
                    {
                        //�����Ҫɱ���Ľ�����   
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
        /// �����ļ��У��ݲ�֧�ֵݹ飩
        /// </summary>
        /// <param name="sourceDirName">Դ�ļ�·��</param>
        /// <param name="destDirName">Ŀ���ļ�·��</param>
        /// <param name="DeldestDir">����ǰ�Ƿ����Ŀ���ļ�</param>
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
        /// �ϴ�ʱ�����µ��ļ���
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
        /// ��̨�ɼ�ʱ�����µ��ļ���;
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
        /// ��¼ϵͳ��־
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
        /// �����ļ�����ʱ��ɾ��ָ��ʱ������ļ�
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
