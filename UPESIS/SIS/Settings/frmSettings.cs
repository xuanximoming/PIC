using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS.Settings;

namespace SIS
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btn_Font_Click(object sender, EventArgs e)
        {
            frmSetFont fsf = new frmSetFont();
            fsf.ShowDialog();
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            frmSetColor fsc = new frmSetColor();
            fsc.ShowDialog();
        }

        private void ribbonMenuButton5_Click(object sender, EventArgs e)
        {
            frmSetCard fsc = new frmSetCard();
            fsc.ShowDialog();
        }

    }
}