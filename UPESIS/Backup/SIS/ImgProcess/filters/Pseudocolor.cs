using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SIS.ImgProcess.filters
{
    public partial class Pseudocolor : UserControl
    {
        private Point p;
        public Pseudocolor()
        {
            InitializeComponent();
            this.trackBar_1.Maximum =255;
            this.trackBar_1.Minimum =0;
            this.trackBar_1.SmallChange =1;
            this.trackBar_1.TickFrequency =10;
            drawArea.Image = (Bitmap)frmImgProcess.imgProcess.drawArea.Image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Pseudocolor_Load(object sender, EventArgs e)
        {

        }

        private void Pseudocolor_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void Pseudocolor_MouseMove(object sender, MouseEventArgs e)
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

        }

        private void PseudoColor(int flag)
        {
            Bitmap ss = null;
            switch (flag)
            {
                case 1: ss = ImgDispose.PseudoColor1(this.drawArea.Image as Bitmap); break;
                case 2: ss = ImgDispose.PseudoColor2(this.drawArea.Image as Bitmap); break;
                case 3: ss = ImgDispose.PseudoColor3(this.drawArea.Image as Bitmap); break;
            }
            this.drawArea.Image = ss;
            this.drawArea.Refresh();
        }

        private void trackBar_1_ValueChanged(object sender, EventArgs e)
        {
            double value = 0.0;
            value = Convert.ToDouble(this.trackBar_1.Value) / Convert.ToDouble(255);
            tb_PseudocolorValue.Text = this.trackBar_1.Value.ToString();
            tb_PseudocolorPercent.Text = Convert.ToInt32(value * 100).ToString() + "%";
        }

        private void tb_PseudocolorValue_TextChanged(object sender, EventArgs e)
        {
            if (ValidateData(tb_PseudocolorValue.Text))
            {
                //huemodifierFilter.Hue = Convert.ToInt32(tb_HueValue.Text);
                trackBar_1.Value = Convert.ToInt32(tb_PseudocolorValue.Text);
                //drawArea.RefreshFilter();
                PseudoColor(1);
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

                        if (Convert.ToInt32(data) >=0)
                            return true;
                        else
                        {
                            MessageBoxEx.Show("取值范围在0~255", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    case -1:
                        if (Convert.ToInt32(data) <= 255)
                            return true;
                        else
                        {
                            MessageBoxEx.Show("取值范围在0~255", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
