using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.Panels
{
    public partial class MyPanel : Panel
    {
        Color clr = Color.Blue;

        public Color BorderColor
        {
            get { return clr;}
            set { clr = value; }
        }
        public MyPanel()
        {
            InitializeComponent();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            PaintEventArgs pe = new PaintEventArgs(g, this.ClientRectangle);
            OnPaint(pe);
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            ControlPaint.DrawBorder(pe.Graphics,
                            this.ClientRectangle,
                            clr,
                            1,
                            ButtonBorderStyle.Solid,     
                            clr,
                            1,
                            ButtonBorderStyle.Solid,
                            clr,
                            1,
                            ButtonBorderStyle.Solid,
                            clr,
                            1,
                            ButtonBorderStyle.Solid); 


            // 调用基类 OnPaint
            base.OnPaint(pe);
        }
    }
}
