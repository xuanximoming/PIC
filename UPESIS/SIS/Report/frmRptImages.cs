using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILL;
using BaseControls.PictureBoxs;
using System.IO;
using System.Collections;
using SIS_Model;
using BaseControls;

namespace SIS
{
    public partial class frmRptImages : BaseControls.Docking.DockContent
    {
        public Panel panel;
        public delegate void ChceckChanged(userCtrPicture ctl);
        public ChceckChanged change;
        //public delegate void DbClick(userCtrPicture ctl);
        //public DbClick dbClick;
        private bool isDockStateChanged = false;
        private bool isDockTop = false;
        public List<ImgObj> arrayImgDel = new List<ImgObj>();//保存被删除的图像
        public List<ImgObj> arrayImg = new List<ImgObj>();//保存修改后的图片，如删除,打上勾
        private WordClass word;
        private delegate void AddNewImage(ImgObj obj);
        private frmImgQuickView queryView;
        private ImageViewer iViewer;
        private bool ReadOnly;
        private frmLocMap frmLocMap;
        private string Dir = Application.StartupPath + "\\temp\\";

        public frmRptImages(WordClass word,ContextMenuStrip cms_tool)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.word = word;
            this.l_Count.ContextMenuStrip = cms_tool;
            //this.ContextMenuStrip = cms_tool;
        }

        public void AddPreferImage(Image image)
        {
            if (frmMainForm.examInf.ExamAccessionNum != "" && frmMainForm.examInf.ReqDateTime != "")
            {
                if (!Directory.Exists(Dir))
                    Directory.CreateDirectory(Dir);
                FileOperator ope = new FileOperator();
                string newFileName = ope.GetNewFileName(Dir, frmMainForm.examInf.ExamAccessionNum, ".jpg");
                string path = Dir + newFileName;
                FileOperator.SaveAsJPEG(image, path, GetConfig.IMS_Quality);
                ImgObj obj = this.AddImgObj(newFileName, path);
                if (obj != null)
                {
                    AddNewImage ani= new AddNewImage(RptAddImage);
                    this.p_RptImages.BeginInvoke(ani, new object[] { obj });
                }
            }
            this.l_Count.Text = "共 " + this.p_RptImages.Controls.Count.ToString() + " 张";
        }

        public void ReSetCheck()
        {
            for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
            {
                userCtrPictureEx u = (userCtrPictureEx)this.p_RptImages.Controls[i];
                u.Picture.SetCheck(false);
            }
        }


        private void RptAddImage(ImgObj obj)
        {
            this.p_RptImages.Controls.Add(this.AddImageCtl(obj, this.p_RptImages.Controls.Count + 1));
            this.l_Count.Text = "共 " + this.p_RptImages.Controls.Count.ToString() + " 张";
        }

        private ImgObj AddImgObj(string newFileName,string path)
        {
            SIS_Model.MImage Mimage = new SIS_Model.MImage();
            Mimage.EXAM_ACCESSION_NUM = frmMainForm.examInf.ExamAccessionNum;
            Mimage.IMAGE_PATH = GetConfig.ServerImgDir + "/" + frmMainForm.examInf.ReqDateTime + "/" + frmMainForm.examInf.ExamAccessionNum + "/" + newFileName;//linux上文件保存路径
            ImageCopy imgCopy = new ImageCopy();
            if (imgCopy.FileUpLoad(Mimage, path,false) != 1)
                return null;
            ImgObj imgObj = new ImgObj(path, false, Mimage);
            frmMainForm.examInf.ArrayImages.Add(imgObj);
            this.arrayImg.Add(imgObj);
            return imgObj;
        }

        public void Exit()
        {
            if (this.iViewer != null)
                this.iViewer.Dispose();
        }

