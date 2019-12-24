using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILL;
using SIS.Query;
using SIS_Function;
using BaseControls.PictureBoxs;
using System.Xml;
using System.IO;
using System.Collections;
namespace SIS
{
    public partial class frmBackImages : BaseControls.Docking.DockContent
    {
        private Panel panel;
        public delegate void DbClick(userCtrPicture ctl);
        public DbClick dbClick;
        private bool isDockStateChanged = false;
        private bool isDockTop = false;
        private string XmlPath = Application.StartupPath + "\\Config\\BackImgprocessed.xml";
        private XmlDocument xmlDoc;
        private string CurrentCtlName = "";
        private delegate void AddNewImage(string path,bool isMark);

        public frmBackImages(Panel panel)
        {
            InitializeComponent();
            this.panel = panel;
            CheckForIllegalCrossThreadCalls = false;
            xmlDoc = new XmlDocument();
        }

        public void AddBackImage(Image image)
        {
            FileOperator ope = new FileOperator();
            string newFileName = ope.GetNewBackFileName(GetConfig.Dynamic, System.DateTime.Now.ToString("yyyyMMdd"), ".jpg");
            string path = GetConfig.Dynamic + "\\" + newFileName;
            FileOperator.SaveAsJPEG(image, path, GetConfig.IMS_Quality);
            AddNewImage ani=new AddNewImage(BackAddImage);
            this.p_BackImags.BeginInvoke(ani, new object[] { path, false });
        }

        private void BackAddImage(string path, bool isMark)
        {
            this.p_BackImags.Controls.Add(this.AddImageCtl(path, false, this.p_BackImags.Controls.Count + 1));
            this.l_Count.Text = "共 " + this.p_BackImags.Controls.Count.ToString() + " 张";
        }

        public bool SaveMark(Image image,ref string name)
        {
            try
            {
                string oldName = name;
                if (!Directory.Exists(GetConfig.Dynamic))
                    Directory.CreateDirectory(GetConfig.Dynamic);
                if (!name.Contains("Mark"))
                    name = "Mark" + name;
                else
                    oldName = name.Replace("Mark", "");
                string newPath = GetConfig.Dynamic + "\\" + name;
                FileOperator.SaveAsJPEG(image, newPath, GetConfig.IMS_Quality);
                userCtrPictureEx u = (userCtrPictureEx)this.p_BackImags.Controls[oldName];
                u.Picture.LoadFile(newPath);
                u.Picture.IsMark = true;
                u.l_Buttom.Text = name;
                this.CurrentCtlName = u.Picture.FileName;
                this.dbClick(u.Picture);
                return true;
            }
            catch { return false; }
        }

        #region 加载与调整图像
        private void BackImages_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
            this.isDockStateChanged = true;
        }

        public void LoadImages()
        {
            if (!System.IO.Directory.Exists(GetConfig.Dynamic))
                System.IO.Directory.CreateDirectory(GetConfig.Dynamic);
            string[] imgs = System.IO.Directory.GetFiles(GetConfig.Dynamic, "*.jpg");
            this.p_BackImags.Controls.Clear();
            Control[] ctls = new Control[imgs.Length];
            for (int i = 0; i < imgs.Length; i++)
            {
                if (!imgs[i].ToString().Contains("Mark"))
                {
                    string fileName = imgs[i].ToString().Substring(imgs[i].LastIndexOf("\\") + 1);
                    if (ExitesMark(fileName))
                        ctls[i] = this.AddImageCtl(GetConfig.Dynamic + "\\Mark" + fileName, true,i);
                    else
                        ctls[i] = this.AddImageCtl(imgs[i].ToString(), false,i);
                }
            }
            for (int i = ctls.Length - 1; i >= 0; i--)
            {
                this.p_BackImags.Controls.Add(ctls[i]);
            }
            this.l_Count.Text = "共 " + this.p_BackImags.Controls.Count.ToString() + " 张";
        }

        private bool ExitesMark(string name)
        {
            string[] names = System.IO.Directory.GetFiles(GetConfig.Dynamic, "Mark" + name);
            if (names.Length > 0)
                return true;
            else
                return false;
        }

        private Control AddImageCtl(string Path,bool isMark,int i)
        {
            userCtrPictureEx ctl = new userCtrPictureEx();
            ctl.Picture.SetCheckBoxVisible(false);
            ctl.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
            ctl.Picture.MouseDoubleClick += new MouseEventHandler(Picture_MouseDoubleClick);
            ctl.Picture.LoadFile(Path);
            ctl.Picture.IsMark = isMark;
            int height = this.p_BackImags.Height;
            int width = this.p_BackImags.Width;
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
            ctl.Name = ctl.Picture.FileName.Replace("Mark","");
            ctl.Size = new Size(width, height);
            ctl.l_Top.TextAlign = ContentAlignment.MiddleLeft;
            ctl.l_Top.BackColor = Color.LightGray;
            ctl.l_Top.ForeColor = Color.Blue;
            ctl.l_Top.Text = i.ToString();
            ctl.l_Buttom.Text = ctl.Picture.FileName;
            return ctl;
        }

