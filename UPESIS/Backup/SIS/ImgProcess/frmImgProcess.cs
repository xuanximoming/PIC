using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.DrawTools;
using BaseControls.ImageBox.DrawTools.DocToolkit;
using BaseControls.ImageBox;
using SIS.ImgProcess.filters;
using BaseControls.ImageTool;
using SIS.ImgProcess.ImageZoom;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using SIS.ImgProcess;
using SIS_Model;
using BaseControls.Docking;
using ILL;
using SIS_Function;
using BaseControls.ImageBox.Imaging.Textures;


namespace SIS
{
    public partial class frmImgProcess : Form
    {
        static public frmImgProcess imgProcess;

        public Bitmap sourceImage;
        private frmBackImages backImages;
        private frmPreferImages preferImages;
        private frmSimpleLocMap frmSLocMap;
        private Bitmap filteredImage;
        //private Rotate rotate;
        //private SIS.ImgProcess.ImageZoom.Zoom zoom;
        private UserControl ToolControl = new UserControl();
        //private int FilterMode = -1;
        private SaveImageToXml SaveImageToXml;
        private DeserializeDockContent m_deserializeDockContent;
        private ImgObj CurrentObj;
        private bool IsBack = false;
        private TexturedFilter filter;
        private Texturer f;
        private string flag = "";
        private IFilter iFilter;
        private HueModifier huemodifierFilter;
        private SaturationCorrection saturationcorrFilter;
        private BrightnessCorrection brightnesscorr;
        private ContrastCorrection contrastCorr;
        private string xml = "";


        public frmImgProcess()
        {
            InitializeComponent();
            imgProcess = this;
            this.drawArea.Initialize();
            SaveImageToXml = new SaveImageToXml();
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            string configFile = Application.StartupPath + "\\Config\\ImgProDockPanel.config";
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            else
            {
                backImages = new frmBackImages(this.p_Main);
                preferImages = new frmPreferImages(this.p_Main);
                backImages.dbClick = new frmBackImages.DbClick(BackPtbDbClick);
                preferImages.dbClick = new frmPreferImages.DbClick(PreferPtbDbClick);
                backImages.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                preferImages.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                if (GetConfig.IsAddLocMap)
                {
                    frmSLocMap = new frmSimpleLocMap(this.p_Main);
                    frmSLocMap.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                }
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            switch (persistString)
            {
                case "SIS.frmBackImages":
                    backImages = new frmBackImages(this.p_Main);
                    backImages.dbClick = new frmBackImages.DbClick(BackPtbDbClick);
                    return backImages;
                case "SIS.frmPreferImages":
                    preferImages = new frmPreferImages(this.p_Main);
                    preferImages.dbClick = new frmPreferImages.DbClick(PreferPtbDbClick);
                    return preferImages;
                case "SIS.frmSimpleLocMap":
                    frmSLocMap = new frmSimpleLocMap(this.p_Main);
                    return frmSLocMap;
                default:
                    return null;
            }
        }

        private void BackPtbDbClick(BaseControls.PictureBoxs.userCtrPicture ctl)
        {
            InitTools();
            if (ctl != null)
            {
                IsBack = true;
                GetPtbImage(ctl);
            }
            else
                ClearPtbImage();
            if (GetConfig.IsAddLocMap)
                MarkLine();
        }

        private void PreferPtbDbClick(BaseControls.PictureBoxs.userCtrPicture ctl)
        {
            InitTools();
            if (ctl != null)
            {
                IsBack = false;
                GetPtbImage(ctl);
                
            }
            else
                ClearPtbImage();

            if (GetConfig.IsAddLocMap)
                MarkLine();
        }

        private void GetPtbImage(BaseControls.PictureBoxs.userCtrPicture ctl)
        {
            this.CurrentObj = (ImgObj)ctl.ImgObj;
            this.drawArea.ImageLocation = ctl.FilePath;
            this.lb_ImageName.Text = ctl.FileName;
            this.drawArea.GraphicsList.Clear();
            this.drawArea.Controls.Clear();
            this.drawArea.Initialize();
            FileStream fs = new FileStream(this.drawArea.ImageLocation, FileMode.Open);
            try
            {
                this.sourceImage = new Bitmap(fs);
                this.filteredImage = (Bitmap)this.sourceImage.Clone();
            }
            catch { }
            finally {fs.Dispose();}
            this.drawArea.Left = (this.p_Picture.Width - this.sourceImage.Width) / 2;
            this.drawArea.Top = (this.p_Picture.Height - this.sourceImage.Height) / 2;
            if (!this.IsBack&&GetConfig.IsAddLocMap&&this.frmSLocMap != null)
            {
                this.frmSLocMap.Get(ctl);
            }
            this.InitLocationSize();
        }

        private void ClearPtbImage()
        {
            this.CurrentObj = null;
            this.drawArea.Image = null;
            this.lb_ImageName.Text = "";
            this.drawArea.GraphicsList.Clear();
            this.drawArea.Controls.Clear();
            this.drawArea.Initialize();
            this.sourceImage = null;
            this.filteredImage = null;
            this.xml = "";
        }

        private void ImgProcess_Load(object sender, EventArgs e)
        {
        }

        public void ApplyFilter(IFilter filter)
        {
            this.drawArea.Image = filter.Apply(this.sourceImage); 
        }

        public Bitmap ApplyFilter(IFilter filter,Bitmap b)
        {
            Bitmap bt = filter.Apply(b);
            return bt;
        }

        private void PseudoColor(int flag)
        {
            Bitmap ss=null;
            switch(flag)
            {
                case 1: ss = ImgDispose.PseudoColor1(this.drawArea.Image as Bitmap); break;
                case 2: ss = ImgDispose.PseudoColor2(this.drawArea.Image as Bitmap); break;
                case 3: ss = ImgDispose.PseudoColor3(this.drawArea.Image as Bitmap); break;
            }
            this.drawArea.Image = ss;
            this.drawArea.Refresh();
        }

        public void SetToolControlDisplay(string FormName, string FormPlace)
        {
          
            for (int K = 0; K < this.Controls.Count; K++)
            {
                if (((Control)this.Controls[K]).Name.ToString() == FormName)
                {
                    ToolControl = (UserControl)(Control)this.Controls[K];
                    ToolControl.Visible = true;
                    //ToolControl.Tag = filteredImage;
                    return;
                }
            }
            ToolControl = (UserControl)Activator.CreateInstance(Type.GetType(FormPlace));    //否则创建 
            ToolControl.Parent = this;
            ToolControl.Location = new Point(MousePosition.X - ToolControl.Width - 20, MousePosition.Y - 90);
            //ToolControl.Tag = filteredImage;
            ToolControl.BringToFront();
            ToolControl.Show();
           
        }
         
        private void MarkText()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Text;
        }

