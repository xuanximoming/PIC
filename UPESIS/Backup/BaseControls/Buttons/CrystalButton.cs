using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.Buttons
{
    /// <summary>
    /// 继承标准的Button，水晶按钮
    /// </summary>
    public partial class CrystalButton : Button
    {
        //鼠标动作类型：None,停留和点击
        private enum MouseActionType
        {
            None,
            Hover,
            Click
        }

        private MouseActionType mouseAction;
        private ImageAttributes imgAttr = new ImageAttributes();

        //构造函数，设置风格、背景颜色和大小
        public CrystalButton()
        {
            InitializeComponent();

            mouseAction = MouseActionType.None;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint, true);

            //The following defaults are better suited to draw the text outline
            this.BackColor = Color.DarkTurquoise;
            this.Size = new Size(112, 48);
        }

        //对按钮棱角就行椭圆处理
        private GraphicsPath GetGraphicsPath(Rectangle rc, int r)
        {
            int x = rc.X, y = rc.Y, w = rc.Width, h = rc.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, r, r, 180, 90);				//Upper left corner
            path.AddArc(x + w - r, y, r, r, 270, 90);			//Upper right corner
            path.AddArc(x + w - r, y + h - r, r, r, 0, 90);		//Lower right corner
            path.AddArc(x, y + h - r, r, r, 90, 90);			//Lower left corner
            path.CloseFigure();
            return path;
        }

        //设置按钮文本布局方式
        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

        #region -  Image  -图像

        private Image mImage;
        /// <summary>
        /// The image displayed on the button that 
        /// is used to help the user identify
        /// it's function if the text is ambiguous.
        /// </summary>
        [Category("Image"),
         DefaultValue(null),
         Description("The image displayed on the button that " +
                     "is used to help the user identify" +
                     "it's function if the text is ambiguous.")]
        public new Image Image
        {
            get { return mImage; }
            set { mImage = value; this.Invalidate(); }
        }

        private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
        /// <summary>
        /// The alignment of the image 
        /// in relation to the button.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
         Description("The alignment of the image " +
                     "in relation to the button.")]
        public new ContentAlignment ImageAlign
        {
            get { return mImageAlign; }
            set { mImageAlign = value; this.Invalidate(); }
        }

        private Size mImageSize = new Size(24, 24);
        /// <summary>
        /// The size of the image to be displayed on the
        /// button. This property defaults to 24x24.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof(Size), "24, 24"),
         Description("The size of the image to be displayed on the" +
                     "button. This property defaults to 24x24.")]
        public Size ImageSize
        {
            get { return mImageSize; }
            set { mImageSize = value; this.Invalidate(); }
        }

        #endregion

        /// <summary>
        /// Draws the image for the button，进行图像绘画
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawImage(Graphics g)
        {
            if (this.Image == null) { return; }
            Rectangle r = new Rectangle(8, 8, this.ImageSize.Width, this.ImageSize.Height);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, 8, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, 8, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height / 2 - this.ImageSize.Height / 2, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width, this.Height - 8 - this.ImageSize.Height, this.ImageSize.Width, this.ImageSize.Height);
                    break;
            }
            g.DrawImage(this.Image, r);
        }

        #region-按钮可视绘画-
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(Color.White);
            g.Clear(SystemColors.ButtonFace);
            Color clr = this.BackColor;
            int shadowOffset = 8;
            int btnOffset = 0;
            switch (mouseAction)
            {
                case MouseActionType.Click:
                    shadowOffset = 4;
                    clr = Color.LightGray;
                    btnOffset = 2;
                    break;
                case MouseActionType.Hover:
                    clr = Color.LightGray;
                    break;
            }
            g.SmoothingMode = SmoothingMode.AntiAlias;

            ///
            /// 创建按钮本身的图形
            /// 
            Rectangle rc = new Rectangle(btnOffset, btnOffset, this.ClientSize.Width - 8 - btnOffset, this.ClientSize.Height - 8 - btnOffset);
            GraphicsPath path1 = this.GetGraphicsPath(rc, 20);
            LinearGradientBrush br1 = new LinearGradientBrush(new Point(0, 0), new Point(0, rc.Height + 6), clr, Color.White);

            ///
            /// 创建按钮阴影
            /// 
            Rectangle rc2 = rc;
            rc2.Offset(shadowOffset, shadowOffset);
            GraphicsPath path2 = this.GetGraphicsPath(rc2, 20);
            PathGradientBrush br2 = new PathGradientBrush(path2);
            br2.CenterColor = Color.Black;
            br2.SurroundColors = new Color[] { SystemColors.ButtonFace };
            //为了更逼真，我们将渐变结束颜色设定为窗体前景颜色，可以根据窗口的前景颜色适当调整

            ///
            /// 创建按钮顶部白色渐变
            /// 
            Rectangle rc3 = rc;
            rc3.Inflate(-5, -5);
            rc3.Height = 15;
            GraphicsPath path3 = GetGraphicsPath(rc3, 20);
            LinearGradientBrush br3 = new LinearGradientBrush(rc3, Color.FromArgb(255, Color.White), Color.FromArgb(0, Color.White), LinearGradientMode.Vertical);

            ///
            /// 绘制图形
            ///
            g.FillPath(br2, path2);	//绘制阴影
            g.FillPath(br1, path1); //绘制按钮
            g.FillPath(br3, path3); //绘制顶部白色泡泡

            ///
            ///设定内存位图对象，进行二级缓存绘图操作
            ///
            DrawImage(e.Graphics);
            ///
            ///将region赋值给button
            Region rgn = new Region(path1);
            rgn.Union(path2);
            this.Region = rgn;

            ///
            /// 绘制按钮的文本
            /// 
            GraphicsPath path4 = new GraphicsPath();

            RectangleF path1bounds = path1.GetBounds();

            Rectangle rcText = new Rectangle((int)path1bounds.X + btnOffset, (int)path1bounds.Y + btnOffset, (int)path1bounds.Width, (int)path1bounds.Height);

            StringFormat strformat = StringFormatAlignment(this.TextAlign);
            path4.AddString(this.Text, this.Font.FontFamily, (int)this.Font.Style, this.Font.Size, rcText, strformat);

            Pen txtPen = new Pen(this.ForeColor, 1);
            g.DrawPath(txtPen, path4);
        }
        #endregion

        #region - 鼠标动作-
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseAction = MouseActionType.Click;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.mouseAction = MouseActionType.None;
            this.Invalidate();
            base.OnMouseLeave(e);
        }
        #endregion 
    }
}