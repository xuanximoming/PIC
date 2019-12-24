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
    public partial class Rotate : UserControl
    {
        private FilterRotate filter;
        private Point p;
        public Rotate()
        {
            InitializeComponent();
            cb_Rotate.Text = "45";
            tb_R.Text ="0";
            tb_G.Text ="0";
            tb_B.Text ="0";
            cb_methodCombo.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OnlyEnterIntNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 45)
            {
                e.Handled = true;
            }

        }

        private void OnlyEnterIntNumber2(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 )
            {
                e.Handled = true;
            }

        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                double angle = double.Parse(cb_Rotate.Text);
                switch (cb_methodCombo.SelectedIndex)
                {
                    case 0:
                        filter = new RotateNearestNeighbor(angle);
                        break;
                    case 1:
                        filter = new RotateBilinear(angle);
                        break;
                    case 2:
                        filter = new RotateBicubic(angle);
                        break;
                }

                filter.FillColor = Color.FromArgb(
                    byte.Parse(tb_R.Text),
                    byte.Parse(tb_G.Text),
                    byte.Parse(tb_B.Text));
                filter.KeepSize = cb_KeepSize.Checked;
                frmImgProcess.imgProcess.ApplyFilter(filter);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Rotate_MouseDown(object sender, MouseEventArgs e)
        {
           p = new Point(e.X, e.Y);
        }

        private void Rotate_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                Point mousePoint = Control.MousePosition;
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePoint);
            }
        }
    }
}
