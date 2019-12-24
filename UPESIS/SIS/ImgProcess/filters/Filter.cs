using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BaseControls.ImageBox;
using BaseControls.ImageBox.Imaging;
using BaseControls.ImageBox.Imaging.Filters;
using BaseControls.ColorSlider;

namespace SIS.ImgProcess.filters
{
    public partial class Filter : UserControl
    {
        private Point p;
        private ColorFiltering colorfilter;
        private Bitmap filterimage;
        private IntRange red = new IntRange(0, 255);
        private IntRange green = new IntRange(0, 255);
        private IntRange blue = new IntRange(0, 255);
        private byte fillR = 0, fillG = 0, fillB = 0;
        private SaveImageToXml saveImgToXml;

        public Filter()
        {
            InitializeComponent();
            colorfilter = new ColorFiltering();
           // this.drawArea.Initialize();
            this.drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
            cb_FillType.SelectedIndex = 0;
            saveImgToXml = new SaveImageToXml();
        }

        private void OnlyEnterIntNumber(object sender,KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Filter_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X,e.Y);
        }

        private void Filter_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                Point mousePoint = Control.MousePosition;
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePoint);

            }
        }

        private void cs_Red_ValuesChanged(object sender, EventArgs e)
        {
            this.tb_Rmin.Text = this.cs_Red.Min.ToString();
            this.tb_Rmax.Text = this.cs_Red.Max.ToString();

        }

        private void tb_Rmin_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Red.Min = red.Min = Math.Min(red.Max, Byte.Parse(this.tb_Rmin.Text));
                UpdateFilter();
            }
        }

        private void tb_Rmax_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Red.Max = red.Max = Math.Max(red.Min, Byte.Parse(this.tb_Rmax.Text));
                UpdateFilter();
            }

        }

        private void cs_Green_ValuesChanged(object sender, EventArgs e)
        {
            this.tb_Gmin.Text = this.cs_Green.Min.ToString();
            this.tb_Gmax.Text = this.cs_Green.Max.ToString();

        }
        private void UpdateFilter()
        {
            colorfilter.Red = red;
            colorfilter.Green = green;
            colorfilter.Blue = blue;
            RefreshFilter();

        }

        private void tb_Gmin_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Green.Min = green.Min = Math.Min(green.Max, Byte.Parse(this.tb_Gmin.Text));
                UpdateFilter();
            }

        }

        private void tb_Gmax_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Green.Max = green.Max = Math.Max(green.Min, Byte.Parse(this.tb_Gmax.Text));
                UpdateFilter();
            }
        }

        private void cs_Blue_ValuesChanged(object sender, EventArgs e)
        {
            this.tb_Bmin.Text = this.cs_Blue.Min.ToString();
            this.tb_Bmax.Text = this.cs_Blue.Max.ToString();
        }

        private void tb_Bmin_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Blue.Min = blue.Min = Math.Min(blue.Max, Byte.Parse(this.tb_Bmin.Text));
                UpdateFilter();
            }
        }

        private void tb_Bmax_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                this.cs_Blue.Max = blue.Max = Math.Max(blue.Min, Byte.Parse(this.tb_Bmax.Text));
                UpdateFilter();
            }
        }

        private void tb_FillRed_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                fillR = byte.Parse(this.tb_FillRed.Text);
                UpdateFillColor();
            }
        }
        private void UpdateFillColor()
        {
            this.cs_Red.Color3 = this.cs_Green.Color3 = this.cs_Blue.Color3 = Color.FromArgb(fillR, fillG, fillB);
            colorfilter.FillColor = new RGB(fillR, fillG, fillB);
            RefreshFilter();
        }

        private void tb_FillGreen_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                fillG = byte.Parse(this.tb_FillGreen.Text);
                UpdateFillColor();
            }
        }

        private void tb_FillBlue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(((TextBox)sender).Text))
            {
                fillB = byte.Parse(this.tb_FillBlue.Text);
                UpdateFillColor();
            }
        }

        private void cb_FillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorSliderType[] types = new ColorSliderType[] { ColorSliderType.InnerGradient, ColorSliderType.OuterGradient };
            ColorSliderType type = types[cb_FillType.SelectedIndex];
            cs_Red.Type = type;
            cs_Green.Type = type;
            cs_Blue.Type = type;
            colorfilter.FillOutsideRange=(cb_FillType.SelectedIndex==0);
            RefreshFilter();
        }

        public void RefreshFilter()//缩略图刷新
        {
            drawArea.Filter = colorfilter;
            drawArea.RefreshFilter();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            frmImgProcess.imgProcess.ApplyFilter(colorfilter);
            saveImgToXml.SaveImgProcess(frmImgProcess.imgProcess.drawArea, frmImgProcess.imgProcess.lb_ImageName.Text, "Filter", colorfilter);
        }


        private bool ValidateData(string data)
        {
            if (data != "")
            {

                if (Convert.ToInt32(data) <= 255)
                    return true;
                else
                {
                    MessageBoxEx.Show("取值范围在0~255", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;

              
        }


    }
}
