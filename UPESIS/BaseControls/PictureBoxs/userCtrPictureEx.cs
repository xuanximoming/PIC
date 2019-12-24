using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.PictureBoxs
{
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
        /// 
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
        /// OnPaint override. This is where the text is rendered vertically.
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


    }
}
