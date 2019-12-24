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
using SIS_Model;

namespace SIS
{
    public partial class frmPreferImages : BaseControls.Docking.DockContent
    {
        private Panel panel;
        public delegate void DbClick(userCtrPicture ctl);
        public DbClick dbClick;
        private bool isDockStateChanged = false;
        private bool isDockTop = false;
        private string Dir = Application.StartupPath + "\\ReportCache";
        private string CurrentCtlName = "";
        private delegate void AddNewImage(string newFileName, string newPath);

        public frmPreferImages(Panel panel)
        {
            InitializeComponent();
            this.panel = panel;
            CheckForIllegalCrossThreadCalls = false;

        }

        public void AddPreferImage(Image image)
        {
            if (frmMainForm.examInf.ExamAccessionNum != "" && frmMainForm.examInf.ReqDateTime != "")
            {

                if (!Directory.Exists(Dir))
                    Directory.CreateDirectory(Dir);
                FileOperator ope = new FileOperator();
                string newFileName = ope.GetNewFileName(Dir, frmMainForm.examInf.ExamAccessionNum, ".jpg");
                string newPath = Dir + "\\" + newFileName;
                FileOperator.SaveAsJPEG(image, newPath, GetConfig.IMS_Quality);
                AddNewImage ani = new AddNewImage(PreferAddImage);
                this.p_PreferImages.BeginInvoke(ani, new object[] { newFileName, newPath });

            }
        }

        private void PreferAddImage(string newFileName, string newPath)
        {
            ImgObj obj = this.AddImgObj(newFileName, newPath);
            if (obj != null)
                this.p_PreferImages.Controls.Add(this.AddImageCtl(obj, this.p_PreferImages.Controls.Count + 1));
            this.l_Count.Text = "共 " + this.p_PreferImages.Controls.Count.ToString() + " 张";
        }


