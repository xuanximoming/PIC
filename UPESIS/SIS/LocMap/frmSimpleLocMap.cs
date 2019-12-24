using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseControls.PictureBoxs;
using SIS.ImgProcess;
using SIS_Model;
using SIS_BLL;
using SIS.Function;
using System.IO;
using SIS_Function;
using ILL;

namespace SIS
{
    public partial class frmSimpleLocMap : BaseControls.Docking.DockContent
    {
        private string LocalMapsDir = Application.StartupPath + "\\LocMaps\\";
        private string path = Application.StartupPath + "\\ReportCache\\";
        private string LocalMapName = "";
        private MImage mImage;
        private MLocationMap mLocMap;
        private SaveImageToXml save;
        private ReadImageFromXML read;
        private userCtrPicture CurrentCtl;
        private Panel p;

        public frmSimpleLocMap(Panel p)
        {
            InitializeComponent();
            save = new SaveImageToXml();
            this.p = p;
            read = new ReadImageFromXML();
            this.drawArea.Initialize();
            if (this.cmb_TagImage.SelectedIndex == -1)
                this.cmb_TagImage.SelectedIndex = 0;
        }

        public void Get(userCtrPicture ctl)
        {
            this.drawArea.Initialize();
            CurrentCtl = ctl;
            this.mImage = (MImage)((ImgObj)ctl.ImgObj).MImage;
            this.mLocMap = (MLocationMap)((ImgObj)ctl.ImgObj).MLocationMap;
            if (this.mLocMap != null && this.mLocMap.MAP_NAME != null && this.mLocMap.MAP_NAME != "")
            {
                this.SetLocMap(this.mLocMap.MAP_NAME);
                CtlComboBox.SetDisplay(this.mLocMap.MAP_PART, this.cmb_Part);
                this.BindExplain(this.mLocMap.MAP_NAME, this.mLocMap.MAP_PART);
                CtlComboBox.SetDisplay(this.mLocMap.MAP_EXPLAIN, this.cmb_Explain);
                if (this.mLocMap.MARK_INF != null && this.mLocMap.MARK_INF != "")
                    read.SetPoint(this.drawArea, this.mLocMap.MARK_INF);
                else
                    drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Point;
            }
            else
            {
                this.cmb_Part.Text = "";
                this.cmb_Explain.Text = "";
                drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Point;
            }
            if (this.cmb_TagImage.SelectedIndex == -1)
                this.cmb_TagImage.SelectedIndex = 0;
        }

        public void init()
        {
            BindLocalMap(frmMainForm.examInf.ExamClass, frmMainForm.examInf.ExamSubClass);
        }
        private void initPartAndExplain(string LocMapName)
        {
            BindPart(LocMapName);
            BindExplain(LocMapName, "");
        }
        #region 数据绑定
        /// <summary>
        /// 绑定定位图
        /// </summary>
        public void BindLocalMap(string ExamClass, string ExamSubClass)
        {
            BExamClass bExamClass = new BExamClass();
            System.Data.DataTable dt = bExamClass.GetList(" EXAM_CLASS = '" + ExamClass + "' and EXAM_SUB_CLASS ='" + ExamSubClass + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                LocalMapName = dt.Rows[0]["TAG_IMAGE_NAME"].ToString();
                if (LocalMapName != "")
                {
                    this.SetLocMap(LocalMapName);
                }
            }
        }

        private void SetLocMap(string LocalMapName)
        {
            FileOperator fileOpe = new FileOperator();
            this.drawArea.Image = fileOpe.GetImageFromFile(LocalMapsDir + LocalMapName);
            this.BindPart(LocalMapName);
            switch (LocalMapName)
            {
                case "stomach.bmp":
                    this.cmb_TagImage.SelectedIndex = 0;
                    break;
                case "colon.bmp":
                    this.cmb_TagImage.SelectedIndex = 1;
                    break;
                case "bronchus.bmp":
                    this.cmb_TagImage.SelectedIndex = 2;
                    break;
                case "laryngoscope.bmp":
                    this.cmb_TagImage.SelectedIndex = 3;
                    break;
                case "ureter.bmp":
                    this.cmb_TagImage.SelectedIndex = 4;
                    break;
                default:
                    break;
            }
        }