        private void MarkLine()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Line;
        }

        private void MarkRectangle()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Rectangle;
        }

        private void MarkPoint()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Point;
        }

        private void btn_MarkEllipse_Click(object sender, EventArgs e)
        {
            MarkEllipse();
        }

        private void MarkEllipse()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Ellipse;
        }

        private void MarkPolygon()
        {
            drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Polygon;
        }
        private void rb_Gray_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new GrayscaleBT709();
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "GrayscaleBT709", iFilter);
        }

        private void rb_PseudoColor_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            SetToolControlDisplay("Pseudocolor", "SIS.ImgProcess.filters.Pseudocolor");
        }

        private void rb_Soft_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new GaussianBlur();
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "Gaussian", iFilter);
        }

        private void rb_Sharpen_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Sharpen();
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "Sharpen", iFilter);
        }

        private void rb_Border_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new DifferenceEdgeDetector();
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "DifferenceEdgeDetector", iFilter);

        }

        private void rb_Mean_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Mean();
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "Mean", iFilter);
        }

        private void rb_Mirror_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            drawArea.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.drawArea.Refresh();
            SaveImageToXml.SaveImgProcess(drawArea, this.lb_ImageName.Text, "RotateFlip", null);
        }
        //截图
        private void rb_ScreenShot_Click(object sender, EventArgs e)
        {
            CaptureImageTool capture = new CaptureImageTool();
            capture.ShowDialog();
        }
        //旋转
        private void rb_Rotate_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            SetToolControlDisplay("Rotate", "SIS.ImgProcess.filters.Rotate");
        }

        //移动
        private void rb_Move_Click(object sender, EventArgs e)
        {

        }

        //过滤
        private void rb_Filter_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            SetToolControlDisplay("Filter", "SIS.ImgProcess.filters.Filter");
        }

        //缩放
        private void rb_ZoomInAndOut_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            SetToolControlDisplay("Zoom", "SIS.ImgProcess.ImageZoom.Zoom");
        }

        //放大镜
        private void rb_MagicWand_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pr = new System.Diagnostics.Process();
            pr.StartInfo.FileName = Application.StartupPath + "//SuperMag//SuperMag.exe";
            pr.Start();
        }

        //文字
        private void rb_MarkText_Click(object sender, EventArgs e)
        {
            MarkText();
        }

        //线
        private void rb_MarkLine_Click(object sender, EventArgs e)
        {
            MarkLine();
        }

        //连接线
        private void rb_MarkPolygon_Click(object sender, EventArgs e)
        {
            MarkPolygon();
        }
        
        //点
        private void rb_MarkPoint_Click(object sender, EventArgs e)
        {
            MarkPoint();
        }

        //椭圆
        private void rb_MarkEllipse_Click(object sender, EventArgs e)
        {
            MarkEllipse();
        }

        //矩形
        private void rb_MarkRectangle_Click(object sender, EventArgs e)
        {
            MarkRectangle();
        }
 
        //删除
        private void rb_LoadIn_Click(object sender, EventArgs e)
        {
            ReadImageFromXML ReadBackImageXml = new ReadImageFromXML(this.lb_ImageName.Text);
            ReadBackImageXml.GetImageProcess();
        }

        //保存
        private void rb_Save_Click(object sender, EventArgs e)
        {
            this.drawArea.Focus();
            if (this.drawArea.GraphicsList.Count > 0)
            {
                this.drawArea.GraphicsList.UnselectAll();
                this.drawArea.Refresh();
            }
            if (this.drawArea.Image == null || this.lb_ImageName.Text == "")
                return;
            if (!this.IsBack && GetConfig.IsAddLocMap && this.frmSLocMap != null)
                this.frmSLocMap.Save();
            drawArea.Refresh();
            string xml = SaveImageToXml.SaveImageToXml2(drawArea, this.lb_ImageName.Text);
            string name = this.lb_ImageName.Text;
            if (xml == "" && (this.CurrentObj == null || !this.CurrentObj.ImagePath.Contains("Mark")))
            {
                preferImages.ReflashName(name);//刷新图片名
                return;
            }
            bool success = false;
            Bitmap b = ImageOpe.FromGraphics((Control)drawArea, this.drawArea.Width, this.drawArea.Height);
            Bitmap bt = ImageOpe.KiResizeImage(b, this.sourceImage.Width, this.sourceImage.Height, 0);
           // string name = this.lb_ImageName.Text;
            if (this.IsBack)
                success = this.backImages.SaveMark(bt, ref name);
            else
            {
                if (this.CurrentObj == null)
                    return;
                success = this.preferImages.SaveMark(bt, this.CurrentObj, xml, ref name);
            }
            if (!success)
                MessageBoxEx.Show("保存失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                this.lb_ImageName.Text = name;
            if (b != null)
                b.Dispose();
            if (bt != null)
                bt.Dispose();

        }

        private void rb_Undo2_Click(object sender, EventArgs e)
        {
            drawArea.Undo();
        }

        private void rb_Redo2_Click(object sender, EventArgs e)
        {
            drawArea.Redo();
        }

        private void DeleteLabel()
        {
            drawArea.GraphicsList.DeleteSelection();
            drawArea.DeleteLabelText();
            drawArea.Refresh();
        }
        //删除
        private void rb_Delete_Click(object sender, EventArgs e)
        {
            DeleteLabel();
        }

        private void frmImgProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Application.StartupPath + "\\Config\\ImgProDockPanel.config";
            dockPanel.SaveAsXml(configFile);
        }

        private void ImgHSLC(string type)
        {
            if (this.tb_Contrast.Value == 50 && this.tb_Hue.Value == 0 && this.tb_Light.Value == 0 && this.tb_Saturation.Value == 0)
            {
                this.drawArea.Image = this.sourceImage;
                return;
            }
            Bitmap bt = this.filteredImage;
            switch (type)
            {
                case "Hue":
                    if (huemodifierFilter == null)
                        huemodifierFilter = new HueModifier();
                    huemodifierFilter.Hue = this.tb_Hue.Value;
                    bt = ApplyFilter(huemodifierFilter, bt);
                    xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "HueModifier", huemodifierFilter);
                    break;
                case "Saturation":
                    if (saturationcorrFilter == null)
                        saturationcorrFilter = new SaturationCorrection();
                    saturationcorrFilter.AdjustValue = Convert.ToDouble(this.tb_Saturation.Value) / Convert.ToDouble(255);
                    bt = ApplyFilter(saturationcorrFilter, bt);
                    xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "Saturation", saturationcorrFilter);
                    break;
                case "Light":
                    if (brightnesscorr == null)
                        brightnesscorr = new BrightnessCorrection();
                    brightnesscorr.AdjustValue = Convert.ToDouble(tb_Light.Value) / Convert.ToDouble(255);
                    bt = ApplyFilter(brightnesscorr, bt);
                    xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "BrightnessCorrection", brightnesscorr);
                    break;
                case "Contrast":
                    if (contrastCorr == null)
                        contrastCorr = new ContrastCorrection();
                    contrastCorr.Factor = Convert.ToDouble(tb_Contrast.Value) / Convert.ToDouble(40);
                    bt = ApplyFilter(contrastCorr, bt);
                    xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "ContrastCorrection", contrastCorr);
                    break;
            }
            this.drawArea.Image = bt;
        }

        private void tb_Hue_ValueChanged(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            ImgHSLC("Hue");
        }

        private void tb_Saturation_ValueChanged(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            ImgHSLC("Saturation");
        }

        private void tb_Light_ValueChanged(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            ImgHSLC("Light");
            //SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, "BrightnessCorrection", brightnesscorr);
        }

        private void tb_Contrast_ValueChanged(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            ImgHSLC("Contrast");
        }

        private void rb_Rusty_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new TexturedFilter(new CloudsTexture(), new Sepia(), new GrayscaleBT709());
            flag = "Rusty";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Marble_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Texturer(new MarbleTexture(this.drawArea.Image.Width / 96, this.drawArea.Image.Height / 48), 0.7f, 0.3f);
            flag = "Marble";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Wood_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Texturer(new WoodTexture(), 0.7f, 0.3f);
            flag = "Wood";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Clouds_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Texturer(new CloudsTexture(), 0.7f, 0.3f);
            flag = "Clouds";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Labyrinth_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Texturer(new LabyrinthTexture(), 0.7f, 0.3f);
            flag = "Labyrinth";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Textile_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            iFilter = new Texturer(new TextileTexture(), 0.7f, 0.3f);
            flag = "Textile";
            ApplyFilter(iFilter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Dirty_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null)
                return;
            TexturedFilter filter = new TexturedFilter(new CloudsTexture(), new Sepia());
            filter.PreserveLevel = 0.30f;
            filter.FilterLevel = 0.90f;
            flag = "Dirty";
            ApplyFilter(filter);
            xml += this.SaveImageToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
            //SaveImgToXml.SaveImgProcess(this.drawArea, this.lb_ImageName.Text, flag);
        }

        private void rb_Revert_Click(object sender, EventArgs e)
        {
            if (this.drawArea.Image == null || this.lb_ImageName.Text == "")
                return;
            if (!this.lb_ImageName.Text.Contains("Mark"))
            {
                try
                {
                    this.drawArea.Image = this.sourceImage;
                    this.filteredImage = (Bitmap)this.sourceImage.Clone();
                }
                catch { }
            }
            else
            {
                string oldPath = this.drawArea.ImageLocation;
                string path = oldPath.Replace("Mark", "");
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    this.sourceImage = new Bitmap(fs);
                    this.drawArea.Image = this.sourceImage;
                    this.filteredImage = (Bitmap)this.sourceImage.Clone();
                }
                catch { }
                finally { fs.Dispose(); }
                if (this.IsBack)
                {
                    File.Delete(oldPath);
                    this.backImages.LoadImages();
                    this.lb_ImageName.Text = path.Substring(path.LastIndexOf("\\") + 1);
                }
                else
                {
                    string name = this.lb_ImageName.Text;
                    this.preferImages.SaveMark(null, this.CurrentObj, "", ref name);
                }
            }
        }

        private void tb_Hue_Leave(object sender, EventArgs e)
        {
            this.filteredImage = ImageOpe.FromGraphics((Control)drawArea, drawArea.Width, drawArea.Height);
        }

        private void tb_Saturation_Leave(object sender, EventArgs e)
        {
            this.filteredImage = ImageOpe.FromGraphics((Control)drawArea, drawArea.Width, drawArea.Height);
        }

        private void tb_Light_Leave(object sender, EventArgs e)
        {
            this.filteredImage = ImageOpe.FromGraphics((Control)drawArea, drawArea.Width, drawArea.Height);
        }

        private void tb_Contrast_Leave(object sender, EventArgs e)
        {
            this.filteredImage = ImageOpe.FromGraphics((Control)drawArea, drawArea.Width, drawArea.Height);
        }

        private void llb_Hue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tb_Hue.Value = 0;
        }

        private void llb_Saturation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tb_Saturation.Value = 0;
        }

        private void llb_Light_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tb_Light.Value = 0;
        }

        private void llb_Contrast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tb_Contrast.Value = 50;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    DeleteLabel();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void p_Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.sourceImage != null)
            {
                this.InitLocationSize();
            }
            else
            {
                this.drawArea.Left = (this.p_Picture.Width - 756) / 2;
                this.drawArea.Top = (this.p_Picture.Height - 568) / 2;
            }
            int width = this.p_Main.Width / 4;
            this.p_H.Location = new Point(0, 0);
            this.p_H.Width = width;
            this.p_S.Location = new Point(width, 0);
            this.p_S.Width = width;
            this.p_L.Location = new Point(2 * width, 0);
            this.p_L.Width = width;
            this.p_C.Location = new Point(3 * width, 0);
            this.p_C.Width = width;
            this.llb_Hue.Location = new Point(width / 2 - this.llb_Hue.Width / 2, this.llb_Hue.Location.Y);
            this.llb_Saturation.Location = new Point(width / 2 - this.llb_Saturation.Width / 2, this.llb_Saturation.Location.Y);
            this.llb_Light.Location = new Point(width / 2 - this.llb_Light.Width / 2, this.llb_Light.Location.Y);
            this.llb_Contrast.Location = new Point(width / 2 - this.llb_Contrast.Width / 2, this.llb_Contrast.Location.Y);
        }

        private void frmImgProcess_Activated(object sender, EventArgs e)
        {
            this.preferImages.LoadImages();
            this.backImages.LoadImages();
        }

        private void frmImgProcess_Enter(object sender, EventArgs e)
        {
            //if (this.preferImages.Visible)
            //    this.preferImages.LoadImages();
            //if (this.backImages.Visible)
            //    this.backImages.LoadImages();
        }

        private void InitLocationSize()
        {
            double ImgRatio = (double)this.sourceImage.Width / (double)this.sourceImage.Height;
            double PRatio = (double)this.p_Picture.Width / (double)this.p_Picture.Height;
            int left = (this.p_Picture.Width - this.sourceImage.Width) / 2;
            int top = (this.p_Picture.Height - this.sourceImage.Height) / 2;
            if (left < 0 || top < 0)
            {
                if (ImgRatio > PRatio)
                {
                    int i, x = this.p_Picture.Width, y = this.p_Picture.Height;
                    for (i = 9; i > 0; i--)
                    {
                        x = (int)((double)i / 10 * (double)this.p_Picture.Width);
                        y = (int)((double)x / ImgRatio);
                        if (y <= this.p_Picture.Height)
                            break;
                    }
                    this.drawArea.Width = x;
                    this.drawArea.Height = y;
                    this.drawArea.Left = (this.p_Picture.Width - this.drawArea.Width) / 2;
                    this.drawArea.Top = (this.p_Picture.Height - this.drawArea.Height) / 2;
                }
                else
                {
                    if (ImgRatio < PRatio)
                    {
                        this.drawArea.Height = this.p_Picture.Height;
                        this.drawArea.Width = (int)((double)this.p_Picture.Height * ImgRatio);
                        this.drawArea.Left = (this.p_Picture.Width - this.drawArea.Width) / 2;
                        this.drawArea.Top = (this.p_Picture.Height - this.drawArea.Height) / 2;
                    }
                    else
                    {
                        this.drawArea.Height = this.p_Picture.Height;
                        this.drawArea.Width = this.p_Picture.Width;
                        this.drawArea.Left = 0;
                        this.drawArea.Top = 0;
                    }
                }
            }
            else
            {
                this.drawArea.Height = this.sourceImage.Height;
                this.drawArea.Width = this.sourceImage.Width;
                this.drawArea.Left = left;
                this.drawArea.Top = top;
            }
        }

        //加载新图片时初始化工具栏
        private void InitTools()
        {
            this.tb_Hue.Value = 180;
            this.tb_Light.Value = 0;
            this.tb_Saturation.Value = 0;
            this.tb_Contrast.Value =100;
        }

        private void frmImgProcess_VisibleChanged(object sender, EventArgs e)
        {
            if (this.preferImages.Visible)
                this.preferImages.LoadImages();
            if (this.backImages.Visible)
                this.backImages.LoadImages();
            //this.preferImages.LoadImages();
            if (GetConfig.IsAddLocMap && this.Visible)
                this.frmSLocMap.init();
        }
    }
}