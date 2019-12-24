using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.PictureBoxs
{
    /// <summary>
    /// 控件userCtrPictureEx，继承于UserControl
    /// </summary>
    public partial class userCtrPictureEx : UserControl
    {
        public enum LBorderStyle
        {
            None,
            Top,
            Left,
            Right,
            Buttom,
            All
        }
        private LBorderStyle _dm = LBorderStyle.None;
        private int border = -1;

        /// <summary>
        /// 属性
        /// </summary>
        [Category("Properties"), Description("Whether the text will be drawn from Bottom or from Top.")]
        public LBorderStyle LabelBorderStyle
        {
            get { return _dm; }
            set { _dm = value; }
        }
        [Category("Properties"), Description("Whether the text will be drawn from Bottom or from Top.")]
        public int LabelBorder
        {
            get { return border; }
            set { border = value; }
        }
        public userCtrPictureEx()
        {
            InitializeComponent();
        }
         /// <summary>
        /// 重写绘图事件
        /// </summary>
        /// <param name="e">PaintEventArgs</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            switch (this.LabelBorderStyle)
            {
                case LBorderStyle.None:
                    this.l_Buttom.Visible = false;
                    this.l_Left.Visible = false;
                    this.l_Right.Visible = false;
                    this.l_Top.Visible = false;
                    break;
                case LBorderStyle.All:
                    this.l_Buttom.Visible = true;
                    this.l_Left.Visible = true;
                    this.l_Right.Visible = true;
                    this.l_Top.Visible = true;
                    break;
                case LBorderStyle.Buttom:
                    this.l_Buttom.Visible = true;
                    this.l_Left.Visible = false;
                    this.l_Right.Visible = false;
                    this.l_Top.Visible = false;
                    break;
                case LBorderStyle.Left:
                    this.l_Buttom.Visible = false;
                    this.l_Left.Visible = true;
                    this.l_Right.Visible = false;
                    this.l_Top.Visible = false;
                    break;
                case LBorderStyle.Right:
                    this.l_Buttom.Visible = false;
                    this.l_Left.Visible = false;
                    this.l_Right.Visible = true;
                    this.l_Top.Visible = false;
                    break;
                case LBorderStyle.Top:
                    this.l_Buttom.Visible = false;
                    this.l_Left.Visible = false;
                    this.l_Right.Visible = false;
                    this.l_Top.Visible = true;
                    break;
            }
            if (this.LabelBorder != -1)
            {
                this.l_Buttom.Size = new Size(this.l_Buttom.Width, this.LabelBorder);
                this.l_Left.Size = new Size(this.LabelBorder, this.l_Left.Height);
                this.l_Right.Size = new Size(this.LabelBorder, this.l_Right.Height);
                this.l_Top.Size = new Size(this.l_Top.Width, this.LabelBorder);
            }
        }

        /// <summary>
        /// 按钮文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_Buttom_TextChanged(object sender, EventArgs e)
        {
            if (ILL.GetConfig.IsAddLocMap)
            {
                SIS.ImgObj obj = (SIS.ImgObj)this.Picture.ImgObj;
                if (obj != null)
                {
                    SIS_Model.MLocationMap mLoc = (SIS_Model.MLocationMap)obj.MLocationMap;
                    if (mLoc != null)
                    {
                        this.l_Buttom.Text = mLoc.MAP_PART + " " + mLoc.MAP_EXPLAIN;
                        this.l_Buttom.ForeColor = Color.Blue;
                        return;
                    }

                }
            }
        }

    }
}