        private void BindPart(string LocalMapName)
        {
            BLocationMapInf bInf = new BLocationMapInf();
            System.Data.DataTable dt = bInf.GetList(" MAP_FILENAME = '" + LocalMapName + "' and MAP_PART is not null");
            this.cmb_Part.DataSource = dt;
            this.cmb_Part.DisplayMember = "MAP_PART";
        }

        private void BindExplain(string LocalMapName, string MapPart)
        {
            BLocationMapInf bInf = new BLocationMapInf();
            // System.Data.DataTable dt = bInf.GetList(" MAP_FILENAME = '" + LocalMapName + "' and MAP_PART = '" + MapPart + "'");
            System.Data.DataTable dt = bInf.GetList(" MAP_FILENAME = '" + LocalMapName + "' and MAP_EXPLAIN is not null");
            this.cmb_Explain.DataSource = dt;
            this.cmb_Explain.DisplayMember = "MAP_EXPLAIN";
        }
        #endregion

        /// <summary>
        /// 切换定位图
        /// </summary>
        private void cmb_TagImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileOperator fileOpe = new FileOperator();
            LocalMapName = "";
            switch (this.cmb_TagImage.SelectedIndex)
            {
                case 0:
                    LocalMapName = "stomach.bmp";
                    break;
                case 1:
                    LocalMapName = "colon.bmp";
                    break;
                case 2:
                    LocalMapName = "bronchus.bmp";
                    break;
                case 3:
                    LocalMapName = "laryngoscope.bmp";
                    break;
                case 4:
                    LocalMapName = "ureter.bmp";
                    break;
                default:
                    break;
            }
            this.drawArea.Image = fileOpe.GetImageFromFile(LocalMapsDir + LocalMapName);
            initPartAndExplain(LocalMapName);
        }

        private void cmb_Part_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.BindExplain(this.LocalMapName, this.cmb_Part.Text.Trim());
        }

        public void Save()
        {
            if (this.mImage == null)
                return;
            Bitmap b = null, bt = null, btp = null;
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                FileOperator ope = new FileOperator();
                string newFileName = "Map" + this.CurrentCtl.FileName.Replace("Mark", "");
                string Newpath = path + newFileName;
                b = ImageOpe.FromGraphics((Control)drawArea, drawArea.Width - 2, drawArea.Height - 2);
                bt = ImageOpe.KiResizeImage(b, 2 * GetConfig.RS_LocMapWidth, 2 * GetConfig.RS_LocMapHeight, 0);
                btp = DrawString(bt, this.cmb_Part.Text.Trim(), this.cmb_Explain.Text.Trim());
                btp.Save(Newpath);
                if (this.mLocMap == null)
                {
                    this.mLocMap = new MLocationMap();
                    mLocMap.MAP_ID = this.mImage.IMAGE_ID;
                    mLocMap.EXAM_ACCESSION_NUM = this.mImage.EXAM_ACCESSION_NUM;
                }
                mLocMap.MAP_PART = this.cmb_Part.Text.Trim();
                mLocMap.MAP_EXPLAIN = this.cmb_Explain.Text.Trim();
                mLocMap.MAP_TIME = System.DateTime.Now;
                mLocMap.MARK_INF = save.SavePoint(this.drawArea);
                mLocMap.MAP_NAME = LocalMapName;
                mLocMap.MAP_PATH = this.mImage.IMAGE_PATH.Substring(0, this.mImage.IMAGE_PATH.LastIndexOf("/") + 1) + newFileName;
                CurrentCtl.LocMapPath = Newpath;
                int i = 0;
                ImageCopy ic = new ImageCopy();
                i = ic.FileUpLoad(mLocMap, Newpath);
                if (i < 0)
                    MessageBoxEx.Show("保存失败！", "警告");
                else
                    ((ImgObj)CurrentCtl.ImgObj).MLocationMap = mLocMap;
            }
            catch { MessageBoxEx.Show("保存失败！", "警告"); }
            finally
            {
                b.Dispose();
                bt.Dispose();
                btp.Dispose();
            }
        }

        private Bitmap DrawString(Bitmap b,string part,string inf)
        {
            Graphics g = Graphics.FromImage(b);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point);
            g.DrawString(part + Environment.NewLine + inf, drawFont, drawBrush, 0, 0);
            return b;
        }

        private void frmSimpleLocMap_DockStateChanged(object sender, EventArgs e)
        {
            p.BringToFront();
        }

    }
}