        #region 加载与调整图像
        private void PreferImages_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
            this.isDockStateChanged = true;
        }

        public void LoadImages(List<ImgObj> array,bool isReLoad,bool ReadOnly)
        {
            this.arrayImg = array;
            this.ReadOnly = ReadOnly;
            this.p_RptImages.Controls.Clear();
            int width = this.p_RptImages.Width;
            List<Control> ctls = new List<Control>();
            for (int i = 0; i < array.Count; i++)
            {
                ImgObj obj = (ImgObj)array[i];
                if (!obj.IsDeleted)
                    ctls.Add(this.AddImageCtl(obj, i + 1));
            }
            for(int i=ctls.Count-1;i>=0;i--)
            {
                this.p_RptImages.Controls.Add(ctls[i]);
            }
            if (!isReLoad)
                arrayImgDel = new List<ImgObj>();
            this.l_Count.Text = "共 " + this.p_RptImages.Controls.Count.ToString() + " 张";
        }

        public void ReLoadImg(MWorkList MworkList)
        {
            ImageCopy imgCopy = new ImageCopy();
            MworkList.REPORT_STATUS = 1;
            this.arrayImg = imgCopy.LoadImages(MworkList, Dir);
            LoadImages(this.arrayImg, false,this.ReadOnly);
            //frmMainForm.examInf.
        }

        private Control AddImageCtl(ImgObj obj,int i)
        {
            userCtrPictureEx ctl = new userCtrPictureEx();
            ctl.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
            ctl.Picture.ImgObj = obj;
            ctl.Picture.SetCheckBoxReadOnly(this.ReadOnly);
            ctl.Picture.SetDoubleClick(true);
            ctl.Picture.SetCheck(obj.IsCheck);
            ctl.Picture.CheckChanged += new EventHandler(Picture_CheckChanged);
            ctl.Picture.MouseDoubleClick += new MouseEventHandler(Picture_MouseDoubleClick);
            ctl.Picture.MouseUp += new MouseEventHandler(Picture_MouseUp);
            ctl.Picture.MouseDown += new MouseEventHandler(Picture_MouseDown);
            if (obj.MarkImgPath == "")
                ctl.Picture.LoadFile(obj.ImagePath);
            else
            {
                ctl.Picture.LoadFile(obj.MarkImgPath);
                ctl.Picture.IsMark = true;
            }
            ctl.Picture.Inf = obj.Inf;
            ctl.Picture.LocMapPath = obj.LocMapPath;
            int height = this.p_RptImages.Height;
            int width = this.p_RptImages.Width;
            if (this.isDockTop)
            {
                if (ctl.Picture.ImageRatio != 0)
                    height = Convert.ToInt32(width / ctl.Picture.ImageRatio);
                ctl.Dock = DockStyle.Top;
            }
            else
            {
                if (ctl.Picture.ImageRatio != 0)
                    width = Convert.ToInt32(height * ctl.Picture.ImageRatio);
                ctl.Dock = DockStyle.Left;
            }
            if (GetConfig.IsAddLocMap)
            {
                string name = obj.ImagePath.Substring(obj.ImagePath.LastIndexOf("\\") + 1);
                if (ExitesMap(name))
                {
                    ctl.Picture.LocMapPath = Dir + "Map" + name;
                }
            }
            ctl.Size = new Size(width, height);
            ctl.l_Top.TextAlign = ContentAlignment.MiddleLeft;
            ctl.l_Top.BackColor = Color.LightGray;
            ctl.l_Top.ForeColor = Color.Blue;
            ctl.l_Top.Text = i.ToString();
            ctl.l_Buttom.Text = ctl.Picture.FileName;
            return ctl;
        }

        private bool ExitesMap(string name)
        {
            string[] names = System.IO.Directory.GetFiles(Dir, "Map" + name);
            if (names.Length > 0)
                return true;
            else
                return false;
        }

        private  void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (queryView != null)
                    queryView.Hide();
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (queryView == null)
                        queryView = new frmImgQuickView();
                    queryView.BackgroundImage = (Image)((userCtrPicture)sender).Image.Clone();
                    queryView.Show();
                }
            }
            catch
            {
            }
        }

        private  void Picture_CheckChanged(object sender, EventArgs e)
        {
            if (!this.ReadOnly)
                this.change((userCtrPicture)sender);
        }

        /*private void Picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            userCtrPicture s = (userCtrPicture)sender;
            userCtrPictureEx u = null;
            for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
            {
                u = (userCtrPictureEx)this.p_RptImages.Controls[i];
                if (u.Picture.FileName != s.FileName && u.Picture.IsSelected)
                {
                    u.Picture.IsSelected = false;
                    u.Picture.IsSelecting = true;
                    u.Picture.Refresh();
                    break;
                }
            }
            string[] ss = new string[1];
            ss[0] = s.FilePath;
            if (GetConfig.IsAddLocMap)
            {
                //if (this.frmLocMap == null || this.frmLocMap.IsDisposed)
                    this.frmLocMap = new frmLocMap(s,word);
                DialogResult dr = this.frmLocMap.ShowDialog();
               // if (dr == DialogResult.OK)
                    u.l_Buttom.Text= "";

 
            }
            else
            {
                Explorer();
                iViewer.SelectImg(s.FileName);
                //if (iViewer == null || iViewer.IsDisposed)
                //    iViewer = new ImageViewer();
                //iViewer.init(ss);
                iViewer.Show();
                iViewer.Activate();
            }
        }*/

        public void Explorer()
        {
            List<string> filePaths = new List<string>();
            for (int i = 0; i < arrayImg.Count; i++)
            {
                ImgObj obj = (ImgObj)arrayImg[i];
                if (!obj.IsDeleted)
                {
                    string ImagePath = obj.MarkImgPath != "" ? obj.MarkImgPath : obj.ImagePath;
                    filePaths.Add(ImagePath);
                }
            }
            if (iViewer == null || iViewer.IsDisposed)
                iViewer = new ImageViewer();
            iViewer.init(filePaths.ToArray());
            iViewer.Show();
            iViewer.Activate();
        }
        private void Picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            userCtrPicture s = (userCtrPicture)sender;
            for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
            {
                userCtrPictureEx u = (userCtrPictureEx)this.p_RptImages.Controls[i];
                if (u.Picture.FileName != s.FileName && u.Picture.IsSelected)
                {
                    u.Picture.IsSelected = false;
                    u.Picture.IsSelecting = true;
                    u.Picture.Refresh();
                }
            }
            string[] ss = new string[1];
            ss[0] = s.FilePath;
            if (GetConfig.IsAddLocMap)
            {
               // if (this.frmLocMap == null || this.frmLocMap.IsDisposed)
                    this.frmLocMap = new frmLocMap(s, word);
                    //this.frmLocMap.init();
                this.frmLocMap.ShowDialog();
                for (int j = 0; j < this.p_RptImages.Controls.Count; j++)
                {
                    userCtrPictureEx u = (userCtrPictureEx)this.p_RptImages.Controls[j];
                    if(s.Equals(u.Picture))
                    {
                        u.l_Buttom.Text = "";
                    }
                }
            }
            else
            {
                Explorer();
                iViewer.SelectImg(ss[0]);
              //  if (iViewer == null || iViewer.IsDisposed)
               //     iViewer = new ImageViewer();
               // iViewer.init(ss);
               // iViewer.Show();
               // iViewer.Activate();
            }
        }
        public List<ImgObj> SaveImgs(ref string ImgToPaxPaths)
        {
            ImgToPaxPaths = "";
            List<ImgObj> arraySaveImg = new List<ImgObj>();
            //string ImgToPaxPaths = "";
            arraySaveImg = arrayImgDel;
            for (int i = 0; i < p_RptImages.Controls.Count; i++)
            {
                userCtrPictureEx ctr = ((userCtrPictureEx)(p_RptImages.Controls[i]));
                
                ImgObj obj = (ImgObj)ctr.Picture.ImgObj;
                obj.IsCheck = ctr.Picture.GetCheck();
                arraySaveImg.Add(obj);
                if (GetConfig.SendCheckImage)
                {
                    if (obj.IsCheck)
                        ImgToPaxPaths += obj.ImagePath + ";";
                }
                else
                {
                    ImgToPaxPaths += obj.ImagePath + ";";
                }
               // ctr.Picture.Image.Save(@"D:\121.jpg");
                Image img = ctr.Picture.Image;
            }
            return arraySaveImg;
        }
        /// <summary>
        /// 切换打印模板时取得图片信息
        /// </summary>
        /// <returns></returns>
        public List<ImgObj> SaveImgs()
        {
            List<ImgObj> arraySaveImg = new List<ImgObj>();
            for (int i = 0; i < p_RptImages.Controls.Count; i++)
            {
                userCtrPictureEx ctr = ((userCtrPictureEx)(p_RptImages.Controls[i]));
                ImgObj obj = (ImgObj)ctr.Picture.ImgObj;
                obj.IsCheck = ctr.Picture.GetCheck();
                arraySaveImg.Add(obj);
            }
            return arraySaveImg;
        }

        private void PreferImages_SizeChanged(object sender, EventArgs e)
        {
            switch (this.DockState)
            {
                case BaseControls.Docking.DockState.DockBottom:
                    this.isDockTop = false;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockBottomAutoHide:
                    this.isDockTop = false;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockLeft:
                    this.isDockTop = true;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockLeftAutoHide:
                    this.isDockTop = true;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockRight:
                    this.isDockTop = true;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockRightAutoHide:
                    this.isDockTop = true;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockTop:
                    this.isDockTop = false;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.DockTopAutoHide:
                    this.isDockTop = false;
                    this.SetImages();
                    break;
                case BaseControls.Docking.DockState.Float:
                    this.isDockTop = true;
                    this.SetImages();
                    break;
            }
        }

        private void LoadThread()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(SetImages));
            thread.IsBackground = true;
            thread.Start();
        }

        private void SetImages()
        {
            bool isSetDock = false;
            if (isDockTop)
            {
                int width = this.p_RptImages.Width;
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    userCtrPictureEx ctl = (userCtrPictureEx)this.p_RptImages.Controls[i];
                    int height = Convert.ToInt32(width / ctl.Picture.ImageRatio);
                    ctl.Size = new Size(width, height);
                    if (isDockStateChanged)
                    {
                        ctl.Dock = DockStyle.Top;
                        isSetDock = true;
                    }
                }
            }
            else
            {
                int height = this.p_RptImages.Height;
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    userCtrPictureEx ctl = (userCtrPictureEx)this.p_RptImages.Controls[i];
                    int width = Convert.ToInt32(height * ctl.Picture.ImageRatio);
                    ctl.Size = new Size(width, height);
                    if (isDockStateChanged)
                    {
                        ctl.Dock = DockStyle.Left;
                        isSetDock = true;
                    }
                }
            }
            if (isSetDock)
                this.isDockStateChanged = false;
            this.p_RptImages.Refresh();
        }

        #endregion


        /// <summary>
        /// 导出选择图像到指定文件夹
        /// </summary>
        public void Export()
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_RptImages.Controls[i];
                    if (axf.Picture.IsSelecting)
                        System.IO.File.Copy(axf.Picture.FilePath, fd.SelectedPath + "\\" + axf.Picture.FileName, true);
                }
            }
        }

        /// <summary>
        /// 导出所有图像到指定文件夹
        /// </summary>
        public void ExportAll()
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_RptImages.Controls[i];
                    System.IO.File.Copy(axf.Picture.FilePath, fd.SelectedPath + "\\" + axf.Picture.FileName, true);
                }
            }
        }

        /// <summary>
        /// 删除图像
        /// </summary>
        /// <param name="DelAll">是否删除全部</param>
        public void DeleteImage(bool DelAll)
        {
            List<Control> delControl = new List<Control>();
            List<Control> printControl = new List<Control>();
            bool HadCheck = false;
            if (this.p_RptImages.Controls.Count > 0)
            {
                //提示
                int delImgCount = 0;
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_RptImages.Controls[i];
                    ImgObj imgobj = (ImgObj)axf.Picture.ImgObj;
                    if (axf.Picture.IsSelecting || axf.Picture.IsSelected || DelAll == true)
                    {
                        delImgCount++;
                    }
                }
                if (delImgCount >1)
                {
                    if (DialogResult.No == MessageBoxEx.Show("已选择"+delImgCount.ToString()+"幅图片，确定删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        return;
                    }
                }
                //提示
                for (int i = 0; i < this.p_RptImages.Controls.Count; i++)
                {
                    try
                    {
                        userCtrPictureEx axf = (userCtrPictureEx)this.p_RptImages.Controls[i];
                        ImgObj imgobj = (ImgObj)axf.Picture.ImgObj;
                        if (axf.Picture.IsSelecting || axf.Picture.IsSelected || DelAll == true)
                        {
                            if (!axf.Picture.GetCheck())
                            {
                                imgobj.IsDeleted = true;
                                delControl.Add(axf);
                                if (!this.arrayImgDel.Contains(imgobj))
                                    this.arrayImgDel.Add(imgobj);
                                this.arrayImg.RemoveAt(i);
                            }
                            else
                            {
                                printControl.Add(axf);
                                HadCheck = true;
                            }
                        }
                    }
                    catch { }
                }
            }
            for (int i = 0; i < delControl.Count; i++)
            {
                this.p_RptImages.Controls.Remove(delControl[i]);
            }
            if (HadCheck)
            {
                if (DialogResult.Yes == MessageBoxEx.Show("选择图像包含打印图像，是否删除？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    for (int i = 0; i < printControl.Count; i++)
                    {
                        userCtrPicture ctr = ((userCtrPictureEx)printControl[i]).Picture;
                        ImgObj imgobj = (ImgObj)ctr.ImgObj;
                        imgobj.IsDeleted = true;
                        if (!this.arrayImgDel.Contains(imgobj))
                            this.arrayImgDel.Add(imgobj);
                        this.arrayImg.Remove(imgobj);
                        if (ctr.LocMapPath == "")
                            word.DelImg(ctr.FilePath);
                        else
                            word.DelImgWithLocMap(ctr.FilePath, ctr.LocMapPath);
                        this.p_RptImages.Controls.Remove(printControl[i]);
                    }
                }
            }
            this.l_Count.Text = "共 " + this.p_RptImages.Controls.Count.ToString() + " 张";
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!this.ReadOnly)
            {
                switch (keyData)
                {
                    case Keys.Delete:
                        this.DeleteImage(false);
                        break;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void frmRptImages_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);
        }

    }
}