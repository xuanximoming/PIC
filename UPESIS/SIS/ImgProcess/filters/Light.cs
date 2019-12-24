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
    public partial class Light : UserControl
    {
        private BrightnessCorrection brightnesscorr; 
        private Point p;
        private SaveBackImageToXml saveImgToXml;
       // private ReadBackImageFromXML readBackImage;
        public Light()
        {
            InitializeComponent();
            this.l_track1_L.Text = "-255";
            this.l_track1_R.Text = "255";
            this.trackBar_1.Maximum = 255;
            this.trackBar_1.Minimum = -255;
            this.trackBar_1.SmallChange = 1;
            this.trackBar_1.TickFrequency = 10;
            brightnesscorr = new BrightnessCorrection();
            this.drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            drawArea.Filter = brightnesscorr;
            saveImgToXml = new SaveBackImageToXml();
           // readBackImage = new ReadBackImageFromXML(ImgProcess.imgProcess.lb_ImageName.Text);
        }


        //private void GetLightValue()
        //{
        //    if (((BrightnessCorrection)readBackImage.GetImageProcess("BrightnessCorrection"))!=null)
        //    this.tb_LightValue.Text = Convert.ToInt32(((BrightnessCorrection)readBackImage.GetImageProcess("BrightnessCorrection")).AdjustValue * 255).ToString();
        //}

        private void Light_Load(object sender, EventArgs e)
        {
           // GetLightValue();
        }


        private void OnlyEnterIntNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 &&e.KeyChar!=45)
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
                default :
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
            tb_LightValue.Text = this.trackBar_1.Value.ToString();
            tb_LightPercent.Text = Convert.ToInt32(value * 100).ToString() + "%";
         
        }

        private void tb_LightValue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(tb_LightValue.Text))
            {
                brightnesscorr.AdjustValue = double.Parse( tb_LightValue.Text) / Convert.ToDouble(255); ;
                trackBar_1.Value = Convert.ToInt32(brightnesscorr.AdjustValue * 255);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            frmImgProcess.imgProcess.ApplyFilter(brightnesscorr);
            saveImgToXml.SaveImgProcess(frmImgProcess.imgProcess.drawArea, frmImgProcess.imgProcess.lb_ImageName.Text, "BrightnessCorrection", brightnesscorr);
        }



      
    }
}
