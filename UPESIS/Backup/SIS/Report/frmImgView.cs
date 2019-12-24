using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILL;

namespace SIS
{
    public partial class frmImgView : Form
    {
        public frmImgView()
        {
            InitializeComponent(); 
            this.Init();
        }

        private void Init()
        {
            string str = GetConfig.RS_ImgLocation;
            if (str == "")
                GetConfig.SetRS_ImgLocation(Location.X.ToString() + "," + Location.Y.ToString() + "," + Size.Width.ToString() + "," + Size.Height.ToString());
            else
            {
                string[] location = str.Split(',');
                this.Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                this.Size = new Size(int.Parse(location[2]), int.Parse(location[3]));
            }
        }

        private void frmImgView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!frmMainForm.isClose)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                string location = this.Location.X.ToString() + "," + this.Location.Y.ToString() + "," + this.Size.Width.ToString() + "," + this.Size.Height.ToString();
                GetConfig.SetRS_ImgLocation(location);
            }
        }
    }
}