        private void Picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            userCtrPicture u = (userCtrPicture)sender;
            this.CurrentCtlName = u.FileName;
            this.dbClick(u);
        }

        private void BackImages_Load(object sender, EventArgs e)
        {
            this.LoadImages();
        }

        private void BackImages_SizeChanged(object sender, EventArgs e)
        {
            switch (this.DockState)
            {
                case BaseControls.Docking.DockState.DockBottom:
                    this.isDockTop = false;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockBottomAutoHide:
                    this.isDockTop = false;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockLeft:
                    this.isDockTop = true;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockLeftAutoHide:
                    this.isDockTop = true;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockRight:
                    this.isDockTop = true;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockRightAutoHide:
                    this.isDockTop = true;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockTop:
                    this.isDockTop = false;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.DockTopAutoHide:
                    this.isDockTop = false;
                    this.LoadThread();
                    break;
                case BaseControls.Docking.DockState.Float:
                    this.isDockTop = true;
                    this.LoadThread();
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
                    int width = this.p_BackImags.Width;
                    for (int i = 0; i < this.p_BackImags.Controls.Count; i++)
                    {
                        userCtrPictureEx ctl = (userCtrPictureEx)this.p_BackImags.Controls[i];
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
                    int height = this.p_BackImags.Height;
                    for (int i = 0; i < this.p_BackImags.Controls.Count; i++)
                    {
                        userCtrPictureEx ctl = (userCtrPictureEx)this.p_BackImags.Controls[i];
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
            //this.p_BackImags.Refresh();
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
                for (int i = 0; i < this.p_BackImags.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_BackImags.Controls[i];
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
                for (int i = 0; i < this.p_BackImags.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_BackImags.Controls[i];
                    System.IO.File.Copy(axf.Picture.FilePath, fd.SelectedPath + "\\" + axf.Picture.FileName, true);
                }
            }
        }

        /// <summary>
        /// 删除选择图像
        /// </summary>
        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            if (this.p_BackImags.Controls.Count > 0)
            {

                // List<string> arrayDelete = new List<string>();
                //List<int> arrayDeleteCtl = new List<int>();
                ArrayList arraydel = new ArrayList();
                for (int i = 0; i < this.p_BackImags.Controls.Count; i++)
                {
                    userCtrPictureEx axf = (userCtrPictureEx)this.p_BackImags.Controls[i];
                    if (axf.Picture.IsSelecting)
                    {
                        arraydel.Add(axf);
                        //arrayDelete.Add(axf.Picture.FilePath);
                        //arrayDeleteCtl.Add(i);
                    }
                }
                if (arraydel.Count > 0)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("是否删除所选择图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        xmlDoc.Load(XmlPath);
                        XmlNode root = xmlDoc.DocumentElement;
                        for (int i = 0; i < arraydel.Count; i++)
                        {
                            userCtrPictureEx axf = (userCtrPictureEx)arraydel[i];
                            System.IO.File.Delete(axf.Picture.FilePath);
                            this.p_BackImags.Controls.Remove(axf);
                            //System.IO.File.Delete(arrayDelete[i]);
                            //this.p_BackImags.Controls.RemoveAt(arrayDeleteCtl[i]);
                            XmlNode node = xmlDoc.SelectSingleNode("PatientBackImage/Image[@Name='" + axf.Picture.FilePath + "'] ");
                            if (node != null)
                                root.RemoveChild(node);
                            if (axf.Picture.FilePath == this.CurrentCtlName)
                                this.dbClick(null);
                        }
                        xmlDoc.Save(XmlPath);
                    }
                }
            }
            this.l_Count.Text = "共 " + this.p_BackImags.Controls.Count.ToString() + " 张";
        }


        /// <summary>
        /// 删除所有图像
        /// </summary>
        private void tsmi_DeleteAll_Click(object sender, EventArgs e)
        {
            if (this.p_BackImags.Controls.Count > 0)
            {
                if (DialogResult.OK == MessageBoxEx.Show("是否删除所有后台图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    xmlDoc.Load(XmlPath);
                    XmlNode root = xmlDoc.DocumentElement;
                    if (System.IO.Directory.Exists(GetConfig.Dynamic))
                        System.IO.Directory.Delete(GetConfig.Dynamic, true);
                    System.IO.Directory.CreateDirectory(GetConfig.Dynamic);
                    this.p_BackImags.Controls.Clear();
                    if (root.HasChildNodes)
                        root.RemoveAll();
                    xmlDoc.Save(XmlPath);
                    this.dbClick(null);
                }
            }
            this.l_Count.Text = "共 " + this.p_BackImags.Controls.Count.ToString() + " 张";
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    this.tsmi_Delete_Click(null, null);
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}