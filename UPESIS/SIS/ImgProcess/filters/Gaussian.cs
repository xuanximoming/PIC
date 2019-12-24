using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.Imaging;
using SIS.ImgProcess;
namespace SIS.ImgProcess.filters
{
    public partial class Gaussian : UserControl
    {
        private GaussianBlur gaussianBlur;
        private Point p;
        private SaveImageToXml saveImgToXml;
        public Gaussian()
        {
            InitializeComponent();
            this.l_track1_L.Text = "30";
            this.l_track1_R.Text = "180";
            this.trackBar_1.Maximum = 180;
            this.trackBar_1.Minimum = 30;
            this.trackBar_1.SmallChange = 1;
            this.trackBar_1.TickFrequency = 10;

            this.l_track1_L2.Text = "30";
            this.l_track1_R2.Text = "210";
            this.trackBar_2.Maximum = 210;
            this.trackBar_2.Minimum = 30;
            this.trackBar_2.SmallChange = 1;
            this.trackBar_2.TickFrequency = 10;


            gaussianBlur = new GaussianBlur();
            this.drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            drawArea.Filter = gaussianBlur;
            saveImgToXml = new SaveImageToXml();
        }
        private void OnlyEnterIntNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }

        }

        private bool ValidateData(string data,int value)
        {

            if (data != "")
            {
                if (Convert.ToInt32(data) <= value)
                    return true;
                else
                {
                    MessageBoxEx.Show("取值范围在0~"+value, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
        }


        private void trackBar_1_ValueChanged(object sender, EventArgs e)
        {
            double value = 0.0;
            value = Convert.ToDouble(this.trackBar_1.Value) / Convert.ToDouble(180);
            tb_GaussianSigemaValue.Text = this.trackBar_1.Value.ToString();
            tb_GaussianSigemaPercent.Text = Convert.ToInt32(value * 100).ToString() + "%";
        }

        private void tb_GaussianSigemaValue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(tb_GaussianSigemaValue.Text, 180))
            {
                gaussianBlur.Sigma = double.Parse(tb_GaussianSigemaValue.Text) / Convert.ToDouble(60); 
                trackBar_1.Value = Convert.ToInt32(gaussianBlur.Sigma * 60);
                drawArea.RefreshFilter();
            }
        }

        private void trackBar_2_ValueChanged(object sender, EventArgs e)
        {
            double value = 0.0;
            value = Convert.ToDouble(this.trackBar_2.Value) / Convert.ToDouble(210);
            tb_GaussianValue.Text = this.trackBar_2.Value.ToString();
            tb_GaussianPercent.Text = Convert.ToInt32(value * 100).ToString() + "%";
        }

        private void tb_GaussianValue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(tb_GaussianValue.Text, 210))
            {
                gaussianBlur.Size = Convert.ToInt32(int.Parse(tb_GaussianValue.Text) / Convert.ToDouble(10));
                trackBar_2.Value = gaussianBlur.Size * 10;
                drawArea.RefreshFilter();
            }
        }

        private void Light_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void Light_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                Point mousePoint = Control.MousePosition;
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePoint);

            }
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            frmImgProcess.imgProcess.ApplyFilter(gaussianBlur);
            saveImgToXml.SaveImgProcess(frmImgProcess.imgProcess.drawArea, frmImgProcess.imgProcess.lb_ImageName.Text, "Gaussian", gaussianBlur);

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
