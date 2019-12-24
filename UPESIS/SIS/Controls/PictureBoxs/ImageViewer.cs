using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseControls
{
    /// <summary>
    /// 快速查询界面中，浏览后台图像用的图像浏览器
    /// </summary>
    public partial class ImageViewer : Form
    {
        public struct Img
        {
            public string Path;
            public string Name;
        }

        public List<Img> imageArray;
        private int imageIndex;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ImageViewer()
        {
            InitializeComponent();
        }

        #region -由文件路径获取图片-
        /// <summary>
        /// 含参数filePaths一批文件路径
        /// </summary>
        /// <param name="filePaths"></param>
        public void init(string[] filePaths)
        {
            imageArray = new List<Img>();
            foreach (string path in filePaths)  //获取该病人所有的图像文件路径名称
            {
                Img i = new Img();
                i.Path = path;
                i.Name = path.Substring(path.LastIndexOf("\\") + 1);
                imageArray.Add(i);
            }
            this.l_Count.Text = this.imageArray.Count.ToString();   //显示图像总数

            if (imageArray.Count > 0)   //如果有图像，则默认显示第一张图像；否则保存按钮不可用
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[0].Path);
                this.imageIndex = 0;
                this.Text = this.imageArray[0].Name + "--图片浏览器";
            }
            else
            {
                this.btn_Save.Enabled = false;
            }
            if (imageArray.Count == 0 || imageArray.Count == 1) //若无图像或者只有一张图像，则前一张和后一张按钮不可用
            {
                this.btn_BackImage.Enabled = false;
                this.btn_ForwardImage.Enabled = false;
            }
        }

        /// <summary>
        /// 选择图片，参数是图片路径名
        /// </summary>
        /// <param name="ImgName"></param>
        public void SelectImg(string ImgName)
        {
            for (int i = 0; i < imageArray.Count; i++)
            {
                Img img = imageArray[i];
                if (img.Path == ImgName)
                {
                    imageIndex=i-1;
                    break;
                }
            }
            btn_ForwardImage_Click(null, null);
        }
        
        /// <summary>
        /// 从图像路径获取图片
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
        #endregion

        /// <summary>
        /// 重写鼠标滚动事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.ptb_Image.imageMode = 0;
            this.ptb_Image.Focus();
            base.OnMouseWheel(e);
        }

        #region -按钮事件-
        /// <summary>
        /// 显示上一张图像，根据当前图片的索引，获取图片列表的顺序上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BackImage_Click(object sender, EventArgs e)
        {
            this.btn_ForwardImage.Enabled = true;
            int i = this.imageIndex - 1;
            if (i >= 0)
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[i].Path.ToString());
                this.imageIndex = i;
                this.Text = this.imageArray[i].Name + "--图片浏览器";
            }
            if (i == 0)
                this.btn_BackImage.Enabled = false;
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// 显示下一张图像，同理根据当前图片的索引，获取图片列表的顺序的下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ForwardImage_Click(object sender, EventArgs e)
        {
            this.btn_BackImage.Enabled = true;
            int i = this.imageIndex + 1;
            if (i <= (this.imageArray.Count - 1))
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[i].Path.ToString());
                this.imageIndex = i;
                this.Text = this.imageArray[i].Name + "--图片浏览器";
            }
            if (i == (this.imageArray.Count - 1))
                this.btn_ForwardImage.Enabled = false;
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// 移动图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Move_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = true;
        }

        /// <summary>
        /// 停止移动图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StopMove_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = false;
        }

        /// <summary>
        /// 顺时针旋转图片，顺时旋转90度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClockwiseRotation_Click(object sender, EventArgs e)
        {
            if (this.ptb_Image.Image == null)
                return;
            this.ptb_Image.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.ptb_Image.Refresh();
        }

        /// <summary>
        /// 逆时针旋转图片，逆时旋转90度，即顺时270度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CounterclockwiseRotation_Click(object sender, EventArgs e)
        {
            if (this.ptb_Image.Image == null)
                return;
            this.ptb_Image.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.ptb_Image.Refresh();
        }

        /// <summary>
        /// 显示图片的原始尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PrimaryBig_Click(object sender, EventArgs e)
        {
            this.ptb_Image.imageMode = 3;
            this.ptb_Image.isPrimary = true;
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// 显示图片的最佳尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BestBig_Click(object sender, EventArgs e)
        {
            this.ptb_Image.imageMode = 2;
            this.ptb_Image.isPrimary = false;
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// 另存当前显示的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.saveImage.FileName = this.imageArray[imageIndex].Path.ToString();
            this.saveImage.ShowDialog();
        }
        #endregion

        /// <summary>
        /// 另存图片操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveImage_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.File.Copy(this.imageArray[imageIndex].Path.ToString(), saveImage.FileName);
        }

        /// <summary>
        /// 当前窗体移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageViewer_Move(object sender, EventArgs e)
        {
            this.ptb_Image.isCtlMoving = true;
            this.ptb_Image.Refresh();
            this.ptb_Image.isCtlMoving = false;
        }

        #region -暂无用的-
        //放大
        private void btn_EnLarge_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = true;
            //this.P_ReqScanImage.isReduce = false;
        }
        
        //缩小
        private void btn_Reduce_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = false;
            //this.P_ReqScanImage.isReduce = true;
        }

        //停止放大缩小
        private void btn_StopEnRe_Click(object sender, EventArgs e)
        {
            //this.P_ReqScanImage.isMove = !this.P_ReqScanImage.isMove;
        }
        #endregion

    }
}