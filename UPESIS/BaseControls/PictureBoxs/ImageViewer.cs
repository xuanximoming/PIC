using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseControls
{
    public partial class ImageViewer : Form
    {
        public struct Img
        {
            public string Path;
            public string Name;
        }
        public List<Img> imageArray;
        private int imageIndex;

        public ImageViewer()
        {
            InitializeComponent();
        }

        public void init(string[] filePaths)
        {
            imageArray = new List<Img>();
            foreach (string path in filePaths)
            {
                Img i = new Img();
                i.Path = path;
                i.Name = path.Substring(path.LastIndexOf("\\") + 1);
                imageArray.Add(i);
            }
            this.l_Count.Text = this.imageArray.Count.ToString();
            if (imageArray.Count > 0)
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[0].Path);
                this.imageIndex = 0;
                this.Text = this.imageArray[0].Name + "--Í¼Æ¬ä¯ÀÀÆ÷";
            }
            else
            {
                this.btn_Save.Enabled = false;
            }
            if (imageArray.Count == 0 || imageArray.Count == 1)
            {
                this.btn_BackImage.Enabled = false;
                this.btn_ForwardImage.Enabled = false;
            }
        }
        public void SelectImg(string ImgName)
        {
            for (int i = 0; i < imageArray.Count; i++)
            {
                Img img = imageArray[i];
                if (img.Name == ImgName)
                {
                    imageIndex=i-1;
                    break;
                }
            }
            btn_ForwardImage_Click(null, null);
        }
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
      

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.ptb_Image.imageMode = 0;
            this.ptb_Image.Focus();
            base.OnMouseWheel(e);
        }

        //Ô­Ê¼³ß´ç
        private void btn_PrimaryBig_Click(object sender, EventArgs e)
        {
            this.ptb_Image.imageMode = 3;
            this.ptb_Image.isPrimary = true;
            this.ptb_Image.Invalidate();
        }

        //ÉÏÒ»ÕÅÍ¼Ïñ
        private void btn_BackImage_Click(object sender, EventArgs e)
        {
            this.btn_ForwardImage.Enabled = true;
            int i = this.imageIndex - 1;
            if (i >= 0)
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[i].Path.ToString());
                this.imageIndex = i;
                this.Text = this.imageArray[i].Name + "--Í¼Æ¬ä¯ÀÀÆ÷";
            }
            if (i == 0)
                this.btn_BackImage.Enabled = false;
            //else
            //{
                //this.ptb_Image.Image = Image.FromFile(this.imageArray[this.imageArray.Count - 1].Path.ToString());
                //this.imageIndex = this.imageArray.Count - 1;
                //this.Text = this.imageArray[this.imageArray.Count - 1].Name + "--Í¼Æ¬ä¯ÀÀÆ÷"; 
            //}
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }

        //ÏÂÒ»ÕÅÍ¼Ïñ
        private void btn_ForwardImage_Click(object sender, EventArgs e)
        {
            this.btn_BackImage.Enabled = true;
            int i = this.imageIndex + 1;
            if (i <= (this.imageArray.Count - 1))
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[i].Path.ToString());
                this.imageIndex = i;
                this.Text = this.imageArray[i].Name + "--Í¼Æ¬ä¯ÀÀÆ÷";
            }
            if (i == (this.imageArray.Count - 1))
                this.btn_ForwardImage.Enabled = false;
            //else
            //{
                //this.ptb_Image.Image = Image.FromFile(this.imageArray[0].Path.ToString());
                //this.imageIndex = 0;
                //this.Text = this.imageArray[0].Name + "--Í¼Æ¬ä¯ÀÀÆ÷";
            //}
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }
        //Ë³Ê±ÕëÐý×ª
        private void btn_ClockwiseRotation_Click(object sender, EventArgs e)
        {
            if (this.ptb_Image.Image == null)
                return;
            this.ptb_Image.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.ptb_Image.Refresh();
        }

        //ÄæÊ±ÕëÐý×ª
        private void btn_CounterclockwiseRotation_Click(object sender, EventArgs e)
        {
            if (this.ptb_Image.Image == null)
                return;
            this.ptb_Image.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.ptb_Image.Refresh();
        }

        //Í£Ö¹·Å´óËõÐ¡
        private void btn_StopEnRe_Click(object sender, EventArgs e)
        {
            //this.P_ReqScanImage.isMove = !this.P_ReqScanImage.isMove;
        }

        //×î¼Ñ³ß´ç
        private void btn_BestBig_Click(object sender, EventArgs e)
        {
            this.ptb_Image.imageMode = 2;
            this.ptb_Image.isPrimary = false;
            this.ptb_Image.Invalidate();
        }

        //·Å´ó
        private void btn_EnLarge_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = true;
            //this.P_ReqScanImage.isReduce = false;
        }
        
        //ËõÐ¡
        private void btn_Reduce_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = false;
            //this.P_ReqScanImage.isReduce = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.saveImage.FileName = this.imageArray[imageIndex].Path.ToString();
            this.saveImage.ShowDialog();
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = true;
        }

        private void btn_StopMove_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = false;
        }

        private void saveImage_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.File.Copy(this.imageArray[imageIndex].Path.ToString(), saveImage.FileName);
        }

        private void ImageViewer_Move(object sender, EventArgs e)
        {
            this.ptb_Image.isCtlMoving = true;
            this.ptb_Image.Refresh();
            this.ptb_Image.isCtlMoving = false;
        }
    }
}