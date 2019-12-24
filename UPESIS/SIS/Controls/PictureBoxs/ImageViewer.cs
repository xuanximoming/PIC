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
    /// ���ٲ�ѯ�����У������̨ͼ���õ�ͼ�������
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
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ImageViewer()
        {
            InitializeComponent();
        }

        #region -���ļ�·����ȡͼƬ-
        /// <summary>
        /// ������filePathsһ���ļ�·��
        /// </summary>
        /// <param name="filePaths"></param>
        public void init(string[] filePaths)
        {
            imageArray = new List<Img>();
            foreach (string path in filePaths)  //��ȡ�ò������е�ͼ���ļ�·������
            {
                Img i = new Img();
                i.Path = path;
                i.Name = path.Substring(path.LastIndexOf("\\") + 1);
                imageArray.Add(i);
            }
            this.l_Count.Text = this.imageArray.Count.ToString();   //��ʾͼ������

            if (imageArray.Count > 0)   //�����ͼ����Ĭ����ʾ��һ��ͼ�񣻷��򱣴水ť������
            {
                this.ptb_Image.Image = this.GetImageFromFile(this.imageArray[0].Path);
                this.imageIndex = 0;
                this.Text = this.imageArray[0].Name + "--ͼƬ�����";
            }
            else
            {
                this.btn_Save.Enabled = false;
            }
            if (imageArray.Count == 0 || imageArray.Count == 1) //����ͼ�����ֻ��һ��ͼ����ǰһ�źͺ�һ�Ű�ť������
            {
                this.btn_BackImage.Enabled = false;
                this.btn_ForwardImage.Enabled = false;
            }
        }

        /// <summary>
        /// ѡ��ͼƬ��������ͼƬ·����
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
        /// ��ͼ��·����ȡͼƬ
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
        /// ��д�������¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.ptb_Image.imageMode = 0;
            this.ptb_Image.Focus();
            base.OnMouseWheel(e);
        }

        #region -��ť�¼�-
        /// <summary>
        /// ��ʾ��һ��ͼ�񣬸��ݵ�ǰͼƬ����������ȡͼƬ�б��˳����һ��
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
                this.Text = this.imageArray[i].Name + "--ͼƬ�����";
            }
            if (i == 0)
                this.btn_BackImage.Enabled = false;
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// ��ʾ��һ��ͼ��ͬ����ݵ�ǰͼƬ����������ȡͼƬ�б��˳�����һ��
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
                this.Text = this.imageArray[i].Name + "--ͼƬ�����";
            }
            if (i == (this.imageArray.Count - 1))
                this.btn_ForwardImage.Enabled = false;
            this.ptb_Image.NewImage();
            this.ptb_Image.Invalidate();
        }

        /// <summary>
        /// �ƶ�ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Move_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = true;
        }

        /// <summary>
        /// ֹͣ�ƶ�ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StopMove_Click(object sender, EventArgs e)
        {
            this.ptb_Image.isMove = false;
        }

        /// <summary>
        /// ˳ʱ����תͼƬ��˳ʱ��ת90��
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
        /// ��ʱ����תͼƬ����ʱ��ת90�ȣ���˳ʱ270��
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
        /// ��ʾͼƬ��ԭʼ�ߴ�
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
        /// ��ʾͼƬ����ѳߴ�
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
        /// ��浱ǰ��ʾ��ͼƬ
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
        /// ���ͼƬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveImage_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.File.Copy(this.imageArray[imageIndex].Path.ToString(), saveImage.FileName);
        }

        /// <summary>
        /// ��ǰ�����ƶ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageViewer_Move(object sender, EventArgs e)
        {
            this.ptb_Image.isCtlMoving = true;
            this.ptb_Image.Refresh();
            this.ptb_Image.isCtlMoving = false;
        }

        #region -�����õ�-
        //�Ŵ�
        private void btn_EnLarge_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = true;
            //this.P_ReqScanImage.isReduce = false;
        }
        
        //��С
        private void btn_Reduce_Click(object sender, EventArgs e)
        {
            //this.ptb_Image.imageMode = 1;
            //this.P_ReqScanImage.isStopEnRe = false;
            //this.P_ReqScanImage.isEnlarge = false;
            //this.P_ReqScanImage.isReduce = true;
        }

        //ֹͣ�Ŵ���С
        private void btn_StopEnRe_Click(object sender, EventArgs e)
        {
            //this.P_ReqScanImage.isMove = !this.P_ReqScanImage.isMove;
        }
        #endregion

    }
}