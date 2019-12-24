using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ImageBox.Imaging;
namespace SIS.ImgProcess.filters
{
    public partial class Saturation : UserControl
    {
        private Point p;
        private SaturationCorrection saturationcorrFilter;
        private SaveBackImageToXml saveImg;
        public Saturation()
        {
            InitializeComponent();
            this.l_track1_L.Text = "-250";
            this.l_track1_R.Text = "250";
            this.trackBar_1.Maximum = 250;
            this.trackBar_1.Minimum = -250;
            this.trackBar_1.SmallChange = 1;
            this.trackBar_1.TickFrequency = 10;
            saturationcorrFilter = new SaturationCorrection();
            drawArea.Filter = saturationcorrFilter;
            drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            saveImg = new SaveBackImageToXml();
        }

        private void OnlyEnterIntNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13&& e.KeyChar!=45)
            {
                e.Handled = true;
            }

        }

        private bool ValidateData(string data)
        {

            if (data != "")
            {
                switch (data.IndexOf("-"))
                {
                    case 0:
                        if (data.Length == 1)
                            return false;

                        if (Convert.ToInt32(data) >= -255)
                            return true;
                        else
                        {
                            MessageBoxEx.Show("取值范围在-255~255", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    case -1:
                        if (Convert.ToInt32(data) <= 255)
                            return true;
                        else
                        {
                            MessageBoxEx.Show("取值范围在-255~255", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    default:
                        MessageBoxEx.Show("输入不合法！");
                        return false;
                }
            }
            else
                return false;


        }

        private void trackBar_1_ValueChanged(object sender, EventArgs e)
        {
            double value = 0.0;
            value = Convert.ToDouble(this.trackBar_1.Value) / Convert.ToDouble(255);
            tb_SaturationValue.Text = this.trackBar_1.Value.ToString();
            tb_SaturationPercent.Text = Convert.ToInt32(value * 100).ToString() + "%";
        }

        private void tb_HueValue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(tb_SaturationValue.Text))
            {
                saturationcorrFilter.AdjustValue = double.Parse(tb_SaturationValue.Text) / Convert.ToDouble(255); ;
                trackBar_1.Value = Convert.ToInt32(saturationcorrFilter.AdjustValue * 255);
                drawArea.RefreshFilter();
            }
        }

        private void Saturation_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void Saturation_MouseMove(object sender, MouseEventArgs e)
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

            frmImgProcess.imgProcess.ApplyFilter(saturationcorrFilter);
            saveImg.SaveImgProcess(frmImgProcess.imgProcess.drawArea, frmImgProcess.imgProcess.lb_ImageName.Text, "Saturation", saturationcorrFilter);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
