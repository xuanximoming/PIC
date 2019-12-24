using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.PictureBoxs
{
    public partial class MyPictureBox : System.Windows.Forms.PictureBox
    {
        public MyPictureBox()
        {
            InitializeComponent();
            this.imageMode = 2;
            this.isPrimary = false;
        }

        //public bool isEnlarge = false; //TRUE:放大
        //public bool isReduce = false;  //TRUE:缩小
        //public bool isStopEnRe = true;//TRUE:停止放大缩小 
        public bool isPrimary = true;//TURE:原始尺寸
        private Rectangle rcxImage, rcxChange, priImage;
        private Point oldMouse = new Point();
        private int X = 0, Y = 0, Ychange = 0;
        public int imageMode = 6;//图像模式
        private bool isFirst = true;//是否图像第一次被加载
        public bool isMove = false;
        public bool isCtlMoving = false;


        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Image != null)
            {
                if (this.isFirst)
                {
                    int x = this.Location.X + (this.Width - this.Image.Size.Width) / 2;
                    int y = this.Location.Y + (this.Height - this.Image.Size.Height) / 2;
                    //x = x >= 0 ? x : 0;
                    //y = y >= 0 ? y : 0;
                    Point pictureCenter = new Point(x, y);
                    this.priImage = new Rectangle(pictureCenter, pe.ClipRectangle.Size);
                    this.isFirst = false;
                }
                if (!this.isCtlMoving)
                {
                    switch (imageMode)
                    {
                        case 0://鼠标滚轮转动
                            ScaleImageIsotropically(pe.Graphics, this.Image, this.rcxChange);
                            break;
                        case 1://鼠标点击控制图像大小
                            ScaleImageIsotropically(pe.Graphics, this.Image, this.rcxChange);
                            break;
                        case 2://最佳尺寸
                            ScaleImageIsotropically(pe.Graphics, this.Image, pe.ClipRectangle);
                            break;
                        case 3://原始尺寸
                            int x = this.Location.X;
                            int y = this.Location.Y;
                            Point pictureCenter = new Point(x, y);
                            this.priImage = new Rectangle(pictureCenter, this.priImage.Size);
                            ScaleImageIsotropically(pe.Graphics, this.Image, priImage);
                            break;
                        case 4://鼠标移动查看图像
                            ScaleImageIsotropically(pe.Graphics, this.Image, this.rcxImage);
                            break;
                        case 5://鼠标移动控制大小
                            ScaleImageIsotropically(pe.Graphics, this.Image, this.rcxChange);
                            break;
                        default://默认情况
                            base.OnPaint(pe);
                            break;
                    }
                }
                else
                    base.OnPaint(pe);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Image != null)
            {
                if (this.isPrimary)
                {
                    this.imageMode = 3;
                }
                else
                {
                    this.imageMode = 2;
                }
            }
            base.OnSizeChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //if (this.isStopEnRe)
                    //{
                    if (this.isMove)
                    {
                        //if (this.rcBaseControls.ImageBox.Size.Height > this.Size.Height || this.rcBaseControls.ImageBox.Size.Width > this.Size.Width)
                        //{

                            this.imageMode = 4;
                            this.Cursor = Cursors.NoMove2D;
                            this.oldMouse.X = e.X;
                            this.oldMouse.Y = e.Y;
                            this.X = this.rcxImage.X;
                            this.Y = this.rcxImage.Y;
                        //}

                    }
                    //this.pictureBox1.Capture = true;
                    //}
                    //else
                    //{
                    //if (this.isEnlarge)
                    //{
                    //    this.Cursor = new Cursor(Application.StartupPath + "\\Zoom+.cur");
                    //}
                    //if (this.isReduce)
                    //{
                    //    this.Cursor = new Cursor(Application.StartupPath + "\\Zoom-.cur");
                    //}
                    else
                    {
                        this.oldMouse.Y = e.Y;
                        this.X = this.rcxImage.X;
                        this.Y = this.rcxImage.Y;
                    }
                    //}

                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                //    if (!this.isStopEnRe)
                //    {
                        //if (this.isEnlarge)
                        //{

                            //this.Cursor = new Cursor(Application.StartupPath + "\\Zoom+.cur");
                          
                        //}
                        //if (this.isReduce)
                        //{
                        //    this.Cursor = new Cursor(Application.StartupPath + "\\Zoom-.cur");
                        //}
                    //}
                            if (this.imageMode == 4)
                            {
                                this.Cursor = Cursors.NoMove2D;

                                int Xchange = e.X - oldMouse.X;
                                int Ychange = e.Y - oldMouse.Y;
                                int X = this.X + Xchange;
                                int Y = this.Y + Ychange;
                                this.rcxImage.X = this.X + Xchange;
                                this.rcxImage.Y = this.Y + Ychange;
                                this.Invalidate();
                            }
                            else
                            {
                                this.Ychange = e.Y - oldMouse.Y;
                            }
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.Image != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.imageMode == 4)
                    {
                        this.imageMode = 6;
                        this.Cursor = Cursors.Default;
                        this.oldMouse = new Point();
                        //this.pictureBox1.Capture = false;
                    }
                    //if (this.isEnlarge)
                    //{
                    else
                    {
                        this.imageMode = 5;
                        EnlageAndReduce(5,e);
                        this.Invalidate();
                        this.Cursor = Cursors.Default;
                        this.oldMouse = new Point();
                    }
                    //}
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //if (!this.isStopEnRe)
            //{
            //    if (this.isEnlarge)
            //    {
            //        this.isReduce = false;
            //        EnlageAndReduce(12,e);
            //    }
            //    if (this.isReduce)
            //    {
            //        this.isEnlarge = false;
            //        EnlageAndReduce(11,e);
            //    }
            //    this.imageMode = 1;
            //    this.Invalidate();
            //}
            base.OnMouseClick(e);
        }

        //鼠标滚轮事件
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.imageMode ==0)
            {
                EnlageAndReduce(0,e);
                this.Invalidate();
            }
            base.OnMouseWheel(e);
        }

        void EnlageAndReduce(int i, MouseEventArgs e)
        {
            this.rcxChange = this.rcxImage;
            switch (i)
            {
                case 0:
                    this.rcxChange.Width += e.Delta / 10;
                    this.rcxChange.Height += e.Delta / 10;
                    break;
                case 11:
                    this.rcxChange.Width -= e.Clicks * 50;
                    this.rcxChange.Height -= e.Clicks * 50;
                    break;
                case 12:
                    this.rcxChange.Width += e.Clicks * 50;
                    this.rcxChange.Height += e.Clicks * 50;
                    break;
                case 5:
                    this.rcxChange.Width -= this.Ychange;
                    this.rcxChange.Height -= this.Ychange;
                    break;
            }
            int pictureBoxX = this.Location.X + this.priImage.Width / 2;
            int pictureBoxY = this.Location.Y + this.priImage.Height / 2;
            if (this.rcxChange.Width < 100 || this.rcxChange.Height < 100)
            {
                this.rcxChange.Width = 100;
                this.rcxChange.Height = 100;
            }
            if (this.rcxChange.Width > 1400 || this.rcxChange.Height > 1200)
            {
                this.rcxChange.Width = 1400;
                this.rcxChange.Height = 1200;
            }
            int rcxChangeX = pictureBoxX - this.rcxChange.Width / 2;
            int rcxChangeY = pictureBoxY - this.rcxChange.Height / 2;
            if (rcxChangeX <= pictureBoxX && rcxChangeY <= pictureBoxY)
            {
                this.rcxChange.X = rcxChangeX;
                this.rcxChange.Y = rcxChangeY;
            }
        }

        void ScaleImageIsotropically(Graphics grfx, Image image, Rectangle rect)
        {
            grfx.Clear(this.BackColor);
            SizeF sizef = new SizeF(image.Width / image.HorizontalResolution, image.Height / image.VerticalResolution);
            float fScale = Math.Min(rect.Width / sizef.Width, rect.Height / sizef.Height);
            sizef.Width *= fScale;
            sizef.Height *= fScale;
            this.rcxImage = new Rectangle((int)(rect.X + (rect.Width - sizef.Width) / 2), (int)(rect.Y + (rect.Height - sizef.Height) / 2), (int)sizef.Width, (int)sizef.Height);
            grfx.DrawImage(image, this.rcxImage);
        }

        public void NewImage()
        {
            //this.isEnlarge = false; //TRUE:放大
            //this.isReduce = false;  //TRUE:缩小
            //this.isStopEnRe = true;//TRUE:停止放大缩小 
            this.isPrimary = true;//TURE:原始尺寸
            this.rcxImage = new Rectangle();
            this.rcxChange = new Rectangle();
            this.priImage = new Rectangle();
            this.oldMouse = new Point();
            this.X = 0;
            this.Y = 0;
            this.imageMode = 6;//图像模式
            this.isFirst = true;//是否图像第一次被加载
        }
    }
}