        private ImgObj AddImgObj(string newFileName,string path)
        {
            MImage Mimage = new MImage();
            Mimage.EXAM_ACCESSION_NUM = frmMainForm.examInf.ExamAccessionNum;
            Mimage.IMAGE_PATH = GetConfig.ServerImgDir + "/" + frmMainForm.examInf.ReqDateTime + "/" + frmMainForm.examInf.ExamAccessionNum + "/" + newFileName;//linux上文件保存路径
            Mimage.IMAGE_DATE = System.DateTime.Now;
            ImageCopy imgCopy = new ImageCopy();
            if (imgCopy.FileUpLoad(Mimage, path,false) != 1)
                return null;
            ImgObj imgObj = new ImgObj(path, false, Mimage);
            frmMainForm.examInf.ArrayImages.Add(imgObj);
            return imgObj;
        }
        //定位图时刷新图片名
        public void ReflashName(string name)
        {
            if (GetConfig.IsAddLocMap)
            {
                try
                {
                    string CName = name;
                    if (name.Contains("Mark"))
                    {
                        CName = name.Replace("Mark", "");
                    }
                    userCtrPictureEx u = (userCtrPictureEx)this.p_PreferImages.Controls[CName];
                    u.l_Buttom.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        /// <summary>
        /// 保存图像处理后的效果
        /// </summary>
        /// <param name="image">新图像</param>
        /// <param name="Obj">图像数据库对象</param>
        /// <param name="xml">处理信息</param>
        /// <param name="name">旧图像名</param>
        /// <returns>是否保存成功</returns>
        public bool SaveMark(Image image, ImgObj Obj, string xml,ref string name)
        {
            if (!Directory.Exists(Dir))
                Directory.CreateDirectory(Dir);
            MImage img = (MImage)Obj.MImage;
            if (xml == "" && name.Contains("Mark"))
            {
                img.MARK_IMAGE_PATH = "";
                img.MARK_INF = "";
                SIS_BLL.BImage bi = new SIS_BLL.BImage();
                if (bi.Update(img, " where IMAGE_ID = " + img.IMAGE_ID) < 0)
                    return false;
                else
                {
                    Obj.MarkImgPath = "";
                    Obj.MarkInf = "";
                    name = name.Replace("Mark", "");
                    string newpath = Dir + "\\" + name;
                    userCtrPictureEx u = (userCtrPictureEx)this.p_PreferImages.Controls[name];
                    u.Picture.LoadFile(newpath);
                    u.Picture.IsMark = false;
                    u.l_Buttom.Text = name;
                    this.CurrentCtlName = u.Picture.FileName;
                    this.dbClick(u.Picture);
                    return true;
                }
            }
            else
            {
                string newPath ="";
                string oldName = name;
                if (xml != "" && !name.Contains("Mark"))
                {
                    name = "Mark" + name;
                    newPath = Dir + "\\" + name;
                    img.MARK_IMAGE_PATH = GetConfig.ServerImgDir + "/" + frmMainForm.examInf.ReqDateTime + "/" + frmMainForm.examInf.ExamAccessionNum + "/" + name;
                }
                else
                {
                    newPath = Obj.MarkImgPath;
                    oldName = name.Replace("Mark", "");
                }
                image.Save(newPath);
                img.MARK_INF = xml;
                ImageCopy imgCopy = new ImageCopy();
                if (imgCopy.FileUpLoad(img, newPath, true) != 1)
                    return false;
                else
                {
                    Obj.MarkImgPath = newPath;
                    Obj.MarkInf = xml;
                    userCtrPictureEx u = (userCtrPictureEx)this.p_PreferImages.Controls[oldName];
                    u.Picture.LoadFile(newPath);
                    u.Picture.IsMark = true;
                    u.l_Buttom.Text = name;
                    this.CurrentCtlName = u.Picture.FileName;
                    this.dbClick(u.Picture);
                    return true;
                }
            }
        }

        #region 加载与调整图像
        private void PreferImages_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
            this.isDockStateChanged = true;
        }

        public void LoadImages()
        {
            this.p_PreferImages.Controls.Clear();
            if (frmMainForm.examInf.ExamAccessionNum != "" && frmMainForm.examInf.ArrayImages.Count > 0)
            {
                int width = this.p_PreferImages.Width;
                Control[] ctls = new Control[frmMainForm.examInf.ArrayImages.Count];
                for (int i = 0; i < frmMainForm.examInf.ArrayImages.Count; i++)
                {
                    ImgObj obj = (ImgObj)frmMainForm.examInf.ArrayImages[i];
                    ctls[i] = this.AddImageCtl(obj,i);
                }
                for (int i = ctls.Length - 1; i >= 0; i--)
                {
                    this.p_PreferImages.Controls.Add(ctls[i]);
                }
            }
            this.l_Count.Text = "共 " + this.p_PreferImages.Controls.Count.ToString() + " 张";
        }

        private Control AddImageCtl(ImgObj obj,int i)
        {
            userCtrPictureEx ctl = new userCtrPictureEx();
            ctl.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
            ctl.Picture.MouseDoubleClick += new MouseEventHandler(Picture_MouseDoubleClick);
            ctl.Picture.SetCheck(obj.IsCheck);
            ctl.Picture.ImgObj = obj;
            if (obj.MarkImgPath == "")
                ctl.Picture.LoadFile(obj.ImagePath);
            else
            {
                ctl.Picture.LoadFile(obj.MarkImgPath);
                ctl.Picture.IsMark = true;
            }
            int height = this.p_PreferImages.Height;
            int width = this.p_PreferImages.Width;
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
            ctl.Name = ctl.Picture.FileName.Replace("Mark", "");
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

        private void Picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            userCtrPicture u = (userCtrPicture)sender;
            this.CurrentCtlName = u.FileName;
            this.dbClick(u);
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
            try
            {
                if (isDockTop)
                {
                    int width = this.p_PreferImages.Width;
                    for (int i = 0; i < this.p_PreferImages.Controls.Count; i++)
                    {
                        userCtrPictureEx ctl = (userCtrPictureEx)this.p_PreferImages.Controls[i];
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
                    int height = this.p_PreferImages.Height;
                    for (int i = 0; i < this.p_PreferImages.Controls.Count; i++)
                    {
                        userCtrPictureEx ctl = (userCtrPictureEx)this.p_PreferImages.Controls[i];
                        int width = Convert.ToInt32(height * ctl.Picture.ImageRatio);
                        ctl.Size = new Size(width, height);
                        if (isDockStateChanged)
                        {
                            ctl.Dock = DockStyle.Left;
                            isSetDock = true;
                        }
                    }
                }
            }
            catch { }
            if (isSetDock)
                this.isDockStateChanged = false;
            //this.p_PreferImages.Refresh();
        }

        #endregion

        #region 右键菜单按钮
        /// <summary>
        /// 刷新后台图像列表
        /// </summary>
        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            this.LoadImages();
        }

        /// <summary>
        /// 导出选择图像到指定文件夹
        /// </summary>
        private void tsmi_Export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < this.p_PreferImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_PreferImages.Controls[i];
                    if (axf.Picture.IsSelecting)
                        System.IO.File.Copy(axf.Picture.FilePath, fd.SelectedPath + "\\" + axf.Picture.FileName, true);
                }
            }
        }

