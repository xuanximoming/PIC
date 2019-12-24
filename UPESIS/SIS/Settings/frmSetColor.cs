using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS.Settings
{
    public partial class frmSetColor : Form
    {
        public frmSetColor()
        {
            InitializeComponent();
            this.colorPickerCtrl1.SelectedColor = BaseControls.CtlSettings.GetCtlColor("ImageCtl_Color");
            this.txt_ImageCtlPenWidth.Text = BaseControls.CtlSettings.GetImageCtlPenWidth().ToString();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            BaseControls.CtlSettings.SetCtlColor(this.colorPickerCtrl1.SelectedColor, "ImageCtl_Color");
            BaseControls.CtlSettings.SetImageCtlPenWidth(Convert.ToInt32(this.txt_ImageCtlPenWidth.Text));
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}