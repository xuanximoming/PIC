using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SIS.ImgProcess.ImageZoom
{
    public partial class Zoom : UserControl
    {
        private float zoom = 1;
        private int width;
        private int height;
        public Zoom()
        {
            InitializeComponent();
            width = frmImgProcess.imgProcess.drawArea.Width;
            height = frmImgProcess.imgProcess.drawArea.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

         private void zoomItem_Click( object sender, System.EventArgs e )
         {

         }

        private void UpdateZoom()
        {
            frmImgProcess.imgProcess.AutoScrollMinSize = new Size((int)zoom * width, (int)zoom * height);

        }

        private void lb_ZoomIn_Click(object sender, EventArgs e)
        {
            Bitmap bt = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            Bitmap btTemp = new Bitmap(bt,Convert.ToInt32(bt.Width*1.5),Convert.ToInt32(bt.Height*1.5));
            frmImgProcess.imgProcess.drawArea.Image = btTemp;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Bitmap bt = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            Bitmap btTemp = new Bitmap(bt, Convert.ToInt32(bt.Width / 1.5), Convert.ToInt32(bt.Height / 1.5));
            frmImgProcess.imgProcess.drawArea.Image = btTemp;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Bitmap bt = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            Bitmap btTemp = new Bitmap(bt, width, height);
            frmImgProcess.imgProcess.drawArea.Image = btTemp;
        }



    }
}