        /// <summary>
        /// 导出所有图像到指定文件夹
        /// </summary>
        private void tsmi_ExportAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < this.p_PreferImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_PreferImages.Controls[i];
                    System.IO.File.Copy(axf.Picture.FilePath, fd.SelectedPath + "\\" + axf.Picture.FileName, true);
                }
            }
        }

        private void DeleteImg(bool isAll)
        {
            if (this.p_PreferImages.Controls.Count > 0)
            {
                List<userCtrPictureEx> arrayDelCheckCtl = new List<userCtrPictureEx>();
                List<userCtrPictureEx> arrayDelCtl = new List<userCtrPictureEx>();
                for (int i = 0; i < this.p_PreferImages.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_PreferImages.Controls[i];
                    if (isAll)
                    {
                        arrayDelCtl.Add(axf);
                        continue;
                    }
                    if (axf.Picture.IsSelecting)
                    {
                        if (axf.Picture.GetCheck())
                            arrayDelCheckCtl.Add(axf);
                        else
                            arrayDelCtl.Add(axf);
                    }
                }
                if (!isAll && arrayDelCtl.Count == 0 && arrayDelCheckCtl.Count == 0)
                    return;
                DialogResult dr;
                if (arrayDelCheckCtl.Count > 0)
                {
                    if (!isAll)
                        dr = MessageBoxEx.Show("选择图像包含打印图像，打印图像不能删除，是否删除其它所选择图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    else
                        dr = MessageBoxEx.Show("该检查包含打印图像，打印图像不能删除，是否删除所有没打印图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!isAll)
                        dr = MessageBoxEx.Show("是否删除所选择图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    else
                        dr = MessageBoxEx.Show("是否删除该检查所有图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                if (dr == DialogResult.OK)
                {
                    ImageCopy imgCopy = new ImageCopy();
                    if (isAll)
                    {
                        for (int i = 0; i < arrayDelCtl.Count; i++)
                        {
                            System.IO.File.Delete(arrayDelCtl[i].Picture.FilePath);
                            ImgObj obj = (ImgObj)arrayDelCtl[i].Picture.ImgObj;
                            imgCopy.DeleteImg((SIS_Model.MImage)obj.MImage);
                        }
                        this.p_PreferImages.Controls.Clear();
                        this.dbClick(null);
                        frmMainForm.examInf.ArrayImages.Clear();
                    }
                    else
                    {
                        for (int i = 0; i < arrayDelCtl.Count; i++)
                        {
                            System.IO.File.Delete(arrayDelCtl[i].Picture.FilePath);
                            this.p_PreferImages.Controls.Remove(arrayDelCtl[i]);
                            ImgObj obj = (ImgObj)arrayDelCtl[i].Picture.ImgObj;
                            imgCopy.DeleteImg((SIS_Model.MImage)obj.MImage);
                            frmMainForm.examInf.ArrayImages.Remove(obj);
                            if (obj.ImagePath.Substring(obj.ImagePath.LastIndexOf("\\") + 1) == this.CurrentCtlName)
                                this.dbClick(null);
                        }
                    }
                }
            }
            this.l_Count.Text = "共 " + this.p_PreferImages.Controls.Count.ToString() + " 张";
        }

        /// <summary>
        /// 删除选择图像
        /// </summary>
        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            this.DeleteImg(false);
        }

        /// <summary>
        /// 删除所有图像
        /// </summary>
        private void tsmi_DeleteAll_Click(object sender, EventArgs e)
        {
            this.DeleteImg(true);
        }
        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    this.DeleteImg(false);
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}